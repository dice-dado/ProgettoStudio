using Entity;
using System;
using System.Collections;
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
    public partial class FrmElenco : Form
    {

        Func<IEnumerable> RefreshDelegate { get; set; }

        Action<EntityBase> EditDelegate { get; set; }

        public FrmElenco()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (RefreshDelegate != null)
            {
                var elenco = RefreshDelegate.Invoke();

                dataGridView.DataSource = elenco.Cast<object>().ToList();
            }

            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;

        }

        private void NewButton_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            if (grid != null && e.RowIndex >= 0)
            {
                var row = grid.Rows[e.RowIndex];
                var item = row.DataBoundItem;

            }


            this.ShowDialog();

        }




        private void ShowModal()
        { 
            
        
        
        
        }

    }
}
