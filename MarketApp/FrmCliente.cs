using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace MarketApp
{
    public partial class FrmCliente : Form
    {
        private static FrmCliente _instancia;
        private bool modoEdicion = false;


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
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private bool ValidarCamposCliente()
        {
            // Validar nombre_cliente: solo acepte letras y espacios
            if (!Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El nombre solo debe contener letras.");
                return false;
            }

            // Validar apellido_cliente: solo acepte letras y espacios
            if (!Regex.IsMatch(txtapellido.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El apellido solo debe contener letras.");
                return false;
            }

            // Validar numero_carnet: solo acepte números
            if (!Regex.IsMatch(textBox1.Text, @"^\d+$"))
            {
                MessageBox.Show("El número de carnet solo debe contener números.");
                return false;
            }

            // Validar telefono: solo acepte números
            if (!Regex.IsMatch(textBox2.Text, @"^\d+$"))
            {
                MessageBox.Show("El teléfono solo debe contener números.");
                return false;
            }

            // No se realizó validación para el campo dirección ya que se aceptan letras, números y espacios

            return true; // Todos los campos son válidos
        }




        //LIMPIAR CAMPOS
        private void clear()
        {
            this.txtnombre.Text = "";
            this.txtapellido.Text = "";
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            //this.textBox4.Text = "";
            this.textBox5.Text = "";
        }

        // Variable para controlar el modo del formulario
        private enum ModoFormulario
        {
            Agregar,
            Modificar
        }

        private ModoFormulario modoFormulario = ModoFormulario.Agregar;

        //CREAR CLIENTES
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si al menos un campo está lleno
                if (string.IsNullOrWhiteSpace(txtnombre.Text) &&
                    string.IsNullOrWhiteSpace(txtapellido.Text) &&
                    string.IsNullOrWhiteSpace(textBox1.Text) &&
                    string.IsNullOrWhiteSpace(textBox2.Text) &&
                    string.IsNullOrWhiteSpace(textBox3.Text) &&
                    string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("Al menos un campo debe ser completado.");
                    return;
                }

                // Verificar si todos los campos están llenos
                if (string.IsNullOrWhiteSpace(txtnombre.Text))
                {
                    MessageBox.Show("Por favor, llene el campo Nombre.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtapellido.Text))
                {
                    MessageBox.Show("Por favor, llene el campo Apellido.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, llene el campo Número de Carnet.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Por favor, llene el campo Teléfono.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Por favor, llene el campo Dirección.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("Por favor, seleccione un Estado.");
                    return;
                }

                if (!ValidarCamposCliente())
                {
                    return; // Si los campos no son válidos, no continuar con la inserción o modificación
                }

                string connectionString = "Server=localhost;Database=db_minimercado;Trusted_Connection=True;Integrated Security=True";
                string query;

                // Verificar si el cliente ya existe por el Carnet de Identidad
                if (ExisteClientePorCarnet(textBox1.Text, modoFormulario == ModoFormulario.Modificar ? textBox5.Text : null))
                {
                    MessageBox.Show("Ya existe un cliente con el mismo Carnet de Identidad.");
                    return; // No continuar con la inserción o modificación
                }

                // Formatear los valores de nombre, apellido y dirección
                string nombre = CapitalizeEachWord(txtnombre.Text);
                string apellido = CapitalizeEachWord(txtapellido.Text);
                string direccion = CapitalizeEachWord(textBox3.Text);

                // Construir la consulta SQL dependiendo del modo de formulario (Agregar o Modificar)
                if (modoFormulario == ModoFormulario.Agregar)
                {
                    // Query para agregar un nuevo cliente
                    query = "INSERT INTO cliente (nombre_cliente, apellido_cliente, numero_carnet, telefono, direccion, estado) " +
                                "VALUES (@nombre, @apellido, @carnet, @telefono, @direccion, @estado)";
                }
                else
                {
                    // Query para modificar un cliente existente
                    query = "UPDATE cliente SET nombre_cliente=@nombre, apellido_cliente=@apellido, numero_carnet=@carnet, telefono=@telefono, direccion=@direccion, estado=@estado WHERE id_cliente=@id";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@carnet", this.textBox1.Text);
                    command.Parameters.AddWithValue("@telefono", this.textBox2.Text);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@estado", this.comboBox1.Text);

                    // Agregar parámetros específicos para la modificación
                    if (modoFormulario == ModoFormulario.Modificar)
                    {
                        command.Parameters.AddWithValue("@id", this.textBox5.Text);
                    }

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        if (modoFormulario == ModoFormulario.Agregar)
                        {
                            MessageBox.Show("Cliente creado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Cliente actualizado correctamente.");
                        }
                        dataGridView1.DataSource = this.Listado_Cliente("");
                        RestablecerFormulario(); // Restablecer el formulario después de la inserción o modificación
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private string CapitalizeEachWord(string input)
        {
            // Dividir la cadena en palabras
            string[] words = input.Split(' ');

            // Crear una variable para almacenar la versión formateada
            string formattedString = "";

            // Recorrer todas las palabras y capitalizar la primera letra
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    formattedString += char.ToUpper(word[0]) + word.Substring(1).ToLower() + " ";
                }
            }

            // Eliminar el espacio adicional al final y devolver la cadena formateada
            return formattedString.TrimEnd();
        }

        // Función para verificar si existe un cliente con el mismo Carnet de Identidad
        private bool ExisteClientePorCarnet(string carnet, string clienteId)
        {
            string connectionString = "Server=localhost;Database=db_minimercado;Trusted_Connection=True;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM cliente WHERE numero_carnet = @carnet";

            // Si clienteId no es null, excluimos el cliente con ese ID de la búsqueda
            if (!string.IsNullOrEmpty(clienteId))
            {
                query += " AND id_cliente != @clienteId";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@carnet", carnet);
                if (!string.IsNullOrEmpty(clienteId))
                {
                    command.Parameters.AddWithValue("@clienteId", clienteId);
                }
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }




        //FUNCION BUSCAR CLIENTES
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

        //BOTON PARA BUSCAR CLIENTES
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        //FUNCION PARA MOVER LA COLUMNA EDITAR
        private void MoverColumnaAlFinal(DataGridView dataGridView, string nombreColumna)
        {
            if (dataGridView.Columns.Contains(nombreColumna))
            {
                int index = dataGridView.Columns[nombreColumna].DisplayIndex;
                dataGridView.Columns[nombreColumna].DisplayIndex = dataGridView.Columns.Count - 1;
            }
        }

        //CARGAR FOMRULARIO
        // Evento Load del formulario FrmCliente
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                // Ocultar el botón de "Modificar Cliente"
                button3.Visible = false;

                // Cargar la lista de clientes al cargar el formulario
                dataGridView1.DataSource = this.Listado_Cliente(txtid.Text.Trim());
                MoverColumnaAlFinal(dataGridView1, "Editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        // Evento CellClick del DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Editar")
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Obtener los valores de las celdas de la fila seleccionada
                int id_cliente = Convert.ToInt32(selectedRow.Cells["id_cliente"].Value);
                string nombre_cliente = Convert.ToString(selectedRow.Cells["nombre_cliente"].Value);
                string apellido_cliente = Convert.ToString(selectedRow.Cells["apellido_cliente"].Value);
                string numero_carnet = Convert.ToString(selectedRow.Cells["numero_carnet"].Value);
                string telefono = Convert.ToString(selectedRow.Cells["telefono"].Value);
                string direccion = Convert.ToString(selectedRow.Cells["direccion"].Value);
                string estado = Convert.ToString(selectedRow.Cells["estado"].Value);

                // Mostrar los valores en los TextBox correspondientes
                this.textBox5.Text = id_cliente.ToString();
                this.txtnombre.Text = nombre_cliente;
                this.txtapellido.Text = apellido_cliente;
                this.textBox1.Text = numero_carnet;
                this.textBox2.Text = telefono;
                this.textBox3.Text = direccion;
                this.comboBox1.Text = estado;

                // Cambiar el texto del botón de "Agregar Cliente" a "Modificar Cliente"
                button2.Text = "Modificar Cliente";
                // Mostrar el botón de "Modificar Cliente"
                button3.Visible = true;

                // Cambiar el modo de formulario a Modificar
                modoFormulario = ModoFormulario.Modificar;
            }
        }

        
        //FUNCION PARA CANCELAR
        private void button3_Click(object sender, EventArgs e)
        {
            if (modoFormulario == ModoFormulario.Modificar)
            {
                // Restablecer el estado del formulario
                RestablecerFormulario();
            }
            else
            {
                // Limpiar los campos y mostrar solo el botón de "Agregar Cliente"
                clear();
                button3.Visible = false; // Ocultar el botón "Cancelar"
                button2.Text = "Agregar Cliente"; // Restablecer el texto del botón "Agregar Cliente"

                // Cambiar el modo de formulario a Agregar
                modoFormulario = ModoFormulario.Agregar;
            }
        }
        // Método para restablecer el estado del formulario
        private void RestablecerFormulario()
        {
            // Restablecer el texto y comportamiento del botón "Agregar Cliente"
            button2.Text = "Agregar Cliente";
            // Ocultar el botón "Modificar Cliente"
            button3.Visible = false;
            // Limpiar los campos si es necesario
            clear();

            // Cambiar el modo de formulario a Agregar
            modoFormulario = ModoFormulario.Agregar;
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Realizar la búsqueda automáticamente mientras el usuario escribe
                dataGridView1.DataSource = this.Listado_Cliente(txtid.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtapellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }   
}
