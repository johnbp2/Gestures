namespace JohnBPearson.Windows.Forms.Gestures
{
    partial class ListView
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
            base.Dispose(disposing);S
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListView));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.transparentFlowPanel1 = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.transparentFlowPanel2 = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.btnSave = new JohnBPearson.Windows.Forms.Controls.NotBetterButton();
            this.btnExport = new JohnBPearson.Windows.Forms.Controls.NotBetterButton();
            this.aLittleBetter_Import = new JohnBPearson.Windows.Forms.Controls.NotBetterButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.transparentFlowPanel1.SuspendLayout();
            this.transparentFlowPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(300, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(797, 378);
            this.dataGridView1.TabIndex = 0;
            // 
            // transparentFlowPanel1
            // 
            this.transparentFlowPanel1.Controls.Add(this.dataGridView1);
            this.transparentFlowPanel1.Controls.Add(this.transparentFlowPanel2);
            this.transparentFlowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transparentFlowPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.transparentFlowPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparentFlowPanel1.Name = "transparentFlowPanel1";
            this.transparentFlowPanel1.Size = new System.Drawing.Size(800, 461);
            this.transparentFlowPanel1.TabIndex = 1;
            // 
            // transparentFlowPanel2
            // 
            this.transparentFlowPanel2.Controls.Add(this.btnSave);
            this.transparentFlowPanel2.Controls.Add(this.btnExport);
            this.transparentFlowPanel2.Controls.Add(this.aLittleBetter_Import);
            this.transparentFlowPanel2.Location = new System.Drawing.Point(3, 387);
            this.transparentFlowPanel2.Name = "transparentFlowPanel2";
            this.transparentFlowPanel2.Size = new System.Drawing.Size(624, 62);
            this.transparentFlowPanel2.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.EndColor = System.Drawing.Color.LightSlateGray;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GradientAngle = 90;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.MouseClickColor1 = System.Drawing.Color.SlateGray;
            this.btnSave.MouseClickColor2 = System.Drawing.Color.LightSlateGray;
            this.btnSave.MouseHoverColor1 = System.Drawing.Color.DarkOrange;
            this.btnSave.MouseHoverColor2 = System.Drawing.Color.DarkOrange;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 50);
            this.btnSave.StartColor = System.Drawing.Color.SlateGray;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextLocation_X = 1;
            this.btnSave.TextLocation_Y = 1;
            this.btnSave.Transparent1 = 150;
            this.btnSave.Transparent2 = 20;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExport.EndColor = System.Drawing.Color.LightSlateGray;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExport.FlatAppearance.BorderSize = 2;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.GradientAngle = 90;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.Location = new System.Drawing.Point(136, 3);
            this.btnExport.MouseClickColor1 = System.Drawing.Color.SlateGray;
            this.btnExport.MouseClickColor2 = System.Drawing.Color.LightSlateGray;
            this.btnExport.MouseHoverColor1 = System.Drawing.Color.DarkOrange;
            this.btnExport.MouseHoverColor2 = System.Drawing.Color.DarkOrange;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(115, 50);
            this.btnExport.StartColor = System.Drawing.Color.SlateGray;
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.TextLocation_X = 1;
            this.btnExport.TextLocation_Y = 1;
            this.btnExport.Transparent1 = 150;
            this.btnExport.Transparent2 = 20;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // aLittleBetter_Import
            // 
            this.aLittleBetter_Import.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aLittleBetter_Import.BackColor = System.Drawing.SystemColors.ControlLight;
            this.aLittleBetter_Import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.aLittleBetter_Import.EndColor = System.Drawing.Color.LightSlateGray;
            this.aLittleBetter_Import.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.aLittleBetter_Import.FlatAppearance.BorderSize = 2;
            this.aLittleBetter_Import.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.aLittleBetter_Import.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aLittleBetter_Import.ForeColor = System.Drawing.Color.Black;
            this.aLittleBetter_Import.GradientAngle = 90;
            this.aLittleBetter_Import.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.aLittleBetter_Import.Location = new System.Drawing.Point(257, 3);
            this.aLittleBetter_Import.MouseClickColor1 = System.Drawing.Color.SlateGray;
            this.aLittleBetter_Import.MouseClickColor2 = System.Drawing.Color.LightSlateGray;
            this.aLittleBetter_Import.MouseHoverColor1 = System.Drawing.Color.DarkOrange;
            this.aLittleBetter_Import.MouseHoverColor2 = System.Drawing.Color.DarkOrange;
            this.aLittleBetter_Import.Name = "aLittleBetter_Import";
            this.aLittleBetter_Import.Size = new System.Drawing.Size(115, 50);
            this.aLittleBetter_Import.StartColor = System.Drawing.Color.SlateGray;
            this.aLittleBetter_Import.TabIndex = 3;
            this.aLittleBetter_Import.Text = "Import";
            this.aLittleBetter_Import.TextLocation_X = 1;
            this.aLittleBetter_Import.TextLocation_Y = 1;
            this.aLittleBetter_Import.Transparent1 = 150;
            this.aLittleBetter_Import.Transparent2 = 20;
            this.aLittleBetter_Import.UseVisualStyleBackColor = true;
            this.aLittleBetter_Import.Click += new System.EventHandler(this.aLittleBetter_Import_Click);
           // this.aLittleBetter_Import.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.aLittleBetter_Import_ChangeUICues);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "json";
            this.openFileDialog1.FileName = "import.json";
            this.openFileDialog1.Filter = "Json File | *.json";
            this.openFileDialog1.InitialDirectory = "%userprofile%";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.Title = "Open exported json";
            // 
            // ListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.transparentFlowPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListView";
            this.Text = "List View";
            this.Load += new System.EventHandler(this.ListView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.transparentFlowPanel1.ResumeLayout(false);
            this.transparentFlowPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Controls.TransparentFlowPanel transparentFlowPanel1;
        private Controls.NotBetterButton btnSave;
        private Controls.TransparentFlowPanel transparentFlowPanel2;
        private Controls.NotBetterButton btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Controls.NotBetterButton aLittleBetter_Import;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}