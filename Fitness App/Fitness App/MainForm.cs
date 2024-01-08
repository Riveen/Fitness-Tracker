using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void workoutBtn_Click(object sender, EventArgs e)
        {
            WorkoutForm workoutwindow = new WorkoutForm();
            workoutwindow.Activate();
            workoutwindow.ShowDialog();
        }

        private void mealBtn_Click(object sender, EventArgs e)
        {
            MealForm mealwindow = new MealForm();
            mealwindow.Activate();
            mealwindow.ShowDialog();
        }

        private void weightBtn_Click(object sender, EventArgs e)
        {
            WeightTrackForm weighttrackwindow = new WeightTrackForm();
            weighttrackwindow.Activate();
            weighttrackwindow.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close? If you choose 'Yes', you will lose any unsaved data.", "Warning!", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            Close();
            Application.Exit();
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            ReportMainForm mainReportForm = new ReportMainForm();
            mainReportForm.Activate();
            mainReportForm.ShowDialog();
            mainReportForm.ShowInTaskbar = false; // not shown on taskbar set to false

        }
    }
}
