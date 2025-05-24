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
        public delegate IEnumerable<EntityBase> FilterRefresh(string filter);
        
        public FilterRefresh FilterRefreshDelegate { get; set; }

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

            filtraButton.Click += Filtra_Click;

            if (FilterRefreshDelegate != null)
            {
                dataGridView.DataSource = FilterRefreshDelegate(null);
            }

        }
         
        private void NewButton_Click(object sender, EventArgs e)
        {
            var list = dataGridView.DataSource as IEnumerable;
            var item = list?.Cast<object>().FirstOrDefault();
            EntityBase entity;
            
            Type tipo = item.GetType();
            object nuovaIstanza = Activator.CreateInstance(tipo);

            entity = (EntityBase)nuovaIstanza;
            
            entity.EntityState = EntityState.Added;
                        
            EditDelegate(entity);
            dataGridView.DataSource = FilterRefreshDelegate(null);
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView grid && e.RowIndex >= 0)
            {
                var row = grid.Rows[e.RowIndex];
                var item = row.DataBoundItem;

                var entity = (EntityBase)item;
                entity.EntityState = EntityState.Unchanged;

                EditDelegate(entity);
                dataGridView.DataSource = FilterRefreshDelegate(null);

            }
        }

        private void Filtra_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = FilterRefreshDelegate(filtraTextBox.Text);
        }

    }
}
