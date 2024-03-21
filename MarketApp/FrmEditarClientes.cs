using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MarketApp
{
    public partial class FrmEditarClientes : Form
    {
        private static FrmEditarClientes _instancia;

        public static FrmEditarClientes GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmEditarClientes();
            }
            return _instancia;
        }

        public FrmEditarClientes()
        {
            InitializeComponent();
        }

        public FrmEditarClientes(int pId)
        {
            InitializeComponent();
            Obtener_Clit(pId);
        }

        private void Obtener_Clit(int pId)
        {
            try
            {
                string connectionString = "Server=localhost;Database=db_minimercado;Trusted_Connection=True;Integrated Security=True";
                string query = "SELECT * FROM cliente WHERE id_cliente = @pId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@pId", pId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtid.Text = reader["id_cliente"].ToString();
                            txtnombre.Text = reader["nombre_cliente"].ToString();
                            txtapellido.Text = reader["apellido_cliente"].ToString();
                            textBox1.Text = reader["numero_carnet"].ToString();
                            textBox2.Text = reader["telefono"].ToString();
                            textBox3.Text = reader["direccion"].ToString();
                            textBox4.Text = reader["estado"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún cliente con el ID proporcionado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
