using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Presentacion
{
    public partial class Add_Provedores : Form
    {
        public Add_Provedores()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection(Common.Cache.UserLoginCache.conexion);
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO Users (LoginName, Password, FirstName, LastName, Position, Email, IdCargo)VALUES(@LoginName, @Password, @FirstName, @LastName, @Position, @Email, @IdCargo)", conexion);
                /*
                comando.Parameters.Add("@UserID", SqlDbType.Float);
                comando.Parameters["@UserID"].Value = float.Parse(txt_nmbre_provedor.Text);
                */
                comando.Parameters.Add("@LoginName", SqlDbType.VarChar);
                comando.Parameters["@LoginName"].Value = txt_telefono.Text;

                comando.Parameters.Add("@Password", SqlDbType.VarChar);
                comando.Parameters["@Password"].Value = txt_email.Text;

                comando.Parameters.Add("@FirstName", SqlDbType.VarChar);
                comando.Parameters["@FirstName"].Value = txt_direccion.Text;

                comando.Parameters.Add("@LastName", SqlDbType.VarChar);
                comando.Parameters["@LastName"].Value = txt_ciudad.Text;

                comando.Parameters.Add("@Position", SqlDbType.VarChar);
                comando.Parameters["@Position"].Value = textBox2.Text;

                comando.Parameters.Add("@Email", SqlDbType.VarChar);
                comando.Parameters["@Email"].Value = textBox1.Text;

                comando.Parameters.Add("@IdCargo", SqlDbType.Float);
                comando.Parameters["@IdCargo"].Value = float.Parse(textBox3.Text);

                comando.ExecuteNonQuery();
                MessageBox.Show("The record was successfully modified", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
                txt_telefono.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("The record was not added correctly", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                txt_telefono.Clear();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void Add_Provedores_Load(object sender, EventArgs e)
        {

        }
    }
}
