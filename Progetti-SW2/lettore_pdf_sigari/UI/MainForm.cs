using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SigariListaPreziApp.Models;
using SigariListaPreziApp.Services;

namespace SigariListaPreziApp.UI
{
    public partial class MainForm : Form
    {
        private List<Sigaro> _sigariOriginali;
        private List<Sigaro> _sigariFiltrati;
        private SigariPdfParser _parser;

        public MainForm()
        {
            InitializeComponent();
            _parser = new SigariPdfParser();
            _sigariOriginali = new List<Sigaro>();
            _sigariFiltrati = new List<Sigaro>();
            
            // Imposta l'indice iniziale del ComboBox
            cmbOrdinamento.SelectedIndex = 0;
        }

        #region Event Handlers

        private void BtnCaricaPdf_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files (*.pdf)|*.pdf";
                ofd.Title = "Seleziona il file PDF della lista prezzi";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Mostra stato di caricamento
                        lblStatus.Text = "⏳ Caricamento in corso...";
                        lblStatus.ForeColor = _accentOrange;
                        this.Cursor = Cursors.WaitCursor;
                        Application.DoEvents();

                        // Parsing del PDF
                        _sigariOriginali = _parser.ParsePdf(ofd.FileName);
                        _sigariFiltrati = new List<Sigaro>(_sigariOriginali);

                        // Carica i dati nella griglia
                        CaricaDataGrid();

                        // Aggiorna l'interfaccia
                        lblStatus.Text = "✓ PDF caricato con successo!";
                        lblStatus.ForeColor = _accentGreen;
                        lblTotale.Text = $"📦 Totale articoli: {_sigariOriginali.Count}";
                        
                        this.Cursor = Cursors.Default;

                        MessageBox.Show(
                            $"Caricati {_sigariOriginali.Count} articoli con successo!",
                            "Successo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        lblStatus.Text = "❌ Errore nel caricamento";
                        lblStatus.ForeColor = _accentRed;
                        
                        MessageBox.Show(
                            $"Errore durante il caricamento del PDF:\n\n{ex.Message}",
                            "Errore",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_sigariOriginali.Count == 0)
                return;

            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Ripristina la lista completa
                _sigariFiltrati = new List<Sigaro>(_sigariOriginali);
            }
            else
            {
                // Filtra per nome o codice
                _sigariFiltrati = _sigariOriginali.Where(s =>
                    s.Nome.ToLower().Contains(searchTerm) ||
                    s.Codice.ToString().Contains(searchTerm) ||
                    s.Confezione.ToLower().Contains(searchTerm)
                ).ToList();
            }

            CaricaDataGrid();
            
