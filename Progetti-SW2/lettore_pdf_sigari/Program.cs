using System;
using System.Windows.Forms;
using SigariListaPreziApp.UI;

namespace SigariListaPreziApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}