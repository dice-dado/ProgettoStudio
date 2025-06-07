using Entity;
using Manager;
using ProgettoStudio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProgettoStudio
{
    public partial class FrmAnagrafiche : Form, ICardForm
    {
        private readonly AnagraficheManager mManager;
        private readonly IDialogService mDialogSerivice;

        public FrmAnagrafiche()
        {
            InitializeComponent();

            mDialogSerivice = new DialogService();
            mManager = new AnagraficheManager(mDialogSerivice);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            riferimentiDataGridView.AllowUserToAddRows = true;
            riferimentiDataGridView.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

        }        
        public void ShowModal(EntityBase entity)
        {
            if (entity.EntityState == EntityState.Unchanged)
            {
                AnagraficaEntity entityDB = (AnagraficaEntity)mManager.Read<AnagraficaEntity>(((AnagraficaEntity)entity).IdAnagrafica.ToString());

                ((AnagraficaEntity)entity).SetRiferimenti(entityDB.Riferimenti,true);
                mManager.Init(entity);

                riferimentiDataGridView.DataSource = ((AnagraficaEntity)entity).Riferimenti;
                riferimentiDataGridView.Refresh();

            }
            else if(entity.EntityState == EntityState.Added)
            {
                mManager.Init(entity);

                riferimentiDataGridView.DataSource = ((AnagraficaEntity)mManager.Entity).Riferimenti;
                idTextBox.ReadOnly = false;
            }


            idTextBox.DataBindings.Clear();
            ragioneSocialeTextBox.DataBindings.Clear();
            partitaIVATextBox.DataBindings.Clear();
            indirizzoTextBox.DataBindings.Clear();
            telefonoTextBox.DataBindings.Clear();

            BindTextOfControl(idTextBox, mManager.Entity, nameof(AnagraficaEntity.IdAnagrafica));
            BindTextOfControl(ragioneSocialeTextBox, mManager.Entity, nameof(AnagraficaEntity.RagioneSociale));
            BindTextOfControl(partitaIVATextBox, mManager.Entity, nameof(AnagraficaEntity.PartitaIVA));
            BindTextOfControl(indirizzoTextBox, mManager.Entity, nameof(AnagraficaEntity.Indirizzo));
            BindTextOfControl(telefonoTextBox, mManager.Entity, nameof(AnagraficaEntity.Telefono));

            BindEnabledOfControl(idTextBox, mManager, nameof(ManagerBase.PKEnabled));

            this.ShowDialog();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {         
            mManager.OnSave();

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
