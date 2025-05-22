using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoStudio.Services
{
    internal class DialogService : IDialogService
    {
        public bool ShowMessageBox(string message)
        {
            var result = MessageBox.Show(
                message,
                "Attenzione",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
