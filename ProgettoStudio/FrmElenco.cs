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

        public Func<IEnumerable<EntityBase>> RefreshDelegate { get; set; }

        public Action<EntityBase> EditDelegate { get; set; }

        public FrmElenco()
        {
            InitializeComponent();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;

            if (RefreshDelegate != null)
            {
                dataGridView.DataSource = RefreshDelegate();
            }

        }

         

        private void NewButton_Click(object sender, EventArgs e)
        {
            EditDelegate(null);
            dataGridView.DataSource = RefreshDelegate();
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            if (grid != null && e.RowIndex >= 0)
            {
                var row = grid.Rows[e.RowIndex];
                var item = row.DataBoundItem;
       
                EditDelegate((EntityBase)item);
                dataGridView.DataSource = RefreshDelegate();

            }

        }


    }
}
