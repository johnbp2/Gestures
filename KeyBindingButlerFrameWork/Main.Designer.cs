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
            this.templatedLabel1 = new JohnBPearson.Windows.Forms.Controls.TemplatedLabel();
            this.cbHotkeySelection = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.cbSecure = new System.Windows.Forms.CheckBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.transparentFlowPanel3 = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.transparentFlowPanel4 = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.listViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.transparentFlowPanel1.SuspendLayout();
            this.transparentFlowPanel3.SuspendLayout();
            this.transparentFlowPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "The butler is in";
            this.notifyIcon1.BalloonTipTitle = "KeyInfo Binding Butler";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "The \"KeyInfo Binding Butler\" is in";
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1015, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
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
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // transparentFlowPanel1
            // 
            this.transparentFlowPanel1.Controls.Add(this.lblKey);
            this.transparentFlowPanel1.Controls.Add(this.templatedLabel1);
            this.transparentFlowPanel1.Controls.Add(this.cbHotkeySelection);
            this.transparentFlowPanel1.Controls.Add(this.lblDescription);
            this.transparentFlowPanel1.Controls.Add(this.tbDesc);
            this.transparentFlowPanel1.Controls.Add(this.cbSecure);
            this.transparentFlowPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.transparentFlowPanel1.Location = new System.Drawing.Point(6, 6);
            this.transparentFlowPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.transparentFlowPanel1.Name = "transparentFlowPanel1";
            this.transparentFlowPanel1.Size = new System.Drawing.Size(453, 329);
            this.transparentFlowPanel1.TabIndex = 2;
            // 
            // lblKey
            // 
            this.lblKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblKey.AutoSize = true;
            this.lblKey.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblKey.Location = new System.Drawing.Point(155, 0);
            this.lblKey.Margin = new System.Windows.Forms.Padding(0);
            this.lblKey.MinimumSize = new System.Drawing.Size(5, 10);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(5, 24);
            this.lblKey.TabIndex = 9;
            this.lblKey.Template = "";
            this.lblKey.TemplateValues = ((System.Collections.Generic.List<string>)(resources.GetObject("lblKey.TemplateValues")));
            // 
            // templatedLabel1
            // 
            this.templatedLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.templatedLabel1.AutoSize = true;
            this.templatedLabel1.Location = new System.Drawing.Point(144, 24);
            this.templatedLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.templatedLabel1.MinimumSize = new System.Drawing.Size(27, 7);
            this.templatedLabel1.Name = "templatedLabel1";
            this.templatedLabel1.Size = new System.Drawing.Size(27, 24);
            this.templatedLabel1.TabIndex = 10;
            this.templatedLabel1.Template = "";
            this.templatedLabel1.TemplateValues = null;
            // 
            // cbHotkeySelection
            // 
            this.cbHotkeySelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHotkeySelection.FormattingEnabled = true;
            this.cbHotkeySelection.Location = new System.Drawing.Point(6, 49);
            this.cbHotkeySelection.Margin = new System.Windows.Forms.Padding(6, 1, 6, 0);
            this.cbHotkeySelection.Name = "cbHotkeySelection";
            this.cbHotkeySelection.Size = new System.Drawing.Size(106, 32);
            this.cbHotkeySelection.TabIndex = 0;
            this.cbHotkeySelection.TextUpdate += new System.EventHandler(this.cbHotkeySelection_TextUpdate);
            this.cbHotkeySelection.SelectedValueChanged += new System.EventHandler(this.cbHotkeySelection_SelectedValueChanged);
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
            this.tbDesc.Size = new System.Drawing.Size(309, 68);
            this.tbDesc.TabIndex = 7;
            this.tbDesc.TextChanged += new System.EventHandler(this.tbDesc_TextChanged);
            this.tbDesc.Leave += new System.EventHandler(this.tbDesc_Leave);
            // 
            // cbSecure
            // 
            this.cbSecure.AutoSize = true;
            this.cbSecure.Location = new System.Drawing.Point(2, 181);
            this.cbSecure.Margin = new System.Windows.Forms.Padding(2);
            this.cbSecure.Name = "cbSecure";
            this.cbSecure.Size = new System.Drawing.Size(100, 28);
            this.cbSecure.TabIndex = 11;
            this.cbSecure.Text = "Secure?";
            this.cbSecure.UseVisualStyleBackColor = true;
            this.cbSecure.CheckedChanged += new System.EventHandler(this.cbSecure_CheckedChanged);
            // 
            // tbValue
            // 
            this.tbValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbValue.BackColor = System.Drawing.SystemColors.Info;
            this.tbValue.Location = new System.Drawing.Point(0, 341);
            this.tbValue.Margin = new System.Windows.Forms.Padding(0);
            this.tbValue.MaximumSize = new System.Drawing.Size(500, 335);
            this.tbValue.MinimumSize = new System.Drawing.Size(9, 50);
            this.tbValue.Multiline = true;
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(329, 93);
            this.tbValue.TabIndex = 0;
            this.tbValue.TabStop = false;
            this.tbValue.Leave += new System.EventHandler(this.tbValue_Leave);
            // 
            // transparentFlowPanel3
            // 
            this.transparentFlowPanel3.Controls.Add(this.button1);
            this.transparentFlowPanel3.Controls.Add(this.button2);
            this.transparentFlowPanel3.Controls.Add(this.btnSave);
            this.transparentFlowPanel3.Location = new System.Drawing.Point(3, 437);
            this.transparentFlowPanel3.Name = "transparentFlowPanel3";
            this.transparentFlowPanel3.Size = new System.Drawing.Size(438, 61);
            this.transparentFlowPanel3.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(89, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 33);
            this.button2.TabIndex = 8;
            this.button2.Text = "Reload";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnSave.Location = new System.Drawing.Point(175, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 33);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // transparentFlowPanel4
            // 
            this.transparentFlowPanel4.Controls.Add(this.transparentFlowPanel1);
            this.transparentFlowPanel4.Controls.Add(this.tbValue);
            this.transparentFlowPanel4.Controls.Add(this.transparentFlowPanel3);
            this.transparentFlowPanel4.Location = new System.Drawing.Point(0, 27);
            this.transparentFlowPanel4.Name = "transparentFlowPanel4";
            this.transparentFlowPanel4.Size = new System.Drawing.Size(441, 601);
            this.transparentFlowPanel4.TabIndex = 10;
            // 
            // listViewToolStripMenuItem
            // 
            this.listViewToolStripMenuItem.Name = "listViewToolStripMenuItem";
            this.listViewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listViewToolStripMenuItem.Text = "List View";
            this.listViewToolStripMenuItem.Click += new System.EventHandler(this.listViewToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1015, 559);
            this.Controls.Add(this.transparentFlowPanel4);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
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
            this.transparentFlowPanel3.ResumeLayout(false);
            this.transparentFlowPanel4.ResumeLayout(false);
            this.transparentFlowPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
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
        private TemplatedLabel templatedLabel1;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox cbSecure;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbValue;
        private TransparentFlowPanel transparentFlowPanel4;
        private TransparentFlowPanel transparentFlowPanel3;
        private System.Windows.Forms.ToolStripMenuItem listViewToolStripMenuItem;
    }
}

