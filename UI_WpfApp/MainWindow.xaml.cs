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
                    FrmElenco frmElenco = new FrmElenco();
                    var frmArea = new FrmAree() as ICardForm;

                    frmElenco.Show();                    
                    frmArea.ReadAllAsync<AreeEntity>(callback<AreeEntity>, ExcCallback);

                    void callback<T>(IEnumerable<T> elenco)
                    {                        
                        frmElenco.Elenco.ItemsSource = elenco.Cast<AreeEntity>();                        
                    }

                    frmElenco.EditDelegate = (EntityBase entity) =>
                    {
                        frmArea.ShowModal((AreeEntity)entity);
                    };


                    break;

                case "Aree (Sync)":     
                    break;

                case "Anagrafiche":
                    break;
            }

        }




        void Callback<T>(IEnumerable<T> result)
        {
            

        }

        void ExcCallback(Exception ex)
        {
            
        }
    }
}
