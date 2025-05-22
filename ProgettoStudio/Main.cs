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

            AreeManager manager = new AreeManager();

            frmElenco.RefreshDelegate += manager.ReadAll<AreeEntity>;            
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

            AnagraficheManager manager = new AnagraficheManager();

            frmElenco.RefreshDelegate += manager.ReadAll<AnagraficaEntity>;            
            frmElenco.EditDelegate += (EntityBase entity) => 
            {                                
                FrmAnagrafiche frmAnagrafica = new FrmAnagrafiche();
               
                frmAnagrafica.FormClosed += (s, args) =>
                {
                  frmElenco.RefreshDelegate.Invoke();
                };
                frmAnagrafica.ShowModal((AnagraficaEntity)entity);                
            };            
            frmElenco.ShowDialog();
        }
         
    }
}
