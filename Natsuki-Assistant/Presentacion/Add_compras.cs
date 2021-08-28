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
    public partial class Add_compras : Form
    {
        public Add_compras()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection(Common.Cache.UserLoginCache.conexion);

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(" INSERT INTO Cargos (IdCargo, Cargo) VALUES(@IdCargo, @Cargo)", conexion);


                comando.Parameters.Add("@Cargo", SqlDbType.VarChar);
                comando.Parameters["@Cargo"].Value= textBox1.Text;

                comando.Parameters.Add("@IdCargo", SqlDbType.Float);
                comando.Parameters["@IdCargo"].Value = float.Parse(txt_telefono.Text);


                comando.ExecuteNonQuery();
                MessageBox.Show("The record was successfully modified", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
                txt_telefono.Clear();
            }
            catch (Exception X)
            {

                MessageBox.Show("The record was not added correctly", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                txt_telefono.Clear();
            }
        }
    }
}
