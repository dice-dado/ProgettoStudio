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
            var frmArea = new FrmAree() as ICardForm;

            frmElenco.FilterRefreshDelegate = (filter) => { 
                var elenco = frmArea.ReadAll<AreeEntity>(); 
                return elenco.Filter(filter); 
            };
            frmElenco.EditDelegate = (EntityBase entity) => 
            {                                           
                frmArea.ShowModal((AreeEntity)entity);                
            };            

            frmElenco.ShowDialog();
        }

        public void Anagrafiche_Click(object sender, EventArgs e)
        {
            FrmElenco frmElenco = new FrmElenco();
            var frmAnagrafica = new FrmAnagrafiche() as ICardForm;

            frmElenco.FilterRefreshDelegate = (filter) => 
            { 
                var elenco = frmAnagrafica.ReadAll<AnagraficaEntity>(); 
                return elenco.Filter(filter); 
            };
            frmElenco.EditDelegate = (EntityBase entity) => 
            {                                               
                frmAnagrafica.ShowModal((AnagraficaEntity)entity);                
            };            
            frmElenco.ShowDialog();
        }
         
    }
}
