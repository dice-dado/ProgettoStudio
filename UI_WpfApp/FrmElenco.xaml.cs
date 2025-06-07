using Entity;
using ProgettoStudio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private ICardForm mCard; 

        public Type FormType { get; set; }

        public bool IsSync { get; set; }


        public FrmElenco(ICardForm card)
        {
            InitializeComponent();
            Elenco.IsReadOnly = true;

            mCard = card;
        }

        protected override void OnContentRendered(EventArgs e)
        {
                  
            base.OnContentRendered(e);

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
            Elenco.ItemsSource = elenco.Cast<T>();
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
            if (Elenco.SelectedIndex >= 0 && Elenco.SelectedItem is EntityBase entity)
            {
                ICardForm newForm = (ICardForm)Activator.CreateInstance(mCard.GetType());

                mCard = newForm;

                entity.EntityState = EntityState.Unchanged;

                mCard.ShowModal(entity);
            }
                        
        }

        

    }
}
