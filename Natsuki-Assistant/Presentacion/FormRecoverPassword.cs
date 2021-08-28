using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace Presentacion
{
    public partial class FormRecoverPassword : Form
    {
        public FormRecoverPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new UserModel();
            var result = user.recoverPassword(textBox1.Text);
            textBox2.Text = result;
        }
    }
}
