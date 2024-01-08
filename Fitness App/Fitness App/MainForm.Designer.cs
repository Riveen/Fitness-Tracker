namespace Fitness_App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.workoutBtn = new System.Windows.Forms.Button();
            this.mealBtn = new System.Windows.Forms.Button();
            this.weightBtn = new System.Windows.Forms.Button();
            this.reportBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // workoutBtn
            // 
            this.workoutBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.workoutBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.workoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.workoutBtn.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workoutBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.workoutBtn.Location = new System.Drawing.Point(119, 150);
            this.workoutBtn.Name = "workoutBtn";
            this.workoutBtn.Size = new System.Drawing.Size(210, 42);
            this.workoutBtn.TabIndex = 1;
            this.workoutBtn.Text = "Workout";
            this.workoutBtn.UseVisualStyleBackColor = false;
            this.workoutBtn.Click += new System.EventHandler(this.workoutBtn_Click);
            // 
            // mealBtn
            // 
            this.mealBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.mealBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mealBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mealBtn.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mealBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mealBtn.Location = new System.Drawing.Point(440, 150);
            this.mealBtn.Name = "mealBtn";
            this.mealBtn.Size = new System.Drawing.Size(210, 42);
            this.mealBtn.TabIndex = 2;
            this.mealBtn.Text = "Cheat Meal";
            this.mealBtn.UseVisualStyleBackColor = false;
            this.mealBtn.Click += new System.EventHandler(this.mealBtn_Click);
            // 
            // weightBtn
            // 
            this.weightBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.weightBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.weightBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.weightBtn.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.weightBtn.Location = new System.Drawing.Point(119, 254);
            this.weightBtn.Name = "weightBtn";
            this.weightBtn.Size = new System.Drawing.Size(210, 42);
            this.weightBtn.TabIndex = 3;
            this.weightBtn.Text = "Track Weight";
            this.weightBtn.UseVisualStyleBackColor = false;
            this.weightBtn.Click += new System.EventHandler(this.weightBtn_Click);
            // 
            // reportBtn
            // 
            this.reportBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.reportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.reportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportBtn.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportBtn.Location = new System.Drawing.Point(440, 254);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(210, 42);
            this.reportBtn.TabIndex = 4;
            this.reportBtn.Text = "REPORTS";
            this.reportBtn.UseVisualStyleBackColor = false;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.exitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exitBtn.Location = new System.Drawing.Point(281, 346);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(210, 42);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "EXIT";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(631, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(169, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.reportBtn);
            this.Controls.Add(this.weightBtn);
            this.Controls.Add(this.mealBtn);
            this.Controls.Add(this.workoutBtn);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fitness Tracking App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button workoutBtn;
        private System.Windows.Forms.Button mealBtn;
        private System.Windows.Forms.Button weightBtn;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

