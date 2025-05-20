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

namespace ProgettoStudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            areeButton.Click += aree_Click;
            //button2.Click += button2_Click;

        }

        public void aree_Click(object sender, EventArgs e)
        {
            FrmElenco elenco = new FrmElenco();

            EngineBase<AreeEntity> engine = new EngineBase<AreeEntity>();

            elenco.RefreshDelegate += engine.ReadAll;            
            elenco.EditDelegate += (EntityBase entity) => 
            {                                
                FrmAree area = new FrmAree();

                area.ShowModal((AreeEntity)entity);                
            };
            
            elenco.ShowDialog();
        }





    }
}
