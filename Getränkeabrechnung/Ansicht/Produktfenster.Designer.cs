namespace Getränkeabrechnung.Ansicht
{
    partial class Produktfenster
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
            Getränkeabrechnung.Ansicht.StornoKnopfRenderer stornoKnopfRenderer1;
            System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
            this.NeuesProduktKnopf = new System.Windows.Forms.ToolStripMenuItem();
            this.ProduktListe = new BrightIdeasSoftware.ObjectListView();
            this.NameSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.KastengrößeSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.EinkaufspreisSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PreisSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.VerstecktSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PositionSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            stornoKnopfRenderer1 = new Getränkeabrechnung.Ansicht.StornoKnopfRenderer();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProduktListe)).BeginInit();
            this.SuspendLayout();
            // 
            // stornoKnopfRenderer1
            // 
            stornoKnopfRenderer1.ButtonPadding = new System.Drawing.Size(10, 10);
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NeuesProduktKnopf});
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(153, 26);
            // 
            // NeuesProduktKnopf
            // 
            this.NeuesProduktKnopf.Name = "NeuesProduktKnopf";
            this.NeuesProduktKnopf.Size = new System.Drawing.Size(152, 22);
            this.NeuesProduktKnopf.Text = "Neues Produkt";
            this.NeuesProduktKnopf.Click += new System.EventHandler(this.NeuesProduktKnopf_Click);
            // 
            // ProduktListe
            // 
            this.ProduktListe.AllColumns.Add(this.NameSpalte);
            this.ProduktListe.AllColumns.Add(this.KastengrößeSpalte);
            this.ProduktListe.AllColumns.Add(this.EinkaufspreisSpalte);
            this.ProduktListe.AllColumns.Add(this.PreisSpalte);
            this.ProduktListe.AllColumns.Add(this.PositionSpalte);
            this.ProduktListe.AllColumns.Add(this.VerstecktSpalte);
            this.ProduktListe.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.ProduktListe.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.ProduktListe.CellEditUseWholeCell = false;
            this.ProduktListe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameSpalte,
            this.KastengrößeSpalte,
            this.EinkaufspreisSpalte,
            this.PreisSpalte,
            this.PositionSpalte,
            this.VerstecktSpalte});
            this.ProduktListe.ContextMenuStrip = contextMenuStrip1;
            this.ProduktListe.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProduktListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProduktListe.FullRowSelect = true;
            this.ProduktListe.Location = new System.Drawing.Point(10, 10);
            this.ProduktListe.MultiSelect = false;
            this.ProduktListe.Name = "ProduktListe";
            this.ProduktListe.RowHeight = 20;
            this.ProduktListe.SelectColumnsOnRightClick = false;
            this.ProduktListe.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.ProduktListe.ShowGroups = false;
            this.ProduktListe.Size = new System.Drawing.Size(574, 429);
            this.ProduktListe.TabIndex = 0;
            this.ProduktListe.UseAlternatingBackColors = true;
            this.ProduktListe.UseCompatibleStateImageBehavior = false;
            this.ProduktListe.UseFiltering = true;
            this.ProduktListe.View = System.Windows.Forms.View.Details;
            this.ProduktListe.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.ProduktListe_ButtonClick);
            this.ProduktListe.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.ProduktListe_CellEditFinished);
            this.ProduktListe.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.ProduktListe_CellEditFinishing);
            this.ProduktListe.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.ProduktListe_CellEditStarting);
            this.ProduktListe.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.ProduktListe_CellToolTipShowing);
            // 
            // NameSpalte
            // 
            this.NameSpalte.AspectName = "Name";
            this.NameSpalte.AspectToStringFormat = "{0}";
            this.NameSpalte.CellEditUseWholeCell = true;
            this.NameSpalte.FillsFreeSpace = true;
            this.NameSpalte.Text = "Name";
            // 
            // KastengrößeSpalte
            // 
            this.KastengrößeSpalte.AspectName = "Kastengröße";
            this.KastengrößeSpalte.AspectToStringFormat = "{0}";
            this.KastengrößeSpalte.CellEditUseWholeCell = true;
            this.KastengrößeSpalte.Text = "Flaschen/Kasten";
            this.KastengrößeSpalte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.KastengrößeSpalte.Width = 100;
            // 
            // EinkaufspreisSpalte
            // 
            this.EinkaufspreisSpalte.AspectName = "Einkaufspreis";
            this.EinkaufspreisSpalte.AspectToStringFormat = "{0:C}";
            this.EinkaufspreisSpalte.CellEditUseWholeCell = true;
            this.EinkaufspreisSpalte.Text = "Einkaufspreis/Kasten";
            this.EinkaufspreisSpalte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.EinkaufspreisSpalte.Width = 120;
            // 
            // PreisSpalte
            // 
            this.PreisSpalte.AspectName = "Preis";
            this.PreisSpalte.AspectToStringFormat = "{0:C}";
            this.PreisSpalte.CellEditUseWholeCell = true;
            this.PreisSpalte.Text = "Verkaufspreis/Flasche";
            this.PreisSpalte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PreisSpalte.Width = 120;
            // 
            // VerstecktSpalte
            // 
            this.VerstecktSpalte.AspectName = "";
            this.VerstecktSpalte.IsButton = true;
            this.VerstecktSpalte.Renderer = stornoKnopfRenderer1;
            this.VerstecktSpalte.Text = "";
            this.VerstecktSpalte.Width = 65;
            // 
            // ToolTip
            // 
            this.ToolTip.AutoPopDelay = 6000;
            this.ToolTip.InitialDelay = 500;
            this.ToolTip.ReshowDelay = 100;
            this.ToolTip.ShowAlways = true;
            this.ToolTip.UseAnimation = false;
            this.ToolTip.UseFading = false;
            // 
            // PositionSpalte
            // 
            this.PositionSpalte.AspectName = "Listenposition";
            this.PositionSpalte.Text = "Listenposition";
            this.PositionSpalte.Width = 40;
            // 
            // Produktfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(594, 449);
            this.Controls.Add(this.ProduktListe);
            this.Name = "Produktfenster";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Produkte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Produktfenster_FormClosing);
            this.Load += new System.EventHandler(this.Produktfenster_Load);
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProduktListe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView ProduktListe;
        private BrightIdeasSoftware.OLVColumn NameSpalte;
        private BrightIdeasSoftware.OLVColumn KastengrößeSpalte;
        private BrightIdeasSoftware.OLVColumn EinkaufspreisSpalte;
        private BrightIdeasSoftware.OLVColumn PreisSpalte;
        private BrightIdeasSoftware.OLVColumn VerstecktSpalte;
        private System.Windows.Forms.ToolStripMenuItem NeuesProduktKnopf;
        private System.Windows.Forms.ToolTip ToolTip;
        private BrightIdeasSoftware.OLVColumn PositionSpalte;
    }
}
