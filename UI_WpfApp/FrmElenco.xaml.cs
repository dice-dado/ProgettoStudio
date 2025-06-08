using Entity;
using ProgettoStudio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
using DataGrid = System.Windows.Controls.DataGrid;

namespace UI_WpfApp
{
    /// <summary>
    /// Interaction logic for frmElenco.xaml
    /// </summary>
    public partial class FrmElenco : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ICardForm mCard; 

        public Type FormType { get; set; }

        public bool IsSync { get; set; }

        public int SelectedIndex { get; set; }

        public object SelectedItem { get; set; }
        
        private bool mIsBusy;
        public bool IsBusy
        {
            get => mIsBusy;
            set
            {
                if (mIsBusy != value)
                {
                    mIsBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        private IEnumerable<object> mElenco;
        public IEnumerable<object> Elenco
        {
            get => mElenco;
            set
            {
                if (mElenco != value)
                {
                    mElenco = value;
                    OnPropertyChanged();
                }
            }
        }



        public FrmElenco(ICardForm card)
        {
            InitializeComponent();

            mCard = card;

            DataContext = this;

        }

        protected override void OnContentRendered(EventArgs e)
        {
                  
            base.OnContentRendered(e);

            IsBusy = true;  

            InvokeCardGenericReadAll();
            
        }


        private void InvokeCardGenericReadAll()
        {

            Type iEnumerableType = typeof(IEnumerable<>).MakeGenericType(FormType);
            Type successCallbackType = typeof(Action<>).MakeGenericType(iEnumerableType);

            MethodInfo handleResultGeneric = typeof(FrmElenco)
                .GetMethod(nameof(Callback), BindingFlags.Instance  | BindingFlags.NonPublic)
                .MakeGenericMethod(FormType);

            Delegate successCallback = Delegate.CreateDelegate(successCallbackType, this, handleResultGeneric);

            Action<Exception> errorCallback = ExcCallback;


            MethodInfo readAllAsync = mCard.GetType()
                .GetMethod(nameof(ICardForm.ReadAllAsync))
                .MakeGenericMethod(FormType);

            readAllAsync.Invoke(mCard, new object[] { successCallback, errorCallback });

        }         

        void Callback<T>(IEnumerable<T> elenco)
        {
            Elenco = elenco.Cast<object>();

            IsBusy = false;
        }

        void ExcCallback(Exception ex)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var newEntity = (EntityBase)Activator.CreateInstance(FormType);
            ICardForm newForm = (ICardForm)Activator.CreateInstance(mCard.GetType());

            mCard = newForm;

            newEntity.EntityState = EntityState.Added;

            mCard.ShowModal(newEntity);
                    
        }

        private void Elenco_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {            
            if (SelectedIndex >= 0 && SelectedItem is EntityBase entity)
            {
                ICardForm newForm = (ICardForm)Activator.CreateInstance(mCard.GetType());

                mCard = newForm;

                entity.EntityState = EntityState.Unchanged;

                mCard.ShowModal(entity);
            }
                        
        }

        

    }
}
