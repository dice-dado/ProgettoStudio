using Entity;
using Manager;
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

namespace ProgettoStudio
{
    public partial class FrmAree : Form
    {
        public AreeManager Manager { get; set; }       

        public FrmAree()
        {
            InitializeComponent();

            Manager = new AreeManager();
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            saveButton.Click += SaveButton_Click;
                        
        }

        public void ShowModal(AreeEntity entity)
        {

            if (entity != null)
            {
                codiceTextBox.Text = entity.Codice;
                descrizioneTextBox.Text = entity.Descrizione;
            }
            else 
            {
                entity = new AreeEntity();    
            }

            Manager.Init(entity);


            this.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ((AreeEntity)Manager.Entity).Codice = codiceTextBox.Text;
            ((AreeEntity)Manager.Entity).Descrizione = descrizioneTextBox.Text;

            var errors = Manager.OnSave();


            if (errors.Count() > 0)
            {
                //ShowModal();
            }
            else
                this.Close();
        }



    }
}
