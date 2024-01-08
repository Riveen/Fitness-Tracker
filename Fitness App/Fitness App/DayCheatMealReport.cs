using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Fitness_App.net.azurewebsites.dbservice3;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace Fitness_App
{
    public partial class DayCheatMealReport : Form
    {
        DataTable cheatMeals = new DataTable();
        public DayCheatMealReport()
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
            DataService service = new DataService();

            cheatmealGrid.DataSource = service.GetMealData();


            foreach (DataGridViewRow row in cheatmealGrid.Rows)
            {
                row.Cells[3].Style.ForeColor = Color.White;

                if (row.Cells[3].Value.ToString() == "High")
                {
                    row.Cells[3].Style.BackColor = Color.Red;
                }
                else if (row.Cells[3].Value.ToString() == "Low")
                {
                    row.Cells[3].Style.BackColor = Color.Green;
                }
                else 
                {
                    row.Cells[3].Style.BackColor = Color.Orange;
                }

            }

            mealChart.DataSource = service.GetMealData();

            mealChart.Series["Calories"].XValueMember = "MEAL NAME";
            mealChart.Series["Calories"].YValueMembers = "CALORIES(KJ)";


            Series s = mealChart.Series[0];
            s.IsValueShownAsLabel = true;


            foreach (DataPoint point in mealChart.Series["Calories"].Points)
            {
                // Set Color on condition.
                if (point.YValues[0] > 400.00 && point.YValues[0] < 600.00)
                {
                    point.Color = Color.Yellow;
                }
                else if (point.YValues[0] <= 400.00)
                {
                    point.Color = Color.LightGreen;
                }
                else 
                {
                    point.Color = Color.Red;
                }
            }

        }


        private void DayCheatMealReport_Load(object sender, EventArgs e)
        {
            initial_data();
        }

        private void PDFBtn_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(() => {
                this.BeginInvoke((Action)delegate
                {
                    export();
                });
            });
            newThread.Start();
            newThread.Join();
        }


        private void export() 
        {
            if (cheatmealGrid.Rows.Count > 1)
            {
                bool error_msg = false;

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "CheatMealsReport.pdf";

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
                            PdfPTable pdfTable = new PdfPTable(cheatmealGrid.Columns.Count);
                            pdfTable.DefaultCell.Padding = 2;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in cheatmealGrid.Columns)
                            {
                                PdfPCell pdfCell = new PdfPCell(new Phrase(col.HeaderText));
                                pdfTable.AddCell(pdfCell);
                            }


                            foreach (DataGridViewRow row in cheatmealGrid.Rows)
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

    }
}
