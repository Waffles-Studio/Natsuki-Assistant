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
    public partial class Add_Sales : Form
    {
        public Add_Sales()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection(Common.Cache.UserLoginCache.conexion);
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(" INSERT INTO Tareas (IdTarea, Cargo, Descripcion, Completada, Fecha_incio) VALUES(@IdTarea, @Cargo, @Descripcion, @Completada, @Fecha_incio)", conexion);

                comando.Parameters.Add("@IdTarea", SqlDbType.Float);
                comando.Parameters["@IdTarea"].Value = float.Parse(txt_monto.Text);

                comando.Parameters.Add("@Cargo", SqlDbType.Float);
                comando.Parameters["@Cargo"].Value = float.Parse(textBox1.Text);

                comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                comando.Parameters["@Descripcion"].Value = textBox2.Text;

                comando.Parameters.Add("@Completada", SqlDbType.Float);
                comando.Parameters["@Completada"].Value = float.Parse(textBox3.Text);

                comando.Parameters.Add("@Fecha_incio", SqlDbType.SmallDateTime);
                comando.Parameters["@Fecha_incio"].Value = dateTimeFecha.Value;




                comando.ExecuteNonQuery();
                MessageBox.Show("The record was successfully modified", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
            }
            catch (Exception X)
            {

                MessageBox.Show("The record was not added correctly", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton_si_CheckedChanged(object sender, EventArgs e)
        {

        }
        

        private void Add_Sales_Load(object sender, EventArgs e)
        {

        }

        private void txt_monto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}