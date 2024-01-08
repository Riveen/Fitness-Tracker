using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using Fitness_App.net.azurewebsites.dbservice2;

namespace Fitness_App
{
    public partial class MealForm : Form
    {
        DataTable meal_records = new DataTable();

        int rowIndex;

        public MealForm()
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

            DBService2 service = new DBService2();
            DataTable dt = service.GetAll();

            mealGridView.DataSource = dt;
            this.mealGridView.Columns[0].Visible = false;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            IdTxtBox.Text = "";
            mealTxtBox.Text = "";
            descTxtBox.Text = "";
            caloAmtTxtBox.Text = "";
            dateTxtBox.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mealTxtBox.Text) || string.IsNullOrWhiteSpace(caloAmtTxtBox.Text))
                {
                    MessageBox.Show("Meal and Calorie Amt. Fields are Required!");
                }
                else
                {

                    DBService2 service = new DBService2();

                    string[] cal_arr = { "High", "Moderate", "Low" };
                    string meal = mealTxtBox.Text;
                    string description = descTxtBox.Text;
                    string calories = caloAmtTxtBox.Text;
                    int cal_amt = Int32.Parse(caloAmtTxtBox.Text);
                    string date = dateTxtBox.Text;
                    string cal_intake = "";
                    bool test;
                    int count = 1;

                    if (cal_amt > 400 & cal_amt < 600)
                    {
                        cal_intake = cal_arr[1];
                    }
                    else if (cal_amt <= 400)
                    {
                        cal_intake = cal_arr[2];
                    }
                    else
                    {
                        cal_intake = cal_arr[0];
                    }

                    for (int row = 0; row < mealGridView.Rows.Count; row++)
                    {
                        if (string.Equals(mealGridView[1, row].Value as string, DateTime.Now.ToString("dd/MM/yyyy")))
                        {
                            count++;
                        }
                    }



                    if (string.IsNullOrWhiteSpace(IdTxtBox.Text))
                    {

                        if (count > 1 && dateTxtBox.Text == DateTime.Now.ToString("dd/MM/yyyy"))
                        {
                            MessageBox.Show("Error! Cannot enter more than one cheat day.", "Warning!", MessageBoxButtons.OK);
                        }
                        else
                        {
                            test = service.insertdb(date, meal, description, calories, cal_intake);

                            if (test == true)
                            {
                                MessageBox.Show("Record Created Successfully!", "Info", MessageBoxButtons.OK);
                                newBtn_Click(sender, e);
                            }
                        }

                    }
                    else 
                    {
                        int id = Int32.Parse(IdTxtBox.Text);

                        test = service.updatedb(id, date, meal, description, calories, cal_intake);

                        if (test == true)
                        {
                            MessageBox.Show("Record Updated Successfully!", "Info", MessageBoxButtons.OK);
                        }

                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Errror: " + err);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdTxtBox.Text))
            {
                MessageBox.Show("No Record Selected to delete!", "Info", MessageBoxButtons.OK);
            }
            else 
            {

                if (MessageBox.Show("Do you want to delete this record?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (mealGridView.Rows.Count > 0)
                    {
                        try
                        {
                            DBService2 service = new DBService2();
                            int id = Int32.Parse(IdTxtBox.Text);

                            bool test = service.delete(id);

                            if (test == true)
                            {
                                MessageBox.Show("Record Deleted Successfully!", "Info", MessageBoxButtons.OK);
                                newBtn_Click(sender, e);
                            }
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
        }

        private void mealGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;

            try
            {
                IdTxtBox.Text = mealGridView.Rows[rowIndex].Cells[0].Value.ToString();
                dateTxtBox.Text = mealGridView.Rows[rowIndex].Cells[1].Value.ToString();
                mealTxtBox.Text = mealGridView.Rows[rowIndex].Cells[2].Value.ToString();
                descTxtBox.Text = mealGridView.Rows[rowIndex].Cells[3].Value.ToString();
                caloAmtTxtBox.Text = mealGridView.Rows[rowIndex].Cells[4].Value.ToString();
            }
            catch (Exception err)
            {
                Console.WriteLine("There has been an error: " + err);
            }
        }

        private void MealForm_Load(object sender, EventArgs e)
        {
            dateTxtBox.Text = DateTime.Now.ToString("dd/MM/yyyy");

            refreshTimer.Start();

            //POPULATE data to begin with.
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

        private void MealForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mainwindow = new MainForm();
            mainwindow.Show();
            this.Hide();
        }

        private void caloAmtTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numeric_key_only(e);

            char ch = e.KeyChar;


            if (Regex.IsMatch(caloAmtTxtBox.Text, @"\d\d\d\d\d") && ch != 8)
            {
                e.Handled = true;
            }
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
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            initial_data();
            refreshTimer.Start();
        }
    }
}
