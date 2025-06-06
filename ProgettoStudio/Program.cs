using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoStudio
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Imposta la modalità per gestire le eccezioni con Application.ThreadException
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.Run(new Form1());
        }

        /*
         
        CurrentDomain vs Application Exception:

             Se fai throw new Exception("errore") dentro un button.Click, verrà intercettato da Application_ThreadException.

             Se invece fai Task.Run(() => throw new Exception("errore")), e non gestisci l’eccezione, la intercetterà CurrentDomain_UnhandledException.

        Application.ThreadException	UI thread	Il programma continua a funzionare

        AppDomain.CurrentDomain.UnhandledException	Non-UI thread o eccezioni globali	Il programma termina (salvo gestione avanzata)             
         */

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"[UI Thread] Eccezione: {e.Exception.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show($"[Non-UI Thread] Eccezione: {ex.Message}", "Errore Critico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
