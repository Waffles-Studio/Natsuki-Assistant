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
using Common.Cache;

namespace Presentacion
{
    public partial class FormConta : Form
    {
        public FormConta()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection(Common.Cache.UserLoginCache.conexion);
        private void FormConta_Load(object sender, EventArgs e)
        {
            label12.Visible = false;
        }
        string debemos, pagamos;

        private void button1_Click(object sender, EventArgs e)
        {
            sumacompra();
            ivacompras();
            pagototal();
            presupuesto();



            ////////////////////////////
            if (debemos == "")
            {
                debemos = "0";
            }
            if (pagamos == "")
            {
                pagamos = "0";
            }
            double deb = double.Parse(debemos);
            double pag = double.Parse(pagamos);
            if (deb > pag)
            {
                label12.Visible = true;
                label12.Text = "You need a profit of " + (deb - pag) + " in order to complete your payment";
            }
            if (pag > deb)
            {
                label12.Visible = true;
                label12.Text = "You generated a profit of " + (pag - deb);
            }
            if (deb == pag)
            {
                label12.Visible = true;
                label12.Text = "No profit was generated or lost";
            }
        }
        public void sumacompra()
        {
            string m1 = "", m2 = "";

            #region meses 1
            if (comboBox1.SelectedItem == "Enero")
            {
                m1 = "01-01-2020";
            }
            if (comboBox1.SelectedItem == "Febrero")
            {
                m1 = "01-02-2020";
            }
            if (comboBox1.SelectedItem == "Marzo")
            {
                m1 = "01-03-2020";
            }
            if (comboBox1.SelectedItem == "Abril")
            {
                m1 = "01-04-2020";
            }
            if (comboBox1.SelectedItem == "Mayo")
            {
                m1 = "01-05-2020";
            }
            if (comboBox1.SelectedItem == "Junio")
            {
                m1 = "01-06-2020";
            }
            if (comboBox1.SelectedItem == "Julio")
            {
                m1 = "01-07-2020";
            }
            if (comboBox1.SelectedItem == "Agosto")
            {
                m1 = "01-08-2020";
            }
            if (comboBox1.SelectedItem == "Septiembre")
            {
                m1 = "01-09-2020";
            }
            if (comboBox1.SelectedItem == "Octubre")
            {
                m1 = "01-10-2020";
            }
            if (comboBox1.SelectedItem == "Noviembre")
            {
                m1 = "01-11-2020";
            }
            if (comboBox1.SelectedItem == "Diciembre")
            {
                m1 = "01-12-2020";
            }
            #endregion

            #region mes2
            if (comboBox2.SelectedItem == "Enero")
            {
                m2 = "31-01-2020";
            }
            if (comboBox2.SelectedItem == "Febrero")
            {
                m2 = "29-02-2020";
            }
            if (comboBox2.SelectedItem == "Marzo")
            {
                m2 = "31-03-2020";
            }
            if (comboBox2.SelectedItem == "Abril")
            {
                m2 = "30-04-2020";
            }
            if (comboBox2.SelectedItem == "Mayo")
            {
                m2 = "31-05-2020";
            }
            if (comboBox2.SelectedItem == "Junio")
            {
                m2 = "30-06-2020";
            }
            if (comboBox2.SelectedItem == "Julio")
            {
                m2 = "31-07-2020";
            }
            if (comboBox2.SelectedItem == "Agosto")
            {
                m2 = "31-08-2020";
            }
            if (comboBox2.SelectedItem == "Septiembre")
            {
                m2 = "30-09-2020";
            }
            if (comboBox2.SelectedItem == "Octubre")
            {
                m2 = "31-10-2020";
            }
            if (comboBox2.SelectedItem == "Noviembre")
            {
                m2 = "30-11-2020";
            }
            if (comboBox2.SelectedItem == "Diciembre")
            {
                m2 = "31-12-2020";
            }
            #endregion

            string consulta = "select SUM(monto_compra) as resu From Compras WHERE fecha_compra BETWEEN @d1 AND @d2 ";
            SqlCommand comando = new System.Data.SqlClient.SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@d1", Convert.ToDateTime(m1));
            comando.Parameters.AddWithValue("@d2", Convert.ToDateTime(m2));
            conexion.Open();
            SqlDataReader resultado1 = comando.ExecuteReader();


            if (resultado1.Read())
            {
                textBox1.Text = "$ " + resultado1["resu"].ToString();
            }
            else
            {

            }

            conexion.Close();

        }

