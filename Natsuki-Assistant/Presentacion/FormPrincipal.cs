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
using System.Data.SqlClient;
using DataAccese;

namespace Presentacion
{
    public partial class FormPrincipal: Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            
        }
        //Conexion 
        
        //SqlConnection 
        SqlConnection conexion = new SqlConnection(Common.Cache.UserLoginCache.conexion);
	
        //Agregar
        SqlCommand agregar;
        //Variable de control del combo y variable de posicion para el data grid
        int control_combobox=0,n=0;

        #region Ba3
        private void LoadUserData()
        {
            label20.Text = UserLoginCache.FirtsName + " " + UserLoginCache.LastName;
            label10.Text = UserLoginCache.Position;
            label11.Text = UserLoginCache.Email;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea cerrar sesion?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de cerrar esta apliacion?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FormAbout FA = new FormAbout();
            FA.Show();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            FormUser FU = new FormUser();
            FU.Show();

        }
        private void button12_Click(object sender, EventArgs e)
        {
            FormUpdates FU = new FormUpdates();
            FU.Show();
        }

        
        private void label12_Click(object sender, EventArgs e)
        {

        }

        
        #endregion
        private void btn_Expand_Click(object sender, EventArgs e)
        {
            labelWELCOME.Visible = true;
            dataGridProducts.Visible = false;
            dataGridProviders.Visible = false;
            dataGridPurchases.Visible = false;
            dataGridSales.Visible = false;
        }
        private void Form01_Load(object sender, EventArgs e)
        {
            LoadUserData();
            //dataGridView2_Product.AllowUserToAddRows = false;

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

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
       private void Aviso()
        {
            if (comboOpcion.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una acción a realizar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            control_combobox = 1;
            //Aviso();
            labelWELCOME.Visible = false;

            dataGridProducts.Visible = true;
          
            dataGridProviders.Visible = false;
            dataGridPurchases.Visible = false;
            dataGridSales.Visible = false;
            //if (comboOpcion.SelectedItem== "Consultar" && dataGridProducts.Visible == true)
            //{
            actualizado_peoductos();
            //}
            if (comboOpcion.SelectedItem == "Insertar")
            {
                Add_Product obj = new Add_Product();
                comboOpcion.SelectedItem = "Seleccionar";
                obj.ShowDialog();
            }
            if (comboOpcion.SelectedItem == "Seleccionar")
            {
                
            }
        }
        //Actualizado de tabla despues de borrar
        private void actualizado_peoductos()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM Notas", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridProducts.DataSource = tabla;
        }
        private void actualizado_Provedores()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM Users", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridProviders.DataSource = tabla;
        }
        private void actualizado_Compras()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM Cargos", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridPurchases.DataSource = tabla;
        }
        private void actualizado_ventas()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM Tareas", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridSales.DataSource = tabla;
        }
        ///
        private void btn_Sales_Click(object sender, EventArgs e)
        {
            control_combobox = 2;
            //Aviso();
            labelWELCOME.Visible = false;
            
            dataGridProducts.Visible = false;
            dataGridProviders.Visible = false;
            dataGridPurchases.Visible = false;
            dataGridSales.Visible = true;
            if (dataGridSales.Visible == true)
            {
                actualizado_ventas();
            }
            if (comboOpcion.SelectedItem == "Insertar")
            {
                Add_Sales obj = new Add_Sales();
                comboOpcion.SelectedItem = "Seleccionar";
                obj.ShowDialog();
            }
            if (comboOpcion.SelectedItem == "Seleccionar")
            {

            }
        }

        private void btn_Clients_Click(object sender, EventArgs e)
        {
            labelWELCOME.Visible = false;
            dataGridProducts.Visible = false;
            dataGridProviders.Visible = false;
            dataGridPurchases.Visible = false;
            dataGridSales.Visible = false;
        }
        private void btn_Providers_Click(object sender, EventArgs e)
        {
            if (label10.Text == "Administrador")
            {
                control_combobox = 4;
                // Aviso();
                labelWELCOME.Visible = false;
                dataGridProducts.Visible = false;
                dataGridProviders.Visible = true;
                dataGridPurchases.Visible = false;
                dataGridSales.Visible = false;
                if (dataGridProviders.Visible == true)
                {
                    actualizado_Provedores();
                }
                if (comboOpcion.SelectedItem == "Insertar")
                {
                    Add_Provedores obj = new Add_Provedores();
                    comboOpcion.SelectedItem = "Seleccionar";
                    obj.ShowDialog();
                }
                if (comboOpcion.SelectedItem == "Seleccionar")
                {

                }
            }
            else
            {

                MessageBox.Show("You need to be an administrator to enter this section", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void btn_Purshases_Click(object sender, EventArgs e)
        {
            if (label10.Text == "Administrador")
            {
                control_combobox = 5;
                //Aviso();
                labelWELCOME.Visible = false;
                dataGridProducts.Visible = false;
                dataGridProviders.Visible = false;
                dataGridPurchases.Visible = true;
                dataGridSales.Visible = false;
                if (dataGridPurchases.Visible == true)
                {
                    actualizado_Compras();
                }
                if (comboOpcion.SelectedItem == "Insertar")
                {
                    Add_compras obj = new Add_compras();
                    comboOpcion.SelectedItem = "Seleccionar";
                    obj.ShowDialog();
                }
                if (comboOpcion.SelectedItem == "Seleccionar")
                {

                }
            }
            else
            {
                MessageBox.Show("You need to be an administrator to enter this section", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        //Boton para b0prrar//////////////////////////////////////////////////////////////////////////////////////////////
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboOpcion.SelectedItem == "Eliminar" && control_combobox == 1)///tabla productos
                {
                    try
                    {
                        string nombre = lblborrar.Text;
                        conexion.Open();
                        SqlCommand comando = new SqlCommand("DELETE Notas WHERE IdNota=@IdNota", conexion);

                        comando.Parameters.Add("@IdNota", SqlDbType.Float);
                        comando.Parameters["@IdNota"].Value = nombre;

                        int cant = comando.ExecuteNonQuery();
                        if (cant == 1)
                        {
                            MessageBox.Show("El registro se ha eliminado");
                            lblborrar.Text = "";
                            actualizado_peoductos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el registro", "Inserte registro valido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        conexion.Close();
                    }
                    catch (Exception x)
                    {

                        MessageBox.Show("Seleccione una celda" + x + ", Falta algun campo o tiene un dato invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                        conexion.Close();
                    }
                }
                if (comboOpcion.SelectedItem == "Eliminar" && control_combobox == 2)///tabla ventas o SALEs
                {
                    try
                    {
                        string nombre = lblborrar.Text;
                        conexion.Open();
                        SqlCommand comando = new SqlCommand("DELETE Tareas WHERE IdTarea=@IdTarea", conexion);
                        comando.Parameters.Add("@IdTarea", SqlDbType.Float);
                        comando.Parameters["@IdTarea"].Value = lblborrar.Text;
                        int cant = comando.ExecuteNonQuery();
                        if (cant == 1)
                        {
                            MessageBox.Show("La tarea se ha eliminado");
                            lblborrar.Text = "";
                            actualizado_ventas();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el registro", "Inserte registro valido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        conexion.Close();
                    }
                    catch (Exception x)
                    {

                        MessageBox.Show("Seleccione una celda" + x + ", Falta algun campo o tiene un dato invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                        conexion.Close();
                    }
                }
                if (comboOpcion.SelectedItem == "Eliminar" && control_combobox == 4)///tabla Provedores
                {
                    try
                    {
                        string nombre = lblborrar.Text;
                        conexion.Open();
                        SqlCommand comando = new SqlCommand("DELETE Users WHERE UserID=@UserID", conexion);
                        comando.Parameters.Add("@UserID", SqlDbType.Float);
                        comando.Parameters["@UserID"].Value = nombre;
                        int cant = comando.ExecuteNonQuery();
                        if (cant == 1)
                        {
                            MessageBox.Show("El registro se ha eliminado");
                            lblborrar.Text = "";
                            actualizado_Provedores();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el registro", "Inserte registro valido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        conexion.Close();
                    }
                    catch (Exception x)
                    {

                        MessageBox.Show("Seleccione una celda" + x + ", Falta algun campo o tiene un dato invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                        conexion.Close();
                    }
                }
                if (comboOpcion.SelectedItem == "Eliminar" && control_combobox == 5)///tabla compras
                {
                    try
                    {
                        conexion.Open();
                        SqlCommand comando = new SqlCommand("DELETE Cargos WHERE IdCargo=@IdCargo", conexion);
                        comando.Parameters.Add("@IdCargo", SqlDbType.Float);
                        comando.Parameters["@IdCargo"].Value = lblborrar.Text;
                        int cant = comando.ExecuteNonQuery();
                        if (cant == 1)
                        {
                            MessageBox.Show("El registro se ha eliminado");
                            lblborrar.Text = "";
                            actualizado_Compras();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el registro", "Inserte registro valido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        conexion.Close();
                    }
                    catch (Exception x)
                    {

                        MessageBox.Show("Seleccione una celda" + x + ", Falta algun campo o tiene un dato invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                        conexion.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Compruebe que no tenga tareas o notas asignada a el cargo que trata de eliminar");
            }
            
        }

        private void dataGridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                n = e.RowIndex;
                if (n != -1)
                {
                    int val = (int)dataGridProducts.Rows[n].Cells[0].Value;
                    lblborrar.Text = "" + val;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Para poder eliminar una nota, tienes que elegir la ID de la nota");
            }
            

        }

        private void dataGridSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                n = e.RowIndex;
                if (n != -1)
                {
                    int val = (int)dataGridSales.Rows[n].Cells[0].Value;
                    lblborrar.Text = "" + val;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Para poder eliminar una tarea, tienes que elegir la ID de la tarea");
            }
        }

        private void dataGridProviders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                n = e.RowIndex;
                if (n != -1)
                {
                    int val = (int)dataGridProviders.Rows[n].Cells[0].Value;
                    lblborrar.Text = "" + val;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Para poder eliminar una cargo, tienes que elegir la ID de el cargo");
            }
        }

        private void dataGridPurchases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                n = e.RowIndex;
                if (n != -1)
                {
                    int val = (int)dataGridPurchases.Rows[n].Cells[0].Value;
                    lblborrar.Text = "" + val;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Para poder eliminar una cargo, tienes que elegir la ID de el cargo");
            }
        }

        private void comboOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboOpcion.SelectedItem == null)
            {
                button9.Visible = false;
                lblborrar.Visible = false;
            }
            //if (comboOpcion.SelectedItem== "Consultar")
            //{
            //    button9.Visible = false;
            //    lblborrar.Visible = false;
            //}
            if (comboOpcion.SelectedItem == "Insertar" && control_combobox==1)
            {
                button9.Visible = false;
                lblborrar.Visible = false;
                Add_Product obj = new Add_Product();
                obj.ShowDialog();
            }
            if (comboOpcion.SelectedItem == "Insertar" && control_combobox == 2)
            {
                button9.Visible = false;
                lblborrar.Visible = false;
                Add_Sales obj = new Add_Sales();
                obj.ShowDialog();
            }
            if (comboOpcion.SelectedItem == "Insertar" && control_combobox == 4)
            {
                button9.Visible = false;
                lblborrar.Visible = false;
                Add_Provedores obj = new Add_Provedores();
                obj.ShowDialog();
            }
            if (comboOpcion.SelectedItem == "Insertar" && control_combobox == 5)
            {
                button9.Visible = false;
                lblborrar.Visible = false;
                Add_compras obj = new Add_compras();
                obj.ShowDialog();
            }
            if (comboOpcion.SelectedItem == "Eliminar")
            {
                button9.Visible = true;
                lblborrar.Visible = true;
            }
        }

        private void dataGridSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormConta fc = new FormConta();
            fc.Show();
        }
    }
}
