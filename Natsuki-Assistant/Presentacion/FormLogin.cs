using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Domain;
using Common.Cache;
using System.IO;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            UserLoginCache.Servi = File.ReadAllText(tempurl);
            label3.Text = "Actual Server: " + File.ReadAllText(tempurl);
            txtserver.Text = File.ReadAllText(tempurl);
        }
        string tempurl = "Servidor\\ETH.txt";
        #region Form Methods

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text== "Username")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text=="")
            {
                txtuser.Text = "Username";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Password")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;

            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Password";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;

            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "Username")
            {
                if (txtpass.Text != "Password")
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtuser.Text,txtpass.Text);
                    if (validLogin == true)
                    {
                        this.Hide();
                        FormWelcome welcome = new FormWelcome();
                        welcome.ShowDialog();
                        FormPrincipal mainMenu = new FormPrincipal();
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout;
                        
                    }
                    else
                    {
                        msgerror("Incorrect user or password. \n     Please try again.");
                        txtpass.Text = "Password";
                        txtuser.Text = "Username";
                    }
                }
                else
                {
                    msgerror("Please enter your password");
                }
            }
            else
            {
                msgerror("Please enter your username");
            }
        }
        private void msgerror(string msg)
        {
            lblerrormensaje.Text = "<!>"+msg;
            lblerrormensaje.Visible = true;

        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtpass.Text = "Password";
            txtpass.UseSystemPasswordChar = false;
            txtuser.Text = "Username";
            lblerrormensaje.Visible = false;
            this.Show();
        }

        private void linkpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recoverPassword = new FormRecoverPassword();
            recoverPassword.ShowDialog();
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            string serv = txtserver.Text;
            File.WriteAllText(tempurl, serv);
            UserLoginCache.Servi = File.ReadAllText(tempurl);
            label3.Text = "Actual Server: " + UserLoginCache.Servi;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            UserLoginCache.Servi = File.ReadAllText(tempurl);
            label3.Text = "Actual Server: " + File.ReadAllText(tempurl);
            txtserver.Text = File.ReadAllText(tempurl);
            
        }
    }
}
