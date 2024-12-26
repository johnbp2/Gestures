using JohnBPearson.Windows.Forms.Controls;

namespace JohnBPearson.Windows.Forms.Gestures
{
    partial class SettingsDialog
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.transparentFlowPanel1 = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.rbFlashOn = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.rbFlashOff = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbAutoSaveOn = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.rbAutoSaveOff = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.lblMinimizeToTray = new System.Windows.Forms.Label();
            this.rbMinimizeToTrayOn = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.rbMinimizeToTrayOff = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbToastOptions = new System.Windows.Forms.ComboBox();
            this.transparentPanel1 = new JohnBPearson.Windows.Forms.Controls.TransparentPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.somewhatBetterButton1 = new JohnBPearson.Windows.Forms.Controls.SomewhatBetterButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.transparentFlowPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.transparentPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // transparentFlowPanel1
            // 
            this.transparentFlowPanel1.Controls.Add(this.tableLayoutPanel1);
            this.transparentFlowPanel1.Controls.Add(this.transparentPanel1);
            this.transparentFlowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transparentFlowPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.transparentFlowPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparentFlowPanel1.Name = "transparentFlowPanel1";
            this.transparentFlowPanel1.Size = new System.Drawing.Size(265, 223);
            this.transparentFlowPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.94574F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.rbFlashOn, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.rbFlashOff, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbAutoSaveOn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbAutoSaveOff, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMinimizeToTray, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbMinimizeToTrayOn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbMinimizeToTrayOff, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbToastOptions, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.somewhatBetterButton1, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(258, 173);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "flash window";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbFlashOn
            // 
            this.rbFlashOn.AutoSize = true;
            this.rbFlashOn.GroupName = "flash";
            this.rbFlashOn.GroupNameLevel = JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton.Level.Form;
            this.rbFlashOn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbFlashOn.Location = new System.Drawing.Point(90, 137);
            this.rbFlashOn.Name = "rbFlashOn";
            this.rbFlashOn.Size = new System.Drawing.Size(38, 17);
            this.rbFlashOn.TabIndex = 14;
            this.rbFlashOn.Text = "on";
            this.rbFlashOn.UseVisualStyleBackColor = true;
            // 
            // rbFlashOff
            // 
            this.rbFlashOff.AutoSize = true;
            this.rbFlashOff.GroupName = "flash";
            this.rbFlashOff.GroupNameLevel = JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton.Level.Form;
            this.rbFlashOff.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbFlashOff.Location = new System.Drawing.Point(175, 137);
            this.rbFlashOff.Name = "rbFlashOff";
            this.rbFlashOff.Size = new System.Drawing.Size(38, 17);
            this.rbFlashOff.TabIndex = 15;
            this.rbFlashOff.Text = "off";
            this.rbFlashOff.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "auto save";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbAutoSaveOn
            // 
            this.rbAutoSaveOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAutoSaveOn.AutoSize = true;
            this.rbAutoSaveOn.GroupName = "autosave";
            this.rbAutoSaveOn.GroupNameLevel = JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton.Level.Form;
            this.rbAutoSaveOn.Location = new System.Drawing.Point(90, 4);
            this.rbAutoSaveOn.Name = "rbAutoSaveOn";
            this.rbAutoSaveOn.Size = new System.Drawing.Size(79, 17);
            this.rbAutoSaveOn.TabIndex = 3;
            this.rbAutoSaveOn.Text = "on";
            this.rbAutoSaveOn.UseVisualStyleBackColor = true;
            // 
            // rbAutoSaveOff
            // 
            this.rbAutoSaveOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAutoSaveOff.AutoSize = true;
            this.rbAutoSaveOff.GroupName = "autosave";
            this.rbAutoSaveOff.GroupNameLevel = JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton.Level.Form;
            this.rbAutoSaveOff.Location = new System.Drawing.Point(175, 4);
            this.rbAutoSaveOff.Name = "rbAutoSaveOff";
            this.rbAutoSaveOff.Size = new System.Drawing.Size(80, 17);
            this.rbAutoSaveOff.TabIndex = 4;
            this.rbAutoSaveOff.Text = "off";
            this.rbAutoSaveOff.UseVisualStyleBackColor = true;
            // 
            // lblMinimizeToTray
            // 
            this.lblMinimizeToTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimizeToTray.AutoSize = true;
            this.lblMinimizeToTray.Location = new System.Drawing.Point(3, 28);
            this.lblMinimizeToTray.Name = "lblMinimizeToTray";
            this.lblMinimizeToTray.Size = new System.Drawing.Size(81, 13);
            this.lblMinimizeToTray.TabIndex = 5;
            this.lblMinimizeToTray.Text = "minimize to tray";
            this.lblMinimizeToTray.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbMinimizeToTrayOn
            // 
            this.rbMinimizeToTrayOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMinimizeToTrayOn.AutoSize = true;
            this.rbMinimizeToTrayOn.GroupName = "minimize";
            this.rbMinimizeToTrayOn.GroupNameLevel = JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton.Level.Form;
            this.rbMinimizeToTrayOn.Location = new System.Drawing.Point(90, 28);
            this.rbMinimizeToTrayOn.Name = "rbMinimizeToTrayOn";
            this.rbMinimizeToTrayOn.Size = new System.Drawing.Size(79, 13);
            this.rbMinimizeToTrayOn.TabIndex = 6;
            this.rbMinimizeToTrayOn.Text = "on";
            this.rbMinimizeToTrayOn.UseVisualStyleBackColor = true;
            // 
            // rbMinimizeToTrayOff
            // 
            this.rbMinimizeToTrayOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMinimizeToTrayOff.AutoSize = true;
            this.rbMinimizeToTrayOff.GroupName = "111";
            this.rbMinimizeToTrayOff.GroupNameLevel = JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton.Level.Form;
            this.rbMinimizeToTrayOff.Location = new System.Drawing.Point(175, 28);
            this.rbMinimizeToTrayOff.Name = "rbMinimizeToTrayOff";
            this.rbMinimizeToTrayOff.Size = new System.Drawing.Size(80, 13);
            this.rbMinimizeToTrayOff.TabIndex = 7;
            this.rbMinimizeToTrayOff.Text = "off";
            this.rbMinimizeToTrayOff.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bg Color";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Toast Options";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbToastOptions
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbToastOptions, 2);
            this.cbToastOptions.FormattingEnabled = true;
            this.cbToastOptions.Items.AddRange(new object[] {
            "All",
            "Save",
            "Hotkey",
            "None"});
            this.cbToastOptions.Location = new System.Drawing.Point(90, 47);
            this.cbToastOptions.Name = "cbToastOptions";
            this.cbToastOptions.Size = new System.Drawing.Size(165, 21);
            this.cbToastOptions.TabIndex = 12;
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.Controls.Add(this.btnSave);
            this.transparentPanel1.Controls.Add(this.btnCancel);
            this.transparentPanel1.Location = new System.Drawing.Point(3, 182);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Size = new System.Drawing.Size(258, 33);
            this.transparentPanel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(175, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(94, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.Color = System.Drawing.Color.LightGray;
            this.colorDialog1.FullOpen = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            // 
            // somewhatBetterButton1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.somewhatBetterButton1, 2);
            this.somewhatBetterButton1.EndColor = System.Drawing.Color.DimGray;
            this.somewhatBetterButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.somewhatBetterButton1.ForeColor = System.Drawing.Color.Black;
            this.somewhatBetterButton1.GradientAngle = 90;
            this.somewhatBetterButton1.Location = new System.Drawing.Point(92, 79);
            this.somewhatBetterButton1.Margin = new System.Windows.Forms.Padding(5);
            this.somewhatBetterButton1.MouseClickColor1 = System.Drawing.Color.DarkOrange;
            this.somewhatBetterButton1.MouseClickColor2 = System.Drawing.Color.Red;
            this.somewhatBetterButton1.MouseHoverColor1 = System.Drawing.Color.Yellow;
            this.somewhatBetterButton1.MouseHoverColor2 = System.Drawing.Color.DarkOrange;
            this.somewhatBetterButton1.Name = "somewhatBetterButton1";
            this.somewhatBetterButton1.Size = new System.Drawing.Size(161, 30);
            this.somewhatBetterButton1.StartColor = System.Drawing.Color.LightGray;
            this.somewhatBetterButton1.TabIndex = 16;
            this.somewhatBetterButton1.Text = "SELECT";
            this.somewhatBetterButton1.TextLocation_X = 36;
            this.somewhatBetterButton1.TextLocation_Y = 16;
            this.somewhatBetterButton1.Transparent1 = 150;
            this.somewhatBetterButton1.Transparent2 = 150;
            this.somewhatBetterButton1.UseVisualStyleBackColor = true;
            this.somewhatBetterButton1.Click += new System.EventHandler(this.somewhatBetterButton1_Click);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 223);
            this.Controls.Add(this.transparentFlowPanel1);
            this.Name = "SettingsDialog";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.transparentFlowPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.transparentPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TransparentFlowPanel transparentFlowPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.TransparentPanel transparentPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private Controls.AdvancedRadioButton rbAutoSaveOn;
        private Controls.AdvancedRadioButton rbAutoSaveOff;
        private System.Windows.Forms.Label lblMinimizeToTray;
        private Controls.AdvancedRadioButton rbMinimizeToTrayOn;
        private Controls.AdvancedRadioButton rbMinimizeToTrayOff;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbToastOptions;
        private System.Windows.Forms.Label label4;
        private AdvancedRadioButton rbFlashOn;
        private AdvancedRadioButton rbFlashOff;
        private SomewhatBetterButton notBetterButton1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Timer timer1;
        private SomewhatBetterButton somewhatBetterButton1;
    }
}