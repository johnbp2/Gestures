﻿using JohnBPearson.Windows.Interop;
using JohnBPearson.Windows.Forms.Controls;

namespace JohnBPearson.Windows.Forms.Gestures
{/// <summary>
/// 
/// </summary>
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelUpper = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.lblHotKeySelected = new System.Windows.Forms.Label();
            this.lblKey = new JohnBPearson.Windows.Forms.Controls.TemplatedLabel();
            this.cbHotkeySelection = new System.Windows.Forms.ComboBox();
            this.cbProtect = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelButtons = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.aLittleBetter_Save = new JohnBPearson.Windows.Forms.Controls.SomewhatBetterButton();
            this.btnReload = new JohnBPearson.Windows.Forms.Controls.SomewhatBetterButton();
            this.notBetterButton2 = new JohnBPearson.Windows.Forms.Controls.SomewhatBetterButton();
            this.panelOuter = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panelUpper.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Gestures Ok";
            this.notifyIcon1.BalloonTipTitle = "Gestures Ok";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Gestures Ok";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(706, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.listViewToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // listViewToolStripMenuItem
            // 
            this.listViewToolStripMenuItem.Name = "listViewToolStripMenuItem";
            this.listViewToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.listViewToolStripMenuItem.Text = "List View";
            this.listViewToolStripMenuItem.Click += new System.EventHandler(this.listViewToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panelUpper
            // 
            this.panelUpper.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelUpper.AutoSize = true;
            this.panelUpper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelUpper.Controls.Add(this.lblHotKeySelected);
            this.panelUpper.Controls.Add(this.lblKey);
            this.panelUpper.Controls.Add(this.cbHotkeySelection);
            this.panelUpper.Controls.Add(this.cbProtect);
            this.panelUpper.Controls.Add(this.lblDescription);
            this.panelUpper.Controls.Add(this.tbDesc);
            this.panelUpper.Controls.Add(this.lblValue);
            this.panelUpper.Controls.Add(this.tbValue);
            this.panelUpper.Controls.Add(this.label1);
            this.panelUpper.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelUpper.Location = new System.Drawing.Point(6, 6);
            this.panelUpper.Margin = new System.Windows.Forms.Padding(6);
            this.panelUpper.Name = "panelUpper";
            this.panelUpper.Size = new System.Drawing.Size(510, 421);
            this.panelUpper.TabIndex = 2;
            // 
            // lblHotKeySelected
            // 
            this.lblHotKeySelected.AutoSize = true;
            this.lblHotKeySelected.BackColor = System.Drawing.SystemColors.Menu;
            this.lblHotKeySelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHotKeySelected.Location = new System.Drawing.Point(10, 10);
            this.lblHotKeySelected.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.lblHotKeySelected.Name = "lblHotKeySelected";
            this.lblHotKeySelected.Size = new System.Drawing.Size(227, 26);
            this.lblHotKeySelected.TabIndex = 12;
            this.lblHotKeySelected.Text = "Select a gesture to modify";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblKey.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey.Location = new System.Drawing.Point(10, 46);
            this.lblKey.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.lblKey.MinimumSize = new System.Drawing.Size(5, 10);
            this.lblKey.Name = "lblKey";
            this.lblKey.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblKey.Size = new System.Drawing.Size(10, 24);
            this.lblKey.TabIndex = 9;
            this.lblKey.Template = "";
            this.lblKey.ValuesToApply = ((System.Collections.Generic.List<string>)(resources.GetObject("lblKey.ValuesToApply")));
            // 
            // cbHotkeySelection
            // 
            this.cbHotkeySelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHotkeySelection.FormattingEnabled = true;
            this.cbHotkeySelection.Location = new System.Drawing.Point(10, 80);
            this.cbHotkeySelection.Margin = new System.Windows.Forms.Padding(10, 10, 6, 0);
            this.cbHotkeySelection.Name = "cbHotkeySelection";
            this.cbHotkeySelection.Size = new System.Drawing.Size(62, 32);
            this.cbHotkeySelection.TabIndex = 0;
            this.cbHotkeySelection.TextUpdate += new System.EventHandler(this.cbHotkeySelection_TextUpdate);
            this.cbHotkeySelection.SelectedValueChanged += new System.EventHandler(this.cbHotkeySelection_SelectedValueChanged);
            // 
            // cbProtect
            // 
            this.cbProtect.AutoSize = true;
            this.cbProtect.Location = new System.Drawing.Point(10, 115);
            this.cbProtect.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cbProtect.Name = "cbProtect";
            this.cbProtect.Size = new System.Drawing.Size(97, 28);
            this.cbProtect.TabIndex = 1002;
            this.cbProtect.Text = "Protect?";
            this.cbProtect.UseVisualStyleBackColor = true;
            this.cbProtect.CheckedChanged += new System.EventHandler(this.cbProtect_CheckedChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.SystemColors.Menu;
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescription.Location = new System.Drawing.Point(10, 156);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(106, 26);
            this.lblDescription.TabIndex = 999;
            this.lblDescription.Text = "Description";
            // 
            // tbDesc
            // 
            this.tbDesc.BackColor = System.Drawing.SystemColors.Info;
            this.tbDesc.Location = new System.Drawing.Point(10, 192);
            this.tbDesc.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(453, 68);
            this.tbDesc.TabIndex = 1;
            this.tbDesc.Leave += new System.EventHandler(this.tbDesc_Leave);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblValue.Location = new System.Drawing.Point(10, 270);
            this.lblValue.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(148, 24);
            this.lblValue.TabIndex = 10;
            this.lblValue.Text = "Gesture Payload";
            // 
            // tbValue
            // 
            this.tbValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbValue.BackColor = System.Drawing.SystemColors.Info;
            this.tbValue.Location = new System.Drawing.Point(10, 304);
            this.tbValue.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.tbValue.MaximumSize = new System.Drawing.Size(500, 335);
            this.tbValue.MinimumSize = new System.Drawing.Size(9, 50);
            this.tbValue.Multiline = true;
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(500, 93);
            this.tbValue.TabIndex = 2;
            this.tbValue.Leave += new System.EventHandler(this.tbValue_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(0, 397);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 1001;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelButtons.AutoSize = true;
            this.panelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelButtons.Controls.Add(this.aLittleBetter_Save);
            this.panelButtons.Controls.Add(this.btnReload);
            this.panelButtons.Controls.Add(this.notBetterButton2);
            this.panelButtons.Location = new System.Drawing.Point(38, 436);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(8);
            this.panelButtons.Size = new System.Drawing.Size(446, 73);
            this.panelButtons.TabIndex = 9;
            // 
            // aLittleBetter_Save
            // 
            this.aLittleBetter_Save.AutoSize = true;
            this.aLittleBetter_Save.EndColor = System.Drawing.Color.LightSkyBlue;
            this.aLittleBetter_Save.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.aLittleBetter_Save.FlatAppearance.BorderSize = 3;
            this.aLittleBetter_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aLittleBetter_Save.Font = new System.Drawing.Font("M+1 Nerd Font Med", 12F);
            this.aLittleBetter_Save.ForeColor = System.Drawing.Color.Black;
            this.aLittleBetter_Save.GradientAngle = 10;
            this.aLittleBetter_Save.Image = ((System.Drawing.Image)(resources.GetObject("aLittleBetter_Save.Image")));
            this.aLittleBetter_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aLittleBetter_Save.Location = new System.Drawing.Point(11, 11);
            this.aLittleBetter_Save.MinimumSize = new System.Drawing.Size(98, 51);
            this.aLittleBetter_Save.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.aLittleBetter_Save.MouseClickColor2 = System.Drawing.Color.Magenta;
            this.aLittleBetter_Save.MouseHoverColor1 = System.Drawing.Color.Magenta;
            this.aLittleBetter_Save.MouseHoverColor2 = System.Drawing.Color.Transparent;
            this.aLittleBetter_Save.Name = "aLittleBetter_Save";
            this.aLittleBetter_Save.Size = new System.Drawing.Size(98, 51);
            this.aLittleBetter_Save.StartColor = System.Drawing.Color.DimGray;
            this.aLittleBetter_Save.TabIndex = 3;
            this.aLittleBetter_Save.Text = "Save";
            this.aLittleBetter_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aLittleBetter_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.aLittleBetter_Save.TextLocation_X = 0;
            this.aLittleBetter_Save.TextLocation_Y = 0;
            this.aLittleBetter_Save.Transparent1 = 150;
            this.aLittleBetter_Save.Transparent2 = 150;
            this.aLittleBetter_Save.UseVisualStyleBackColor = false;
            this.aLittleBetter_Save.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReload
            // 
            this.btnReload.AutoSize = true;
            this.btnReload.EndColor = System.Drawing.Color.LightSkyBlue;
            this.btnReload.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReload.FlatAppearance.BorderSize = 3;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("M+1 Nerd Font Med", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.Black;
            this.btnReload.GradientAngle = 65;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReload.Location = new System.Drawing.Point(115, 11);
            this.btnReload.MinimumSize = new System.Drawing.Size(134, 51);
            this.btnReload.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.btnReload.MouseClickColor2 = System.Drawing.Color.Magenta;
            this.btnReload.MouseHoverColor1 = System.Drawing.Color.Magenta;
            this.btnReload.MouseHoverColor2 = System.Drawing.Color.Transparent;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(134, 51);
            this.btnReload.StartColor = System.Drawing.Color.DimGray;
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "Reload";
            this.btnReload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReload.TextLocation_X = 0;
            this.btnReload.TextLocation_Y = 0;
            this.btnReload.Transparent1 = 150;
            this.btnReload.Transparent2 = 150;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // notBetterButton2
            // 
            this.notBetterButton2.AutoSize = true;
            this.notBetterButton2.EndColor = System.Drawing.Color.LightSkyBlue;
            this.notBetterButton2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.notBetterButton2.FlatAppearance.BorderSize = 3;
            this.notBetterButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notBetterButton2.Font = new System.Drawing.Font("M+1 Nerd Font Med", 12F);
            this.notBetterButton2.ForeColor = System.Drawing.Color.Black;
            this.notBetterButton2.GradientAngle = 65;
            this.notBetterButton2.Image = ((System.Drawing.Image)(resources.GetObject("notBetterButton2.Image")));
            this.notBetterButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.notBetterButton2.Location = new System.Drawing.Point(255, 11);
            this.notBetterButton2.MinimumSize = new System.Drawing.Size(180, 51);
            this.notBetterButton2.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.notBetterButton2.MouseClickColor2 = System.Drawing.Color.Magenta;
            this.notBetterButton2.MouseHoverColor1 = System.Drawing.Color.Magenta;
            this.notBetterButton2.MouseHoverColor2 = System.Drawing.Color.Transparent;
            this.notBetterButton2.Name = "notBetterButton2";
            this.notBetterButton2.Size = new System.Drawing.Size(180, 51);
            this.notBetterButton2.StartColor = System.Drawing.Color.DimGray;
            this.notBetterButton2.TabIndex = 5;
            this.notBetterButton2.Text = "Copy payload";
            this.notBetterButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.notBetterButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.notBetterButton2.TextLocation_X = 0;
            this.notBetterButton2.TextLocation_Y = 0;
            this.notBetterButton2.Transparent1 = 150;
            this.notBetterButton2.Transparent2 = 150;
            this.notBetterButton2.UseVisualStyleBackColor = true;
            this.notBetterButton2.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // panelOuter
            // 
            this.panelOuter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelOuter.AutoSize = true;
            this.panelOuter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelOuter.Controls.Add(this.panelUpper);
            this.panelOuter.Controls.Add(this.panelButtons);
            this.panelOuter.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelOuter.Location = new System.Drawing.Point(0, 27);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(522, 512);
            this.panelOuter.TabIndex = 10;
            this.panelOuter.WrapContents = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(706, 666);
            this.Controls.Add(this.panelOuter);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Gestures";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            this.Controls.SetChildIndex(this.panelOuter, 0);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelUpper.ResumeLayout(false);
            this.panelUpper.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panelOuter.ResumeLayout(false);
            this.panelOuter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel panelUpper;
        private System.Windows.Forms.ComboBox cbHotkeySelection;
       // private System.Windows.Forms.Button btnCopyGuildLog;
       // private Controls.TransparentPanel transparentPanel1;
       // private System.Windows.Forms.ListBox lbPlanetsList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private TemplatedLabel lblKey;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbValue;
        private TransparentFlowPanel panelOuter;
        private TransparentFlowPanel panelButtons;
        private System.Windows.Forms.ToolStripMenuItem listViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private SomewhatBetterButton aLittleBetter_Save;
        private SomewhatBetterButton btnReload;
        private SomewhatBetterButton notBetterButton2;
        private System.Windows.Forms.Label lblHotKeySelected;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbProtect;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}

