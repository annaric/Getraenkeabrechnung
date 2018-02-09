namespace Getränkeabrechnung.Ansicht.AbrechnungsWizard
{
    partial class Abrechnungsfenster
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
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            this.WeiterKnopf = new System.Windows.Forms.Button();
            this.ZurückKnopf = new System.Windows.Forms.Button();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 467);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(684, 4);
            panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(this.WeiterKnopf);
            flowLayoutPanel1.Controls.Add(this.ZurückKnopf);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 471);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(684, 40);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // WeiterKnopf
            // 
            this.WeiterKnopf.Location = new System.Drawing.Point(599, 3);
            this.WeiterKnopf.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.WeiterKnopf.Name = "WeiterKnopf";
            this.WeiterKnopf.Size = new System.Drawing.Size(75, 23);
            this.WeiterKnopf.TabIndex = 0;
            this.WeiterKnopf.Text = "Weiter";
            this.WeiterKnopf.UseVisualStyleBackColor = true;
            this.WeiterKnopf.Click += new System.EventHandler(this.WeiterKnopf_Click);
            // 
            // ZurückKnopf
            // 
            this.ZurückKnopf.Location = new System.Drawing.Point(518, 3);
            this.ZurückKnopf.Name = "ZurückKnopf";
            this.ZurückKnopf.Size = new System.Drawing.Size(75, 23);
            this.ZurückKnopf.TabIndex = 1;
            this.ZurückKnopf.Text = "Zurück";
            this.ZurückKnopf.UseVisualStyleBackColor = true;
            this.ZurückKnopf.Click += new System.EventHandler(this.ZurückKnopf_Click);
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 1;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.Controls.Add(panel1, 0, 1);
            this.TableLayout.Controls.Add(flowLayoutPanel1, 0, 2);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 3;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TableLayout.Size = new System.Drawing.Size(684, 511);
            this.TableLayout.TabIndex = 0;
            // 
            // Abrechnungsfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.TableLayout);
            this.Name = "Abrechnungsfenster";
            this.Text = "Abrechnung";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Abrechnungsfenster_FormClosing);
            this.Load += new System.EventHandler(this.Abrechnungsfenster_Load);
            flowLayoutPanel1.ResumeLayout(false);
            this.TableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.Button WeiterKnopf;
        private System.Windows.Forms.Button ZurückKnopf;
    }
}
