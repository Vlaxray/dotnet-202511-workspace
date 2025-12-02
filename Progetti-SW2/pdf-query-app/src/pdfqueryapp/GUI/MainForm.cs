using PdfQueryApp.Models;
using PdfQueryApp.Services;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
// using PdfQueryApp.Properties; // Removed because the namespace does not exist

namespace PdfQueryApp.GUI
{
    public partial class MainForm : Form
    {
        private readonly IPdfService _pdfService;
        private List<PdfData> _currentPdfData = new();
        private string _currentPdfFile = string.Empty;
        private QueryHistory _queryHistory = new();

        // Controlli principali
        private ComboBox cmbPdfFiles = new();
        private ComboBox cmbQueryExamples = new();
        private TextBox txtQuery = new();
        private RichTextBox txtResults = new();
        private DataGridView dgvResults = new();
        private TabControl tabControl = new();
        private StatusStrip statusStrip = new();
        private ToolStripStatusLabel lblStatus = new();
        private ToolStripProgressBar progressBar = new();
        private PropertyGrid propertyGrid = new();

        public MainForm(IPdfService pdfService)
        {
            _pdfService = pdfService;
            InitializeComponent();
            LoadAvailablePdfs();
            SetupQueryExamples();
        }

        private void InitializeComponent()
        {
            // Configurazione della finestra
            this.Text = "🔍 PDF Query Analyzer Pro";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = SystemIcons.Information;
            this.Font = new Font("Segoe UI", 9);

            // Menu superiore migliorato
            var menuStrip = CreateMenuStrip();
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;

            // Toolbar
            var toolStrip = CreateToolStrip();
            this.Controls.Add(toolStrip);

            // Pannello superiore (PDF selection)
            var topPanel = CreateTopPanel();
            this.Controls.Add(topPanel);

            // TabControl principale
            tabControl.Dock = DockStyle.Fill;
            tabControl.Padding = new Point(10, 10);
            tabControl.SelectedIndex = 0;

            // Tab 1: Query e Risultati
            var tabQuery = new TabPage("🔍 Query & Risultati");
            tabQuery.Controls.Add(CreateQueryPanel());
            tabControl.TabPages.Add(tabQuery);

            // Tab 2: Anteprima PDF
            var tabPreview = new TabPage("📄 Anteprima PDF");
            tabPreview.Controls.Add(CreatePreviewPanel());
            tabControl.TabPages.Add(tabPreview);

            // Tab 3: Statistiche
            var tabStats = new TabPage("📊 Statistiche");
            tabStats.Controls.Add(CreateStatsPanel());
            tabControl.TabPages.Add(tabStats);

            // Tab 4: Cronologia Query
            var tabHistory = new TabPage("📝 Cronologia");
            tabHistory.Controls.Add(CreateHistoryPanel());
            tabControl.TabPages.Add(tabHistory);

            this.Controls.Add(tabControl);

            // Status bar migliorata
            CreateStatusBar();
            this.Controls.Add(statusStrip);

            // Configura colori
            ApplyTheme();
        }

        private MenuStrip CreateMenuStrip()
        {
            var menuStrip = new MenuStrip { BackColor = Color.FromArgb(45, 45, 48), ForeColor = Color.White };

            // File Menu
            var fileMenu = new ToolStripMenuItem("📁 File");
            fileMenu.DropDownItems.Add("📂 Carica PDF...", null, LoadPdf_Click);
            fileMenu.DropDownItems.Add("🔄 Ricarica lista PDF", null, (s, e) => LoadAvailablePdfs());
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add("💾 Esporta risultati...", null, ExportResults_Click);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add("🚪 Esci", null, (s, e) => Application.Exit());

            // Modifica Menu
            var editMenu = new ToolStripMenuItem("✏️ Modifica");
            editMenu.DropDownItems.Add("📋 Copia risultati", null, CopyResults_Click);
            editMenu.DropDownItems.Add("🧹 Pulisci tutto", null, ClearAll_Click);
            editMenu.DropDownItems.Add("⚙️ Opzioni query...", null, QueryOptions_Click);

            // Visualizza Menu
            var viewMenu = new ToolStripMenuItem("👁️ Visualizza");
            var gridMenuItem = new ToolStripMenuItem("📊 Mostra griglia", null, ToggleGrid_Click)
            {
                CheckOnClick = true
            };
            viewMenu.DropDownItems.Add(gridMenuItem);

            var statsMenuItem = new ToolStripMenuItem("📈 Mostra statistiche", null, ToggleStats_Click)
            {
                CheckOnClick = true
            };
            viewMenu.DropDownItems.Add(statsMenuItem);
            viewMenu.DropDownItems.Add(new ToolStripSeparator());
            viewMenu.DropDownItems.Add("🎨 Tema chiaro", null, ToggleTheme_Click);

            // Strumenti Menu
            var toolsMenu = new ToolStripMenuItem("🛠️ Strumenti");
            toolsMenu.DropDownItems.Add("🔍 Analisi avanzata...", null, AdvancedAnalysis_Click);
            toolsMenu.DropDownItems.Add("📑 Estrai tabelle...", null, ExtractTables_Click);
            toolsMenu.DropDownItems.Add("🖼️ Estrai immagini...", null, ExtractImages_Click);

            // Aiuto Menu
            var helpMenu = new ToolStripMenuItem("❓ Aiuto");
            helpMenu.DropDownItems.Add("📖 Guida rapida", null, QuickGuide_Click);
            helpMenu.DropDownItems.Add("🎥 Tutorial", null, Tutorial_Click);
            helpMenu.DropDownItems.Add(new ToolStripSeparator());
            helpMenu.DropDownItems.Add("ℹ️ Informazioni", null, About_Click);

            menuStrip.Items.AddRange(new[] { fileMenu, editMenu, viewMenu, toolsMenu, helpMenu });
            return menuStrip;
        }

