namespace NetworkScanner
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
            this.AdminLabel = new System.Windows.Forms.Label();
            this.IPBox = new System.Windows.Forms.ListBox();
            this.IPFromBox = new System.Windows.Forms.TextBox();
            this.IPToBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.PortButton = new System.Windows.Forms.Button();
            this.MinPortUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxPortUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MinPortUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPortUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminLabel
            // 
            this.AdminLabel.AutoSize = true;
            this.AdminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdminLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.AdminLabel.Location = new System.Drawing.Point(798, 25);
            this.AdminLabel.Name = "AdminLabel";
            this.AdminLabel.Size = new System.Drawing.Size(61, 20);
            this.AdminLabel.TabIndex = 0;
            this.AdminLabel.Text = "ADMIN";
            this.AdminLabel.Visible = false;
            // 
            // IPBox
            // 
            this.IPBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IPBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.IPBox.FormattingEnabled = true;
            this.IPBox.ItemHeight = 31;
            this.IPBox.Location = new System.Drawing.Point(28, 25);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(343, 252);
            this.IPBox.TabIndex = 1;
            this.IPBox.SelectedIndexChanged += new System.EventHandler(this.IPBox_SelectedIndexChanged);
            // 
            // IPFromBox
            // 
            this.IPFromBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IPFromBox.Location = new System.Drawing.Point(28, 321);
            this.IPFromBox.Name = "IPFromBox";
            this.IPFromBox.Size = new System.Drawing.Size(343, 35);
            this.IPFromBox.TabIndex = 2;
            // 
            // IPToBox
            // 
            this.IPToBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IPToBox.Location = new System.Drawing.Point(472, 321);
            this.IPToBox.Name = "IPToBox";
            this.IPToBox.Size = new System.Drawing.Size(343, 35);
            this.IPToBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(169, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(628, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "To:";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StartButton.Location = new System.Drawing.Point(173, 396);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(493, 134);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Start scan";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PortButton
            // 
            this.PortButton.Enabled = false;
            this.PortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PortButton.Location = new System.Drawing.Point(414, 25);
            this.PortButton.Name = "PortButton";
            this.PortButton.Size = new System.Drawing.Size(252, 74);
            this.PortButton.TabIndex = 7;
            this.PortButton.Text = "Scan selected for open ports";
            this.PortButton.UseVisualStyleBackColor = true;
            this.PortButton.Click += new System.EventHandler(this.PortButton_Click);
            // 
            // MinPortUpDown
            // 
            this.MinPortUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MinPortUpDown.Location = new System.Drawing.Point(414, 105);
            this.MinPortUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinPortUpDown.Name = "MinPortUpDown";
            this.MinPortUpDown.Size = new System.Drawing.Size(104, 31);
            this.MinPortUpDown.TabIndex = 8;
            this.MinPortUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MaxPortUpDown
            // 
            this.MaxPortUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaxPortUpDown.Location = new System.Drawing.Point(562, 105);
            this.MaxPortUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxPortUpDown.Name = "MaxPortUpDown";
            this.MaxPortUpDown.Size = new System.Drawing.Size(104, 31);
            this.MaxPortUpDown.TabIndex = 9;
            this.MaxPortUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(445, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(591, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Max";
            // 
            // MainForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MaxPortUpDown);
            this.Controls.Add(this.MinPortUpDown);
            this.Controls.Add(this.PortButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPToBox);
            this.Controls.Add(this.IPFromBox);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.AdminLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "NetworkSweeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinPortUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPortUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AdminLabel;
        private System.Windows.Forms.ListBox IPBox;
        private System.Windows.Forms.TextBox IPFromBox;
        private System.Windows.Forms.TextBox IPToBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button PortButton;
        private System.Windows.Forms.NumericUpDown MinPortUpDown;
        private System.Windows.Forms.NumericUpDown MaxPortUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

