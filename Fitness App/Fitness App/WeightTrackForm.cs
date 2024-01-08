using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fitness_App.xmlservice;

namespace Fitness_App
{
    public partial class WeightTrackForm : Form
    {
        DataTable weightrecords = new DataTable("weight");
        xmlService service = new xmlService();

        string file = Path.GetDirectoryName(Application.ExecutablePath) + "\\Data.xml";

        public WeightTrackForm()
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

        //sample data
        private void initial_data()
        {
            weightrecords.Columns.Add("ID");
            weightrecords.Columns.Add("Date");
            weightrecords.Columns.Add("Weight");
            weightrecords.Columns.Add("Height");


            weightrecords = service.read(file);// read web method call

            weightGridView.DataSource = weightrecords;
            weightGridView.Columns["ID"].Visible = false;
        }
        private void newBtn_Click(object sender, EventArgs e)
        {
            IdTxtBox.Text = "";
            weightTxtBox.Text = "";
            heightTxtBox.Text = "";
            dateTxtBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(heightTxtBox.Text) || string.IsNullOrWhiteSpace(weightTxtBox.Text))
                {
                    MessageBox.Show("Weight & Height both are Required!");
                }
                else 
                {
                    int count = 1;
                    string id;
                    string height = heightTxtBox.Text;
                    string weight = weightTxtBox.Text;
                    string date = dateTxtBox.Text;


                    for (int row = 0; row < weightGridView.Rows.Count; row++)
                    {
                        if (string.Equals(weightGridView[1, row].Value as string, DateTime.Now.ToString("dd/MM/yyyy")))
                        {
                            count++;
                        }
                    }

                    if (string.IsNullOrEmpty(IdTxtBox.Text))
                    {
                        if (count > 1 && dateTxtBox.Text == DateTime.Now.ToString("dd/MM/yyyy"))
                        {
                            MessageBox.Show("Error! Cannot enter weight more than once for a day.", "Warning!", MessageBoxButtons.OK);
                        }
                        else 
                        {
                            id = Guid.NewGuid().ToString();
                            weightrecords.Rows.Add(id, date, weight, height);
                            MessageBox.Show("Record Created Successfully!", "Info", MessageBoxButtons.OK);

                        }

                    }
                    else
                    {
                        id = IdTxtBox.Text;

                        for (int v = 0; v < weightGridView.Rows.Count; v++)
                        {
                            if (string.Equals(weightGridView[0, v].Value as string, id))
                            {
                                weightGridView.Rows.RemoveAt(v);
                                v--;
                            }
                        }

                        weightrecords.Rows.Add(id, date, weight, height);
                        MessageBox.Show("Record Updated Successfully!", "Info", MessageBoxButtons.OK);
                    }

                    service.write(file, weightrecords); //write web method call


                    newBtn_Click(sender, e);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Errror: " + err);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this record?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (weightrecords.Rows.Count > 0)
                {
                    try
                    {
                        // delete the row by row index from the selected cell by the user
                        weightrecords.Rows[weightGridView.CurrentCell.RowIndex].Delete();
                        service.write(file, weightrecords);

                        

                        newBtn_Click(sender, e);

                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("Errror: " + err);
                    }
                }
                else
                {
                    MessageBox.Show("No records are available!", "Error!", MessageBoxButtons.OK);
                }

            }
        }


        private void weightGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                IdTxtBox.Text = weightrecords.Rows[weightGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
                dateTxtBox.Text = weightrecords.Rows[weightGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
                weightTxtBox.Text = weightrecords.Rows[weightGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
                heightTxtBox.Text = weightrecords.Rows[weightGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
            }
            catch (Exception err)
            {
                Console.WriteLine("There has been an error: " + err);
            }
        }

        private void WeightTrackForm_Load(object sender, EventArgs e)
        {

            dateTxtBox.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // populate sample data for now.
            initial_data();
        }

        private void deleteBtn_MouseHover(object sender, EventArgs e)
        {
            deleteBtn.ForeColor = Color.Red;
        }

        private void deleteBtn_MouseLeave(object sender, EventArgs e)
        {
            deleteBtn.ForeColor = Color.Black;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void weightTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numeric_key_only(e);
        }


        // method to only accept numeric characters
        private void numeric_key_only(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // checks digits and backspace..
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }


            if (Regex.IsMatch(weightTxtBox.Text, @"\d\d\d") && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void heightTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;


            if (!Char.IsDigit(ch) && ch != '\b' && ch != '.' && ch != 8)
            {
                e.Handled = true;
            }


            if (ch == '.' && heightTxtBox.Text.Contains("."))
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(heightTxtBox.Text, @"\d\d\d\d") && ch != 8)
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(heightTxtBox.Text, @"\.\d\d") && ch != 8)
            {
                e.Handled = true;
            }


        }
    }
}
