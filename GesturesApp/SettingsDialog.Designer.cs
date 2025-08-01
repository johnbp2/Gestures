﻿using JohnBPearson.Windows.Forms.Controls;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbAutoSaveOn = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.rbAutoSaveOff = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.lblMinimizeToTray = new System.Windows.Forms.Label();
            this.rbMinimizeToTrayOn = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.rbMinimizeToTrayOff = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbToastOptions = new System.Windows.Forms.ComboBox();
            this.somewhatBetterButton1 = new JohnBPearson.Windows.Forms.Controls.SomewhatBetterButton();
            this.rbFlashOff = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbFlashOn = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbJsonOn = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.rbJsonOff = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.rbLastSavedOn = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.rbLastSavedOff = new JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.somewhatBetterButton2 = new JohnBPearson.Windows.Forms.Controls.SomewhatBetterButton();
            this.transparentPanel1 = new JohnBPearson.Windows.Forms.Controls.TransparentPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.transparentFlowPanel1 = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.transparentPanel1.SuspendLayout();
            this.transparentFlowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.90539F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.24056F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.85405F));
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
            this.tableLayoutPanel1.Controls.Add(this.rbFlashOff, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.rbFlashOn, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.rbJsonOn, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.rbJsonOff, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.rbLastSavedOn, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.rbLastSavedOff, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbFile, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.somewhatBetterButton2, 2, 8);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(502, 284);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
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
            this.rbAutoSaveOn.Location = new System.Drawing.Point(173, 4);
            this.rbAutoSaveOn.Name = "rbAutoSaveOn";
            this.rbAutoSaveOn.Size = new System.Drawing.Size(160, 17);
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
            this.rbAutoSaveOff.Location = new System.Drawing.Point(339, 4);
            this.rbAutoSaveOff.Name = "rbAutoSaveOff";
            this.rbAutoSaveOff.Size = new System.Drawing.Size(160, 17);
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
            this.lblMinimizeToTray.Size = new System.Drawing.Size(164, 13);
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
            this.rbMinimizeToTrayOn.Location = new System.Drawing.Point(173, 28);
            this.rbMinimizeToTrayOn.Name = "rbMinimizeToTrayOn";
            this.rbMinimizeToTrayOn.Size = new System.Drawing.Size(160, 13);
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
            this.rbMinimizeToTrayOff.Location = new System.Drawing.Point(339, 28);
            this.rbMinimizeToTrayOff.Name = "rbMinimizeToTrayOff";
            this.rbMinimizeToTrayOff.Size = new System.Drawing.Size(160, 13);
            this.rbMinimizeToTrayOff.TabIndex = 7;
            this.rbMinimizeToTrayOff.Text = "off";
            this.rbMinimizeToTrayOff.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
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
            this.label3.Size = new System.Drawing.Size(164, 13);
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
            this.cbToastOptions.Location = new System.Drawing.Point(173, 47);
            this.cbToastOptions.Name = "cbToastOptions";
            this.cbToastOptions.Size = new System.Drawing.Size(165, 21);
            this.cbToastOptions.TabIndex = 12;
            // 
            // somewhatBetterButton1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.somewhatBetterButton1, 2);
            this.somewhatBetterButton1.EndColor = System.Drawing.Color.DimGray;
            this.somewhatBetterButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.somewhatBetterButton1.ForeColor = System.Drawing.Color.Black;
            this.somewhatBetterButton1.GradientAngle = 90;
            this.somewhatBetterButton1.Location = new System.Drawing.Point(175, 79);
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
            // rbFlashOff
            // 
            this.rbFlashOff.AutoSize = true;
            this.rbFlashOff.GroupName = "flash";
            this.rbFlashOff.GroupNameLevel = JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton.Level.Form;
            this.rbFlashOff.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbFlashOff.Location = new System.Drawing.Point(339, 137);
            this.rbFlashOff.Name = "rbFlashOff";
            this.rbFlashOff.Size = new System.Drawing.Size(38, 17);
            this.rbFlashOff.TabIndex = 15;
            this.rbFlashOff.Text = "off";
            this.rbFlashOff.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(168, 13);
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
            this.rbFlashOn.Location = new System.Drawing.Point(173, 137);
            this.rbFlashOn.Name = "rbFlashOn";
            this.rbFlashOn.Size = new System.Drawing.Size(38, 17);
            this.rbFlashOn.TabIndex = 14;
            this.rbFlashOn.Text = "on";
            this.rbFlashOn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Save as Json";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "load  last saved json file on open";
            // 
            // rbJsonOn
            // 
            this.rbJsonOn.AutoSize = true;
            this.rbJsonOn.GroupName = "json";
            this.rbJsonOn.GroupNameLevel = JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton.Level.Form;
            this.rbJsonOn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbJsonOn.Location = new System.Drawing.Point(173, 167);
            this.rbJsonOn.Name = "rbJsonOn";
            this.rbJsonOn.Size = new System.Drawing.Size(38, 14);
            this.rbJsonOn.TabIndex = 19;
            this.rbJsonOn.Text = "on";
            this.rbJsonOn.UseVisualStyleBackColor = true;
            // 
            // rbJsonOff
            // 
            this.rbJsonOff.AutoSize = true;
            this.rbJsonOff.GroupName = "json";
            this.rbJsonOff.GroupNameLevel = JohnBPearson.Windows.Forms.Controls.AdvancedRadioButton.Level.Form;
            this.rbJsonOff.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbJsonOff.Location = new System.Drawing.Point(339, 167);
            this.rbJsonOff.Name = "rbJsonOff";
            this.rbJsonOff.Size = new System.Drawing.Size(38, 14);
            this.rbJsonOff.TabIndex = 20;
            this.rbJsonOff.Text = "off";
            this.rbJsonOff.UseVisualStyleBackColor = true;
            // 
            // rbLastSavedOn
            // 
            this.rbLastSavedOn.AutoSize = true;
            this.rbLastSavedOn.GroupName = "LastSaved";
            this.rbLastSavedOn.Location = new System.Drawing.Point(173, 187);
            this.rbLastSavedOn.Name = "rbLastSavedOn";
            this.rbLastSavedOn.Size = new System.Drawing.Size(38, 14);
            this.rbLastSavedOn.TabIndex = 21;
            this.rbLastSavedOn.Text = "on";
            this.rbLastSavedOn.UseVisualStyleBackColor = true;
            // 
            // rbLastSavedOff
            // 
            this.rbLastSavedOff.AutoSize = true;
            this.rbLastSavedOff.GroupName = "LastSaved";
            this.rbLastSavedOff.Location = new System.Drawing.Point(339, 187);
            this.rbLastSavedOff.Name = "rbLastSavedOff";
            this.rbLastSavedOff.Size = new System.Drawing.Size(38, 14);
            this.rbLastSavedOff.TabIndex = 22;
            this.rbLastSavedOff.Text = "off";
            this.rbLastSavedOff.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Default File";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // tbFile
            // 
            this.tbFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFile.Location = new System.Drawing.Point(173, 214);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(160, 20);
            this.tbFile.TabIndex = 24;
            // 
            // somewhatBetterButton2
            // 
            this.somewhatBetterButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.somewhatBetterButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.somewhatBetterButton2.EndColor = System.Drawing.Color.Silver;
            this.somewhatBetterButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.somewhatBetterButton2.ForeColor = System.Drawing.Color.Black;
            this.somewhatBetterButton2.GradientAngle = 45;
            this.somewhatBetterButton2.Location = new System.Drawing.Point(339, 209);
            this.somewhatBetterButton2.MouseClickColor1 = System.Drawing.Color.Orange;
            this.somewhatBetterButton2.MouseClickColor2 = System.Drawing.Color.Navy;
            this.somewhatBetterButton2.MouseHoverColor1 = System.Drawing.Color.Navy;
            this.somewhatBetterButton2.MouseHoverColor2 = System.Drawing.Color.Orange;
            this.somewhatBetterButton2.Name = "somewhatBetterButton2";
            this.somewhatBetterButton2.Size = new System.Drawing.Size(160, 29);
            this.somewhatBetterButton2.StartColor = System.Drawing.Color.Orange;
            this.somewhatBetterButton2.TabIndex = 25;
            this.somewhatBetterButton2.Text = "Select File";
            this.somewhatBetterButton2.TextLocation_X = 63;
            this.somewhatBetterButton2.TextLocation_Y = 6;
            this.somewhatBetterButton2.Transparent1 = 50;
            this.somewhatBetterButton2.Transparent2 = 150;
            this.somewhatBetterButton2.UseVisualStyleBackColor = true;
            this.somewhatBetterButton2.Click += new System.EventHandler(this.somewhatBetterButton2_Click);
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.transparentPanel1.AutoSize = true;
            this.transparentPanel1.Controls.Add(this.btnSave);
            this.transparentPanel1.Controls.Add(this.btnCancel);
            this.transparentPanel1.Location = new System.Drawing.Point(3, 293);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Size = new System.Drawing.Size(253, 29);
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
            // transparentFlowPanel1
            // 
            this.transparentFlowPanel1.Controls.Add(this.tableLayoutPanel1);
            this.transparentFlowPanel1.Controls.Add(this.transparentPanel1);
            this.transparentFlowPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.transparentFlowPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.transparentFlowPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparentFlowPanel1.Name = "transparentFlowPanel1";
            this.transparentFlowPanel1.Size = new System.Drawing.Size(508, 470);
            this.transparentFlowPanel1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 640);
            this.Controls.Add(this.transparentFlowPanel1);
            this.Name = "SettingsDialog";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.Controls.SetChildIndex(this.transparentFlowPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.transparentPanel1.ResumeLayout(false);
            this.transparentFlowPanel1.ResumeLayout(false);
            this.transparentFlowPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private AdvancedRadioButton rbJsonOn;
        private AdvancedRadioButton rbJsonOff;
        private AdvancedRadioButton rbLastSavedOn;
        private AdvancedRadioButton rbLastSavedOff;
        private TransparentFlowPanel transparentFlowPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFile;
        private SomewhatBetterButton somewhatBetterButton2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}