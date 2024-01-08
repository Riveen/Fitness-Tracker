using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_App
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            progressTimer.Start();
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;

                percentageLabel.Text = progressBar1.Value.ToString() + "%";

                if (progressBar1.Value > 49 && progressBar1.Value < 51)
                {
                    Thread.Sleep(3000);
                    progressBar1.Value += 1;
                }
            }
            else
            {
                Thread.Sleep(4000);
                progressTimer.Stop();

                this.Hide();

                MainForm menu = new MainForm();
                menu.Activate();
                menu.ShowDialog();
            }
        }
    }
}
