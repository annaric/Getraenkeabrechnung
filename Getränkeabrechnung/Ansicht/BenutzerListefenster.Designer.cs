namespace Getränkeabrechnung.Ansicht
{
    partial class BenutzerListefenster
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
            System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
            this.AktivListe = new BrightIdeasSoftware.ObjectListView();
            this.ZimmerAktiv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.VornameAktiv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NachnameAktiv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.RufnameAktiv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.HinzufügenKnopf = new System.Windows.Forms.Button();
            this.InaktivListe = new BrightIdeasSoftware.ObjectListView();
            this.ZimmerInaktiv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.VornameInaktiv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NachnameInaktiv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.RufnameInaktiv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.AktivierenKnopf = new System.Windows.Forms.Button();
            this.DeaktivierenKnopf = new System.Windows.Forms.Button();
            this.AnzeigenOptionAktiv = new System.Windows.Forms.ToolStripMenuItem();
            this.AnzeigenOptionInaktiv = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AktivListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InaktivListe)).BeginInit();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(this.AktivListe, 0, 1);
            tableLayoutPanel1.Controls.Add(this.HinzufügenKnopf, 1, 3);
            tableLayoutPanel1.Controls.Add(this.InaktivListe, 2, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 2, 0);
            tableLayoutPanel1.Controls.Add(this.AktivierenKnopf, 1, 2);
            tableLayoutPanel1.Controls.Add(this.DeaktivierenKnopf, 1, 4);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(684, 561);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // AktivListe
            // 
            this.AktivListe.AllColumns.Add(this.ZimmerAktiv);
            this.AktivListe.AllColumns.Add(this.VornameAktiv);
            this.AktivListe.AllColumns.Add(this.NachnameAktiv);
            this.AktivListe.AllColumns.Add(this.RufnameAktiv);
            this.AktivListe.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.AktivListe.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.AktivListe.CellEditUseWholeCell = false;
            this.AktivListe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ZimmerAktiv,
            this.VornameAktiv,
            this.NachnameAktiv,
            this.RufnameAktiv});
            this.AktivListe.ContextMenuStrip = contextMenuStrip1;
            this.AktivListe.Cursor = System.Windows.Forms.Cursors.Default;
            this.AktivListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AktivListe.FullRowSelect = true;
            this.AktivListe.Location = new System.Drawing.Point(13, 33);
            this.AktivListe.Name = "AktivListe";
            tableLayoutPanel1.SetRowSpan(this.AktivListe, 5);
            this.AktivListe.SelectColumnsOnRightClick = false;
            this.AktivListe.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.AktivListe.ShowGroups = false;
            this.AktivListe.ShowSortIndicators = false;
            this.AktivListe.Size = new System.Drawing.Size(313, 515);
            this.AktivListe.TabIndex = 6;
            this.AktivListe.UseAlternatingBackColors = true;
            this.AktivListe.UseCompatibleStateImageBehavior = false;
            this.AktivListe.UseFiltering = true;
            this.AktivListe.View = System.Windows.Forms.View.Details;
            this.AktivListe.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.AktivListe_CellEditFinished);
            // 
            // ZimmerAktiv
            // 
            this.ZimmerAktiv.AspectName = "Zimmernummer";
            this.ZimmerAktiv.AspectToStringFormat = "{0}";
            this.ZimmerAktiv.CellEditUseWholeCell = true;
            this.ZimmerAktiv.Text = "Zimmer";
            this.ZimmerAktiv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ZimmerAktiv.Width = 50;
            // 
            // VornameAktiv
            // 
            this.VornameAktiv.AspectName = "Vorname";
            this.VornameAktiv.AspectToStringFormat = "{0}";
            this.VornameAktiv.CellEditUseWholeCell = true;
            this.VornameAktiv.Text = "Vorname";
            this.VornameAktiv.Width = 80;
            // 
            // NachnameAktiv
            // 
            this.NachnameAktiv.AspectName = "Nachname";
            this.NachnameAktiv.AspectToStringFormat = "{0}";
            this.NachnameAktiv.CellEditUseWholeCell = true;
            this.NachnameAktiv.FillsFreeSpace = true;
            this.NachnameAktiv.Text = "Nachname";
            this.NachnameAktiv.Width = 100;
            // 
            // RufnameAktiv
            // 
            this.RufnameAktiv.AspectName = "Rufname";
            this.RufnameAktiv.AspectToStringFormat = "{0}";
            this.RufnameAktiv.CellEditUseWholeCell = true;
            this.RufnameAktiv.Text = "Rufname";
            this.RufnameAktiv.Width = 100;
            // 
            // HinzufügenKnopf
            // 
            this.HinzufügenKnopf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HinzufügenKnopf.Location = new System.Drawing.Point(329, 275);
            this.HinzufügenKnopf.Margin = new System.Windows.Forms.Padding(0);
            this.HinzufügenKnopf.Name = "HinzufügenKnopf";
            this.HinzufügenKnopf.Size = new System.Drawing.Size(25, 31);
            this.HinzufügenKnopf.TabIndex = 2;
            this.HinzufügenKnopf.Text = "+";
            this.HinzufügenKnopf.UseVisualStyleBackColor = true;
            this.HinzufügenKnopf.Click += new System.EventHandler(this.HinzufügenKnopf_Click);
            // 
            // InaktivListe
            // 
            this.InaktivListe.AllColumns.Add(this.ZimmerInaktiv);
            this.InaktivListe.AllColumns.Add(this.VornameInaktiv);
            this.InaktivListe.AllColumns.Add(this.NachnameInaktiv);
            this.InaktivListe.AllColumns.Add(this.RufnameInaktiv);
            this.InaktivListe.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.InaktivListe.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.InaktivListe.CellEditUseWholeCell = false;
            this.InaktivListe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ZimmerInaktiv,
            this.VornameInaktiv,
            this.NachnameInaktiv,
            this.RufnameInaktiv});
            this.InaktivListe.ContextMenuStrip = contextMenuStrip2;
            this.InaktivListe.Cursor = System.Windows.Forms.Cursors.Default;
            this.InaktivListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InaktivListe.FullRowSelect = true;
            this.InaktivListe.Location = new System.Drawing.Point(357, 33);
            this.InaktivListe.Name = "InaktivListe";
            tableLayoutPanel1.SetRowSpan(this.InaktivListe, 5);
            this.InaktivListe.SelectColumnsOnRightClick = false;
            this.InaktivListe.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.InaktivListe.ShowGroups = false;
            this.InaktivListe.ShowSortIndicators = false;
            this.InaktivListe.Size = new System.Drawing.Size(314, 515);
            this.InaktivListe.TabIndex = 3;
            this.InaktivListe.UseAlternatingBackColors = true;
            this.InaktivListe.UseCompatibleStateImageBehavior = false;
            this.InaktivListe.UseFiltering = true;
            this.InaktivListe.View = System.Windows.Forms.View.Details;
            this.InaktivListe.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.InaktivListe_CellEditFinished);
            // 
            // ZimmerInaktiv
            // 
            this.ZimmerInaktiv.AspectName = "Zimmernummer";
            this.ZimmerInaktiv.AspectToStringFormat = "{0}";
            this.ZimmerInaktiv.CellEditUseWholeCell = true;
            this.ZimmerInaktiv.Text = "Zimmer";
            this.ZimmerInaktiv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ZimmerInaktiv.Width = 50;
            // 
            // VornameInaktiv
            // 
            this.VornameInaktiv.AspectName = "Vorname";
            this.VornameInaktiv.AspectToStringFormat = "{0}";
            this.VornameInaktiv.CellEditUseWholeCell = true;
            this.VornameInaktiv.Text = "Vorname";
            this.VornameInaktiv.Width = 80;
            // 
            // NachnameInaktiv
            // 
            this.NachnameInaktiv.AspectName = "Nachname";
            this.NachnameInaktiv.AspectToStringFormat = "{0}";
            this.NachnameInaktiv.CellEditUseWholeCell = true;
            this.NachnameInaktiv.FillsFreeSpace = true;
            this.NachnameInaktiv.Text = "Nachname";
            this.NachnameInaktiv.Width = 100;
            // 
            // RufnameInaktiv
            // 
            this.RufnameInaktiv.AspectName = "Rufname";
            this.RufnameInaktiv.AspectToStringFormat = "{0}";
            this.RufnameInaktiv.CellEditUseWholeCell = true;
            this.RufnameInaktiv.Text = "Rufname";
            this.RufnameInaktiv.Width = 100;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(13, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(313, 20);
            label1.TabIndex = 4;
            label1.Text = "Aktive Benutzer";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(357, 10);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(314, 20);
            label2.TabIndex = 5;
            label2.Text = "Inaktive Benutzer";
            label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // AktivierenKnopf
            // 
            this.AktivierenKnopf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AktivierenKnopf.Location = new System.Drawing.Point(329, 244);
            this.AktivierenKnopf.Margin = new System.Windows.Forms.Padding(0);
            this.AktivierenKnopf.Name = "AktivierenKnopf";
            this.AktivierenKnopf.Size = new System.Drawing.Size(25, 31);
            this.AktivierenKnopf.TabIndex = 7;
            this.AktivierenKnopf.Text = "<-";
            this.AktivierenKnopf.UseVisualStyleBackColor = true;
            this.AktivierenKnopf.Click += new System.EventHandler(this.AktivierenKnopf_Click);
            // 
            // DeaktivierenKnopf
            // 
            this.DeaktivierenKnopf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeaktivierenKnopf.Location = new System.Drawing.Point(329, 306);
            this.DeaktivierenKnopf.Margin = new System.Windows.Forms.Padding(0);
            this.DeaktivierenKnopf.Name = "DeaktivierenKnopf";
            this.DeaktivierenKnopf.Size = new System.Drawing.Size(25, 31);
            this.DeaktivierenKnopf.TabIndex = 8;
            this.DeaktivierenKnopf.Text = "->";
            this.DeaktivierenKnopf.UseVisualStyleBackColor = true;
            this.DeaktivierenKnopf.Click += new System.EventHandler(this.DeaktivierenKnopf_Click);
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnzeigenOptionAktiv});
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.ShowImageMargin = false;
            contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // AnzeigenOptionAktiv
            // 
            this.AnzeigenOptionAktiv.Name = "AnzeigenOptionAktiv";
            this.AnzeigenOptionAktiv.Size = new System.Drawing.Size(127, 22);
            this.AnzeigenOptionAktiv.Text = "Anzeigen...";
            this.AnzeigenOptionAktiv.Click += new System.EventHandler(this.AnzeigenOptionAktiv_Click);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnzeigenOptionInaktiv});
            contextMenuStrip2.Name = "contextMenuStrip1";
            contextMenuStrip2.ShowImageMargin = false;
            contextMenuStrip2.Size = new System.Drawing.Size(128, 48);
            // 
            // AnzeigenOptionInaktiv
            // 
            this.AnzeigenOptionInaktiv.Name = "AnzeigenOptionInaktiv";
            this.AnzeigenOptionInaktiv.Size = new System.Drawing.Size(127, 22);
            this.AnzeigenOptionInaktiv.Text = "Anzeigen...";
            this.AnzeigenOptionInaktiv.Click += new System.EventHandler(this.AnzeigenOptionInaktiv_Click);
            // 
            // BenutzerListefenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(tableLayoutPanel1);
            this.Name = "BenutzerListefenster";
            this.Text = "Benutzer Verwalten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BenutzerListefenster_FormClosing);
            this.Load += new System.EventHandler(this.BenutzerListefenster_Load);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AktivListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InaktivListe)).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button HinzufügenKnopf;
        private BrightIdeasSoftware.ObjectListView InaktivListe;
        private BrightIdeasSoftware.OLVColumn ZimmerInaktiv;
        private BrightIdeasSoftware.OLVColumn VornameInaktiv;
        private BrightIdeasSoftware.OLVColumn NachnameInaktiv;
        private BrightIdeasSoftware.OLVColumn RufnameInaktiv;
        private BrightIdeasSoftware.ObjectListView AktivListe;
        private BrightIdeasSoftware.OLVColumn ZimmerAktiv;
        private BrightIdeasSoftware.OLVColumn VornameAktiv;
        private BrightIdeasSoftware.OLVColumn NachnameAktiv;
        private BrightIdeasSoftware.OLVColumn RufnameAktiv;
        private System.Windows.Forms.Button AktivierenKnopf;
        private System.Windows.Forms.Button DeaktivierenKnopf;
        private System.Windows.Forms.ToolStripMenuItem AnzeigenOptionAktiv;
        private System.Windows.Forms.ToolStripMenuItem AnzeigenOptionInaktiv;
    }
}
