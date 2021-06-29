namespace BloqLab
{
    partial class Form2
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
            this.OkButton = new System.Windows.Forms.Button();
            this.SzerekoscLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SzerokoscNumeric = new System.Windows.Forms.NumericUpDown();
            this.WysokoscNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.SzerokoscNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WysokoscNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(104, 126);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // SzerekoscLabel
            // 
            this.SzerekoscLabel.AutoSize = true;
            this.SzerekoscLabel.Location = new System.Drawing.Point(12, 34);
            this.SzerekoscLabel.Name = "SzerekoscLabel";
            this.SzerekoscLabel.Size = new System.Drawing.Size(57, 13);
            this.SzerekoscLabel.TabIndex = 1;
            this.SzerekoscLabel.Text = "Szerokość";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wysokość";
            // 
            // SzerokoscNumeric
            // 
            this.SzerokoscNumeric.Location = new System.Drawing.Point(123, 27);
            this.SzerokoscNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.SzerokoscNumeric.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SzerokoscNumeric.Name = "SzerokoscNumeric";
            this.SzerokoscNumeric.Size = new System.Drawing.Size(120, 20);
            this.SzerokoscNumeric.TabIndex = 3;
            this.SzerokoscNumeric.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // WysokoscNumeric
            // 
            this.WysokoscNumeric.Location = new System.Drawing.Point(123, 80);
            this.WysokoscNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.WysokoscNumeric.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.WysokoscNumeric.Name = "WysokoscNumeric";
            this.WysokoscNumeric.Size = new System.Drawing.Size(120, 20);
            this.WysokoscNumeric.TabIndex = 4;
            this.WysokoscNumeric.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.WysokoscNumeric);
            this.Controls.Add(this.SzerokoscNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SzerekoscLabel);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nowy Schemat";
            ((System.ComponentModel.ISupportInitialize)(this.SzerokoscNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WysokoscNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label SzerekoscLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SzerokoscNumeric;
        private System.Windows.Forms.NumericUpDown WysokoscNumeric;
    }
}