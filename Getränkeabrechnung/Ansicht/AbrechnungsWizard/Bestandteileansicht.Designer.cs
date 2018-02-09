namespace Getränkeabrechnung.Ansicht.AbrechnungsWizard
{
    partial class Bestandteileansicht
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Benutzerliste = new BrightIdeasSoftware.ObjectListView();
            this.NameSpalteBenutzer = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Zimmerspalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Einkaufliste = new BrightIdeasSoftware.ObjectListView();
            this.RechnungSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DatumSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BetragSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Produktliste = new BrightIdeasSoftware.ObjectListView();
            this.NameSpalteProdukt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Benutzerliste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Einkaufliste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Produktliste)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.Benutzerliste, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Einkaufliste, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Produktliste, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 550);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Benutzerliste
            // 
            this.Benutzerliste.AllColumns.Add(this.NameSpalteBenutzer);
            this.Benutzerliste.AllColumns.Add(this.Zimmerspalte);
            this.Benutzerliste.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.Benutzerliste.CellEditUseWholeCell = false;
            this.Benutzerliste.CheckBoxes = true;
            this.Benutzerliste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameSpalteBenutzer});
            this.Benutzerliste.Cursor = System.Windows.Forms.Cursors.Default;
            this.Benutzerliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Benutzerliste.FullRowSelect = true;
            this.Benutzerliste.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Benutzerliste.HideSelection = false;
            this.Benutzerliste.Location = new System.Drawing.Point(13, 78);
            this.Benutzerliste.Name = "Benutzerliste";
            this.Benutzerliste.SelectColumnsOnRightClick = false;
            this.Benutzerliste.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.Benutzerliste.ShowGroups = false;
            this.Benutzerliste.Size = new System.Drawing.Size(220, 394);
            this.Benutzerliste.TabIndex = 0;
            this.Benutzerliste.UseAlternatingBackColors = true;
            this.Benutzerliste.UseCompatibleStateImageBehavior = false;
            this.Benutzerliste.UseFiltering = true;
            this.Benutzerliste.View = System.Windows.Forms.View.Details;
            this.Benutzerliste.HeaderCheckBoxChanging += new System.EventHandler<BrightIdeasSoftware.HeaderCheckBoxChangingEventArgs>(this.Benutzerliste_HeaderCheckBoxChanging);
            // 
            // NameSpalteBenutzer
            // 
            this.NameSpalteBenutzer.AspectName = "Anzeigename";
            this.NameSpalteBenutzer.FillsFreeSpace = true;
            this.NameSpalteBenutzer.HeaderCheckBox = true;
            this.NameSpalteBenutzer.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.NameSpalteBenutzer.Text = "Benutzer";
            // 
            // Zimmerspalte
            // 
            this.Zimmerspalte.AspectName = "Zimmernummer";
            this.Zimmerspalte.DisplayIndex = 1;
            this.Zimmerspalte.IsVisible = false;
            this.Zimmerspalte.Text = "#";
            this.Zimmerspalte.Width = 40;
            // 
            // Einkaufliste
            // 
            this.Einkaufliste.AllColumns.Add(this.RechnungSpalte);
            this.Einkaufliste.AllColumns.Add(this.DatumSpalte);
            this.Einkaufliste.AllColumns.Add(this.BetragSpalte);
            this.Einkaufliste.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.Einkaufliste.CellEditUseWholeCell = false;
            this.Einkaufliste.CheckBoxes = true;
            this.Einkaufliste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RechnungSpalte,
            this.DatumSpalte,
            this.BetragSpalte});
            this.Einkaufliste.Cursor = System.Windows.Forms.Cursors.Default;
            this.Einkaufliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Einkaufliste.FullRowSelect = true;
            this.Einkaufliste.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Einkaufliste.Location = new System.Drawing.Point(239, 78);
            this.Einkaufliste.MultiSelect = false;
            this.Einkaufliste.Name = "Einkaufliste";
            this.Einkaufliste.SelectColumnsOnRightClick = false;
            this.Einkaufliste.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.Einkaufliste.ShowGroups = false;
            this.Einkaufliste.Size = new System.Drawing.Size(220, 394);
            this.Einkaufliste.TabIndex = 1;
            this.Einkaufliste.UseAlternatingBackColors = true;
            this.Einkaufliste.UseCompatibleStateImageBehavior = false;
            this.Einkaufliste.UseFiltering = true;
            this.Einkaufliste.View = System.Windows.Forms.View.Details;
            this.Einkaufliste.HeaderCheckBoxChanging += new System.EventHandler<BrightIdeasSoftware.HeaderCheckBoxChangingEventArgs>(this.Einkaufliste_HeaderCheckBoxChanging);
            // 
            // RechnungSpalte
            // 
            this.RechnungSpalte.AspectName = "Rechnungsnummer";
            this.RechnungSpalte.FillsFreeSpace = true;
            this.RechnungSpalte.HeaderCheckBox = true;
            this.RechnungSpalte.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.RechnungSpalte.Text = "Einkauf";
            // 
            // DatumSpalte
            // 
            this.DatumSpalte.AspectName = "Zeitpunkt";
            this.DatumSpalte.AspectToStringFormat = "{0:d}";
            this.DatumSpalte.Text = "Datum";
            this.DatumSpalte.Width = 65;
            // 
            // BetragSpalte
            // 
            this.BetragSpalte.AspectName = "Betrag";
            this.BetragSpalte.AspectToStringFormat = "{0:C}";
            this.BetragSpalte.Text = "Betrag";
            this.BetragSpalte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Produktliste
            // 
            this.Produktliste.AllColumns.Add(this.NameSpalteProdukt);
            this.Produktliste.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.Produktliste.CellEditUseWholeCell = false;
            this.Produktliste.CheckBoxes = true;
            this.Produktliste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameSpalteProdukt});
            this.Produktliste.Cursor = System.Windows.Forms.Cursors.Default;
            this.Produktliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Produktliste.FullRowSelect = true;
            this.Produktliste.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Produktliste.HideSelection = false;
            this.Produktliste.Location = new System.Drawing.Point(465, 78);
            this.Produktliste.MultiSelect = false;
            this.Produktliste.Name = "Produktliste";
            this.Produktliste.SelectColumnsOnRightClick = false;
            this.Produktliste.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.Produktliste.ShowGroups = false;
            this.Produktliste.Size = new System.Drawing.Size(222, 394);
            this.Produktliste.TabIndex = 2;
            this.Produktliste.UseAlternatingBackColors = true;
            this.Produktliste.UseCompatibleStateImageBehavior = false;
            this.Produktliste.UseFiltering = true;
            this.Produktliste.View = System.Windows.Forms.View.Details;
            this.Produktliste.HeaderCheckBoxChanging += new System.EventHandler<BrightIdeasSoftware.HeaderCheckBoxChangingEventArgs>(this.Produktliste_HeaderCheckBoxChanging);
            // 
            // NameSpalteProdukt
            // 
            this.NameSpalteProdukt.AspectName = "Name";
            this.NameSpalteProdukt.AspectToStringFormat = "";
            this.NameSpalteProdukt.FillsFreeSpace = true;
            this.NameSpalteProdukt.HeaderCheckBox = true;
            this.NameSpalteProdukt.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.NameSpalteProdukt.Text = "Produkt";
            // 
            // Bestandteileansicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Bestandteileansicht";
            this.Size = new System.Drawing.Size(700, 550);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Benutzerliste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Einkaufliste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Produktliste)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BrightIdeasSoftware.ObjectListView Benutzerliste;
        private BrightIdeasSoftware.OLVColumn Zimmerspalte;
        private BrightIdeasSoftware.OLVColumn NameSpalteBenutzer;
        private BrightIdeasSoftware.ObjectListView Einkaufliste;
        private BrightIdeasSoftware.OLVColumn RechnungSpalte;
        private BrightIdeasSoftware.OLVColumn DatumSpalte;
        private BrightIdeasSoftware.OLVColumn BetragSpalte;
        private BrightIdeasSoftware.ObjectListView Produktliste;
        private BrightIdeasSoftware.OLVColumn NameSpalteProdukt;
    }
}
