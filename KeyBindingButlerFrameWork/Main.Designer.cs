using JohnBPearson.Windows.Interop;
using JohnBPearson.Windows.Forms.Controls;

namespace JohnBPearson.Windows.Forms.KeyBindingButler
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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentFlowPanel1 = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.lblKey = new JohnBPearson.Windows.Forms.Controls.TemplatedLabel();
            this.cbHotkeySelection = new System.Windows.Forms.ComboBox();
            this.templatedLabel1 = new JohnBPearson.Windows.Forms.Controls.TemplatedLabel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.transparentPanel2 = new JohnBPearson.Windows.Forms.Controls.TransparentPanel();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblGuildAd = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.transparentFlowPanel1.SuspendLayout();
            this.transparentPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "The butler is in";
            this.notifyIcon1.BalloonTipTitle = "Key Binding Butler";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "The \"Key Binding Butler\" is in";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // transparentFlowPanel1
            // 
            this.transparentFlowPanel1.Controls.Add(this.lblKey);
            this.transparentFlowPanel1.Controls.Add(this.cbHotkeySelection);
            this.transparentFlowPanel1.Controls.Add(this.templatedLabel1);
            this.transparentFlowPanel1.Controls.Add(this.lblDescription);
            this.transparentFlowPanel1.Controls.Add(this.tbDesc);
            this.transparentFlowPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.transparentFlowPanel1.Location = new System.Drawing.Point(42, 39);
            this.transparentFlowPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.transparentFlowPanel1.Name = "transparentFlowPanel1";
            this.transparentFlowPanel1.Size = new System.Drawing.Size(321, 168);
            this.transparentFlowPanel1.TabIndex = 2;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblKey.Location = new System.Drawing.Point(3, 0);
            this.lblKey.MinimumSize = new System.Drawing.Size(5, 10);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(5, 24);
            this.lblKey.TabIndex = 9;
            this.lblKey.Template = null;
            this.lblKey.TemplateValues = ((System.Collections.Generic.List<string>)(resources.GetObject("lblKey.TemplateValues")));
            // 
            // cbHotkeySelection
            // 
            this.cbHotkeySelection.FormattingEnabled = true;
            this.cbHotkeySelection.Location = new System.Drawing.Point(6, 30);
            this.cbHotkeySelection.Margin = new System.Windows.Forms.Padding(6);
            this.cbHotkeySelection.Name = "cbHotkeySelection";
            this.cbHotkeySelection.Size = new System.Drawing.Size(218, 32);
            this.cbHotkeySelection.TabIndex = 0;
            this.cbHotkeySelection.TextUpdate += new System.EventHandler(this.cbHotkeySelection_TextUpdate);
            this.cbHotkeySelection.SelectedValueChanged += new System.EventHandler(this.cbHotkeySelection_SelectedValueChanged);
            // 
            // templatedLabel1
            // 
            this.templatedLabel1.AutoSize = true;
            this.templatedLabel1.Location = new System.Drawing.Point(3, 57);
            this.templatedLabel1.Name = "templatedLabel1";
            this.templatedLabel1.Size = new System.Drawing.Size(0, 24);
            this.templatedLabel1.TabIndex = 10;
            this.templatedLabel1.Template = null;
            this.templatedLabel1.TemplateValues = null;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.SystemColors.Menu;
            this.lblDescription.Location = new System.Drawing.Point(3, 81);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(104, 24);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(3, 108);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(248, 32);
            this.tbDesc.TabIndex = 7;
            this.tbDesc.TextChanged += new System.EventHandler(this.tbDesc_TextChanged);
            this.tbDesc.Leave += new System.EventHandler(this.tbDesc_Leave);
            // 
            // transparentPanel2
            // 
            this.transparentPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.transparentPanel2.Controls.Add(this.btnReload);
            this.transparentPanel2.Controls.Add(this.btnCopy);
            this.transparentPanel2.Controls.Add(this.btnSave);
            this.transparentPanel2.Controls.Add(this.lblGuildAd);
            this.transparentPanel2.Controls.Add(this.tbValue);
            this.transparentPanel2.Location = new System.Drawing.Point(11, 219);
            this.transparentPanel2.Margin = new System.Windows.Forms.Padding(6);
            this.transparentPanel2.Name = "transparentPanel2";
            this.transparentPanel2.Size = new System.Drawing.Size(573, 203);
            this.transparentPanel2.TabIndex = 1;
            // 
            // btnReload
            // 
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(406, -2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(97, 32);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "Refresh";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(406, 46);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(97, 32);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy ";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnSave.Location = new System.Drawing.Point(406, 112);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 37);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblGuildAd
            // 
            this.lblGuildAd.AutoSize = true;
            this.lblGuildAd.Location = new System.Drawing.Point(26, 7);
            this.lblGuildAd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGuildAd.Name = "lblGuildAd";
            this.lblGuildAd.Size = new System.Drawing.Size(0, 24);
            this.lblGuildAd.TabIndex = 3;
            // 
            // tbValue
            // 
            this.tbValue.BackColor = System.Drawing.SystemColors.Info;
            this.tbValue.Location = new System.Drawing.Point(0, 7);
            this.tbValue.Margin = new System.Windows.Forms.Padding(0);
            this.tbValue.Multiline = true;
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(363, 142);
            this.tbValue.TabIndex = 0;
            this.tbValue.TabStop = false;
            this.tbValue.Leave += new System.EventHandler(this.tbValue_Leave);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 428);
            this.Controls.Add(this.transparentFlowPanel1);
            this.Controls.Add(this.transparentPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Butler copy my...";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.transparentFlowPanel1.ResumeLayout(false);
            this.transparentFlowPanel1.PerformLayout();
            this.transparentPanel2.ResumeLayout(false);
            this.transparentPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private JohnBPearson.Windows.Forms.Controls.TransparentPanel transparentPanel2;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label lblGuildAd;
        private System.Windows.Forms.Button btnSave;
        private JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel transparentFlowPanel1;
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
        private System.Windows.Forms.Button btnCopy;
        private TemplatedLabel templatedLabel1;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnReload;
    }
}

