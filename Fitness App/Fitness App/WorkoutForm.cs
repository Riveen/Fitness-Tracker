using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fitness_App.net.azurewebsites.dbservice1;

namespace Fitness_App
{
    public partial class WorkoutForm : Form
    {
        DataTable workout_records = new DataTable();

        int rowIndex;
        public WorkoutForm()
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

        //initial data
        private void initial_data()
        {
            DataTable dt = new DataTable("Workouts");
            CRUDService service = new CRUDService(); //instance of web service class 

            dt = service.GetAll();

            workoutGridView.DataSource = dt;
            this.workoutGridView.Columns["ID"].Visible = false;
        }

        //new btn functionality
        private void newBtn_Click(object sender, EventArgs e)
        {
            workoutCmbBox.SelectedIndex = -1;
            weightCmbBox.SelectedIndex = -1;

            setsTxtBox.Text = "";
            repsTxtBox.Text = "";
            timeTxtBox.Text = "";
            IdTxtBox.Text = "";

            dateTxtBox.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        // save event functionality
        private void saveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(setsTxtBox.Text)
                    || string.IsNullOrWhiteSpace(repsTxtBox.Text)
                    || string.IsNullOrWhiteSpace(timeTxtBox.Text)
                    || workoutCmbBox.SelectedIndex == -1
                    || weightCmbBox.SelectedIndex == -1)
                {
                    MessageBox.Show("All Fields are Mandatory!");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(IdTxtBox.Text))
                    {   
                        CRUDService service = new CRUDService();
                        bool test = false;
                        string sets = setsTxtBox.Text;
                        string reps = repsTxtBox.Text;
                        string timetaken = timeTxtBox.Text;
                        string date = dateTxtBox.Text;

                        string workout = (string)workoutCmbBox.SelectedItem;
                        string weight = (string)weightCmbBox.SelectedItem;


                        if (Int32.Parse(timeTxtBox.Text) > 1440)
                        {
                            MessageBox.Show("Error, Duration can't be that long!", "Warning", MessageBoxButtons.OK);
                        }
                        else 
                        {
                            test = service.insertdb(date, workout, weight, sets, reps, timetaken);
                        }

                        if (test == true)
                        {
                            MessageBox.Show("Record Created Successfully!", "Info", MessageBoxButtons.OK);
                            newBtn_Click(sender, e);
                        }

                    }
                    else 
                    {
                        CRUDService service = new CRUDService();
                        int id = Int32.Parse(IdTxtBox.Text);
                        string sets = setsTxtBox.Text;
                        string reps = repsTxtBox.Text;
                        string timetaken = timeTxtBox.Text;
                        string date = dateTxtBox.Text;
                        bool test = false;

                        string workout = (string)workoutCmbBox.SelectedItem;
                        string weight = (string)weightCmbBox.SelectedItem;

                        if (Int32.Parse(timeTxtBox.Text) > 1440)
                        {
                            MessageBox.Show("Error, Duration can't be that long!", "Warning", MessageBoxButtons.OK);
                        }
                        else
                        {
                            test = service.updatedb(id, date, workout, weight, sets, reps, timetaken);

                        }

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
        // delete event functionality
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
                    if (workoutGridView.Rows.Count > 0)
                    {
                        try
                        {
                            int id;
                            CRUDService service = new CRUDService();


                            id = Int32.Parse(IdTxtBox.Text);

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

        private void workoutGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // get the row index of the cell clicked
            rowIndex = e.RowIndex;

            //specify 0, if the Id is in the first Column else in place of 0 e.ColumnIndex
            //var id = workoutGridView.Rows[rowIndex].Cells[0].Value;

            try
            {
                IdTxtBox.Text = workoutGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                dateTxtBox.Text = workoutGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                setsTxtBox.Text = workoutGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                repsTxtBox.Text = workoutGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                timeTxtBox.Text = workoutGridView.Rows[e.RowIndex].Cells[6].Value.ToString();

                String item1ToLookFor = workoutGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                workoutCmbBox.SelectedIndex = workoutCmbBox.Items.IndexOf(item1ToLookFor);


                String item2ToLookFor = workoutGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                weightCmbBox.SelectedIndex = weightCmbBox.Items.IndexOf(item2ToLookFor);
            }
            catch (Exception err)
            {
                Console.WriteLine("There has been an error: " + err);
            }
        }

        private void WorkoutForm_Load(object sender, EventArgs e)
        {
            dateTxtBox.Text = DateTime.Now.ToString("dd/MM/yyyy");

            timer1.Start();

            //populate data method to begin with.
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

        private void setsTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows only numeric characters
            numeric_key_only(e);

            char ch = e.KeyChar;


            if (Regex.IsMatch(setsTxtBox.Text, @"\d\d") && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void repsTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numeric_key_only(e);

            char ch = e.KeyChar;


            if (Regex.IsMatch(repsTxtBox.Text, @"\d\d\d\d") && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void timeTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            numeric_key_only(e);

            char ch = e.KeyChar;


            if (Regex.IsMatch(timeTxtBox.Text, @"\d\d\d\d") && ch != 8)
            {
                e.Handled = true;
            }

            int int_value = 0;

            Int32.TryParse(timeTxtBox.Text, out int_value);

            if (int_value > 1440 && timeTxtBox.Text != "")
            {
                timeTxtBox.Text = "1440";
                timeTxtBox.SelectionStart = timeTxtBox.Text.Length;
                timeTxtBox.SelectionLength = 0;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            initial_data();
            timer1.Start();
        }

        private void workoutGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // get the row index of the cell clicked
            rowIndex = e.RowIndex;

        }
    }
}
