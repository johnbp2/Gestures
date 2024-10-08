namespace JohnBPearson.Windows.Forms.KeyBindingButler
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.transparentFlowPanel1 = new JohnBPearson.Windows.Forms.Controls.TransparentFlowPanel();
            this.btnSave = new JohnBPearson.Windows.Forms.Controls.NotBetterButton();
            this.notBetterButton1 = new JohnBPearson.Windows.Forms.Controls.NotBetterButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.transparentFlowPanel1.SuspendLayout();
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
            this.transparentFlowPanel1.Controls.Add(this.notBetterButton1);
            this.transparentFlowPanel1.Controls.Add(this.btnSave);
            this.transparentFlowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transparentFlowPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.transparentFlowPanel1.Location = new System.Drawing.Point(0, 0);
            this.transparentFlowPanel1.Name = "transparentFlowPanel1";
            this.transparentFlowPanel1.Size = new System.Drawing.Size(800, 600);
            this.transparentFlowPanel1.TabIndex = 1;
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
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GradientAngle = 90;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.Location = new System.Drawing.Point(3, 443);
            this.btnSave.MouseClickColor1 = System.Drawing.Color.DarkOrange;
            this.btnSave.MouseClickColor2 = System.Drawing.Color.Red;
            this.btnSave.MouseHoverColor1 = System.Drawing.Color.Yellow;
            this.btnSave.MouseHoverColor2 = System.Drawing.Color.DarkOrange;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 50);
            this.btnSave.StartColor = System.Drawing.Color.SlateGray;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSave.TextLocation_X = 1;
            this.btnSave.TextLocation_Y = 1;
            this.btnSave.Transparent1 = 150;
            this.btnSave.Transparent2 = 20;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // notBetterButton1
            // 
            
            this.notBetterButton1.EndColor = System.Drawing.Color.DarkBlue;
            this.notBetterButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notBetterButton1.ForeColor = System.Drawing.Color.White;
            this.notBetterButton1.GradientAngle = 90;
            this.notBetterButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.notBetterButton1.Location = new System.Drawing.Point(3, 387);
            this.notBetterButton1.MouseClickColor1 = System.Drawing.Color.DarkOrange;
            this.notBetterButton1.MouseClickColor2 = System.Drawing.Color.Red;
            this.notBetterButton1.MouseHoverColor1 = System.Drawing.Color.Yellow;
            this.notBetterButton1.MouseHoverColor2 = System.Drawing.Color.DarkOrange;
            this.notBetterButton1.Name = "notBetterButton1";
            this.notBetterButton1.Size = new System.Drawing.Size(200, 50);
            this.notBetterButton1.StartColor = System.Drawing.Color.LightGreen;
            this.notBetterButton1.TabIndex = 2;
            this.notBetterButton1.Text = "notBetterButton1";
            this.notBetterButton1.TextLocation_X = 76;
            this.notBetterButton1.TextLocation_Y = 24;
            this.notBetterButton1.Transparent1 = 150;
            this.notBetterButton1.Transparent2 = 150;
            this.notBetterButton1.UseVisualStyleBackColor = true;
            // 
            // ListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.transparentFlowPanel1);
            this.Name = "ListView";
            this.Text = "ListView";
            this.Load += new System.EventHandler(this.ListView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.transparentFlowPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Controls.TransparentFlowPanel transparentFlowPanel1;
        private Controls.NotBetterButton btnSave;
        private Controls.NotBetterButton notBetterButton1;
    }
}