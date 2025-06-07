using Entity;
using Manager;
using ProgettoStudio;
using ProgettoStudio.Services;
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
    /// Interaction logic for FrmAree.xaml
    /// </summary>
    public partial class FrmAree : Window, ICardForm
    {        
        private readonly AreeManager mManager;
        private readonly IDialogService mDialogSerivice;

        public FrmAree()
        {
            InitializeComponent();
            mDialogSerivice = new DialogService();
            mManager = new AreeManager(mDialogSerivice);
        }

        public IEnumerable<T> ReadAll<T>() where T : EntityBase
        {
            return mManager.ReadAll<T>();
        }

        public void ReadAllAsync<T>(Action<IEnumerable<T>> callback, Action<Exception> excCallback) where T : EntityBase
        {
            mManager.ReadAllAsync<T>(callback, excCallback);
        }

        public void ShowModal(EntityBase entity)
        {            
            mManager.Init(entity);
            this.DataContext = mManager;

            ShowDialog();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var errors = mManager.OnSave();

            if (!errors.Any())
                this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            base.OnClosed(e);

            mManager.Dispose();
        }
    }
}
