using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MarketApp
{
    public partial class FrmCliente : Form
    {
        private static FrmCliente _instancia;


        public static FrmCliente GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmCliente();
            }
            return _instancia;
        }

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();

            // Mostrar el formulario FrmClientes
            frmClientes.Show();

        }

        private DataTable Listado_Cliente(string busqueda)
        {
            DataTable Table = new DataTable();
            try
            {
                // Cadena de conexión a la base de datos
                string connectionString = "Server=localhost;Database=db_minimercado;Trusted_Connection=True;Integrated Security=True";

                // Query SQL para buscar clientes por nombre, apellido o número de carnet
                string query = "SELECT id_cliente, nombre_cliente, apellido_cliente, numero_carnet, telefono, direccion, estado " +
                               "FROM cliente " +
                               "WHERE nombre_cliente LIKE @busqueda OR apellido_cliente LIKE @busqueda OR numero_carnet LIKE @busqueda";

                // Crear la conexión a la base de datos y el comando SQL
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Pasar el parámetro de búsqueda al comando SQL
                    command.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

                    // Crear un adaptador de datos para ejecutar el comando y llenar el DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(Table);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y registrarla si es necesario
                Console.WriteLine("Error: " + ex.Message);
            }

            return Table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.Listado_Cliente(txtid.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.Listado_Cliente(txtid.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Editar")
            {
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_cliente"].Value.ToString());
                FrmEditarClientes FeditC = new FrmEditarClientes(ID);
                FeditC.ShowDialog();
                Listado_Cliente("%");
            }
        }
    }   
}