        public void ivacompras()
        {
            string m1 = "", m2 = "";

            #region meses 1
            if (comboBox1.SelectedItem == "Enero")
            {
                m1 = "01-01-2020";
            }
            if (comboBox1.SelectedItem == "Febrero")
            {
                m1 = "01-02-2020";
            }
            if (comboBox1.SelectedItem == "Marzo")
            {
                m1 = "01-03-2020";
            }
            if (comboBox1.SelectedItem == "Abril")
            {
                m1 = "01-04-2020";
            }
            if (comboBox1.SelectedItem == "Mayo")
            {
                m1 = "01-05-2020";
            }
            if (comboBox1.SelectedItem == "Junio")
            {
                m1 = "01-06-2020";
            }
            if (comboBox1.SelectedItem == "Julio")
            {
                m1 = "01-07-2020";
            }
            if (comboBox1.SelectedItem == "Agosto")
            {
                m1 = "01-08-2020";
            }
            if (comboBox1.SelectedItem == "Septiembre")
            {
                m1 = "01-09-2020";
            }
            if (comboBox1.SelectedItem == "Octubre")
            {
                m1 = "01-10-2020";
            }
            if (comboBox1.SelectedItem == "Noviembre")
            {
                m1 = "01-11-2020";
            }
            if (comboBox1.SelectedItem == "Diciembre")
            {
                m1 = "01-12-2020";
            }
            #endregion

            #region mes2
            if (comboBox2.SelectedItem == "Enero")
            {
                m2 = "31-01-2020";
            }
            if (comboBox2.SelectedItem == "Febrero")
            {
                m2 = "29-02-2020";
            }
            if (comboBox2.SelectedItem == "Marzo")
            {
                m2 = "31-03-2020";
            }
            if (comboBox2.SelectedItem == "Abril")
            {
                m2 = "30-04-2020";
            }
            if (comboBox2.SelectedItem == "Mayo")
            {
                m2 = "31-05-2020";
            }
            if (comboBox2.SelectedItem == "Junio")
            {
                m2 = "30-06-2020";
            }
            if (comboBox2.SelectedItem == "Julio")
            {
                m2 = "31-07-2020";
            }
            if (comboBox2.SelectedItem == "Agosto")
            {
                m2 = "31-08-2020";
            }
            if (comboBox2.SelectedItem == "Septiembre")
            {
                m2 = "30-09-2020";
            }
            if (comboBox2.SelectedItem == "Octubre")
            {
                m2 = "31-10-2020";
            }
            if (comboBox2.SelectedItem == "Noviembre")
            {
                m2 = "30-11-2020";
            }
            if (comboBox2.SelectedItem == "Diciembre")
            {
                m2 = "31-12-2020";
            }
            #endregion

            string consulta = "select (SUM(monto_compra)*.16) as resu FROM Compras WHERE fecha_compra BETWEEN @d1 AND @d2 ";
            SqlCommand comando = new System.Data.SqlClient.SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@d1", Convert.ToDateTime(m1));
            comando.Parameters.AddWithValue("@d2", Convert.ToDateTime(m2));
            conexion.Open();
            SqlDataReader resultado1 = comando.ExecuteReader();


            if (resultado1.Read())
            {
                textBox2.Text = "$ " + resultado1["resu"].ToString();
            }
            else
            {

            }

            conexion.Close();
        }

        public void pagototal()
        {
            string m1 = "", m2 = "";

            #region meses 1
            if (comboBox1.SelectedItem == "Enero")
            {
                m1 = "01-01-2020";
            }
            if (comboBox1.SelectedItem == "Febrero")
            {
                m1 = "01-02-2020";
            }
            if (comboBox1.SelectedItem == "Marzo")
            {
                m1 = "01-03-2020";
            }
            if (comboBox1.SelectedItem == "Abril")
            {
                m1 = "01-04-2020";
            }
            if (comboBox1.SelectedItem == "Mayo")
            {
                m1 = "01-05-2020";
            }
            if (comboBox1.SelectedItem == "Junio")
            {
                m1 = "01-06-2020";
            }
            if (comboBox1.SelectedItem == "Julio")
            {
                m1 = "01-07-2020";
            }
            if (comboBox1.SelectedItem == "Agosto")
            {
                m1 = "01-08-2020";
            }
            if (comboBox1.SelectedItem == "Septiembre")
            {
                m1 = "01-09-2020";
            }
            if (comboBox1.SelectedItem == "Octubre")
            {
                m1 = "01-10-2020";
            }
            if (comboBox1.SelectedItem == "Noviembre")
            {
                m1 = "01-11-2020";
            }
            if (comboBox1.SelectedItem == "Diciembre")
            {
                m1 = "01-12-2020";
            }
            #endregion

            #region mes2
            if (comboBox2.SelectedItem == "Enero")
            {
                m2 = "31-01-2020";
            }
            if (comboBox2.SelectedItem == "Febrero")
            {
                m2 = "29-02-2020";
            }
            if (comboBox2.SelectedItem == "Marzo")
            {
                m2 = "31-03-2020";
            }
            if (comboBox2.SelectedItem == "Abril")
            {
                m2 = "30-04-2020";
            }
            if (comboBox2.SelectedItem == "Mayo")
            {
                m2 = "31-05-2020";
            }
            if (comboBox2.SelectedItem == "Junio")
            {
                m2 = "30-06-2020";
            }
            if (comboBox2.SelectedItem == "Julio")
            {
                m2 = "31-07-2020";
            }
            if (comboBox2.SelectedItem == "Agosto")
            {
                m2 = "31-08-2020";
            }
            if (comboBox2.SelectedItem == "Septiembre")
            {
                m2 = "30-09-2020";
            }
            if (comboBox2.SelectedItem == "Octubre")
            {
                m2 = "31-10-2020";
            }
            if (comboBox2.SelectedItem == "Noviembre")
            {
                m2 = "30-11-2020";
            }
            if (comboBox2.SelectedItem == "Diciembre")
            {
                m2 = "31-12-2020";
            }
            #endregion

            string consulta = "select SUM(monto_compra) + (SUM(monto_compra)*0.16) as resu  From compras  WHERE fecha_compra BETWEEN @d1 AND @d2 ";
            SqlCommand comando = new System.Data.SqlClient.SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@d1", Convert.ToDateTime(m1));
            comando.Parameters.AddWithValue("@d2", Convert.ToDateTime(m2));

            conexion.Open();
            SqlDataReader resultado1 = comando.ExecuteReader();


            if (resultado1.Read())
            {
                textBox3.Text = "$ " + resultado1["resu"].ToString();
                textBox5.Text = "$ " + resultado1["resu"].ToString();
                debemos = resultado1["resu"].ToString();
            }
            else
            {
                MessageBox.Show("No data was recorded on those dates");
            }

            conexion.Close();

        }

