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

            button1.Click += button1_Click;
            //button2.Click += button2_Click;

        }

        public void button1_Click(object sender, EventArgs e)
        {
            FrmElenco elenco = new FrmElenco();

            EngineBase<AreeEntity> engine = new EngineBase<AreeEntity>();

            elenco.RefreshDelegate += engine.ReadAll;            
            elenco.EditDelegate += (EntityBase pk) => 
            { 
                engine.Read(pk);  
                
            };
            
            elenco.ShowDialog();
        }





    }
}
