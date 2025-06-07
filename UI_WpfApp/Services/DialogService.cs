using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ProgettoStudio.Services
{
    internal class DialogService : IDialogService
    {
        public bool ShowMessageBox(string message)
        {
            var result = System.Windows.MessageBox.Show(
                message,
                "Attenzione",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            return result == MessageBoxResult.Yes;
        }
    }
}
