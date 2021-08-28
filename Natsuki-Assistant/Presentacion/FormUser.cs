using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using Domain;

namespace Presentacion
{
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            loadUserData();
            initializePassEditControl();

            if (UserLoginCache.IdUser == 1)//BRIAN
            {
                pictureBox1.Image = Image.FromFile("Resources\\Brian.PNG");
            }
            if (UserLoginCache.IdUser == 2)//DANIEL
            {
                pictureBox1.Image = Image.FromFile("Resources\\Daniel.PNG");
            }
            if (UserLoginCache.IdUser == 3)//CESAR
            {
                pictureBox1.Image = Image.FromFile("Resources\\Cesar.PNG");
            }
            if (UserLoginCache.IdUser == 4)//DARIEN
            {
                pictureBox1.Image = Image.FromFile("Resources\\Darien_perfil.bmp");
            }
            if (UserLoginCache.IdUser == 5)//USER
            {
                pictureBox1.Image = Image.FromFile("Resources\\User.PNG");
            }
            if (UserLoginCache.IdUser == 6)//LUPITA
            {
                pictureBox1.Image = Image.FromFile("Resources\\Lupita.PNG");
            }
            if (UserLoginCache.IdUser == 7)//CHRIS
            {
                pictureBox1.Image = Image.FromFile("Resources\\Chris_perfil.bmp");
            }
        }

        private void loadUserData()
        {
            lbluser.Text = UserLoginCache.LoginName;
            lblfirstname.Text = UserLoginCache.FirtsName;
            lbllastname.Text = UserLoginCache.LastName;
            lblemail.Text = UserLoginCache.Email;
            lblposition.Text = UserLoginCache.Position;

            txtusername.Text = UserLoginCache.LoginName;
            txtfirstname.Text = UserLoginCache.FirtsName;
            txtlastname.Text = UserLoginCache.LastName;
            txtemail.Text = UserLoginCache.Email;
            txtnewpass.Text = UserLoginCache.password;
            txtconfirmpass.Text = UserLoginCache.password;
            txtpass.Text = "";
        }

        private void initializePassEditControl()
        {
            LinkEditPass.Text = "Edit";
            txtnewpass.Enabled = false;
            txtnewpass.UseSystemPasswordChar = true;
            txtconfirmpass.Enabled = false;
            txtconfirmpass.UseSystemPasswordChar = true;
        }

        private void reset()
        {
            loadUserData();
            initializePassEditControl();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
            loadUserData();
        }

        private void LinkEditPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LinkEditPass.Text == "Edit")
            {
                LinkEditPass.Text = "Cancel";
                txtnewpass.Enabled = true;
                txtnewpass.Text = "";
                txtconfirmpass.Enabled = true;
                txtconfirmpass.Text = "";
            }
            else
            {
                if (LinkEditPass.Text == "Cancel")
                {
                    initializePassEditControl();
                    txtnewpass.Text = UserLoginCache.password;
                    txtconfirmpass.Text = UserLoginCache.password;
       
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnewpass.Text == txtconfirmpass.Text)
            {
                if (txtpass.Text == UserLoginCache.password)
                {
                    var userModel = new UserModel(idUser:UserLoginCache.IdUser,
                        LoginName: txtusername.Text,
                        password: txtnewpass.Text,
                        firstName: txtfirstname.Text,
                        LastName: txtlastname.Text,
                        position: null,
                        email: txtemail.Text);
                    var result = userModel.editUserPorfile();
                    MessageBox.Show(result);
                    reset();
                    panel1.Visible =false;
                }
                else
                {
                    MessageBox.Show("Incorrect current password, try again");
                }
            }
            else
            {
                MessageBox.Show("The password do not match, try again");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            reset();
        }
    }
}
