namespace Fitness_App
{
    partial class DayCheatMealReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DayCheatMealReport));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.cheatmealGrid = new System.Windows.Forms.DataGridView();
            this.PDFBtn = new System.Windows.Forms.Button();
            this.mealChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cheatmealGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mealChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // cheatmealGrid
            // 
            this.cheatmealGrid.AllowUserToAddRows = false;
            this.cheatmealGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cheatmealGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cheatmealGrid.Location = new System.Drawing.Point(362, 65);
            this.cheatmealGrid.Name = "cheatmealGrid";
            this.cheatmealGrid.ReadOnly = true;
            this.cheatmealGrid.Size = new System.Drawing.Size(533, 307);
            this.cheatmealGrid.TabIndex = 0;
            // 
            // PDFBtn
            // 
            this.PDFBtn.BackColor = System.Drawing.Color.DarkRed;
            this.PDFBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PDFBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PDFBtn.Image = ((System.Drawing.Image)(resources.GetObject("PDFBtn.Image")));
            this.PDFBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PDFBtn.Location = new System.Drawing.Point(765, 378);
            this.PDFBtn.Name = "PDFBtn";
            this.PDFBtn.Size = new System.Drawing.Size(79, 35);
            this.PDFBtn.TabIndex = 4;
            this.PDFBtn.Text = "PDF";
            this.PDFBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PDFBtn.UseVisualStyleBackColor = false;
            this.PDFBtn.Click += new System.EventHandler(this.PDFBtn_Click);
            // 
            // mealChart
            // 
            this.mealChart.BorderlineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            this.mealChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.mealChart.Legends.Add(legend1);
            this.mealChart.Location = new System.Drawing.Point(12, 65);
            this.mealChart.Name = "mealChart";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Calories";
            this.mealChart.Series.Add(series1);
            this.mealChart.Size = new System.Drawing.Size(331, 307);
            this.mealChart.TabIndex = 5;
            this.mealChart.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Cheat Day Calories Summary";
            this.mealChart.Titles.Add(title1);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(-1, -2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(80, 26);
            this.backBtn.TabIndex = 19;
            this.backBtn.Text = "BACK";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(907, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(816, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(91, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // DayCheatMealReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.mealChart);
            this.Controls.Add(this.PDFBtn);
            this.Controls.Add(this.cheatmealGrid);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DayCheatMealReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheat Day Report";
            this.Load += new System.EventHandler(this.DayCheatMealReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cheatmealGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mealChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView cheatmealGrid;
        private System.Windows.Forms.Button PDFBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart mealChart;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}