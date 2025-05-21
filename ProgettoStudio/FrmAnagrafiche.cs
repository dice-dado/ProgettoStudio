using Engine;
using Entity;
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

        private AnagraficaEntity mEntity;

        public FrmAnagrafiche()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            saveButton.Click += SaveButton_Click;

            riferimentiDataGridView.AllowUserToAddRows = true;
            riferimentiDataGridView.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            riferimentiDataGridView.ReadOnly = false;

            mEntity = new AnagraficaEntity();
        }

        public void ShowModal(AnagraficaEntity entity)
        {
            if (entity != null)
            {
                this.mEntity = entity;

                idTextBox.Text = entity?.IdAnagrafica.ToString();
                ragioneSocialeTextBox.Text = entity?.RagioneSociale;
                partitaIVATextBox.Text = entity?.PartitaIVA;
                indirizzoTextBox.Text = entity?.Indirizzo;
                telefonoTextBox.Text = entity?.Telefono;


                AnagraficheEngine engineBase = new AnagraficheEngine();
                AnagraficaEntity entityDB = (AnagraficaEntity)engineBase.Read(entity.IdAnagrafica.ToString());

                riferimentiDataGridView.DataSource = entityDB.Riferimenti;
                riferimentiDataGridView.Refresh();
            }
            

            this.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            AnagraficheEngine engineBase = new AnagraficheEngine();


            mEntity.IdAnagrafica = int.Parse(idTextBox.Text);
            mEntity.RagioneSociale = ragioneSocialeTextBox.Text;
            mEntity.PartitaIVA = partitaIVATextBox.Text;
            mEntity.Indirizzo = indirizzoTextBox.Text;
            mEntity.Telefono = telefonoTextBox.Text;

            mEntity.Riferimenti.Clear();

            foreach (var rif in (IEnumerable<RiferimentoEntity>)riferimentiDataGridView.DataSource ?? Enumerable.Empty<RiferimentoEntity>())
            {
                var riferimento = new RiferimentoEntity
                {
                    Nome = rif.Nome,
                    Cognome = rif.Cognome,
                    Telefono = rif.Telefono
                };

                mEntity.Riferimenti.Add(riferimento);
            }
            
            engineBase.Update(this.mEntity);

            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            ((BindingList<RiferimentoEntity>)riferimentiDataGridView.DataSource).Add(new RiferimentoEntity { Telefono = "aaaaaa" });
        }
    }
}
