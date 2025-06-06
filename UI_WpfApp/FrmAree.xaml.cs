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
    /// Interaction logic for FrmAree.xaml
    /// </summary>
    public partial class FrmAree : Window, ICardForm
    {
        public FrmAree()
        {
            InitializeComponent();            
        }

        public IEnumerable<T> ReadAll<T>() where T : EntityBase
        {
            throw new NotImplementedException();
        }

        public void ReadAllAsync<T>(Action<IEnumerable<T>> callback, Action<Exception> excCallback) where T : EntityBase
        {
            throw new NotImplementedException();
        }

        public void ShowModal(EntityBase entity)
        {
            throw new NotImplementedException();
        }
    }
}
