using Entity;
using Manager;
using ProgettoStudio.Services;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Control = System.Windows.Forms.Control;

namespace ProgettoStudio
{
    public partial class FrmAree : Form, ICardForm
    {
        private readonly AreeManager mManager;     

        public FrmAree()
        {
            InitializeComponent();

            mManager = new AreeManager(new DialogService());            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += CancelButton_Click;
            
        }

        public void ShowModal(EntityBase entity)
        {           
            if (entity != null)
            {
          
            }
            else 
            {
                entity = new AreeEntity();    
            }

            BindControl(codiceTextBox, entity, nameof(AreeEntity.Codice));
            BindControl(descrizioneTextBox, entity, nameof(AreeEntity.Descrizione));


            mManager.Init(entity);
            

            this.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {        
            var errors = mManager.OnSave();


            if (errors.Count() > 0)
            {
                //ShowModal();
            }
            else
                this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            string res = (mManager.Action("Cancel").FirstOrDefault() ?? "");
            if (res == "Yes" || res == string.Empty)
                this.Close();
        }

        public static void BindControl(Control control, object dataSource, string propertyName)
        {
            control.DataBindings.Clear();
            control.DataBindings.Add("Text", dataSource, propertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public IEnumerable<T> ReadAll<T>() where T : EntityBase
        {
            return mManager.ReadAll<T>();
        }

    }
}