        public void presupuesto()
        {
            string m1 = "", m2 = "";

            #region meses 1
            if (comboBox1.SelectedItem == "Enero")
            {
                m1 = "01-01-2020";
            }
            if (comboBox1.SelectedItem == "Febrero")
            {
                m1 = "01-02-2020";
            }
            if (comboBox1.SelectedItem == "Marzo")
            {
                m1 = "01-03-2020";
            }
            if (comboBox1.SelectedItem == "Abril")
            {
                m1 = "01-04-2020";
            }
            if (comboBox1.SelectedItem == "Mayo")
            {
                m1 = "01-05-2020";
            }
            if (comboBox1.SelectedItem == "Junio")
            {
                m1 = "01-06-2020";
            }
            if (comboBox1.SelectedItem == "Julio")
            {
                m1 = "01-07-2020";
            }
            if (comboBox1.SelectedItem == "Agosto")
            {
                m1 = "01-08-2020";
            }
            if (comboBox1.SelectedItem == "Septiembre")
            {
                m1 = "01-09-2020";
            }
            if (comboBox1.SelectedItem == "Octubre")
            {
                m1 = "01-10-2020";
            }
            if (comboBox1.SelectedItem == "Noviembre")
            {
                m1 = "01-11-2020";
            }
            if (comboBox1.SelectedItem == "Diciembre")
            {
                m1 = "01-12-2020";
            }
            #endregion

            #region mes2
            if (comboBox2.SelectedItem == "Enero")
            {
                m2 = "31-01-2020";
            }
            if (comboBox2.SelectedItem == "Febrero")
            {
                m2 = "29-02-2020";
            }
            if (comboBox2.SelectedItem == "Marzo")
            {
                m2 = "31-03-2020";
            }
            if (comboBox2.SelectedItem == "Abril")
            {
                m2 = "30-04-2020";
            }
            if (comboBox2.SelectedItem == "Mayo")
            {
                m2 = "31-05-2020";
            }
            if (comboBox2.SelectedItem == "Junio")
            {
                m2 = "30-06-2020";
            }
            if (comboBox2.SelectedItem == "Julio")
            {
                m2 = "31-07-2020";
            }
            if (comboBox2.SelectedItem == "Agosto")
            {
                m2 = "31-08-2020";
            }
            if (comboBox2.SelectedItem == "Septiembre")
            {
                m2 = "30-09-2020";
            }
            if (comboBox2.SelectedItem == "Octubre")
            {
                m2 = "31-10-2020";
            }
            if (comboBox2.SelectedItem == "Noviembre")
            {
                m2 = "30-11-2020";
            }
            if (comboBox2.SelectedItem == "Diciembre")
            {
                m2 = "31-12-2020";
            }
            #endregion

            string consulta = "select SUM(monto_venta) as resu From Venta WHERE fecha_venta BETWEEN @d1 AND @d2 ";
            SqlCommand comando = new System.Data.SqlClient.SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@d1", Convert.ToDateTime(m1));
            comando.Parameters.AddWithValue("@d2", Convert.ToDateTime(m2));

            conexion.Open();
            SqlDataReader resultado1 = comando.ExecuteReader();


            if (resultado1.Read())
            {
                textBox7.Text = "$ " + resultado1["resu"].ToString();
                textBox6.Text = "$ " + resultado1["resu"].ToString();
                textBox4.Text = "$ " + resultado1["resu"].ToString();
                pagamos = resultado1["resu"].ToString();
            }
            else
            {
                MessageBox.Show("No data was recorded on those dates");
            }

            conexion.Close();
        }
    }
}