        private ToolStrip CreateToolStrip()
        {
            var toolStrip = new ToolStrip
            {
                Dock = DockStyle.None,
                Location = new Point(0, 24),
                Size = new Size(1200, 38),
                GripStyle = ToolStripGripStyle.Hidden,
                BackColor = Color.FromArgb(62, 62, 66)
            };

            toolStrip.Items.Add(new ToolStripButton("📂 Carica", null, LoadPdf_Click)
            {
                ToolTipText = "Carica PDF selezionato",
                BackColor = Color.SteelBlue,
                ForeColor = Color.White
            });

            toolStrip.Items.Add(new ToolStripSeparator());
            toolStrip.Items.Add(new ToolStripButton("🔍 Esegui", null, ExecuteQuery_Click)
            {
                ToolTipText = "Esegui query",
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            });

            toolStrip.Items.Add(new ToolStripButton("🧹 Pulisci", null, (s, e) => ClearQuery_Click())
            {
                ToolTipText = "Pulisci query"
            });

            toolStrip.Items.Add(new ToolStripSeparator());

            var cmbQueryType = new ToolStripComboBox("QueryType")
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 120,
                ToolTipText = "Tipo di query"
            };
            cmbQueryType.Items.AddRange(new[] { "📝 Testo", "🔢 Numerica", "📅 Data", "🔗 Combinata" });
            cmbQueryType.SelectedIndex = 0;
            toolStrip.Items.Add(cmbQueryType);

            toolStrip.Items.Add(new ToolStripSeparator());
            toolStrip.Items.Add(new ToolStripLabel("🔎 Ricerca:"));
            
            var txtQuickSearch = new ToolStripTextBox
            {
                Width = 150,
                ToolTipText = "Ricerca rapida nel PDF corrente"
            };
            txtQuickSearch.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                    QuickSearch(txtQuickSearch.Text);
            };
            toolStrip.Items.Add(txtQuickSearch);

