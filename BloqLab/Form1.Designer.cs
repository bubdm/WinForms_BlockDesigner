namespace BloqLab
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PictureFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.JęzykGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.AngielskiButton = new System.Windows.Forms.Button();
            this.PolskiButton = new System.Windows.Forms.Button();
            this.EdycjaGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.RhombusRadioButton = new System.Windows.Forms.RadioButton();
            this.StopRadioButton = new System.Windows.Forms.RadioButton();
            this.StartRadioButton = new System.Windows.Forms.RadioButton();
            this.RectRadioButton = new System.Windows.Forms.RadioButton();
            this.LinkRadioButton = new System.Windows.Forms.RadioButton();
            this.TrashRadioButton = new System.Windows.Forms.RadioButton();
            this.ChosedBlockTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PlikGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ZapiszSchematButton = new System.Windows.Forms.Button();
            this.WczytajSchematButton = new System.Windows.Forms.Button();
            this.NowySchematButton = new System.Windows.Forms.Button();
            this.FrameTimer = new System.Windows.Forms.Timer(this.components);
            this.MainTableLayoutPanel.SuspendLayout();
            this.PictureFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.JęzykGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.EdycjaGroupBox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.PlikGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            resources.ApplyResources(this.MainTableLayoutPanel, "MainTableLayoutPanel");
            this.MainTableLayoutPanel.Controls.Add(this.PictureFlowLayoutPanel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            // 
            // PictureFlowLayoutPanel
            // 
            resources.ApplyResources(this.PictureFlowLayoutPanel, "PictureFlowLayoutPanel");
            this.PictureFlowLayoutPanel.Controls.Add(this.MainPictureBox);
            this.PictureFlowLayoutPanel.Name = "PictureFlowLayoutPanel";
            this.PictureFlowLayoutPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PictureFlowLayoutPanel_Scroll);
            // 
            // MainPictureBox
            // 
            resources.ApplyResources(this.MainPictureBox, "MainPictureBox");
            this.MainPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPictureBox_Paint);
            this.MainPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseClick);
            this.MainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseDown);
            this.MainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseMove);
            this.MainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.Controls.Add(this.JęzykGroupBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.EdycjaGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PlikGroupBox, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // JęzykGroupBox
            // 
            resources.ApplyResources(this.JęzykGroupBox, "JęzykGroupBox");
            this.JęzykGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.JęzykGroupBox.Name = "JęzykGroupBox";
            this.JęzykGroupBox.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.AngielskiButton, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.PolskiButton, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // AngielskiButton
            // 
            resources.ApplyResources(this.AngielskiButton, "AngielskiButton");
            this.AngielskiButton.Name = "AngielskiButton";
            this.AngielskiButton.UseVisualStyleBackColor = true;
            this.AngielskiButton.Click += new System.EventHandler(this.AngielskiButton_Click);
            // 
            // PolskiButton
            // 
            resources.ApplyResources(this.PolskiButton, "PolskiButton");
            this.PolskiButton.Name = "PolskiButton";
            this.PolskiButton.UseVisualStyleBackColor = true;
            this.PolskiButton.Click += new System.EventHandler(this.PolskiButton_Click);
            // 
            // EdycjaGroupBox
            // 
            resources.ApplyResources(this.EdycjaGroupBox, "EdycjaGroupBox");
            this.EdycjaGroupBox.Controls.Add(this.tableLayoutPanel4);
            this.EdycjaGroupBox.Name = "EdycjaGroupBox";
            this.EdycjaGroupBox.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ChosedBlockTextBox, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.RhombusRadioButton, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.StopRadioButton, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.StartRadioButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.RectRadioButton, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.LinkRadioButton, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.TrashRadioButton, 1, 1);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // RhombusRadioButton
            // 
            resources.ApplyResources(this.RhombusRadioButton, "RhombusRadioButton");
            this.RhombusRadioButton.BackgroundImage = global::BloqLab.Properties.Resources.rhombus;
            this.RhombusRadioButton.Name = "RhombusRadioButton";
            this.RhombusRadioButton.TabStop = true;
            this.RhombusRadioButton.UseVisualStyleBackColor = true;
            // 
            // StopRadioButton
            // 
            resources.ApplyResources(this.StopRadioButton, "StopRadioButton");
            this.StopRadioButton.BackgroundImage = global::BloqLab.Properties.Resources.stop;
            this.StopRadioButton.Name = "StopRadioButton";
            this.StopRadioButton.TabStop = true;
            this.StopRadioButton.UseVisualStyleBackColor = true;
            // 
            // StartRadioButton
            // 
            resources.ApplyResources(this.StartRadioButton, "StartRadioButton");
            this.StartRadioButton.BackgroundImage = global::BloqLab.Properties.Resources.start;
            this.StartRadioButton.Name = "StartRadioButton";
            this.StartRadioButton.TabStop = true;
            this.StartRadioButton.UseVisualStyleBackColor = true;
            // 
            // RectRadioButton
            // 
            resources.ApplyResources(this.RectRadioButton, "RectRadioButton");
            this.RectRadioButton.BackgroundImage = global::BloqLab.Properties.Resources.rect;
            this.RectRadioButton.Name = "RectRadioButton";
            this.RectRadioButton.TabStop = true;
            this.RectRadioButton.UseVisualStyleBackColor = true;
            // 
            // LinkRadioButton
            // 
            resources.ApplyResources(this.LinkRadioButton, "LinkRadioButton");
            this.LinkRadioButton.BackgroundImage = global::BloqLab.Properties.Resources.link;
            this.LinkRadioButton.Name = "LinkRadioButton";
            this.LinkRadioButton.TabStop = true;
            this.LinkRadioButton.UseVisualStyleBackColor = true;
            // 
            // TrashRadioButton
            // 
            resources.ApplyResources(this.TrashRadioButton, "TrashRadioButton");
            this.TrashRadioButton.BackgroundImage = global::BloqLab.Properties.Resources.trash;
            this.TrashRadioButton.Name = "TrashRadioButton";
            this.TrashRadioButton.TabStop = true;
            this.TrashRadioButton.UseVisualStyleBackColor = true;
            // 
            // ChosedBlockTextBox
            // 
            resources.ApplyResources(this.ChosedBlockTextBox, "ChosedBlockTextBox");
            this.ChosedBlockTextBox.Name = "ChosedBlockTextBox";
            this.ChosedBlockTextBox.TextChanged += new System.EventHandler(this.ChosedBlockTextBox_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // PlikGroupBox
            // 
            resources.ApplyResources(this.PlikGroupBox, "PlikGroupBox");
            this.PlikGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.PlikGroupBox.Name = "PlikGroupBox";
            this.PlikGroupBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.ZapiszSchematButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.WczytajSchematButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.NowySchematButton, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // ZapiszSchematButton
            // 
            resources.ApplyResources(this.ZapiszSchematButton, "ZapiszSchematButton");
            this.ZapiszSchematButton.Name = "ZapiszSchematButton";
            this.ZapiszSchematButton.UseVisualStyleBackColor = true;
            this.ZapiszSchematButton.Click += new System.EventHandler(this.ZapiszSchematButton_Click);
            // 
            // WczytajSchematButton
            // 
            resources.ApplyResources(this.WczytajSchematButton, "WczytajSchematButton");
            this.WczytajSchematButton.Name = "WczytajSchematButton";
            this.WczytajSchematButton.UseVisualStyleBackColor = true;
            this.WczytajSchematButton.Click += new System.EventHandler(this.WczytajSchematButton_Click);
            // 
            // NowySchematButton
            // 
            resources.ApplyResources(this.NowySchematButton, "NowySchematButton");
            this.NowySchematButton.Name = "NowySchematButton";
            this.NowySchematButton.UseVisualStyleBackColor = true;
            this.NowySchematButton.Click += new System.EventHandler(this.NowySchematButton_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Name = "MainForm";
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.PictureFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.JęzykGroupBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.EdycjaGroupBox.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.PlikGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel PictureFlowLayoutPanel;
        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.GroupBox PlikGroupBox;
        private System.Windows.Forms.Button ZapiszSchematButton;
        private System.Windows.Forms.Button WczytajSchematButton;
        private System.Windows.Forms.Button NowySchematButton;
        private System.Windows.Forms.GroupBox JęzykGroupBox;
        private System.Windows.Forms.Button AngielskiButton;
        private System.Windows.Forms.Button PolskiButton;
        private System.Windows.Forms.GroupBox EdycjaGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.RadioButton StartRadioButton;
        private System.Windows.Forms.RadioButton LinkRadioButton;
        private System.Windows.Forms.RadioButton RhombusRadioButton;
        private System.Windows.Forms.RadioButton StopRadioButton;
        private System.Windows.Forms.RadioButton RectRadioButton;
        private System.Windows.Forms.RadioButton TrashRadioButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer FrameTimer;
        private System.Windows.Forms.TextBox ChosedBlockTextBox;
        private System.Windows.Forms.Label label1;
    }
}

