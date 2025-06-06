﻿using Engine;
using Entity;
using Shared.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public abstract class ManagerBase : INotifyPropertyChanged, IDisposable
    {

        private bool mPKEnabled;
        public bool PKEnabled
        {
            get { return mPKEnabled; }
            set
            {
                if (mPKEnabled != value)
                {
                    mPKEnabled = value;
                    RaiseNotifyPropertyChanged(nameof(PKEnabled));
                }
            }
        }

        public virtual EntityBase Entity { get; set; }
        protected EngineBase Engine { get; set; }

        protected IDialogService mDialogService;

        public event PropertyChangedEventHandler PropertyChanged;

        protected ManagerBase(IDialogService service) 
        {
            mDialogService = service;
        }
        
        public virtual void Init(EntityBase entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Inizializzare sempre la Entity prima Init() del Manager");             
            }
            else
            {
                Entity = entity;
            }

            PKEnabled = entity.EntityState == EntityState.Added;
            
            //master
            Entity.PropertyChanged += DataChangedCaller;            
            //slaves
            SubscribeListItemsPropertyChanged(entity, true);
        }

        public virtual EntityBase Read<T>(object pk) where T : EntityBase
        {
            return Engine.Read<T>(pk);
        }

        //qua senza i Generics mi sono bloccato
        public virtual IEnumerable<T> ReadAll<T>() where T : EntityBase 
        {
            return Engine.ReadAll<T>();
        }

        public void ReadAllAsync<T>(Action<IEnumerable<T>> callback, Action<Exception> excCallback) where T : EntityBase
        { 
            AsyncHelper.CallAsync(() => ReadAll<T>(), callback, excCallback);
        }

        public void ActionAsync(string action, Action<List<string>> callback, Action<Exception> excCallback)
        {
            try
            {
                var result = Action(action);
                callback?.Invoke(result);
            }
            catch (Exception ex)
            {
                excCallback?.Invoke(ex);
            }
        }

        protected abstract EngineBase GetEngine();

        private void DataChangedCaller(object sender, PropertyChangedEventArgs e)
        {            
            OnDataChanged(e.PropertyName);
        }
        
        private void DataSlaveChangedCaller(object sender, PropertyChangedEventArgs e)
        {
            OnDataSlaveChanged((BindableEntity)sender, e.PropertyName);
        }
        protected virtual void OnDataChanged(string property)
        {
            
        }

        protected virtual void OnDataSlaveChanged(BindableEntity row, string property)
        {
            if (Entity.EntityState != EntityState.Added)
                Entity.EntityState = EntityState.Modified;
        }

        public virtual List<string> OnSave()
        {
            if (Entity.EntityState != EntityState.Unchanged)
            {
                return Engine.Update(Entity);
            }
            else return new List<string>();
        }
         
        private void SubscribeListItemsPropertyChanged(object target, bool subscribe)
        {

            /*
                Vado ad assegnare DataSlaveChanged a tutti gli item delle prop che implementano IBindableList
             */
            var props = target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {               
                if (typeof(IBindingList).IsAssignableFrom(prop.PropertyType))
                {
                    if (!(prop.GetValue(target) is IBindingList list))
                        continue;
                    if(subscribe)
                        list.ListChanged += HandleListChanged;
                    else
                        list.ListChanged -= HandleListChanged;

                    //se aggiungo nuovo item poi questo è un problema, devo fare ri-scattare questa assegnazione, ho bisogno di HandleListChanged
                    foreach (var item in list)
                    {
                        if (item is INotifyPropertyChanged npc && item is BindableEntity)
                        {
                            if(subscribe)
                                npc.PropertyChanged += DataSlaveChangedCaller;
                            else
                                npc.PropertyChanged -= DataSlaveChangedCaller;
                        }
                    }
                }
            }
        }

        private void HandleListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                var list =(IBindingList)sender;
                var newItem = (INotifyPropertyChanged)list[e.NewIndex];

                newItem.PropertyChanged += DataSlaveChangedCaller;                
            }
        }

        public List<string> Action(string action)
        {
            switch (action)
            {
                case "Cancel":
                    return OnCancel(); 
                default:
                    return new List<string>();
            }

        }

        protected virtual List<string> OnCancel()
        {
            if (Entity.EntityState == EntityState.Modified)
            {
                bool result = mDialogService.ShowMessageBox("Le modifiche non salvate verranno perse.\nProseguire?");

                return new List<string>() { result ? "Yes" : "No" };
            }

            return new List<string>();
        }

        protected void RaiseNotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            Entity.PropertyChanged -= DataChangedCaller;

            SubscribeListItemsPropertyChanged(Entity, false);
        }
    }
}