            // Aggiorna il contatore
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                lblTotale.Text = $"📦 Totale articoli: {_sigariOriginali.Count}";
            }
            else
            {
                lblTotale.Text = $"📦 Articoli trovati: {_sigariFiltrati.Count} / {_sigariOriginali.Count}";
            }
        }

        private void BtnOrdina_Click(object sender, EventArgs e)
        {
            if (_sigariFiltrati.Count == 0)
            {
                MessageBox.Show(
                    "Nessun dato da ordinare!\n\nCarica prima un file PDF.",
                    "Attenzione",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            bool crescente = chkCrescente.Checked;
            string criterio = "";

            switch (cmbOrdinamento.SelectedIndex)
            {
                case 0: // Numero Pezzi
                    _sigariFiltrati = crescente
                        ? _sigariFiltrati.OrderBy(s => s.Pezzi).ToList()
                        : _sigariFiltrati.OrderByDescending(s => s.Pezzi).ToList();
                    criterio = "Numero Pezzi";
                    break;

                case 1: // Prezzo al Kg
                    _sigariFiltrati = crescente
                        ? _sigariFiltrati.OrderBy(s => s.PrezzoKgConvenzionale).ToList()
                        : _sigariFiltrati.OrderByDescending(s => s.PrezzoKgConvenzionale).ToList();
                    criterio = "Prezzo al Kg";
                    break;

                case 2: // Prezzo Confezione
                    _sigariFiltrati = crescente
                        ? _sigariFiltrati.OrderBy(s => s.PrezzoConfezione).ToList()
                        : _sigariFiltrati.OrderByDescending(s => s.PrezzoConfezione).ToList();
                    criterio = "Prezzo Confezione";
                    break;

                default:
                    return;
            }

            CaricaDataGrid();
            
            string ordine = crescente ? "crescente" : "decrescente";
            lblStatus.Text = $"✓ Ordinato per {criterio} ({ordine})";
            lblStatus.ForeColor = _accentGreen;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Reset filtri e ricerca
            txtSearch.Clear();
            cmbOrdinamento.SelectedIndex = 0;
            chkCrescente.Checked = true;
            
            // Ripristina lista originale
            _sigariFiltrati = new List<Sigaro>(_sigariOriginali);
            
            CaricaDataGrid();
            
            lblTotale.Text = $"📦 Totale articoli: {_sigariOriginali.Count}";
            lblStatus.Text = "↻ Reset completato";
            lblStatus.ForeColor = _accentOrange;
        }

        private void BtnEsporta_Click(object sender, EventArgs e)
        {
            if (_sigariFiltrati.Count == 0)
            {
                MessageBox.Show(
                    "Nessun dato da esportare!\n\nCarica prima un file PDF.",
                    "Attenzione",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "File CSV (*.csv)|*.csv|File di testo (*.txt)|*.txt";
                sfd.Title = "Esporta dati in CSV";
                sfd.FileName = $"Sigari_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        lblStatus.Text = "⏳ Esportazione in corso...";
                        lblStatus.ForeColor = _accentOrange;
                        this.Cursor = Cursors.WaitCursor;
                        Application.DoEvents();

                        using (var writer = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            // Intestazione
                            writer.WriteLine("Codice;Nome;Confezione;Pezzi;€/Kg Conv.;€/Conf.");

                            // Dati
                            foreach (var sigaro in _sigariFiltrati)
                            {
                                writer.WriteLine($"{sigaro.Codice};{sigaro.Nome};{sigaro.Confezione};" +
                                    $"{sigaro.Pezzi};{sigaro.PrezzoKgConvenzionale:F2};{sigaro.PrezzoConfezione:F2}");
                            }
                        }

                        this.Cursor = Cursors.Default;
                        lblStatus.Text = "💾 Esportazione completata!";
                        lblStatus.ForeColor = _accentPurple;

                        var result = MessageBox.Show(
                            $"File esportato con successo!\n\nPercorso: {sfd.FileName}\n\nVuoi aprire la cartella?",
                            "Esportazione completata",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information
                        );

                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{sfd.FileName}\"");
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        lblStatus.Text = "❌ Errore nell'esportazione";
                        lblStatus.ForeColor = _accentRed;

                        MessageBox.Show(
                            $"Errore durante l'esportazione:\n\n{ex.Message}",
                            "Errore",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private void CaricaDataGrid()
        {
            // Salva la posizione di scroll corrente
            int scrollPosition = dgvSigari.FirstDisplayedScrollingRowIndex;

            // Ricarica i dati
            dgvSigari.DataSource = null;
            dgvSigari.DataSource = _sigariFiltrati;

            if (dgvSigari.Columns.Count > 0)
            {
                ConfiguraColonne();
            }

            // Ripristina la posizione di scroll
            if (scrollPosition >= 0 && scrollPosition < dgvSigari.RowCount)
            {
                dgvSigari.FirstDisplayedScrollingRowIndex = scrollPosition;
            }
        }

        private void ConfiguraColonne()
        {
            // Colonna Codice
            dgvSigari.Columns["Codice"].HeaderText = "CODICE";
            dgvSigari.Columns["Codice"].Width = 100;
            dgvSigari.Columns["Codice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSigari.Columns["Codice"].DefaultCellStyle.Font = new Font("Consolas", 9F, FontStyle.Bold);

            // Colonna Nome
            dgvSigari.Columns["Nome"].HeaderText = "NOME SIGARO";
            dgvSigari.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSigari.Columns["Nome"].MinimumWidth = 300;

            // Colonna Confezione
            dgvSigari.Columns["Confezione"].HeaderText = "CONFEZIONE";
            dgvSigari.Columns["Confezione"].Width = 130;
            dgvSigari.Columns["Confezione"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Colonna Pezzi
            dgvSigari.Columns["Pezzi"].HeaderText = "PEZZI";
            dgvSigari.Columns["Pezzi"].Width = 80;
            dgvSigari.Columns["Pezzi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSigari.Columns["Pezzi"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvSigari.Columns["Pezzi"].DefaultCellStyle.ForeColor = _accentBlue;

            // Colonna Prezzo Kg Convenzionale
            dgvSigari.Columns["PrezzoKgConvenzionale"].HeaderText = "€/KG CONV.";
            dgvSigari.Columns["PrezzoKgConvenzionale"].Width = 120;
            dgvSigari.Columns["PrezzoKgConvenzionale"].DefaultCellStyle.Format = "N2";
            dgvSigari.Columns["PrezzoKgConvenzionale"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSigari.Columns["PrezzoKgConvenzionale"].DefaultCellStyle.ForeColor = _accentGreen;

            // Colonna Prezzo Confezione
            dgvSigari.Columns["PrezzoConfezione"].HeaderText = "€/CONF.";
            dgvSigari.Columns["PrezzoConfezione"].Width = 120;
            dgvSigari.Columns["PrezzoConfezione"].DefaultCellStyle.Format = "N2";
            dgvSigari.Columns["PrezzoConfezione"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSigari.Columns["PrezzoConfezione"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvSigari.Columns["PrezzoConfezione"].DefaultCellStyle.ForeColor = _accentOrange;
        }

        #endregion
    }
}