using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormUpdates : Form
    {
        public FormUpdates()
        {
            InitializeComponent();
        }
        private int a = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            a = 1;
            progressBar1.Value = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool flag = a == 1;
            if (flag)
            {
                this.progressBar1.Increment(1);
                bool flag2 = this.progressBar1.Value == 1;
                if (flag2)
                {
                    this.panel2.Visible = true;
                    this.panel2.BringToFront();
                    this.textBox4.Text = "Validating Information";
                }
                bool flag3 = this.progressBar1.Value == 30;
                if (flag3)
                {
                    this.textBox4.Text = "Connecting to the Server";
                }
                bool flag4 = this.progressBar1.Value == 60;
                if (flag4)
                {
                    this.textBox4.Text = "Checking for Updates";
                }
                bool flag5 = this.progressBar1.Value == 90;
                if (flag5)
                {
                    this.panel2.SendToBack();
                    this.textBox4.Text = "Validating files";
                }
                bool flag6 = this.progressBar1.Value == 100;
                if (flag6)
                {
                    this.timer1.Stop();
                    MessageBox.Show("The program is in the latest version available:)", "Updated system");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormChaanges FC = new FormChaanges();
            FC.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
