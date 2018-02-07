namespace Getränkeabrechnung.Ansicht
{
    partial class Benutzerfenster
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
            this.BetragBox2 = new System.Windows.Forms.TextBox();
            this.KontoAuswahl2 = new System.Windows.Forms.ComboBox();
            this.KautionKnopf = new System.Windows.Forms.Button();
            this.GuthabenLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.Zahlungsliste = new BrightIdeasSoftware.ObjectListView();
            this.DatumSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BetragSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NeuesGuthaben = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BeschreibungSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.KontoSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.StornoSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.stornoKnopfRenderer = new Getränkeabrechnung.Ansicht.StornoKnopfRenderer();
            this.ErstellungSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.KontoAuswahl = new System.Windows.Forms.ComboBox();
            this.HinzufügenKnopf = new System.Windows.Forms.Button();
            this.BeschreibungBox = new System.Windows.Forms.TextBox();
            this.BetragBox = new System.Windows.Forms.TextBox();
            this.DatumBox = new System.Windows.Forms.DateTimePicker();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            groupBox1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Zahlungsliste)).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            tableLayoutPanel1.SetColumnSpan(groupBox1, 2);
            groupBox1.Controls.Add(tableLayoutPanel3);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(3, 414);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(678, 44);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kaution";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(this.BetragBox2, 3, 0);
            tableLayoutPanel3.Controls.Add(this.KontoAuswahl2, 1, 0);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(label2, 2, 0);
            tableLayoutPanel3.Controls.Add(this.KautionKnopf, 4, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new System.Drawing.Size(672, 25);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // BetragBox2
            // 
            this.BetragBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BetragBox2.Location = new System.Drawing.Point(253, 3);
            this.BetragBox2.Name = "BetragBox2";
            this.BetragBox2.Size = new System.Drawing.Size(94, 20);
            this.BetragBox2.TabIndex = 7;
            this.BetragBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // KontoAuswahl2
            // 
            this.KontoAuswahl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KontoAuswahl2.FormattingEnabled = true;
            this.KontoAuswahl2.Location = new System.Drawing.Point(63, 3);
            this.KontoAuswahl2.Name = "KontoAuswahl2";
            this.KontoAuswahl2.Size = new System.Drawing.Size(94, 21);
            this.KontoAuswahl2.TabIndex = 6;
            // 
            // label1
            // 
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 25);
            label1.TabIndex = 0;
            label1.Text = "Nach:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(163, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(84, 25);
            label2.TabIndex = 6;
            label2.Text = "Neue Kaution:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // KautionKnopf
            // 
            this.KautionKnopf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KautionKnopf.Location = new System.Drawing.Point(353, 0);
            this.KautionKnopf.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.KautionKnopf.Name = "KautionKnopf";
            this.KautionKnopf.Size = new System.Drawing.Size(94, 25);
            this.KautionKnopf.TabIndex = 8;
            this.KautionKnopf.Text = "Kaution Setzen";
            this.KautionKnopf.UseVisualStyleBackColor = true;
            this.KautionKnopf.Click += new System.EventHandler(this.KautionKnopf_Click);
            this.KautionKnopf.Leave += new System.EventHandler(this.KautionKnopf_Leave);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(this.GuthabenLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(this.NameLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(this.Zahlungsliste, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(684, 461);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // GuthabenLabel
            // 
            this.GuthabenLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GuthabenLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.GuthabenLabel.Location = new System.Drawing.Point(345, 0);
            this.GuthabenLabel.Name = "GuthabenLabel";
            this.GuthabenLabel.Size = new System.Drawing.Size(336, 60);
            this.GuthabenLabel.TabIndex = 2;
            this.GuthabenLabel.Text = "Guthaben";
            this.GuthabenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(336, 60);
            this.NameLabel.TabIndex = 100;
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Zahlungsliste
            // 
            this.Zahlungsliste.AllColumns.Add(this.DatumSpalte);
            this.Zahlungsliste.AllColumns.Add(this.BetragSpalte);
            this.Zahlungsliste.AllColumns.Add(this.NeuesGuthaben);
            this.Zahlungsliste.AllColumns.Add(this.BeschreibungSpalte);
            this.Zahlungsliste.AllColumns.Add(this.KontoSpalte);
            this.Zahlungsliste.AllColumns.Add(this.StornoSpalte);
            this.Zahlungsliste.AllColumns.Add(this.ErstellungSpalte);
            this.Zahlungsliste.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.Zahlungsliste.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.Zahlungsliste.CellEditUseWholeCell = false;
            this.Zahlungsliste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DatumSpalte,
            this.BetragSpalte,
            this.NeuesGuthaben,
            this.BeschreibungSpalte,
            this.KontoSpalte,
            this.StornoSpalte});
            tableLayoutPanel1.SetColumnSpan(this.Zahlungsliste, 2);
            this.Zahlungsliste.Cursor = System.Windows.Forms.Cursors.Default;
            this.Zahlungsliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Zahlungsliste.FullRowSelect = true;
            this.Zahlungsliste.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Zahlungsliste.Location = new System.Drawing.Point(3, 63);
            this.Zahlungsliste.MultiSelect = false;
            this.Zahlungsliste.Name = "Zahlungsliste";
            this.Zahlungsliste.RowHeight = 20;
            this.Zahlungsliste.SelectColumnsOnRightClick = false;
            this.Zahlungsliste.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.Zahlungsliste.ShowGroups = false;
            this.Zahlungsliste.Size = new System.Drawing.Size(678, 319);
            this.Zahlungsliste.TabIndex = 3;
            this.Zahlungsliste.UseAlternatingBackColors = true;
            this.Zahlungsliste.UseCompatibleStateImageBehavior = false;
            this.Zahlungsliste.View = System.Windows.Forms.View.Details;
            this.Zahlungsliste.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.Zahlungsliste_ButtonClick);
            this.Zahlungsliste.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.Zahlungsliste_CellEditFinished);
            // 
            // DatumSpalte
            // 
            this.DatumSpalte.AspectName = "Buchungszeitpunkt";
            this.DatumSpalte.AspectToStringFormat = "{0:d}";
            this.DatumSpalte.IsEditable = false;
            this.DatumSpalte.Text = "Datum";
            this.DatumSpalte.Width = 80;
            // 
            // BetragSpalte
            // 
            this.BetragSpalte.AspectName = "Betrag";
            this.BetragSpalte.AspectToStringFormat = "{0:C}";
            this.BetragSpalte.IsEditable = false;
            this.BetragSpalte.Text = "Betrag";
            this.BetragSpalte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BetragSpalte.Width = 100;
            // 
            // NeuesGuthaben
            // 
            this.NeuesGuthaben.AspectName = "NeuesGuthaben";
            this.NeuesGuthaben.AspectToStringFormat = "{0:C}";
            this.NeuesGuthaben.IsEditable = false;
            this.NeuesGuthaben.Text = "Neues Guthaben";
            this.NeuesGuthaben.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NeuesGuthaben.Width = 100;
            // 
            // BeschreibungSpalte
            // 
            this.BeschreibungSpalte.AspectName = "Beschreibung";
            this.BeschreibungSpalte.CellEditUseWholeCell = true;
            this.BeschreibungSpalte.FillsFreeSpace = true;
            this.BeschreibungSpalte.Text = "Beschreibung";
            // 
            // KontoSpalte
            // 
            this.KontoSpalte.AspectName = "Überweisung";
            this.KontoSpalte.IsEditable = false;
            this.KontoSpalte.Text = "Konto";
            this.KontoSpalte.Width = 100;
            // 
            // StornoSpalte
            // 
            this.StornoSpalte.AspectName = "Löschbar";
            this.StornoSpalte.IsButton = true;
            this.StornoSpalte.IsEditable = false;
            this.StornoSpalte.Renderer = this.stornoKnopfRenderer;
            this.StornoSpalte.Text = "";
            this.StornoSpalte.Width = 65;
            // 
            // stornoKnopfRenderer
            // 
            this.stornoKnopfRenderer.ButtonPadding = null;
            // 
            // ErstellungSpalte
            // 
            this.ErstellungSpalte.AspectName = "Erstellungszeitpunkt";
            this.ErstellungSpalte.AspectToStringFormat = "{0:d}";
            this.ErstellungSpalte.IsEditable = false;
            this.ErstellungSpalte.IsVisible = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 7;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(this.KontoAuswahl, 4, 0);
            tableLayoutPanel2.Controls.Add(this.HinzufügenKnopf, 5, 0);
            tableLayoutPanel2.Controls.Add(this.BeschreibungBox, 3, 0);
            tableLayoutPanel2.Controls.Add(this.BetragBox, 1, 0);
            tableLayoutPanel2.Controls.Add(this.DatumBox, 0, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 385);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(684, 26);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // KontoAuswahl
            // 
            this.KontoAuswahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KontoAuswahl.FormattingEnabled = true;
            this.KontoAuswahl.Location = new System.Drawing.Point(502, 3);
            this.KontoAuswahl.Name = "KontoAuswahl";
            this.KontoAuswahl.Size = new System.Drawing.Size(94, 21);
            this.KontoAuswahl.TabIndex = 4;
            // 
            // HinzufügenKnopf
            // 
            this.HinzufügenKnopf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HinzufügenKnopf.Location = new System.Drawing.Point(602, 0);
            this.HinzufügenKnopf.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.HinzufügenKnopf.Name = "HinzufügenKnopf";
            this.HinzufügenKnopf.Size = new System.Drawing.Size(59, 26);
            this.HinzufügenKnopf.TabIndex = 5;
            this.HinzufügenKnopf.Text = "+";
            this.HinzufügenKnopf.UseVisualStyleBackColor = true;
            this.HinzufügenKnopf.Click += new System.EventHandler(this.HinzufügenKnopf_Click);
            // 
            // BeschreibungBox
            // 
            this.BeschreibungBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeschreibungBox.Location = new System.Drawing.Point(283, 3);
            this.BeschreibungBox.Name = "BeschreibungBox";
            this.BeschreibungBox.Size = new System.Drawing.Size(213, 20);
            this.BeschreibungBox.TabIndex = 3;
            // 
            // BetragBox
            // 
            this.BetragBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BetragBox.Location = new System.Drawing.Point(83, 3);
            this.BetragBox.Name = "BetragBox";
            this.BetragBox.Size = new System.Drawing.Size(94, 20);
            this.BetragBox.TabIndex = 2;
            this.BetragBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BetragBox.Leave += new System.EventHandler(this.BetragBox_Leave);
            // 
            // DatumBox
            // 
            this.DatumBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatumBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatumBox.Location = new System.Drawing.Point(3, 3);
            this.DatumBox.Name = "DatumBox";
            this.DatumBox.Size = new System.Drawing.Size(74, 20);
            this.DatumBox.TabIndex = 1;
            // 
            // Benutzerfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Benutzerfenster";
            this.Text = "Benutzerfenster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Benutzerfenster_FormClosing);
            this.Load += new System.EventHandler(this.Benutzerfenster_Load);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Zahlungsliste)).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label GuthabenLabel;
        private BrightIdeasSoftware.ObjectListView Zahlungsliste;
        private BrightIdeasSoftware.OLVColumn DatumSpalte;
        private BrightIdeasSoftware.OLVColumn BetragSpalte;
        private BrightIdeasSoftware.OLVColumn NeuesGuthaben;
        private BrightIdeasSoftware.OLVColumn BeschreibungSpalte;
        private BrightIdeasSoftware.OLVColumn KontoSpalte;
        private BrightIdeasSoftware.OLVColumn StornoSpalte;
        private StornoKnopfRenderer stornoKnopfRenderer;
        private BrightIdeasSoftware.OLVColumn ErstellungSpalte;
        private System.Windows.Forms.TextBox BetragBox;
        private System.Windows.Forms.TextBox BeschreibungBox;
        private System.Windows.Forms.Button HinzufügenKnopf;
        private System.Windows.Forms.ComboBox KontoAuswahl;
        private System.Windows.Forms.DateTimePicker DatumBox;
        private System.Windows.Forms.ComboBox KontoAuswahl2;
        private System.Windows.Forms.TextBox BetragBox2;
        private System.Windows.Forms.Button KautionKnopf;
    }
}
