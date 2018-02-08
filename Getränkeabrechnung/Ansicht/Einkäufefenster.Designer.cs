namespace Getränkeabrechnung.Ansicht
{
    partial class Einkäufefenster
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            Getränkeabrechnung.Ansicht.StornoKnopfRenderer stornoKnopfRenderer1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
            this.Einkäufeliste = new BrightIdeasSoftware.ObjectListView();
            this.Rechnungsnummerspalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DatumSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BetragSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.KontoSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.AbrechnungSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.EinkaufLöschenSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Positionenliste = new BrightIdeasSoftware.ObjectListView();
            this.ProduktSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.AnzahlSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PositionLöschenSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.RechnungsnummberBox = new System.Windows.Forms.TextBox();
            this.DatumBox = new System.Windows.Forms.DateTimePicker();
            this.NeuerEinkaufKnopf = new System.Windows.Forms.Button();
            this.BetragBox = new Getränkeabrechnung.Ansicht.BetragBox();
            this.KontoBox = new Getränkeabrechnung.Ansicht.KontoBox();
            this.AnzahlBox = new System.Windows.Forms.NumericUpDown();
            this.NeuePositionKnopf = new System.Windows.Forms.Button();
            this.ProduktBox = new Getränkeabrechnung.Ansicht.ProduktBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            stornoKnopfRenderer1 = new Getränkeabrechnung.Ansicht.StornoKnopfRenderer();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Einkäufeliste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Positionenliste)).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnzahlBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(this.Einkäufeliste, 0, 0);
            tableLayoutPanel1.Controls.Add(this.Positionenliste, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(7);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            tableLayoutPanel1.Size = new System.Drawing.Size(784, 461);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Einkäufeliste
            // 
            this.Einkäufeliste.AllColumns.Add(this.Rechnungsnummerspalte);
            this.Einkäufeliste.AllColumns.Add(this.DatumSpalte);
            this.Einkäufeliste.AllColumns.Add(this.BetragSpalte);
            this.Einkäufeliste.AllColumns.Add(this.KontoSpalte);
            this.Einkäufeliste.AllColumns.Add(this.AbrechnungSpalte);
            this.Einkäufeliste.AllColumns.Add(this.EinkaufLöschenSpalte);
            this.Einkäufeliste.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.Einkäufeliste.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.Einkäufeliste.CellEditUseWholeCell = false;
            this.Einkäufeliste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Rechnungsnummerspalte,
            this.DatumSpalte,
            this.BetragSpalte,
            this.KontoSpalte,
            this.AbrechnungSpalte,
            this.EinkaufLöschenSpalte});
            this.Einkäufeliste.Cursor = System.Windows.Forms.Cursors.Default;
            this.Einkäufeliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Einkäufeliste.FullRowSelect = true;
            this.Einkäufeliste.HideSelection = false;
            this.Einkäufeliste.Location = new System.Drawing.Point(10, 10);
            this.Einkäufeliste.Margin = new System.Windows.Forms.Padding(3, 3, 17, 3);
            this.Einkäufeliste.MultiSelect = false;
            this.Einkäufeliste.Name = "Einkäufeliste";
            this.Einkäufeliste.RowHeight = 20;
            this.Einkäufeliste.ShowGroups = false;
            this.Einkäufeliste.Size = new System.Drawing.Size(519, 415);
            this.Einkäufeliste.TabIndex = 0;
            this.Einkäufeliste.UseAlternatingBackColors = true;
            this.Einkäufeliste.UseCompatibleStateImageBehavior = false;
            this.Einkäufeliste.View = System.Windows.Forms.View.Details;
            this.Einkäufeliste.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.Einkäufeliste_ButtonClick);
            this.Einkäufeliste.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.Einkäufeliste_CellEditFinished);
            this.Einkäufeliste.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.Einkäufeliste_CellEditStarting);
            this.Einkäufeliste.SelectionChanged += new System.EventHandler(this.Einkäufeliste_SelectionChanged);
            // 
            // Rechnungsnummerspalte
            // 
            this.Rechnungsnummerspalte.AspectName = "Rechnungsnummer";
            this.Rechnungsnummerspalte.AspectToStringFormat = "{0}";
            this.Rechnungsnummerspalte.CellEditUseWholeCell = true;
            this.Rechnungsnummerspalte.FillsFreeSpace = true;
            this.Rechnungsnummerspalte.Text = "Rechnungsnummer";
            // 
            // DatumSpalte
            // 
            this.DatumSpalte.AspectName = "Zeitpunkt";
            this.DatumSpalte.AspectToStringFormat = "{0:d}";
            this.DatumSpalte.CellEditUseWholeCell = true;
            this.DatumSpalte.Text = "Datum";
            this.DatumSpalte.Width = 80;
            // 
            // BetragSpalte
            // 
            this.BetragSpalte.AspectName = "Betrag";
            this.BetragSpalte.AspectToStringFormat = "{0:C}";
            this.BetragSpalte.CellEditUseWholeCell = true;
            this.BetragSpalte.IsEditable = false;
            this.BetragSpalte.Text = "Betrag";
            this.BetragSpalte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BetragSpalte.Width = 80;
            // 
            // KontoSpalte
            // 
            this.KontoSpalte.AspectName = "Überweisung";
            this.KontoSpalte.Text = "Konto";
            // 
            // AbrechnungSpalte
            // 
            this.AbrechnungSpalte.AspectName = "Abrechnung";
            this.AbrechnungSpalte.IsEditable = false;
            this.AbrechnungSpalte.Text = "Abrechnung";
            this.AbrechnungSpalte.Width = 120;
            // 
            // EinkaufLöschenSpalte
            // 
            this.EinkaufLöschenSpalte.AspectName = "Abrechnung";
            this.EinkaufLöschenSpalte.IsButton = true;
            this.EinkaufLöschenSpalte.Renderer = stornoKnopfRenderer1;
            this.EinkaufLöschenSpalte.Text = "";
            this.EinkaufLöschenSpalte.Width = 65;
            // 
            // stornoKnopfRenderer1
            // 
            stornoKnopfRenderer1.ButtonPadding = new System.Drawing.Size(10, 10);
            // 
            // Positionenliste
            // 
            this.Positionenliste.AllColumns.Add(this.ProduktSpalte);
            this.Positionenliste.AllColumns.Add(this.AnzahlSpalte);
            this.Positionenliste.AllColumns.Add(this.PositionLöschenSpalte);
            this.Positionenliste.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.Positionenliste.CellEditUseWholeCell = false;
            this.Positionenliste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProduktSpalte,
            this.AnzahlSpalte,
            this.PositionLöschenSpalte});
            this.Positionenliste.Cursor = System.Windows.Forms.Cursors.Default;
            this.Positionenliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Positionenliste.FullRowSelect = true;
            this.Positionenliste.Location = new System.Drawing.Point(549, 10);
            this.Positionenliste.Name = "Positionenliste";
            this.Positionenliste.RowHeight = 20;
            this.Positionenliste.ShowGroups = false;
            this.Positionenliste.Size = new System.Drawing.Size(225, 415);
            this.Positionenliste.TabIndex = 1;
            this.Positionenliste.UseCompatibleStateImageBehavior = false;
            this.Positionenliste.View = System.Windows.Forms.View.Details;
            this.Positionenliste.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.Positionenliste_ButtonClick);
            this.Positionenliste.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.Positionenliste_CellEditStarting);
            // 
            // ProduktSpalte
            // 
            this.ProduktSpalte.AspectName = "Produkt";
            this.ProduktSpalte.CellEditUseWholeCell = true;
            this.ProduktSpalte.FillsFreeSpace = true;
            this.ProduktSpalte.Text = "Produkt";
            // 
            // AnzahlSpalte
            // 
            this.AnzahlSpalte.AspectName = "AnzahlKästen";
            this.AnzahlSpalte.AspectToStringFormat = "{0}";
            this.AnzahlSpalte.CellEditUseWholeCell = true;
            this.AnzahlSpalte.Text = "Anzahl";
            this.AnzahlSpalte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PositionLöschenSpalte
            // 
            this.PositionLöschenSpalte.AspectName = "Einkauf";
            this.PositionLöschenSpalte.IsButton = true;
            this.PositionLöschenSpalte.Renderer = stornoKnopfRenderer1;
            this.PositionLöschenSpalte.Text = "";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            tableLayoutPanel2.Controls.Add(this.RechnungsnummberBox, 0, 0);
            tableLayoutPanel2.Controls.Add(this.DatumBox, 1, 0);
            tableLayoutPanel2.Controls.Add(this.NeuerEinkaufKnopf, 4, 0);
            tableLayoutPanel2.Controls.Add(this.BetragBox, 2, 0);
            tableLayoutPanel2.Controls.Add(this.KontoBox, 3, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(7, 428);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 17, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(522, 26);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // RechnungsnummberBox
            // 
            this.RechnungsnummberBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RechnungsnummberBox.Location = new System.Drawing.Point(3, 3);
            this.RechnungsnummberBox.Name = "RechnungsnummberBox";
            this.RechnungsnummberBox.Size = new System.Drawing.Size(191, 20);
            this.RechnungsnummberBox.TabIndex = 0;
            // 
            // DatumBox
            // 
            this.DatumBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DatumBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatumBox.Location = new System.Drawing.Point(200, 3);
            this.DatumBox.Name = "DatumBox";
            this.DatumBox.Size = new System.Drawing.Size(74, 20);
            this.DatumBox.TabIndex = 1;
            // 
            // NeuerEinkaufKnopf
            // 
            this.NeuerEinkaufKnopf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NeuerEinkaufKnopf.Location = new System.Drawing.Point(460, 0);
            this.NeuerEinkaufKnopf.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.NeuerEinkaufKnopf.Name = "NeuerEinkaufKnopf";
            this.NeuerEinkaufKnopf.Size = new System.Drawing.Size(59, 26);
            this.NeuerEinkaufKnopf.TabIndex = 3;
            this.NeuerEinkaufKnopf.Text = "+";
            this.NeuerEinkaufKnopf.UseVisualStyleBackColor = true;
            this.NeuerEinkaufKnopf.Click += new System.EventHandler(this.NeuerEinkaufKnopf_Click);
            // 
            // BetragBox
            // 
            this.BetragBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BetragBox.Location = new System.Drawing.Point(280, 3);
            this.BetragBox.Name = "BetragBox";
            this.BetragBox.Size = new System.Drawing.Size(74, 20);
            this.BetragBox.TabIndex = 4;
            // 
            // KontoBox
            // 
            this.KontoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KontoBox.DisplayMember = "Name";
            this.KontoBox.Filter = null;
            this.KontoBox.FormattingEnabled = true;
            this.KontoBox.Kontosteuerung = null;
            this.KontoBox.Location = new System.Drawing.Point(360, 3);
            this.KontoBox.Name = "KontoBox";
            this.KontoBox.Size = new System.Drawing.Size(94, 21);
            this.KontoBox.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            tableLayoutPanel3.Controls.Add(this.AnzahlBox, 1, 0);
            tableLayoutPanel3.Controls.Add(this.NeuePositionKnopf, 2, 0);
            tableLayoutPanel3.Controls.Add(this.ProduktBox, 0, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(546, 428);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new System.Drawing.Size(231, 26);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // AnzahlBox
            // 
            this.AnzahlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AnzahlBox.Location = new System.Drawing.Point(109, 3);
            this.AnzahlBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AnzahlBox.Name = "AnzahlBox";
            this.AnzahlBox.Size = new System.Drawing.Size(54, 20);
            this.AnzahlBox.TabIndex = 0;
            this.AnzahlBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NeuePositionKnopf
            // 
            this.NeuePositionKnopf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NeuePositionKnopf.Location = new System.Drawing.Point(169, 0);
            this.NeuePositionKnopf.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.NeuePositionKnopf.Name = "NeuePositionKnopf";
            this.NeuePositionKnopf.Size = new System.Drawing.Size(59, 26);
            this.NeuePositionKnopf.TabIndex = 1;
            this.NeuePositionKnopf.Text = "+";
            this.NeuePositionKnopf.UseVisualStyleBackColor = true;
            this.NeuePositionKnopf.Click += new System.EventHandler(this.NeuePositionKnopf_Click);
            // 
            // ProduktBox
            // 
            this.ProduktBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProduktBox.DisplayMember = "Name";
            this.ProduktBox.Filter = null;
            this.ProduktBox.FormattingEnabled = true;
            this.ProduktBox.Location = new System.Drawing.Point(3, 3);
            this.ProduktBox.Name = "ProduktBox";
            this.ProduktBox.Produkt = null;
            this.ProduktBox.Produktsteuerung = null;
            this.ProduktBox.Size = new System.Drawing.Size(100, 21);
            this.ProduktBox.TabIndex = 2;
            // 
            // Einkäufefenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(tableLayoutPanel1);
            this.Name = "Einkäufefenster";
            this.Text = "Einkäufe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Einkäufefenster_FormClosing);
            this.Load += new System.EventHandler(this.Einkäufefenster_Load);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Einkäufeliste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Positionenliste)).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnzahlBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView Einkäufeliste;
        private BrightIdeasSoftware.OLVColumn Rechnungsnummerspalte;
        private BrightIdeasSoftware.ObjectListView Positionenliste;
        private BrightIdeasSoftware.OLVColumn DatumSpalte;
        private BrightIdeasSoftware.OLVColumn BetragSpalte;
        private BrightIdeasSoftware.OLVColumn AbrechnungSpalte;
        private BrightIdeasSoftware.OLVColumn ProduktSpalte;
        private BrightIdeasSoftware.OLVColumn AnzahlSpalte;
        private BrightIdeasSoftware.OLVColumn EinkaufLöschenSpalte;
        private BrightIdeasSoftware.OLVColumn PositionLöschenSpalte;
        private System.Windows.Forms.TextBox RechnungsnummberBox;
        private System.Windows.Forms.DateTimePicker DatumBox;
        private System.Windows.Forms.Button NeuerEinkaufKnopf;
        private BetragBox BetragBox;
        private KontoBox KontoBox;
        private BrightIdeasSoftware.OLVColumn KontoSpalte;
        private System.Windows.Forms.NumericUpDown AnzahlBox;
        private System.Windows.Forms.Button NeuePositionKnopf;
        private ProduktBox ProduktBox;
    }
}
