using Engine;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public abstract class ManagerBase
    {
        public virtual EntityBase Entity { get; set; }
        public EngineBase Engine { get; set; }

        
        public virtual void Init(EntityBase entity)
        {
            if (entity != null)
                Entity = entity;
            
            //Entity.PropertyChanged += DataChangedCaller;

            //SubscribeListItemsPropertyChanged(entity, DataSlaveChangedCaller);
        }

        public virtual EntityBase Read<T>(object pk) where T : EntityBase
        {
            return Engine.Read<T>(pk);
        }


        //qua senza i Generics mi sono bloccato
        public virtual IEnumerable<EntityBase> ReadAll<T>() where T : EntityBase 
        {
            return Engine.ReadAll<T>();
        }

        protected abstract EngineBase GetEngine();

        protected void DataChangedCaller(object sender, PropertyChangedEventArgs e)
        {
            OnDataChanged(e.PropertyName);
        
        }
        
        protected void DataSlaveChangedCaller(object sender, PropertyChangedEventArgs e)
        {
            OnDataSlaveChanged((BindableEntity)sender, e.PropertyName);
        
        }
        
        protected virtual void OnDataChanged(string property)
        {

        }

        protected virtual void OnDataSlaveChanged(BindableEntity row, string property)
        { 
                
        }

        public virtual List<string> OnSave()
        { 
            return Engine.Update(Entity);        
        }



        private void SubscribeListItemsPropertyChanged(object target, PropertyChangedEventHandler handler)
        {        
            var props = target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {               
                if (typeof(IList).IsAssignableFrom(prop.PropertyType))
                {
                    if (!(prop.GetValue(target) is IList list))
                        continue;

                    foreach (var item in list)
                    {
                        if (item is INotifyPropertyChanged npc && item is BindableEntity)
                        {
                            npc.PropertyChanged += handler;
                        }
                    }
                }
            }
        }

    }
}
