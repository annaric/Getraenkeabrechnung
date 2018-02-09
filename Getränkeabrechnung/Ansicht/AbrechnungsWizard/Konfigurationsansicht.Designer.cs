namespace Getränkeabrechnung.Ansicht.AbrechnungsWizard
{
    partial class Konfigurationsansicht
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.NameBox = new System.Windows.Forms.TextBox();
            this.StartzeitBox = new System.Windows.Forms.DateTimePicker();
            this.EndzeitBox = new System.Windows.Forms.DateTimePicker();
            this.AbrechnungBox = new System.Windows.Forms.ComboBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            tableLayoutPanel1.Controls.Add(label2, 1, 2);
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 1, 3);
            tableLayoutPanel1.Controls.Add(label4, 1, 4);
            tableLayoutPanel1.Controls.Add(this.NameBox, 2, 1);
            tableLayoutPanel1.Controls.Add(this.StartzeitBox, 2, 2);
            tableLayoutPanel1.Controls.Add(this.EndzeitBox, 2, 3);
            tableLayoutPanel1.Controls.Add(this.AbrechnungBox, 2, 4);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(700, 550);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(175, 235);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(114, 40);
            label2.TabIndex = 1;
            label2.Text = "Startdatum:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(175, 195);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(114, 40);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(175, 275);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(114, 40);
            label3.TabIndex = 2;
            label3.Text = "Endddatum:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Location = new System.Drawing.Point(175, 315);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(114, 40);
            label4.TabIndex = 3;
            label4.Text = "Letzte Abrechnung:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameBox
            // 
            this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NameBox.Location = new System.Drawing.Point(295, 205);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(144, 20);
            this.NameBox.TabIndex = 4;
            this.NameBox.Leave += new System.EventHandler(this.NameBox_Leave);
            // 
            // StartzeitBox
            // 
            this.StartzeitBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StartzeitBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartzeitBox.Location = new System.Drawing.Point(295, 245);
            this.StartzeitBox.Name = "StartzeitBox";
            this.StartzeitBox.Size = new System.Drawing.Size(144, 20);
            this.StartzeitBox.TabIndex = 5;
            this.StartzeitBox.ValueChanged += new System.EventHandler(this.StartzeitBox_ValueChanged);
            // 
            // EndzeitBox
            // 
            this.EndzeitBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EndzeitBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndzeitBox.Location = new System.Drawing.Point(295, 285);
            this.EndzeitBox.Name = "EndzeitBox";
            this.EndzeitBox.Size = new System.Drawing.Size(144, 20);
            this.EndzeitBox.TabIndex = 6;
            this.EndzeitBox.ValueChanged += new System.EventHandler(this.EndzeitBox_ValueChanged);
            // 
            // AbrechnungBox
            // 
            this.AbrechnungBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AbrechnungBox.FormattingEnabled = true;
            this.AbrechnungBox.Location = new System.Drawing.Point(295, 324);
            this.AbrechnungBox.Name = "AbrechnungBox";
            this.AbrechnungBox.Size = new System.Drawing.Size(144, 21);
            this.AbrechnungBox.TabIndex = 7;
            this.AbrechnungBox.SelectedIndexChanged += new System.EventHandler(this.AbrechnungBox_SelectedIndexChanged);
            // 
            // Konfigurationsansicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(tableLayoutPanel1);
            this.Name = "Konfigurationsansicht";
            this.Size = new System.Drawing.Size(700, 550);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.DateTimePicker StartzeitBox;
        private System.Windows.Forms.DateTimePicker EndzeitBox;
        private System.Windows.Forms.ComboBox AbrechnungBox;
    }
}
