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

namespace ProgettoStudio
{
    public partial class FrmAnagrafiche : Form, ICardForm
    {
        private readonly AnagraficheManager mManager;

        public FrmAnagrafiche()
        {
            InitializeComponent();

            mManager = new AnagraficheManager(new DialogService());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            saveButton.Click += SaveButton_Click;
            cancelButton.Click += CancelButton_Click;

            riferimentiDataGridView.AllowUserToAddRows = true;
            riferimentiDataGridView.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            riferimentiDataGridView.ReadOnly = false;

        }

        public void ShowModal(EntityBase entity)
        {
            if (entity != null)
            {
                AnagraficaEntity entityDB = (AnagraficaEntity)mManager.Read<AnagraficaEntity>(((AnagraficaEntity)entity).IdAnagrafica.ToString());

                ((AnagraficaEntity)entity).SetRiferimenti(entityDB.Riferimenti,true);
                mManager.Init(entity);

                riferimentiDataGridView.DataSource = ((AnagraficaEntity)entity).Riferimenti;
                riferimentiDataGridView.Refresh();

                idTextBox.ReadOnly = true;

            }
            else
            {
                mManager.Init(new AnagraficaEntity());

                riferimentiDataGridView.DataSource = ((AnagraficaEntity)mManager.Entity).Riferimenti;
                idTextBox.ReadOnly = false;
            }

            BindControl(idTextBox, entity, nameof(AnagraficaEntity.IdAnagrafica));
            BindControl(ragioneSocialeTextBox, entity, nameof(AnagraficaEntity.RagioneSociale));
            BindControl(partitaIVATextBox, entity, nameof(AnagraficaEntity.PartitaIVA));
            BindControl(indirizzoTextBox, entity, nameof(AnagraficaEntity.Indirizzo));
            BindControl(telefonoTextBox, entity, nameof(AnagraficaEntity.Telefono));


            this.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            var errors = mManager.OnSave();

            if (errors.Count() > 0)
            {
                //ShowModal();
            }
            else
                this.Close();
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            string res = (mManager.Action("Cancel").FirstOrDefault() ?? "");
            if (res == "Yes" || res == string.Empty)
                this.Close();
        }

        public static void BindControl(Control control, object dataSource, string propertyName)
        {
            control.DataBindings.Clear();
            control.DataBindings.Add("Text", dataSource, propertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public IEnumerable<T> ReadAll<T>() where T : EntityBase
        {
            return mManager.ReadAll<T>();
        }
    }
}
