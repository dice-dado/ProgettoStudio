using Entity;
using Manager;
using ProgettoStudio;
using ProgettoStudio.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UI_WpfApp.Helpers;

namespace UI_WpfApp
{
    /// <summary>
    /// Interaction logic for FrmAnagrafiche.xaml
    /// </summary>
    public partial class FrmAnagrafiche : Window, ICardForm
    {
        private DialogService mDialogSerivice;
        private AnagraficheManager mManager;

        public FrmAnagrafiche()
        {
            InitializeComponent();

            mDialogSerivice = new DialogService();
            mManager = new AnagraficheManager(mDialogSerivice);

            DataContext = mManager;
        }

        public IEnumerable<T> ReadAll<T>() where T : EntityBase
        {
            throw new NotImplementedException();
        }

        public void ReadAllAsync<T>(Action<IEnumerable<T>> callback, Action<Exception> excCallback) where T : EntityBase
        {
            mManager.ReadAllAsync<T>(callback, excCallback);
        }

        public void ShowModal(EntityBase entity)
        {
            if (entity.EntityState == EntityState.Unchanged)
            {
                AnagraficaEntity entityDB = (AnagraficaEntity)mManager.Read<AnagraficaEntity>(((AnagraficaEntity)entity).IdAnagrafica.ToString());

                ((AnagraficaEntity)entity).SetRiferimenti(entityDB.Riferimenti, true);
                mManager.Init(entity);

                this.DataContext = mManager;

                dgRiferimenti.ItemsSource = new ObservableListWrapper<RiferimentoEntity>(((AnagraficaEntity)entity).Riferimenti);

            }
            else if (entity.EntityState == EntityState.Added)
            {
                mManager.Init(entity);

                this.DataContext = mManager;

                dgRiferimenti.ItemsSource = new ObservableListWrapper<RiferimentoEntity>(((AnagraficaEntity)mManager.Entity).Riferimenti);


            }

            this.ShowDialog();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var errors = mManager.OnSave();

            if (!errors.Any())
                this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {

            string res = (mManager.Action("Cancel").FirstOrDefault() ?? "");
            if (res == "Yes" || res == string.Empty)
                this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            mManager.Dispose();
        }


    }
}
