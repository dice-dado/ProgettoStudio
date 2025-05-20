using Engine;
using Entity;
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

        private AreeEntity mEntity;        

        public FrmAree()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            saveButton.Click += SaveButton_Click;
        }

        public void ShowModal(AreeEntity entity)
        { 
            this.mEntity = entity;

            codiceTextBox.Text = entity.Codice;
            descrizioneTextBox.Text = entity.Descrizione;

            this.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)     
        {            
            mEntity.Codice = codiceTextBox.Text;
            mEntity.Descrizione = descrizioneTextBox.Text;

            AreeEngine engineBase = new AreeEngine();            
            engineBase.Update(this.mEntity);

            this.Close();
        }



    }
}
