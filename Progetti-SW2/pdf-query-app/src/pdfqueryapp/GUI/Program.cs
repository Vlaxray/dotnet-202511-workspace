using PdfQueryApp.GUI;
using PdfQueryApp.Services;
using System.Windows.Forms;

namespace PdfQueryApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configura l'applicazione
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Crea il servizio PDF
            var pdfService = new PdfService();
            
            // Crea e mostra la finestra principale
            var mainForm = new MainForm(pdfService);
            
            // Controlla se ci sono PDF disponibili
            var availablePdfs = pdfService.GetAvailablePdfs();
            if (availablePdfs.Count == 0)
            {
                MessageBox.Show(
                    "⚠️ Nessun PDF trovato nella cartella Data.\n" +
                    "Per favore, aggiungi dei file PDF nella cartella:\n" +
                    $"{Path.Combine(Directory.GetCurrentDirectory(), "Data")}\n\n" +
                    "Riavvia l'applicazione dopo aver aggiunto i PDF.",
                    "Attenzione",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            
            Application.Run(mainForm);
        }
    }
}