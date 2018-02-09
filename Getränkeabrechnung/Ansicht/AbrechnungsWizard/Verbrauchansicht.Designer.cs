namespace Getränkeabrechnung.Ansicht.AbrechnungsWizard
{
    partial class Verbrauchansicht
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
            this.Verbrauchliste = new BrightIdeasSoftware.ObjectListView();
            this.NameSpalte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.Verbrauchliste)).BeginInit();
            this.SuspendLayout();
            // 
            // Verbrauchliste
            // 
            this.Verbrauchliste.AllColumns.Add(this.NameSpalte);
            this.Verbrauchliste.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.Verbrauchliste.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.Verbrauchliste.CellEditEnterChangesRows = true;
            this.Verbrauchliste.CellEditUseWholeCell = false;
            this.Verbrauchliste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameSpalte});
            this.Verbrauchliste.Cursor = System.Windows.Forms.Cursors.Default;
            this.Verbrauchliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Verbrauchliste.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Verbrauchliste.Location = new System.Drawing.Point(10, 10);
            this.Verbrauchliste.MultiSelect = false;
            this.Verbrauchliste.Name = "Verbrauchliste";
            this.Verbrauchliste.SelectColumnsOnRightClick = false;
            this.Verbrauchliste.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.Verbrauchliste.ShowGroups = false;
            this.Verbrauchliste.Size = new System.Drawing.Size(680, 530);
            this.Verbrauchliste.TabIndex = 0;
            this.Verbrauchliste.UseAlternatingBackColors = true;
            this.Verbrauchliste.UseCompatibleStateImageBehavior = false;
            this.Verbrauchliste.View = System.Windows.Forms.View.Details;
            this.Verbrauchliste.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.Verbrauchliste_CellEditFinished);
            this.Verbrauchliste.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.Verbrauchliste_CellEditStarting);
            this.Verbrauchliste.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.Verbrauchliste_FormatCell);
            this.Verbrauchliste.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.Verbrauchliste_FormatRow);
            // 
            // NameSpalte
            // 
            this.NameSpalte.FillsFreeSpace = true;
            this.NameSpalte.IsEditable = false;
            this.NameSpalte.MinimumWidth = 40;
            this.NameSpalte.Text = "Benutzer";
            // 
            // Verbrauchansicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.Verbrauchliste);
            this.Name = "Verbrauchansicht";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(700, 550);
            ((System.ComponentModel.ISupportInitialize)(this.Verbrauchliste)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView Verbrauchliste;
        private BrightIdeasSoftware.OLVColumn NameSpalte;
    }
}
