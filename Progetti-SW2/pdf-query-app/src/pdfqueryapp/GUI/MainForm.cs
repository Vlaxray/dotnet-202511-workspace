using PdfQueryApp.Models;
using PdfQueryApp.Services;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PdfQueryApp.GUI
{
    public partial class MainForm : Form
    {
        private readonly IPdfService _pdfService;
        private List<PdfData> _currentPdfData;
        private string _currentPdfFile = string.Empty;

        // Controlli
        private ComboBox cmbPdfFiles = new();
        private TextBox txtQuery = new();
        private TextBox txtResults = new();
        private DataGridView dgvResults = new();
        private StatusStrip statusStrip = new();
        private ToolStripStatusLabel lblStatus = new();

        public MainForm(IPdfService pdfService)
        {
            _pdfService = pdfService;
            _currentPdfData = new List<PdfData>();
            InitializeComponent();
            LoadAvailablePdfs();
        }

        private void InitializeComponent()
        {
            // Configurazione della finestra
            this.Text = "PDF Query Application - Docker";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Menu superiore
            var menuStrip = new MenuStrip();
            var fileMenu = new ToolStripMenuItem("File");
            fileMenu.DropDownItems.Add("Carica PDF", null, LoadPdf_Click);
            fileMenu.DropDownItems.Add("Esci", null, (s, e) => Application.Exit());
            
            var helpMenu = new ToolStripMenuItem("Aiuto");
            helpMenu.DropDownItems.Add("Guida", null, ShowHelp);
            
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(helpMenu);
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;

            // Split Container
            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 300
            };

            // Pannello sinistro - Query
            var leftPanel = new Panel { Dock = DockStyle.Fill };
            
            var lblPdf = new Label 
            { 
                Text = "Seleziona PDF:", 
                Location = new Point(10, 40),
                Size = new Size(100, 25)
            };
            
            cmbPdfFiles.Location = new Point(120, 40);
            cmbPdfFiles.Size = new Size(200, 25);
            cmbPdfFiles.DropDownStyle = ComboBoxStyle.DropDownList;
            
            var btnLoad = new Button
            {
                Text = "📂 Carica",
                Location = new Point(330, 40),
                Size = new Size(100, 25),
                BackColor = Color.LightBlue
            };
            btnLoad.Click += LoadPdf_Click;

            var lblQuery = new Label
            {
                Text = "Query:",
                Location = new Point(10, 80),
                Size = new Size(100, 25)
            };

            txtQuery.Location = new Point(120, 80);
            txtQuery.Size = new Size(310, 100);
            txtQuery.Multiline = true;
            txtQuery.ScrollBars = ScrollBars.Vertical;
            txtQuery.Text = "CONTAINS 'testo'";

            var btnExecute = new Button
            {
                Text = "🔍 Esegui Query",
                Location = new Point(120, 190),
                Size = new Size(150, 35),
                BackColor = Color.LightGreen,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnExecute.Click += ExecuteQuery_Click;

            var btnClear = new Button
            {
                Text = "🗑️ Pulisci",
                Location = new Point(280, 190),
                Size = new Size(80, 35),
                BackColor = Color.LightCoral
            };
            btnClear.Click += (s, e) => txtResults.Clear();

            var lblExamples = new Label
            {
                Text = "📝 Esempi query:\n" +
                       "• CONTAINS 'testo'\n" +
                       "• PAGE = 1\n" +
                       "• testo da cercare\n\n" +
                       "📊 Statistiche PDF:\n" +
                       "• Pagine: 0\n" +
                       "• Risultati: 0",
                Location = new Point(10, 240),
                Size = new Size(400, 150),
                BorderStyle = BorderStyle.FixedSingle
            };

            leftPanel.Controls.AddRange(new Control[] 
            { 
                lblPdf, cmbPdfFiles, btnLoad, lblQuery, txtQuery, 
                btnExecute, btnClear, lblExamples 
            });

            // Pannello destro - Risultati
            var rightPanel = new Panel { Dock = DockStyle.Fill };

            txtResults.Multiline = true;
            txtResults.ScrollBars = ScrollBars.Both;
            txtResults.Font = new Font("Consolas", 10);
            txtResults.ReadOnly = true;
            txtResults.Dock = DockStyle.Fill;

            // DataGridView per risultati tabellari
            dgvResults.Dock = DockStyle.Bottom;
            dgvResults.Height = 200;
            dgvResults.ReadOnly = true;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configura colonne DataGridView
            dgvResults.Columns.Add("Page", "Pagina");
            dgvResults.Columns.Add("Preview", "Anteprima Testo");
            dgvResults.Columns.Add("Words", "Parole");
            dgvResults.Columns[1].Width = 300;

            rightPanel.Controls.Add(txtResults);
            rightPanel.Controls.Add(dgvResults);

            splitContainer.Panel1.Controls.Add(leftPanel);
            splitContainer.Panel2.Controls.Add(rightPanel);

            this.Controls.Add(splitContainer);

            // Status bar
            lblStatus.Text = "Pronto - Inserisci un PDF nella cartella /app/Data";
            lblStatus.Spring = true;
            statusStrip.Items.Add(lblStatus);
            this.Controls.Add(statusStrip);
        }

        private void LoadAvailablePdfs()
        {
            try
            {
                var pdfs = _pdfService.GetAvailablePdfs();
                cmbPdfFiles.Items.Clear();
                if (pdfs.Count > 0)
                {
                    cmbPdfFiles.Items.AddRange(pdfs.ToArray());
                    cmbPdfFiles.SelectedIndex = 0;
                    lblStatus.Text = $"Trovati {pdfs.Count} PDF(s) nella cartella Data";
                }
                else
                {
                    lblStatus.Text = "Nessun PDF trovato. Aggiungi PDF in /app/Data";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore caricamento PDF: {ex.Message}");
            }
        }

        private async void LoadPdf_Click(object sender, EventArgs e)
        {
            if (cmbPdfFiles.SelectedItem == null)
            {
                MessageBox.Show("Seleziona un PDF dalla lista.");
                return;
            }

            try
            {
                lblStatus.Text = "Caricamento PDF in corso...";
                this.Cursor = Cursors.WaitCursor;

                var pdfFile = cmbPdfFiles.SelectedItem.ToString()!;
                var pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", pdfFile);
                
                _currentPdfData = await _pdfService.ExtractDataFromPdf(pdfPath);
                _currentPdfFile = pdfFile;
                
                lblStatus.Text = $"PDF caricato: {pdfFile} ({_currentPdfData.Count} pagine)";
                
                txtResults.Text = $"✅ PDF '{pdfFile}' caricato con successo!\n";
                txtResults.Text += $"📄 Pagine: {_currentPdfData.Count}\n";
                txtResults.Text += $"📝 Totale caratteri: {_currentPdfData.Sum(d => d.Text.Length):N0}\n";
                txtResults.Text += $"⏱️ Data estrazione: {DateTime.Now:HH:mm:ss}\n\n";
                txtResults.Text += $"💡 Pronto per le query! Prova:\n";
                txtResults.Text += $"   • CONTAINS 'testo'\n";
                txtResults.Text += $"   • PAGE = 1\n";
                txtResults.Text += $"   • Qualsiasi parola da cercare\n";

                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Errore nel caricamento PDF:\n{ex.Message}", 
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Errore nel caricamento";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void ExecuteQuery_Click(object sender, EventArgs e)
        {
            if (_currentPdfData.Count == 0)
            {
                MessageBox.Show("⚠️ Prima carica un PDF.", 
                    "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuery.Text))
            {
                MessageBox.Show("⚠️ Inserisci una query.", 
                    "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatus.Text = "Esecuzione query in corso...";
                this.Cursor = Cursors.WaitCursor;

                var result = await _pdfService.ExecuteQuery(txtQuery.Text, _currentPdfData);

                // Mostra risultati in formato testo
                txtResults.Text = $"🔍 === RISULTATI QUERY ===\n";
                txtResults.Text += $"📋 Query: {txtQuery.Text}\n";
                txtResults.Text += $"⏱️ Tempo esecuzione: {result.ExecutionTime.TotalMilliseconds} ms\n";
                txtResults.Text += $"✅ Risultati trovati: {result.TotalMatches}\n\n";

                if (result.TotalMatches == 0)
                {
                    txtResults.Text += "❌ Nessun risultato trovato.\n";
                }
                else
                {
                    int showCount = Math.Min(result.Results.Count, 20);
                    for (int i = 0; i < showCount; i++)
                    {
                        var data = result.Results[i];
                        txtResults.Text += $"--- 📄 Pagina {data.PageNumber} ---\n";
                        
                        // Mostra anteprima di 300 caratteri
                        var preview = data.Text.Length > 300 
                            ? data.Text.Substring(0, 300) + "..." 
                            : data.Text;
                        txtResults.Text += $"{preview}\n\n";
                    }

                    if (result.TotalMatches > showCount)
                        txtResults.Text += $"📊 ... e altri {result.TotalMatches - showCount} risultati\n";
                }

                // Aggiorna DataGridView
                dgvResults.Rows.Clear();
                foreach (var data in result.Results.Take(50))
                {
                    dgvResults.Rows.Add(
                        data.PageNumber,
                        data.Text.Length > 100 ? data.Text.Substring(0, 100) + "..." : data.Text,
                        data.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length
                    );
                }
                
                lblStatus.Text = $"✅ Query completata. Trovati {result.TotalMatches} risultati in {result.ExecutionTime.TotalMilliseconds}ms";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Errore nell'esecuzione query:\n{ex.Message}", 
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "❌ Errore nell'esecuzione query";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void UpdateDataGrid()
        {
            dgvResults.Rows.Clear();
            foreach (var data in _currentPdfData.Take(100))
            {
                dgvResults.Rows.Add(
                    data.PageNumber,
                    data.Text.Length > 100 ? data.Text.Substring(0, 100) + "..." : data.Text,
                    data.Metadata.TryGetValue("WordCount", out var wc) ? wc : "0"
                );
            }
        }

        private void ShowHelp(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "📚 GUIDA PDF QUERY APP\n\n" +
                "1. Metti i tuoi PDF nella cartella /app/Data\n" +
                "2. Seleziona un PDF dalla lista\n" +
                "3. Clicca 'Carica' per estrarre i dati\n" +
                "4. Scrivi una query nel campo 'Query'\n" +
                "5. Clicca 'Esegui Query'\n\n" +
                "📝 ESEMPI QUERY:\n" +
                "• CONTAINS 'parola'\n" +
                "• PAGE = 3\n" +
                "• Cerca qualsiasi testo\n\n" +
                "🔄 Ricarica l'app se aggiungi nuovi PDF",
                "Aiuto", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
            );
        }
    }
}