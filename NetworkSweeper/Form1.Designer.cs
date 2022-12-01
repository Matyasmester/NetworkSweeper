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
            this.IPBox.Location = new System.Drawing.Point(251, 25);
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
            // MainForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
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
    }
}

