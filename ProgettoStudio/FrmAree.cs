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

namespace ProgettoStudio
{
    public partial class FrmAree : Form
    {
        public FrmAree()
        {
            InitializeComponent();
        }


        public void ShowModal(AreeEntity entity)
        { 
            codiceTextBox.Text = entity.Codice;
            descrizioneTextBox.Text = entity.Descrizione;

            this.ShowDialog();
        }

    }
}
