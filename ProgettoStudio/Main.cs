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

            areeButton.Click += Aree_Click;
            anagraficheButton.Click += Anagrafiche_Click;

        }

        public void Aree_Click(object sender, EventArgs e)
        {
            FrmElenco frmElenco = new FrmElenco();

            AreeEngine engine = new AreeEngine();

            frmElenco.RefreshDelegate += engine.ReadAll;            
            frmElenco.EditDelegate += (EntityBase entity) => 
            {                                
                FrmAree frmArea = new FrmAree();

                frmArea.FormClosed += (s, args) =>
                {
                  frmElenco.RefreshDelegate.Invoke();
                };
                frmArea.ShowModal((AreeEntity)entity);                
            };            
            frmElenco.ShowDialog();
        }

        public void Anagrafiche_Click(object sender, EventArgs e)
        {
            FrmElenco frmElenco = new FrmElenco();

            AnagraficheEngine engine = new AnagraficheEngine();

            frmElenco.RefreshDelegate += engine.ReadAll;            
            frmElenco.EditDelegate += (EntityBase entity) => 
            {                                
                FrmAnagrafiche fromAnagrafica = new FrmAnagrafiche();

                fromAnagrafica.FormClosed += (s, args) =>
                {
                  frmElenco.RefreshDelegate.Invoke();
                };
                fromAnagrafica.ShowModal((AnagraficaEntity)entity);                
            };            
            frmElenco.ShowDialog();
        }
         
    }
}
