using Entity;
using ProgettoStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI_WpfApp
{
    /// <summary>
    /// Interaction logic for frmElenco.xaml
    /// </summary>
    public partial class FrmElenco : Window
    {
        public Func<string, IEnumerable<EntityBase>> FilterRefreshDelegate { get; set; }

        public Action<EntityBase> EditDelegate { get; set; }

        public FrmElenco()
        {
            InitializeComponent();



        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);


            if (FilterRefreshDelegate != null)
            {
                Elenco.ItemsSource = FilterRefreshDelegate(null);
            }
        }

      
    }
}
