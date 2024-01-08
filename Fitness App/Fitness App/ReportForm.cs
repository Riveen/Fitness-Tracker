using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Fitness_App.net.azurewebsites.dbservice3;
using Fitness_App.xmlservice;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace Fitness_App
{
    public partial class ReportForm : Form
    {
        DataTable weeklywrkouts = new DataTable();
        public ReportForm()
        {
            InitializeComponent();
        }


        //Disable close button
        private const int CP_DISABLE_CLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CP_DISABLE_CLOSE_BUTTON;
                return cp;
            }
        }

        private void initial_data()
        {
            string filepath = "D:\\Data.xml";
            int future_weight = 0;
            string future_fitness_status = "None";
            double future_bmi = 0.0;

            DataService service = new DataService();
            xmlService servicexml = new xmlService();
            

            DateTime today_date_time = DateTime.Today;

            string start_date = StartOfWeek(today_date_time).ToString("dd/MM/yyyy");
            string end_date = EndOfWeek(today_date_time).ToString("dd/MM/yyyy");

            WeeklyWorkoutGrid.DataSource = service.GetWeeklyData(start_date, end_date);
            AllDataGridView.DataSource = service.GetAllData();

            weeklyChart.DataSource = service.GetWeeklyData(start_date, end_date);

            weeklyChart.Series["Workout"].XValueMember = "WORKOUT TYPE";
            weeklyChart.Series["Workout"].YValueMembers = "TOTAL DURATION(mins)";

            future_weight = servicexml.predict_weight(filepath);
            future_bmi = servicexml.predict_bmi(filepath);
            future_fitness_status = servicexml.fitness_stats(future_bmi);

            string weightTxt = future_weight + "Kg";
            string BMITxt = future_bmi + "kg/m2";
            string fitnessTxt = future_fitness_status;


            this.weightTxtBox.Cursor = Cursors.No;
            this.statusTxtBox.Cursor = Cursors.No;
            this.BMITextBox.Cursor = Cursors.No;

            weightTxtBox.Text = weightTxt;
            statusTxtBox.Text = fitnessTxt;
            BMITextBox.Text = BMITxt;

            if (BMITxt == "Low") 
            {
                statusTxtBox.ForeColor = Color.White;
                statusTxtBox.BackColor = Color.Red;
            }
            else 
            {
                statusTxtBox.ForeColor = Color.White;
                statusTxtBox.BackColor = Color.Green;
            }

        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            /**
             * Initial data
             * */
            initial_data();
        }

        private void PDFBtn_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(() => {
                this.BeginInvoke((Action)delegate () {
                    export();
                });
            });
            newThread.Start();
            newThread.Join();
        }

        private void export() 
        {

            if (WeeklyWorkoutGrid.Rows.Count > 1)
            {
                bool error_msg = false;

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "WorkoutReport.pdf";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            error_msg = true;
                            MessageBox.Show("An exception occured to write data: " + ex.Message);
                        }
                    }

                    if (!error_msg)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(WeeklyWorkoutGrid.Columns.Count);
                            pdfTable.DefaultCell.Padding = 2;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in WeeklyWorkoutGrid.Columns)
                            {
                                PdfPCell pdfCell = new PdfPCell(new Phrase(col.HeaderText));
                                pdfTable.AddCell(pdfCell);
                            }


                            foreach (DataGridViewRow row in WeeklyWorkoutGrid.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    // set AllowUserToAddRows = false; in Form Design
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            FileStream fStream = new FileStream(save.FileName, FileMode.Create);

                            using (fStream)
                            {
                                Document doc = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(doc, fStream);
                                doc.Open();
                                doc.Add(pdfTable);
                                doc.Close();
                                fStream.Close();
                            }

                            MessageBox.Show("Table Data Export Successfully!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while exporting table data, " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found!", "Info");
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public DateTime EndOfWeek(DateTime dateTime)
        {
            DateTime start = StartOfWeek(dateTime);

            return start.AddDays(6);
        }

        public DateTime StartOfWeek(DateTime dateTime)
        {
            int days = dateTime.DayOfWeek - DayOfWeek.Monday;

            if (days < 0)
                days += 7;

            return dateTime.AddDays(-1 * days).Date;
        }
    }
}
