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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MenuItemsControl.ItemsSource = new List<String>() { "Aree", "Aree (Sync)", "Anagrafiche" };
        }

        private void MenuItemClick(object sender, RoutedEventArgs e)
        {

            var clickedItem = (string)((Button)sender).Content;
            switch (clickedItem)
            { 
                case "Aree":
                    var frmArea = new FrmAree() as ICardForm;
                    var frmElenco = new FrmElenco(frmArea);
                    frmElenco.FormType = typeof(AreeEntity);

                    frmElenco.Show();
                    break;

                case "Aree (Sync)":
                    

                    break;

                case "Anagrafiche":
                    break;
            }

        }

    }
}
