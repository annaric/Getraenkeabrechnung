namespace Getränkeabrechnung.Ansicht
{
    partial class Kontofenster
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
            this.KontoAuswahl = new System.Windows.Forms.ComboBox();
            this.BetragBox2 = new System.Windows.Forms.TextBox();
            this.UmbuchenKnopf = new System.Windows.Forms.Button();
            this.Überweisungsliste = new BrightIdeasSoftware.ObjectListView();
            this.DatumSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BetragSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NeuerKontostandSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BeschreibungSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.StornoSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.stornoKnopfRenderer1 = new Getränkeabrechnung.Ansicht.StornoKnopfRenderer();
            this.ErstellungSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.KontostandLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.HinzufügenKnopf = new System.Windows.Forms.Button();
            this.BeschreibungBox = new System.Windows.Forms.TextBox();
            this.DatumBox = new System.Windows.Forms.MaskedTextBox();
            this.BetragBox = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            groupBox1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Überweisungsliste)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            tableLayoutPanel1.SetColumnSpan(groupBox1, 2);
            groupBox1.Controls.Add(tableLayoutPanel3);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(3, 485);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(646, 44);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Umbuchen";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(this.KontoAuswahl, 1, 0);
            tableLayoutPanel3.Controls.Add(label2, 2, 0);
            tableLayoutPanel3.Controls.Add(this.BetragBox2, 3, 0);
            tableLayoutPanel3.Controls.Add(this.UmbuchenKnopf, 4, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new System.Drawing.Size(640, 25);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 25);
            label1.TabIndex = 0;
            label1.Text = "Nach:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // KontoAuswahl
            // 
            this.KontoAuswahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KontoAuswahl.FormattingEnabled = true;
            this.KontoAuswahl.Location = new System.Drawing.Point(63, 3);
            this.KontoAuswahl.Name = "KontoAuswahl";
            this.KontoAuswahl.Size = new System.Drawing.Size(134, 21);
            this.KontoAuswahl.TabIndex = 1;
            // 
            // label2
            // 
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(203, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(54, 25);
            label2.TabIndex = 2;
            label2.Text = "Betrag:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BetragBox2
            // 
            this.BetragBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BetragBox2.Location = new System.Drawing.Point(263, 3);
            this.BetragBox2.Name = "BetragBox2";
            this.BetragBox2.Size = new System.Drawing.Size(94, 20);
            this.BetragBox2.TabIndex = 3;
            this.BetragBox2.Leave += new System.EventHandler(this.BetragBox2_Leave);
            // 
            // UmbuchenKnopf
            // 
            this.UmbuchenKnopf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UmbuchenKnopf.Location = new System.Drawing.Point(363, 0);
            this.UmbuchenKnopf.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.UmbuchenKnopf.Name = "UmbuchenKnopf";
            this.UmbuchenKnopf.Size = new System.Drawing.Size(94, 25);
            this.UmbuchenKnopf.TabIndex = 4;
            this.UmbuchenKnopf.Text = "Umbuchen";
            this.UmbuchenKnopf.UseVisualStyleBackColor = true;
            this.UmbuchenKnopf.Click += new System.EventHandler(this.UmbuchenKnopf_Click);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(this.Überweisungsliste, 0, 1);
            tableLayoutPanel1.Controls.Add(this.KontostandLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 3);
            tableLayoutPanel1.Controls.Add(this.NameBox, 0, 0);
            tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(652, 532);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Überweisungsliste
            // 
            this.Überweisungsliste.AllColumns.Add(this.DatumSpalte);
            this.Überweisungsliste.AllColumns.Add(this.BetragSpalte);
            this.Überweisungsliste.AllColumns.Add(this.NeuerKontostandSpalte);
            this.Überweisungsliste.AllColumns.Add(this.BeschreibungSpalte);
            this.Überweisungsliste.AllColumns.Add(this.StornoSpalte);
            this.Überweisungsliste.AllColumns.Add(this.ErstellungSpalte);
            this.Überweisungsliste.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.Überweisungsliste.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.Überweisungsliste.CellEditUseWholeCell = false;
            this.Überweisungsliste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DatumSpalte,
            this.BetragSpalte,
            this.NeuerKontostandSpalte,
            this.BeschreibungSpalte,
            this.StornoSpalte});
            tableLayoutPanel1.SetColumnSpan(this.Überweisungsliste, 2);
            this.Überweisungsliste.Cursor = System.Windows.Forms.Cursors.Default;
            this.Überweisungsliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Überweisungsliste.FullRowSelect = true;
            this.Überweisungsliste.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Überweisungsliste.Location = new System.Drawing.Point(3, 63);
            this.Überweisungsliste.MultiSelect = false;
            this.Überweisungsliste.Name = "Überweisungsliste";
            this.Überweisungsliste.RowHeight = 20;
            this.Überweisungsliste.SelectColumnsOnRightClick = false;
            this.Überweisungsliste.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.Überweisungsliste.ShowGroups = false;
            this.Überweisungsliste.Size = new System.Drawing.Size(646, 390);
            this.Überweisungsliste.TabIndex = 1;
            this.Überweisungsliste.UseAlternatingBackColors = true;
            this.Überweisungsliste.UseCompatibleStateImageBehavior = false;
            this.Überweisungsliste.View = System.Windows.Forms.View.Details;
            this.Überweisungsliste.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.Überweisungsliste_ButtonClick);
            this.Überweisungsliste.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.Überweisungsliste_CellEditFinished);
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
            // NeuerKontostandSpalte
            // 
            this.NeuerKontostandSpalte.AspectName = "NeuerKontostand";
            this.NeuerKontostandSpalte.AspectToStringFormat = "{0:C}";
            this.NeuerKontostandSpalte.IsEditable = false;
            this.NeuerKontostandSpalte.Text = "Neuer Kontostand";
            this.NeuerKontostandSpalte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NeuerKontostandSpalte.Width = 100;
            // 
            // BeschreibungSpalte
            // 
            this.BeschreibungSpalte.AspectName = "Beschreibung";
            this.BeschreibungSpalte.CellEditUseWholeCell = true;
            this.BeschreibungSpalte.FillsFreeSpace = true;
            this.BeschreibungSpalte.Text = "Beschreibung";
            // 
            // StornoSpalte
            // 
            this.StornoSpalte.AspectName = "Löschbar";
            this.StornoSpalte.IsButton = true;
            this.StornoSpalte.IsEditable = false;
            this.StornoSpalte.Renderer = this.stornoKnopfRenderer1;
            this.StornoSpalte.Text = "";
            this.StornoSpalte.Width = 65;
            // 
            // stornoKnopfRenderer1
            // 
            this.stornoKnopfRenderer1.ButtonPadding = new System.Drawing.Size(10, 10);
            // 
            // ErstellungSpalte
            // 
            this.ErstellungSpalte.AspectName = "Erstellungszeitpunkt";
            this.ErstellungSpalte.AspectToStringFormat = "{0:C}";
            this.ErstellungSpalte.IsEditable = false;
            this.ErstellungSpalte.IsVisible = false;
            // 
            // KontostandLabel
            // 
            this.KontostandLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KontostandLabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.KontostandLabel.Location = new System.Drawing.Point(329, 0);
            this.KontostandLabel.Name = "KontostandLabel";
            this.KontostandLabel.Size = new System.Drawing.Size(320, 60);
            this.KontostandLabel.TabIndex = 3;
            this.KontostandLabel.Text = "Kontostand";
            this.KontostandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameBox
            // 
            this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NameBox.BackColor = System.Drawing.SystemColors.Control;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBox.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.NameBox.Location = new System.Drawing.Point(3, 14);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(320, 31);
            this.NameBox.TabIndex = 10;
            this.NameBox.TabStop = false;
            this.NameBox.Text = "Name";
            this.NameBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NameBox_KeyUp);
            this.NameBox.Leave += new System.EventHandler(this.NameBox_Leave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.Controls.Add(this.HinzufügenKnopf, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.BeschreibungBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.DatumBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BetragBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 456);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(652, 26);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // HinzufügenKnopf
            // 
            this.HinzufügenKnopf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HinzufügenKnopf.Location = new System.Drawing.Point(590, 0);
            this.HinzufügenKnopf.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.HinzufügenKnopf.Name = "HinzufügenKnopf";
            this.HinzufügenKnopf.Size = new System.Drawing.Size(59, 26);
            this.HinzufügenKnopf.TabIndex = 4;
            this.HinzufügenKnopf.Text = "+";
            this.HinzufügenKnopf.UseVisualStyleBackColor = true;
            this.HinzufügenKnopf.Click += new System.EventHandler(this.HinzufügenKnopf_Click);
            // 
            // BeschreibungBox
            // 
            this.BeschreibungBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeschreibungBox.Location = new System.Drawing.Point(283, 3);
            this.BeschreibungBox.Name = "BeschreibungBox";
            this.BeschreibungBox.Size = new System.Drawing.Size(301, 20);
            this.BeschreibungBox.TabIndex = 3;
            // 
            // DatumBox
            // 
            this.DatumBox.AllowPromptAsInput = false;
            this.DatumBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatumBox.Location = new System.Drawing.Point(3, 3);
            this.DatumBox.Mask = "00/00/0000";
            this.DatumBox.Name = "DatumBox";
            this.DatumBox.Size = new System.Drawing.Size(74, 20);
            this.DatumBox.TabIndex = 0;
            this.DatumBox.ValidatingType = typeof(System.DateTime);
            // 
            // BetragBox
            // 
            this.BetragBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BetragBox.Location = new System.Drawing.Point(83, 3);
            this.BetragBox.Name = "BetragBox";
            this.BetragBox.Size = new System.Drawing.Size(94, 20);
            this.BetragBox.TabIndex = 0;
            this.BetragBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BetragBox.Leave += new System.EventHandler(this.BetragBox_Leave);
            // 
            // Kontofenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(652, 532);
            this.Controls.Add(tableLayoutPanel1);
            this.Name = "Kontofenster";
            this.Text = "Kontofenster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kontofenster_FormClosing);
            this.Load += new System.EventHandler(this.Kontofenster_Load);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Überweisungsliste)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label KontostandLabel;
        private System.Windows.Forms.TextBox NameBox;
        private BrightIdeasSoftware.ObjectListView Überweisungsliste;
        private BrightIdeasSoftware.OLVColumn DatumSpalte;
        private BrightIdeasSoftware.OLVColumn BetragSpalte;
        private BrightIdeasSoftware.OLVColumn NeuerKontostandSpalte;
        private BrightIdeasSoftware.OLVColumn BeschreibungSpalte;
        private BrightIdeasSoftware.OLVColumn StornoSpalte;
        private StornoKnopfRenderer stornoKnopfRenderer1;
        private BrightIdeasSoftware.OLVColumn ErstellungSpalte;
        private System.Windows.Forms.MaskedTextBox DatumBox;
        private System.Windows.Forms.TextBox BeschreibungBox;
        private System.Windows.Forms.Button HinzufügenKnopf;
        private System.Windows.Forms.TextBox BetragBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox KontoAuswahl;
        private System.Windows.Forms.TextBox BetragBox2;
        private System.Windows.Forms.Button UmbuchenKnopf;
    }
}
