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
    public partial class ReportMainForm : Form
    {
        public ReportMainForm()
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

        private void reportBtn_1_Click(object sender, EventArgs e)
        {
            ReportForm fitness_report = new ReportForm();
            fitness_report.Activate();
            fitness_report.ShowDialog();
        }

        private void reportBtn_2_Click(object sender, EventArgs e)
        {
            DayCheatMealReport cheat_day_report = new DayCheatMealReport();
            cheat_day_report.Activate();
            cheat_day_report.ShowDialog();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