            return toolStrip;
        }

        private Panel CreateTopPanel()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(30, 30, 35),
                Padding = new Padding(10)
            };

            // Label PDF
            var lblPdf = new Label
            {
                Text = "📄 PDF:",
                ForeColor = Color.White,
                Location = new Point(10, 15),
                Size = new Size(50, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // ComboBox PDF
            cmbPdfFiles.Location = new Point(70, 15);
            cmbPdfFiles.Size = new Size(250, 30);
            cmbPdfFiles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPdfFiles.Font = new Font("Segoe UI", 10);
            cmbPdfFiles.SelectedIndexChanged += (s, e) =>
            {
                if (cmbPdfFiles.SelectedItem != null)
                    AutoLoadPdf();
            };

            // Info PDF
            var lblInfo = new Label
            {
                Text = "Nessun PDF caricato",
                ForeColor = Color.LightGray,
                Location = new Point(330, 15),
                Size = new Size(400, 25),
                Font = new Font("Segoe UI", 9)
            };

            // Bottone carica
            var btnLoad = new Button
            {
                Text = "📂 CARICA",
                Location = new Point(700, 12),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLoad.Click += LoadPdf_Click;
            btnLoad.FlatAppearance.BorderSize = 0;

            // Bottone info
            var btnInfo = new Button
            {
                Text = "ℹ️",
                Location = new Point(830, 12),
                Size = new Size(35, 35),
                BackColor = Color.FromArgb(64, 64, 64),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12),
                Cursor = Cursors.Hand
            };
            btnInfo.Click += ShowPdfInfo_Click;

            panel.Controls.AddRange(new Control[] { lblPdf, cmbPdfFiles, lblInfo, btnLoad, btnInfo });
            return panel;
        }

        private Panel CreateQueryPanel()
        {
            var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };

            // Split container orizzontale
            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 300
            };

            // Pannello sinistro - Query
            var leftPanel = new Panel { Dock = DockStyle.Fill };

            // Label query
            var lblQuery = new Label
            {
                Text = "🔍 Scrivi la tua query:",
                Location = new Point(0, 0),
                Size = new Size(280, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // TextBox query migliorata
            txtQuery.Multiline = true;
            txtQuery.Location = new Point(0, 30);
            txtQuery.Size = new Size(280, 120);
            txtQuery.Font = new Font("Consolas", 10);
            txtQuery.ScrollBars = ScrollBars.Vertical;
            txtQuery.PlaceholderText = "Es: CONTAINS 'testo' AND PAGE < 5";
            txtQuery.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.Enter)
                    ExecuteQuery_Click(s, e);
            };

            // Esempi query
            var lblExamples = new Label
            {
                Text = "📝 Esempi:",
                Location = new Point(0, 160),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 9)
            };

            cmbQueryExamples.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQueryExamples.Location = new Point(0, 185);
            cmbQueryExamples.Size = new Size(280, 25);
            cmbQueryExamples.SelectedIndexChanged += (s, e) =>
            {
                if (cmbQueryExamples.SelectedItem is QueryExample example)
                {
                    txtQuery.Text = example.Query;
                    txtQuery.Focus();
                }
            };

            // Bottoni query
            var btnExecute = new Button
            {
                Text = "🚀 ESegui Query",
                Location = new Point(0, 220),
                Size = new Size(140, 35),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnExecute.Click += ExecuteQuery_Click;
            btnExecute.FlatAppearance.BorderSize = 0;

            var btnClear = new Button
            {
                Text = "🧹 Pulisci",
                Location = new Point(150, 220),
                Size = new Size(130, 35),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClear.Click += (s, e) => ClearQuery_Click();

            // Query builder panel
            var queryBuilderPanel = CreateQueryBuilderPanel();
            queryBuilderPanel.Location = new Point(0, 270);
            leftPanel.Controls.Add(queryBuilderPanel);

            leftPanel.Controls.AddRange(new Control[] 
            { 
                lblQuery, txtQuery, lblExamples, cmbQueryExamples, 
                btnExecute, btnClear 
            });

            // Pannello destro - Risultati
            var rightPanel = new Panel { Dock = DockStyle.Fill };

            // RichTextBox per risultati formattati
            txtResults.Dock = DockStyle.Fill;
            txtResults.Font = new Font("Consolas", 10);
            txtResults.ReadOnly = true;
            txtResults.BackColor = Color.FromArgb(25, 25, 25);
            txtResults.ForeColor = Color.LightGray;
            txtResults.WordWrap = false;
            txtResults.ScrollBars = RichTextBoxScrollBars.Both;

            // DataGridView migliorato
            dgvResults.Dock = DockStyle.Bottom;
            dgvResults.Height = 250;
            dgvResults.ReadOnly = true;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.RowHeadersVisible = false;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvResults.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvResults.RowPrePaint += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvResults.Rows.Count)
                {
                    var row = dgvResults.Rows[e.RowIndex];
                    row.DefaultCellStyle.BackColor = e.RowIndex % 2 == 0 ? 
                        Color.FromArgb(245, 245, 245) : Color.White;
                }
            };
            dgvResults.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var page = Convert.ToInt32(dgvResults.Rows[e.RowIndex].Cells["Page"].Value);
                    ShowPagePreview(page);
                }
            };

            // Configura colonne
            ConfigureDataGridColumns();

            rightPanel.Controls.Add(txtResults);
            rightPanel.Controls.Add(dgvResults);

            splitContainer.Panel1.Controls.Add(leftPanel);
            splitContainer.Panel2.Controls.Add(rightPanel);

            panel.Controls.Add(splitContainer);
            return panel;
        }

        private Panel CreateQueryBuilderPanel()
        {
            var panel = new Panel
            {
                Size = new Size(280, 150),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            var lblBuilder = new Label
            {
                Text = "🔨 Query Builder",
                Location = new Point(5, 5),
                Size = new Size(270, 20),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            // Filtri rapidi
            var btnContains = new Button
            {
                Text = "CONTAINS",
                Location = new Point(5, 30),
                Size = new Size(80, 25),
                Tag = "CONTAINS ''"
            };
            btnContains.Click += AddQueryPart_Click;

            var btnPage = new Button
            {
                Text = "PAGE =",
                Location = new Point(90, 30),
                Size = new Size(80, 25),
                Tag = "PAGE = "
            };
            btnPage.Click += AddQueryPart_Click;

            var btnAnd = new Button
            {
                Text = "AND",
                Location = new Point(175, 30),
                Size = new Size(40, 25),
                Tag = " AND "
            };
            btnAnd.Click += AddQueryPart_Click;

            var btnOr = new Button
            {
                Text = "OR",
                Location = new Point(220, 30),
                Size = new Size(40, 25),
                Tag = " OR "
            };
            btnOr.Click += AddQueryPart_Click;

            var btnNot = new Button
            {
                Text = "NOT",
                Location = new Point(5, 60),
                Size = new Size(80, 25),
                Tag = "NOT "
            };
            btnNot.Click += AddQueryPart_Click;

            var btnRegex = new Button
            {
                Text = "REGEX",
                Location = new Point(90, 60),
                Size = new Size(80, 25),
                Tag = "REGEX ''"
            };
            btnRegex.Click += AddQueryPart_Click;

            // Campo di testo per valore
            var txtValue = new TextBox
            {
                Location = new Point(5, 90),
                Size = new Size(150, 25),
                PlaceholderText = "Valore da cercare"
            };

            var btnAddValue = new Button
            {
                Text = "➕ Aggiungi",
                Location = new Point(160, 90),
                Size = new Size(100, 25),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White
            };
            btnAddValue.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtValue.Text))
                {
                    txtQuery.AppendText($"'{txtValue.Text}' ");
                    txtValue.Clear();
                }
            };

            panel.Controls.AddRange(new Control[] 
            { 
                lblBuilder, btnContains, btnPage, btnAnd, btnOr, 
                btnNot, btnRegex, txtValue, btnAddValue 
            });
            return panel;
        }

        private void ConfigureDataGridColumns()
        {
            dgvResults.Columns.Clear();
            
            var colPage = new DataGridViewTextBoxColumn
            {
                Name = "Page",
                HeaderText = "📄 Pagina",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Consolas", 9, FontStyle.Bold)
                }
            };

            var colPreview = new DataGridViewTextBoxColumn
            {
                Name = "Preview",
                HeaderText = "📝 Contenuto",
                Width = 400,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    WrapMode = DataGridViewTriState.True,
                    Font = new Font("Segoe UI", 9)
                }
            };

            var colWords = new DataGridViewTextBoxColumn
            {
                Name = "Words",
                HeaderText = "🔤 Parole",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            var colMatches = new DataGridViewTextBoxColumn
            {
                Name = "Matches",
                HeaderText = "🔍 Match",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.Green,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                }
            };

            dgvResults.Columns.AddRange(new DataGridViewColumn[] 
            { 
                colPage, colPreview, colWords, colMatches 
            });
        }

        private Panel CreatePreviewPanel()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            
            var webView = new WebBrowser
            {
                Dock = DockStyle.Fill,
                ScriptErrorsSuppressed = true
            };

            var pageNavigator = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.LightGray
            };

            var lblPage = new Label
            {
                Text = "Pagina: 1",
                Location = new Point(10, 10),
                AutoSize = true
            };

            var btnPrev = new Button
            {
                Text = "◀️",
                Location = new Point(100, 5),
                Size = new Size(30, 30)
            };

            var btnNext = new Button
            {
                Text = "▶️",
                Location = new Point(140, 5),
                Size = new Size(30, 30)
            };

            pageNavigator.Controls.AddRange(new Control[] { lblPage, btnPrev, btnNext });
            panel.Controls.Add(webView);
            panel.Controls.Add(pageNavigator);

            return panel;
        }

        private Panel CreateStatsPanel()
        {
            var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };

            var statsGrid = new PropertyGrid
            {
                Dock = DockStyle.Fill,
                ToolbarVisible = false,
                HelpVisible = false
            };

            panel.Controls.Add(statsGrid);
            return panel;
        }

        private Panel CreateHistoryPanel()
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            
            var lstHistory = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10),
                ItemHeight = 25
            };

            var btnClearHistory = new Button
            {
                Text = "🧹 Cancella cronologia",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.IndianRed,
                ForeColor = Color.White
            };
            btnClearHistory.Click += (s, e) => lstHistory.Items.Clear();

            panel.Controls.Add(lstHistory);
            panel.Controls.Add(btnClearHistory);
            return panel;
        }

        private void CreateStatusBar()
        {
            statusStrip.BackColor = Color.FromArgb(45, 45, 48);
            statusStrip.ForeColor = Color.White;

            lblStatus.Text = "Pronto - Seleziona un PDF per iniziare";
            lblStatus.Spring = true;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = false;

            var lblPages = new ToolStripStatusLabel
            {
                Text = "Pagine: 0",
                BorderSides = ToolStripStatusLabelBorderSides.Left,
                BorderStyle = Border3DStyle.Etched
            };

            var lblWords = new ToolStripStatusLabel
            {
                Text = "Parole: 0",
                BorderSides = ToolStripStatusLabelBorderSides.Left,
                BorderStyle = Border3DStyle.Etched
            };

            var lblTime = new ToolStripStatusLabel
            {
                Text = "Tempo: 0ms",
                BorderSides = ToolStripStatusLabelBorderSides.Left,
                BorderStyle = Border3DStyle.Etched
            };

            statusStrip.Items.AddRange(new ToolStripItem[] 
            { 
                lblStatus, progressBar, lblPages, lblWords, lblTime 
            });
        }

        private void SetupQueryExamples()
        {
            var examples = new List<QueryExample>
            {
                new("Testo semplice", "cerca questo testo"),
                new("Testo esatto", "CONTAINS 'testo esatto'"),
                new("Per pagina", "PAGE = 1"),
                new("Range pagine", "PAGE >= 1 AND PAGE <= 10"),
                new("Multipla ricerca", "CONTAINS 'testo' AND PAGE < 5"),
                new("Esclusione", "CONTAINS 'importante' AND NOT CONTAINS 'segreto'"),
                new("Regex semplice", "REGEX '\\d{3}-\\d{3}'"),
                new("Email", "REGEX '[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}'"),
                new("Data", "REGEX '\\d{2}/\\d{2}/\\d{4}'"),
                new("Parole multiple", "CONTAINS 'termine1' OR CONTAINS 'termine2'"),
                new("Parole vicine", "NEAR('termine1', 'termine2', 50)"),
                new("Case insensitive", "LOWER(CONTAINS 'TEST')"),
                new("Conteggio parole", "WORDCOUNT > 100"),
                new("Inizio pagina", "STARTSWITH 'CAPITOLO'"),
                new("Fine pagina", "ENDSWITH 'FINE'")
            };

            cmbQueryExamples.DisplayMember = "Description";
            cmbQueryExamples.ValueMember = "Query";
            cmbQueryExamples.DataSource = examples;
        }

        // ============== METODI DI GESTIONE ==============

        private async void LoadPdf_Click(object sender, EventArgs e)
        {
            if (cmbPdfFiles.SelectedItem == null)
            {
                ShowMessage("Seleziona un PDF dalla lista.", MessageType.Warning);
                return;
            }

            try
            {
                StartOperation($"Caricamento PDF '{cmbPdfFiles.SelectedItem}' in corso...");

                var pdfFile = cmbPdfFiles.SelectedItem.ToString()!;
                var pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", pdfFile);
                
                _currentPdfData = await _pdfService.ExtractDataFromPdf(pdfPath);
                _currentPdfFile = pdfFile;
                
                UpdateUIAfterLoad(pdfFile);
                UpdateStatistics();
                
                ShowMessage($"✅ PDF '{pdfFile}' caricato ({_currentPdfData.Count} pagine)", MessageType.Success);
            }
            catch (Exception ex)
            {
                ShowMessage($"❌ Errore: {ex.Message}", MessageType.Error);
            }
            finally
            {
                EndOperation();
            }
        }

        private async void ExecuteQuery_Click(object sender, EventArgs e)
        {
            if (_currentPdfData.Count == 0)
            {
                ShowMessage("Carica prima un PDF.", MessageType.Warning);
                return;
            }

            var query = txtQuery.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                ShowMessage("Inserisci una query.", MessageType.Warning);
                return;
            }

            try
            {
                StartOperation($"Esecuzione query '{query}'...");

                // Aggiungi alla cronologia
                _queryHistory.Add(query, DateTime.Now);
                
                // Esegui query
                var result = await _pdfService.ExecuteQuery(query, _currentPdfData);
                
                // Mostra risultati
                DisplayQueryResults(query, result);
                UpdateQueryStatistics(result);
                
                ShowMessage($"✅ Trovati {result.TotalMatches} risultati in {result.ExecutionTime.TotalMilliseconds}ms", 
                    MessageType.Success);
            }
            catch (Exception ex)
            {
                ShowMessage($"❌ Errore query: {ex.Message}", MessageType.Error);
            }
            finally
            {
                EndOperation();
            }
        }

        private void DisplayQueryResults(string query, QueryResult result)
        {
            // Formattazione avanzata per RichTextBox
            txtResults.Clear();

            // Intestazione
            txtResults.SelectionColor = Color.Cyan;
            txtResults.AppendText("══════════════════════════════════════════════════════════\n");
            txtResults.AppendText($"🔍 RISULTATI QUERY\n");
            txtResults.AppendText($"══════════════════════════════════════════════════════════\n\n");
            
            txtResults.SelectionColor = Color.White;
            txtResults.AppendText($"📋 Query: ");
            txtResults.SelectionColor = Color.Yellow;
            txtResults.AppendText($"{query}\n");
            
            txtResults.SelectionColor = Color.White;
            txtResults.AppendText($"⏱️  Tempo esecuzione: ");
            txtResults.SelectionColor = Color.LightGreen;
            txtResults.AppendText($"{result.ExecutionTime.TotalMilliseconds} ms\n");
            
            txtResults.SelectionColor = Color.White;
            txtResults.AppendText($"✅ Risultati trovati: ");
            txtResults.SelectionColor = result.TotalMatches > 0 ? Color.Lime : Color.Red;
            txtResults.AppendText($"{result.TotalMatches}\n\n");

            if (result.TotalMatches == 0)
            {
                txtResults.SelectionColor = Color.Orange;
                txtResults.AppendText("❌ Nessun risultato trovato.\n");
                txtResults.AppendText("💡 Suggerimenti:\n");
                txtResults.AppendText("   • Controlla l'ortografia\n");
                txtResults.AppendText("   • Prova termini più generali\n");
                txtResults.AppendText("   • Usa CONTAINS per ricerche testuali\n");
            }
            else
            {
                // Risultati
                txtResults.SelectionColor = Color.Cyan;
                txtResults.AppendText($"📄 RISULTATI ({Math.Min(result.Results.Count, 100)}/{result.TotalMatches}):\n");
                txtResults.AppendText($"══════════════════════════════════════════════════════════\n\n");

                for (int i = 0; i < Math.Min(result.Results.Count, 100); i++)
                {
                    var data = result.Results[i];
                    
                    txtResults.SelectionColor = Color.Magenta;
                    txtResults.AppendText($"[Pagina {data.PageNumber}] ");
                    
                    if (data.Metadata.TryGetValue("Relevance", out var relevance))
                    {
                        txtResults.SelectionColor = GetRelevanceColor(Convert.ToDouble(relevance));
                        txtResults.AppendText($"(Pertinenza: {relevance}%) ");
                    }
                    
                    txtResults.AppendText("\n");
                    
                    // Mostra contesto con evidenziazione
                    var context = GetHighlightedContext(data.Text, query);
                    txtResults.SelectionColor = Color.LightGray;
                    txtResults.AppendText($"{context}\n\n");
                }

                if (result.TotalMatches > 100)
                {
                    txtResults.SelectionColor = Color.Yellow;
                    txtResults.AppendText($"📊 ... e altri {result.TotalMatches - 100} risultati non mostrati\n");
                }
            }

            // Aggiorna DataGridView
            UpdateResultsGrid(result.Results);
            
            // Torna all'inizio
            txtResults.SelectionStart = 0;
            txtResults.ScrollToCaret();
        }

        private Color GetRelevanceColor(double relevance)
        {
            return relevance switch
            {
                >= 80 => Color.Lime,
                >= 60 => Color.YellowGreen,
                >= 40 => Color.Orange,
                _ => Color.OrangeRed
            };
        }

        private string GetHighlightedContext(string text, string query)
        {
            // Cerca parole della query nel testo
            var words = query.ToLower()
                .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length > 3)
                .ToArray();

            if (words.Length == 0)
                return text.Length > 300 ? text.Substring(0, 300) + "..." : text;

            var lowerText = text.ToLower();
            int startPos = 0;
            
            // Trova la prima occorrenza di una parola della query
            foreach (var word in words)
            {
                var pos = lowerText.IndexOf(word);
                if (pos >= 0)
                {
                    startPos = Math.Max(0, pos - 50);
                    break;
                }
            }

            var endPos = Math.Min(text.Length, startPos + 300);
            var context = text.Substring(startPos, endPos - startPos);
            
            if (startPos > 0)
                context = "..." + context;
            if (endPos < text.Length)
                context = context + "...";
            
            return context;
        }

        private void UpdateResultsGrid(List<PdfData> results)
        {
            dgvResults.Rows.Clear();
            
            foreach (var data in results.Take(100))
            {
                var matchCount = data.Metadata.TryGetValue("MatchCount", out var mc) ? 
                    Convert.ToInt32(mc) : 1;
                    
                var preview = data.Text.Length > 200 ? 
                    data.Text.Substring(0, 200) + "..." : data.Text;
                
                dgvResults.Rows.Add(
                    data.PageNumber,
                    preview,
                    data.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length,
                    matchCount
                );
                
                // Colora le righe in base alla pertinenza
                if (data.Metadata.TryGetValue("Relevance", out var relevance) && 
                    Convert.ToDouble(relevance) < 30)
                {
                    dgvResults.Rows[^1].DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
            
            // Autosize altezza righe
            dgvResults.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void UpdateUIAfterLoad(string pdfFile)
        {
            var pageCount = _currentPdfData.Count;
            var totalWords = _currentPdfData.Sum(d => 
                d.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length);

            txtResults.Text = $"🎉 PDF CARICATO CON SUCCESSO!\n";
            txtResults.Text += $"══════════════════════════════════════════════════════════\n\n";
            txtResults.Text += $"📄 File: {pdfFile}\n";
            txtResults.Text += $"📊 Pagine: {pageCount}\n";
            txtResults.Text += $"🔤 Parole totali: {totalWords:N0}\n";
            txtResults.Text += $"📏 Caratteri: {_currentPdfData.Sum(d => d.Text.Length):N0}\n";
            txtResults.Text += $"⏱️  Tempo estrazione: {DateTime.Now:HH:mm:ss}\n\n";
            txtResults.Text += $"💡 SUGGERIMENTI:\n";
            txtResults.Text += $"   • Usa 'CONTAINS' per ricerche testuali\n";
            txtResults.Text += $"   • Usa 'PAGE = X' per cercare in una pagina specifica\n";
            txtResults.Text += $"   • Combina query con AND/OR\n";
            txtResults.Text += $"   • Usa 'REGEX' per pattern complessi\n\n";
            txtResults.Text += $"🚀 Pronto per le query!";

            UpdateResultsGrid(_currentPdfData);
        }

        private void UpdateStatistics()
        {
            // Aggiorna statistiche nella property grid
            var stats = new PdfStatistics
            {
                FileName = _currentPdfFile,
                PageCount = _currentPdfData.Count,
                TotalWords = _currentPdfData.Sum(d => 
                    d.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length),
                TotalCharacters = _currentPdfData.Sum(d => d.Text.Length),
                AverageWordsPerPage = _currentPdfData.Average(d => 
                    d.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length),
                LoadTime = DateTime.Now
            };

            // Trova il property grid nella tab statistics
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Text == "📊 Statistiche")
                {
                    var panel = tab.Controls[0] as Panel;
                    if (panel != null)
                    {
                        var propGrid = panel.Controls[0] as PropertyGrid;
                        if (propGrid != null)
                            propGrid.SelectedObject = stats;
                    }
                    break;
                }
            }
        }

        private void UpdateQueryStatistics(QueryResult result)
        {
            // Aggiorna status bar
            var statusItems = statusStrip.Items;
            if (statusItems.Count >= 4)
            {
                ((ToolStripStatusLabel)statusItems[2]).Text = $"Pagine: {result.Results.Count}";
                ((ToolStripStatusLabel)statusItems[3]).Text = $"Parole: {result.TotalMatches}";
                ((ToolStripStatusLabel)statusItems[4]).Text = $"Tempo: {result.ExecutionTime.TotalMilliseconds}ms";
            }
        }

        // ============== METODI AUSILIARI ==============

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
                    ShowMessage($"Trovati {pdfs.Count} PDF(s)", MessageType.Info);
                }
                else
                {
                    ShowMessage("Nessun PDF trovato in /app/Data", MessageType.Warning);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Errore caricamento PDF: {ex.Message}", MessageType.Error);
            }
        }

        private void StartOperation(string message)
        {
            lblStatus.Text = message;
            progressBar.Visible = true;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
        }

        private void EndOperation()
        {
            progressBar.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void ShowMessage(string message, MessageType type)
        {
            lblStatus.Text = message;
            
            switch (type)
            {
                case MessageType.Success:
                    lblStatus.ForeColor = Color.Lime;
                    break;
                case MessageType.Error:
                    lblStatus.ForeColor = Color.Red;
                    break;
                case MessageType.Warning:
                    lblStatus.ForeColor = Color.Yellow;
                    break;
                default:
                    lblStatus.ForeColor = Color.White;
                    break;
            }
        }

        private void ApplyTheme()
        {
            // Applica tema scuro
            this.BackColor = Color.FromArgb(37, 37, 38);
            this.ForeColor = Color.White;
        }

        // ============== METODI EVENTI ==============

        private bool _autoLoadPdfEnabled = false; // Set to true to enable auto-load

        private void AutoLoadPdf()
        {
            if (_autoLoadPdfEnabled && cmbPdfFiles.SelectedItem != null)
            {
                LoadPdf_Click(null, EventArgs.Empty);
            }
        }

        private void AddQueryPart_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string queryPart)
            {
                txtQuery.AppendText(queryPart + " ");
                txtQuery.Focus();
            }
        }

        private void ClearQuery_Click()
        {
            txtQuery.Clear();
            txtResults.Clear();
            dgvResults.Rows.Clear();
            ShowMessage("Query pulita", MessageType.Info);
        }

        private void QuickSearch(string text)
        {
            if (!string.IsNullOrWhiteSpace(text) && _currentPdfData.Count > 0)
            {
                txtQuery.Text = $"CONTAINS '{text}'";
                ExecuteQuery_Click(null, EventArgs.Empty);
            }
        }

        private void ShowPagePreview(int pageNumber)
        {
            tabControl.SelectedIndex = 1; // Vai alla tab anteprima
            // Qui implementeresti la visualizzazione della pagina specifica
        }

        // ============== CLASSI AUSILIARIE ==============

        private enum MessageType { Info, Success, Warning, Error }

        private class QueryExample
        {
            public string Description { get; set; }
            public string Query { get; set; }

            public QueryExample(string description, string query)
            {
                Description = description;
                Query = query;
            }

            public override string ToString() => Description;
        }

        private class QueryHistory
        {
            private List<QueryHistoryItem> _items = new();
            private const int MaxHistory = 50;

            public void Add(string query, DateTime timestamp)
            {
                _items.Insert(0, new QueryHistoryItem(query, timestamp));
                if (_items.Count > MaxHistory)
                    _items.RemoveAt(MaxHistory);
            }

            public List<QueryHistoryItem> GetRecent(int count = 10)
            {
                return _items.Take(count).ToList();
            }

            public class QueryHistoryItem
            {
                public string Query { get; set; }
                public DateTime Timestamp { get; set; }
                public bool Success { get; set; }

                public QueryHistoryItem(string query, DateTime timestamp, bool success = true)
                {
                    Query = query;
                    Timestamp = timestamp;
                    Success = success;
                }
            }
        }

        [Serializable]
        private class PdfStatistics
        {
            [Category("📄 File")]
            [Description("Nome del file PDF")]
            public string FileName { get; set; }

            [Category("📊 Statistiche")]
            [Description("Numero totale di pagine")]
            public int PageCount { get; set; }

            [Category("📊 Statistiche")]
            [Description("Parole totali nel documento")]
            public int TotalWords { get; set; }

            [Category("📊 Statistiche")]
            [Description("Caratteri totali nel documento")]
            public int TotalCharacters { get; set; }

            [Category("📊 Statistiche")]
            [Description("Media parole per pagina")]
            public double AverageWordsPerPage { get; set; }

            [Category("⏱️ Tempi")]
            [Description("Data/ora di caricamento")]
            public DateTime LoadTime { get; set; }

            [Category("⏱️ Tempi")]
            [Description("Durata caricamento")]
            public TimeSpan LoadDuration { get; set; }
        }

        // Metodi per gli altri eventi click (implementazione di base)
        private void ExportResults_Click(object sender, EventArgs e) { }
        private void CopyResults_Click(object sender, EventArgs e) { }
        private void ClearAll_Click(object sender, EventArgs e) { }
        private void QueryOptions_Click(object sender, EventArgs e) { }
        private void ToggleGrid_Click(object sender, EventArgs e) { }
        private void ToggleStats_Click(object sender, EventArgs e) { }
        private void ToggleTheme_Click(object sender, EventArgs e) { }
        private void AdvancedAnalysis_Click(object sender, EventArgs e) { }
        private void ExtractTables_Click(object sender, EventArgs e) { }
        private void ExtractImages_Click(object sender, EventArgs e) { }
        private void QuickGuide_Click(object sender, EventArgs e) { }
        private void Tutorial_Click(object sender, EventArgs e) { }
        private void About_Click(object sender, EventArgs e) { }
        private void ShowPdfInfo_Click(object sender, EventArgs e) { }
    }
}