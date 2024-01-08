namespace Fitness_App
{
    partial class ReportMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportMainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.reportBtn_2 = new System.Windows.Forms.Button();
            this.reportBtn_1 = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // reportBtn_2
            // 
            this.reportBtn_2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.reportBtn_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.reportBtn_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportBtn_2.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBtn_2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportBtn_2.Location = new System.Drawing.Point(448, 178);
            this.reportBtn_2.Name = "reportBtn_2";
            this.reportBtn_2.Size = new System.Drawing.Size(283, 77);
            this.reportBtn_2.TabIndex = 4;
            this.reportBtn_2.Text = "Cheat Day Report ";
            this.reportBtn_2.UseVisualStyleBackColor = false;
            this.reportBtn_2.Click += new System.EventHandler(this.reportBtn_2_Click);
            // 
            // reportBtn_1
            // 
            this.reportBtn_1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.reportBtn_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.reportBtn_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportBtn_1.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBtn_1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportBtn_1.Location = new System.Drawing.Point(68, 178);
            this.reportBtn_1.Name = "reportBtn_1";
            this.reportBtn_1.Size = new System.Drawing.Size(308, 77);
            this.reportBtn_1.TabIndex = 3;
            this.reportBtn_1.Text = "Weekly Fitness Report";
            this.reportBtn_1.UseVisualStyleBackColor = false;
            this.reportBtn_1.Click += new System.EventHandler(this.reportBtn_1_Click);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.backBtn.Location = new System.Drawing.Point(290, 322);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(210, 42);
            this.backBtn.TabIndex = 6;
            this.backBtn.Text = "BACK";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(631, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(169, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // ReportMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.reportBtn_2);
            this.Controls.Add(this.reportBtn_1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReportMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Reports";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button reportBtn_2;
        private System.Windows.Forms.Button reportBtn_1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}