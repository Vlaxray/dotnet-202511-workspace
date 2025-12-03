using System.Drawing;
using System.Windows.Forms;

namespace SigariListaPreziApp.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            
            // Colors
            this._darkBackground = Color.FromArgb(32, 32, 32);
            this._panelBackground = Color.FromArgb(45, 45, 48);
            this._textColor = Color.FromArgb(240, 240, 240);
            this._accentBlue = Color.FromArgb(52, 152, 219);
            this._accentGreen = Color.FromArgb(46, 204, 113);
            this._accentOrange = Color.FromArgb(230, 126, 34);
            this._accentRed = Color.FromArgb(231, 76, 60);
            this._accentPurple = Color.FromArgb(155, 89, 182);

            // Initialize components
            this.topPanel = new Panel();
            this.titleLabel = new Label();
            this.btnCaricaPdf = new ModernButton();
            this.centerPanel = new Panel();
            this.searchPanel = new Panel();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.lblOrdina = new Label();
            this.cmbOrdinamento = new ComboBox();
            this.chkCrescente = new CheckBox();
            this.btnOrdina = new ModernButton();
            this.btnReset = new ModernButton();
            this.btnEsporta = new ModernButton();
            this.gridContainer = new Panel();
            this.dgvSigari = new DataGridView();
            this.bottomPanel = new Panel();
            this.lblTotale = new Label();
            this.lblStatus = new Label();

            this.topPanel.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.gridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigari)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // topPanel
            // 
            this.topPanel.BackColor = this._panelBackground;
            this.topPanel.Controls.Add(this.btnCaricaPdf);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Location = new Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new Padding(20, 10, 20, 10);
            this.topPanel.Size = new Size(1400, 80);
            this.topPanel.TabIndex = 0;

            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            this.titleLabel.ForeColor = this._accentBlue;
            this.titleLabel.Location = new Point(20, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new Size(450, 45);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "🚬 LISTA PREZZI SIGARI";

            // 
            // btnCaricaPdf
            // 
            this.btnCaricaPdf.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnCaricaPdf.BorderRadius = 10;
            this.btnCaricaPdf.Cursor = Cursors.Hand;
            this.btnCaricaPdf.FlatAppearance.BorderSize = 0;
            this.btnCaricaPdf.FlatStyle = FlatStyle.Flat;
            this.btnCaricaPdf.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCaricaPdf.ForeColor = Color.White;
            this.btnCaricaPdf.HoverColor = Color.FromArgb(39, 174, 96);
            this.btnCaricaPdf.Location = new Point(1180, 15);
            this.btnCaricaPdf.Name = "btnCaricaPdf";
            this.btnCaricaPdf.NormalColor = this._accentGreen;
            this.btnCaricaPdf.PressedColor = Color.FromArgb(30, 140, 70);
            this.btnCaricaPdf.Size = new Size(180, 50);
            this.btnCaricaPdf.TabIndex = 1;
            this.btnCaricaPdf.Text = "📂 CARICA PDF";
            this.btnCaricaPdf.UseVisualStyleBackColor = false;
            this.btnCaricaPdf.Click += new System.EventHandler(this.BtnCaricaPdf_Click);

            // 
            // centerPanel
            // 
            this.centerPanel.BackColor = this._darkBackground;
            this.centerPanel.Controls.Add(this.gridContainer);
            this.centerPanel.Controls.Add(this.searchPanel);
            this.centerPanel.Dock = DockStyle.Fill;
            this.centerPanel.Location = new Point(0, 80);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Padding = new Padding(20);
            this.centerPanel.Size = new Size(1400, 760);
            this.centerPanel.TabIndex = 1;

            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = this._panelBackground;
            this.searchPanel.Controls.Add(this.btnEsporta);
            this.searchPanel.Controls.Add(this.btnReset);
            this.searchPanel.Controls.Add(this.btnOrdina);
            this.searchPanel.Controls.Add(this.chkCrescente);
            this.searchPanel.Controls.Add(this.cmbOrdinamento);
            this.searchPanel.Controls.Add(this.lblOrdina);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.lblSearch);
            this.searchPanel.Dock = DockStyle.Top;
            this.searchPanel.Location = new Point(20, 20);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new Padding(15);
            this.searchPanel.Size = new Size(1360, 80);
            this.searchPanel.TabIndex = 0;

            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblSearch.ForeColor = this._textColor;
            this.lblSearch.Location = new Point(15, 25);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new Size(75, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "🔍 Cerca:";

            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = this._darkBackground;
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSearch.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtSearch.ForeColor = this._textColor;
            this.txtSearch.Location = new Point(100, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new Size(300, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // 
            // lblOrdina
            // 
            this.lblOrdina.AutoSize = true;
            this.lblOrdina.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblOrdina.ForeColor = this._textColor;
            this.lblOrdina.Location = new Point(420, 25);
            this.lblOrdina.Name = "lblOrdina";
            this.lblOrdina.Size = new Size(105, 19);
            this.lblOrdina.TabIndex = 2;
            this.lblOrdina.Text = "📊 Ordina per:";

            // 
            // cmbOrdinamento
            // 
            this.cmbOrdinamento.BackColor = this._darkBackground;
            this.cmbOrdinamento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOrdinamento.FlatStyle = FlatStyle.Flat;
            this.cmbOrdinamento.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cmbOrdinamento.ForeColor = this._textColor;
            this.cmbOrdinamento.FormattingEnabled = true;
            this.cmbOrdinamento.Items.AddRange(new object[] {
                "Numero Pezzi",
                "Prezzo al Kg",
                "Prezzo Confezione"
            });
            this.cmbOrdinamento.Location = new Point(530, 22);
            this.cmbOrdinamento.Name = "cmbOrdinamento";
            this.cmbOrdinamento.Size = new Size(200, 25);
            this.cmbOrdinamento.TabIndex = 3;

            // 
            // chkCrescente
            // 
            this.chkCrescente.AutoSize = true;
            this.chkCrescente.FlatStyle = FlatStyle.Flat;
            this.chkCrescente.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.chkCrescente.ForeColor = this._textColor;
            this.chkCrescente.Location = new Point(750, 24);
            this.chkCrescente.Name = "chkCrescente";
            this.chkCrescente.Size = new Size(105, 23);
            this.chkCrescente.TabIndex = 4;
            this.chkCrescente.Text = "↑ Crescente";
            this.chkCrescente.UseVisualStyleBackColor = true;
            this.chkCrescente.Checked = true;

            // 
            // btnOrdina
            // 
            this.btnOrdina.BorderRadius = 10;
            this.btnOrdina.Cursor = Cursors.Hand;
            this.btnOrdina.FlatAppearance.BorderSize = 0;
            this.btnOrdina.FlatStyle = FlatStyle.Flat;
            this.btnOrdina.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnOrdina.ForeColor = Color.White;
            this.btnOrdina.HoverColor = Color.FromArgb(41, 128, 185);
            this.btnOrdina.Location = new Point(870, 17);
            this.btnOrdina.Name = "btnOrdina";
            this.btnOrdina.NormalColor = this._accentBlue;
            this.btnOrdina.PressedColor = Color.FromArgb(30, 100, 150);
            this.btnOrdina.Size = new Size(120, 45);
            this.btnOrdina.TabIndex = 5;
            this.btnOrdina.Text = "✓ ORDINA";
            this.btnOrdina.UseVisualStyleBackColor = false;
            this.btnOrdina.Click += new System.EventHandler(this.BtnOrdina_Click);

            // 
            // btnReset
            // 
            this.btnReset.BorderRadius = 10;
            this.btnReset.Cursor = Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = FlatStyle.Flat;
            this.btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnReset.ForeColor = Color.White;
            this.btnReset.HoverColor = Color.FromArgb(211, 84, 0);
            this.btnReset.Location = new Point(1000, 17);
            this.btnReset.Name = "btnReset";
            this.btnReset.NormalColor = this._accentOrange;
            this.btnReset.PressedColor = Color.FromArgb(180, 70, 0);
            this.btnReset.Size = new Size(120, 45);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "↻ RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);

            // 
            // btnEsporta
            // 
            this.btnEsporta.BorderRadius = 10;
            this.btnEsporta.Cursor = Cursors.Hand;
            this.btnEsporta.FlatAppearance.BorderSize = 0;
            this.btnEsporta.FlatStyle = FlatStyle.Flat;
            this.btnEsporta.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnEsporta.ForeColor = Color.White;
            this.btnEsporta.HoverColor = Color.FromArgb(142, 68, 173);
            this.btnEsporta.Location = new Point(1130, 17);
            this.btnEsporta.Name = "btnEsporta";
            this.btnEsporta.NormalColor = this._accentPurple;
            this.btnEsporta.PressedColor = Color.FromArgb(120, 50, 150);
            this.btnEsporta.Size = new Size(120, 45);
            this.btnEsporta.TabIndex = 7;
            this.btnEsporta.Text = "💾 ESPORTA";
            this.btnEsporta.UseVisualStyleBackColor = false;
            this.btnEsporta.Click += new System.EventHandler(this.BtnEsporta_Click);

            // 
            // gridContainer
            // 
            this.gridContainer.Controls.Add(this.dgvSigari);
            this.gridContainer.Dock = DockStyle.Fill;
            this.gridContainer.Location = new Point(20, 100);
            this.gridContainer.Name = "gridContainer";
            this.gridContainer.Padding = new Padding(0, 10, 0, 0);
            this.gridContainer.Size = new Size(1360, 640);
            this.gridContainer.TabIndex = 1;

            // 
            // dgvSigari
            // 
            this.dgvSigari.AllowUserToAddRows = false;
            this.dgvSigari.AllowUserToDeleteRows = false;
            this.dgvSigari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSigari.BackgroundColor = this._darkBackground;
            this.dgvSigari.BorderStyle = BorderStyle.None;
            this.dgvSigari.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvSigari.ColumnHeadersHeight = 40;
            this.dgvSigari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            
            // Column Headers Style
            this.dgvSigari.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSigari.ColumnHeadersDefaultCellStyle.BackColor = this._panelBackground;
            this.dgvSigari.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.dgvSigari.ColumnHeadersDefaultCellStyle.ForeColor = this._accentBlue;
            this.dgvSigari.ColumnHeadersDefaultCellStyle.SelectionBackColor = this._panelBackground;
            this.dgvSigari.ColumnHeadersDefaultCellStyle.SelectionForeColor = this._accentBlue;
            this.dgvSigari.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            
            // Default Cell Style
            this.dgvSigari.DefaultCellStyle.BackColor = this._darkBackground;
            this.dgvSigari.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.dgvSigari.DefaultCellStyle.ForeColor = this._textColor;
            this.dgvSigari.DefaultCellStyle.SelectionBackColor = this._accentBlue;
            this.dgvSigari.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvSigari.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            
            // Alternating Rows Style
            this.dgvSigari.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            this.dgvSigari.AlternatingRowsDefaultCellStyle.ForeColor = this._textColor;
            this.dgvSigari.AlternatingRowsDefaultCellStyle.SelectionBackColor = this._accentBlue;
            this.dgvSigari.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            
            this.dgvSigari.Dock = DockStyle.Fill;
            this.dgvSigari.EnableHeadersVisualStyles = false;
            this.dgvSigari.GridColor = Color.FromArgb(60, 60, 60);
            this.dgvSigari.Location = new Point(0, 10);
            this.dgvSigari.MultiSelect = false;
            this.dgvSigari.Name = "dgvSigari";
            this.dgvSigari.ReadOnly = true;
            this.dgvSigari.RowHeadersVisible = false;
            this.dgvSigari.RowHeadersWidth = 51;
            this.dgvSigari.RowTemplate.Height = 30;
            this.dgvSigari.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSigari.Size = new Size(1360, 630);
            this.dgvSigari.TabIndex = 0;

            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = this._panelBackground;
            this.bottomPanel.Controls.Add(this.lblStatus);
            this.bottomPanel.Controls.Add(this.lblTotale);
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.Location = new Point(0, 840);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new Padding(20, 10, 20, 10);
            this.bottomPanel.Size = new Size(1400, 60);
            this.bottomPanel.TabIndex = 2;

            // 
            // lblTotale
            // 
            this.lblTotale.AutoSize = true;
            this.lblTotale.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTotale.ForeColor = this._accentGreen;
            this.lblTotale.Location = new Point(20, 18);
            this.lblTotale.Name = "lblTotale";
            this.lblTotale.Size = new Size(165, 20);
            this.lblTotale.TabIndex = 0;
            this.lblTotale.Text = "📦 Totale articoli: 0";

            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblStatus.ForeColor = this._textColor;
            this.lblStatus.Location = new Point(1290, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(75, 19);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "⚡ Pronto";
            this.lblStatus.TextAlign = ContentAlignment.MiddleRight;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = this._darkBackground;
            this.ClientSize = new Size(1400, 900);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.MinimumSize = new Size(1200, 700);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Lista Prezzi Sigari - Manager";
            
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.centerPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.gridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigari)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Label titleLabel;
        private ModernButton btnCaricaPdf;
        private Panel centerPanel;
        private Panel searchPanel;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblOrdina;
        private ComboBox cmbOrdinamento;
        private CheckBox chkCrescente;
        private ModernButton btnOrdina;
        private ModernButton btnReset;
        private ModernButton btnEsporta;
        private Panel gridContainer;
        private DataGridView dgvSigari;
        private Panel bottomPanel;
        private Label lblTotale;
        private Label lblStatus;
        
        // Colors
        private Color _darkBackground;
        private Color _panelBackground;
        private Color _textColor;
        private Color _accentBlue;
        private Color _accentGreen;
        private Color _accentOrange;
        private Color _accentRed;
        private Color _accentPurple;
    }
}