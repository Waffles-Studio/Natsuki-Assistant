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
    public partial class Add_Product : Form
    {
        public Add_Product()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection(Common.Cache.UserLoginCache.conexion);
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO Notas (IdNota,Usuario,Tiuto_Nota,Descipcion )VALUES(@IdNota,@Usuario,@Tiuto_Nota,@Descipcion)", conexion);

                comando.Parameters.Add("@IdNota", SqlDbType.Float);
                comando.Parameters["@IdNota"].Value = float.Parse(txt_nbre.Text);

                comando.Parameters.Add("@Usuario", SqlDbType.Float);
                comando.Parameters["@Usuario"].Value = float.Parse(txt_precio.Text);

                comando.Parameters.Add("@Tiuto_Nota", SqlDbType.VarChar);
                comando.Parameters["@Tiuto_Nota"].Value = txt_dep.Text;

                comando.Parameters.Add("@Descipcion", SqlDbType.VarChar);
                comando.Parameters["@Descipcion"].Value = txtDes.Text;


                comando.ExecuteNonQuery();
                MessageBox.Show("The record was successfully modified", "Successful operation", MessageBoxButtons.OK,MessageBoxIcon.Information);
                conexion.Close();
                txt_nbre.Clear();
                txt_precio.Clear();
                txt_dep.Clear();
            }
            catch(FormatException X)
            {
                MessageBox.Show("The record was not added correctly", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
            }
        }
    }
}
