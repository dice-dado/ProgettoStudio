﻿using Entity;
using Manager;
using ProgettoStudio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Control = System.Windows.Forms.Control;

namespace ProgettoStudio
{
    public partial class FrmAree : Form, ICardForm
    {
        private readonly AreeManager mManager;
        private readonly IDialogService mDialogSerivice;

        public FrmAree()
        {
            InitializeComponent();

            mDialogSerivice = new DialogService();
            mManager = new AreeManager(mDialogSerivice);            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
                        
        }

        public void ShowModal(EntityBase entity)
        {           
            if (entity != null)
            {
          
            }
            else 
            {
                entity = new AreeEntity();    
            }

            mManager.Init(entity);

            codiceTextBox.DataBindings.Clear();
            descrizioneTextBox.DataBindings.Clear();

            BindTextOfControl(codiceTextBox, mManager.Entity, nameof(AreeEntity.Codice));
            BindTextOfControl(descrizioneTextBox, mManager.Entity, nameof(AreeEntity.Descrizione));

            BindEnabledOfControl(codiceTextBox, mManager, nameof(ManagerBase.PKEnabled));

            this.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {        
            var errors = mManager.OnSave();

            if(!errors.Any())
                this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            string res = (mManager.Action("Cancel").FirstOrDefault() ?? "");
            if (res == "Yes" || res == string.Empty)
                this.Close();
        }

        private void BindTextOfControl(Control control, object dataSource, string propertyName)
        {
            control.DataBindings.Add("Text", dataSource, propertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BindEnabledOfControl(Control control, object dataSource, string propertyName)
        {            
            control.DataBindings.Add("Enabled", dataSource, propertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public IEnumerable<T> ReadAll<T>() where T : EntityBase
        {
            return mManager.ReadAll<T>();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            mManager.Dispose();
        }

        public void ReadAllAsync<T>(Action<IEnumerable<T>> callback, Action<Exception> excCallback) where T : EntityBase
        {
            throw new NotImplementedException();
        }
    }
}
