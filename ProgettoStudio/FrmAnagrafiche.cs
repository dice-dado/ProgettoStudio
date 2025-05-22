using Entity;
using Manager;
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
    public partial class FrmAnagrafiche : Form
    {
        public AnagraficheManager Manager { get; set; }

        public FrmAnagrafiche()
        {
            InitializeComponent();

            Manager = new AnagraficheManager();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            saveButton.Click += SaveButton_Click;

            riferimentiDataGridView.AllowUserToAddRows = true;
            riferimentiDataGridView.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            riferimentiDataGridView.ReadOnly = false;

        }

        public void ShowModal(AnagraficaEntity entity)
        {
            if (entity != null)
            {
                AnagraficaEntity entityDB = (AnagraficaEntity)Manager.Read<AnagraficaEntity>(entity.IdAnagrafica.ToString());

                entity.Riferimenti = entityDB.Riferimenti;
                Manager.Init(entity);

                riferimentiDataGridView.DataSource = entity.Riferimenti;
                riferimentiDataGridView.Refresh();

                idTextBox.Text = entity?.IdAnagrafica.ToString();
                ragioneSocialeTextBox.Text = entity?.RagioneSociale;
                partitaIVATextBox.Text = entity?.PartitaIVA;
                indirizzoTextBox.Text = entity?.Indirizzo;
                telefonoTextBox.Text = entity?.Telefono;


                idTextBox.ReadOnly = true;

            }
            else
            {
                Manager.Init(new AnagraficaEntity());

                riferimentiDataGridView.DataSource = ((AnagraficaEntity)Manager.Entity).Riferimenti;
                idTextBox.ReadOnly = false;
            }


            this.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            ((AnagraficaEntity)Manager.Entity).IdAnagrafica = int.Parse(idTextBox.Text);
            ((AnagraficaEntity)Manager.Entity).RagioneSociale = ragioneSocialeTextBox.Text;
            ((AnagraficaEntity)Manager.Entity).PartitaIVA = partitaIVATextBox.Text;
            ((AnagraficaEntity)Manager.Entity).Indirizzo = indirizzoTextBox.Text;
            ((AnagraficaEntity)Manager.Entity).Telefono = telefonoTextBox.Text;


            var errors = Manager.OnSave();

            if (errors.Count() > 0)
            {
                //ShowModal();
            }
            else
                this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ((BindingList<RiferimentoEntity>)riferimentiDataGridView.DataSource).Add(new RiferimentoEntity { Telefono = "aaaaaa" });
        }
    }
}
