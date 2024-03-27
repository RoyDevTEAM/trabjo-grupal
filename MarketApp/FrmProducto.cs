using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace MarketApp
{
    public partial class FrmProducto : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=prueba;Integrated Security=True";

        // Instancia estática del formulario Ssubcategoria
        private static Ssubcategoria categoriaForm;
        private static UnidadMedida unidadMedidaForm;

        public FrmProducto()
        {
            InitializeComponent();
            CargarSubCategoria();
            CargarUnidadMedida();
            AgregarColumnasEditarEliminar();
            CargarProductos();
            // Asociar el evento CellContentClick del DataGridView
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void AñadirCategoria_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario para agregar una nueva categoría
            if (categoriaForm == null || categoriaForm.IsDisposed)
            {
                categoriaForm = new Ssubcategoria();
            }
            categoriaForm.Show();
            categoriaForm.BringToFront();
        }

        public static FrmProducto GetInstancia()
        {
            return new FrmProducto();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void añadirMarca_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario Ssubcategoria ya está creado
            if (categoriaForm == null || categoriaForm.IsDisposed)
            {
                // Si no está creado o está cerrado, crear una nueva instancia
                categoriaForm = new Ssubcategoria();
            }

            // Mostrar el formulario Ssubcategoria
            categoriaForm.Show();
            categoriaForm.BringToFront(); // Asegurarse de que esté al frente
        }

        private void añadirUnidadM_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario Ssubcategoria ya está creado
            if (unidadMedidaForm == null || unidadMedidaForm.IsDisposed)
            {
                // Si no está creado o está cerrado, crear una nueva instancia
                unidadMedidaForm = new UnidadMedida();
            }

            // Mostrar el formulario Ssubcategoria
            unidadMedidaForm.Show();
            unidadMedidaForm.BringToFront(); // Asegurarse de que esté al frente
        }

        private void comboSubCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Método para obtener el ID de la categoría seleccionada
        private int ObtenerIdSubCategoria(string nombreSubCategoria, SqlConnection connection)
        {
            int idSubCategoria = -1; // Valor por defecto

            // Query SQL para obtener el ID de la categoría
            string query = "SELECT id_subcategoria FROM subcategoria WHERE nombre_subcategoria = @nombreSubCategoria";

            // Crear y ejecutar el comando SQL
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Agregar parámetro al comando SQL
                command.Parameters.AddWithValue("@nombreSubCategoria", nombreSubCategoria);

                // Ejecutar el comando SQL y obtener el ID de la categoría
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    idSubCategoria = Convert.ToInt32(result);
                }
            }

            return idSubCategoria;
        }

        private void CargarSubCategoria()
        {
            try
            {
                comboSubCateg.Items.Clear(); // Limpiar los elementos actuales del ComboBox

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT nombre_subcategoria FROM subcategoria";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreSubCategoria = reader["nombre_subcategoria"].ToString();
                                comboSubCateg.Items.Add(nombreSubCategoria);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las Subcategorías: " + ex.Message);
            }
        }

        // Método para obtener el ID de la UNIDAD MEDIDA seleccionada
        private int ObtenerIdUnidadMedida(string nombreUnidadMedida, SqlConnection connection)
        {
            int idUnidadMedida = -1; // Valor por defecto

            // Query SQL para obtener el ID de la categoría
            string query = "SELECT id_unidad_medida FROM unidad_medida WHERE abreviatura = @nombreUnidadMedida";

            // Crear y ejecutar el comando SQL
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Agregar parámetro al comando SQL
                command.Parameters.AddWithValue("@nombreUnidadMedida", nombreUnidadMedida);

                // Ejecutar el comando SQL y obtener el ID de la categoría
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    idUnidadMedida = Convert.ToInt32(result);
                }
            }

            return idUnidadMedida;
        }

        private void CargarUnidadMedida()
        {
            try
            {
                comboBoxUnid.Items.Clear(); // Limpiar los elementos actuales del ComboBox

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT abreviatura FROM unidad_medida";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreUnidadMedida = reader["abreviatura"].ToString();
                                comboBoxUnid.Items.Add(nombreUnidadMedida);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la unidad de medida: " + ex.Message);
            }
        }


        private void buttonAñadirProduc_Click(object sender, EventArgs e)
        {
            if (buttonAñadirProduc.Text == "Actualizar")
            {
                // Realizar la actualización del producto aquí
                if (comboSubCateg.SelectedItem != null && comboBoxUnid.SelectedItem != null)
                {
                    // Obtener los datos de la interfaz de usuario
                    int idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                    string nombreProducto = textBoxNombreProd.Text;
                    string precioProducto = textBoxPVenta.Text;
                    string descripcionProducto = textBoxDescrip.Text;
                    int stockProducto;

                    if (!int.TryParse(textBoxCantidad.Text, out stockProducto))
                    {
                        MessageBox.Show("Ingrese un valor numérico válido para el stock.");
                        return;
                    }

                    string subcategoriaSeleccionada = comboSubCateg.SelectedItem.ToString();
                    string unidadMedidaSeleccionada = comboBoxUnid.SelectedItem.ToString();

                    try
                    {
                        // Establecer la conexión con la base de datos
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            // Abrir la conexión
                            connection.Open();

                            // Obtener el ID de la subcategoría seleccionada
                            int idSubcategoria = ObtenerIdSubCategoria(subcategoriaSeleccionada, connection);

                            // Obtener el ID de la unidad de medida seleccionada
                            int idUnidadMedida = ObtenerIdUnidadMedida(unidadMedidaSeleccionada, connection);

                            // Query SQL para la actualización de datos en la tabla producto
                            string query = "UPDATE producto SET id_unidad_medida = @idUnidadMedida, " +
                                           "id_subcategoria = @idSubcategoria, nombre_producto = @nombreProducto, " +
                                           "precio_producto = @precioProducto, descripcion_producto = @descripcionProducto, " +
                                           "stock = @stock WHERE id_producto = @idProducto";

                            // Crear y ejecutar el comando SQL
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Agregar parámetros al comando SQL
                                command.Parameters.AddWithValue("@idUnidadMedida", idUnidadMedida);
                                command.Parameters.AddWithValue("@idSubcategoria", idSubcategoria);
                                command.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                                command.Parameters.AddWithValue("@precioProducto", precioProducto);
                                command.Parameters.AddWithValue("@descripcionProducto", descripcionProducto);
                                command.Parameters.AddWithValue("@stock", stockProducto);
                                command.Parameters.AddWithValue("@idProducto", idProducto);

                                // Ejecutar el comando SQL
                                int rowsAffected = command.ExecuteNonQuery();

                                // Verificar si se actualizó el producto correctamente
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("El producto se ha actualizado correctamente.");
                                    buttonAñadirProduc.Text = "Añadir";
                                    LimpiarCampos();
                                    CargarProductos();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo actualizar el producto.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar el producto: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una subcategoría y una unidad de medida.");
                }
            }
            else
            {
                // Código para añadir un nuevo producto (ya implementado anteriormente)
                if (comboSubCateg.SelectedItem != null && comboBoxUnid.SelectedItem != null)
                {
                    // Obtener los datos de la interfaz de usuario
                    string nombreProducto = textBoxNombreProd.Text;
                    string precioProducto = textBoxPVenta.Text;
                    string descripcionProducto = textBoxDescrip.Text;
                    int stockProducto;

                    if (!int.TryParse(textBoxCantidad.Text, out stockProducto))
                    {
                        MessageBox.Show("Ingrese un valor numérico válido para el stock.");
                        return;
                    }

                    string subcategoriaSeleccionada = comboSubCateg.SelectedItem.ToString();
                    string unidadMedidaSeleccionada = comboBoxUnid.SelectedItem.ToString();

                    try
                    {
                        // Establecer la conexión con la base de datos
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            // Abrir la conexión
                            connection.Open();

                            // Obtener el ID de la subcategoría seleccionada
                            int idSubcategoria = ObtenerIdSubCategoria(subcategoriaSeleccionada, connection);

                            // Obtener el ID de la unidad de medida seleccionada
                            int idUnidadMedida = ObtenerIdUnidadMedida(unidadMedidaSeleccionada, connection);

                            // Query SQL para la inserción de datos en la tabla producto
                            string query = "INSERT INTO producto (id_unidad_medida, id_subcategoria, nombre_producto, precio_producto, descripcion_producto, stock) " +
                                           "VALUES (@idUnidadMedida, @idSubcategoria, @nombreProducto, @precioProducto, @descripcionProducto, @stock)";

                            // Crear y ejecutar el comando SQL
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Agregar parámetros al comando SQL
                                command.Parameters.AddWithValue("@idUnidadMedida", idUnidadMedida);
                                command.Parameters.AddWithValue("@idSubcategoria", idSubcategoria);
                                command.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                                command.Parameters.AddWithValue("@precioProducto", precioProducto);
                                command.Parameters.AddWithValue("@descripcionProducto", descripcionProducto);
                                command.Parameters.AddWithValue("@stock", stockProducto);

                                // Ejecutar el comando SQL
                                int rowsAffected = command.ExecuteNonQuery();

                                // Verificar si se insertaron filas correctamente
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("El producto se ha añadido correctamente.");
                                    CargarProductos();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo agregar el producto.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al agregar el producto: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una subcategoría y una unidad de medida.");
                }
            }
        }





        private void CargarProductos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string consulta = "SELECT * FROM VistaProductos";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "EditarColumna")
                {
                    // Obtener el ID del producto seleccionado
                    int idProducto = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                    // Obtener los datos del producto seleccionado
                    string nombreProducto = dataGridView1.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
                    string precioProducto = dataGridView1.Rows[e.RowIndex].Cells["PRECIO"].Value.ToString();
                    string descripcionProducto = dataGridView1.Rows[e.RowIndex].Cells["DESCRIPCION"].Value.ToString();
                    int stockProducto = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CANTIDAD"].Value);
                    string subcategoriaSeleccionada = dataGridView1.Rows[e.RowIndex].Cells["SUBCATEGORIA"].Value.ToString();
                    string unidadMedidaSeleccionada = dataGridView1.Rows[e.RowIndex].Cells["ABREVIATURA"].Value.ToString();

                    // Rellenar los campos del formulario con los datos del producto seleccionado
                    textBoxNombreProd.Text = nombreProducto;
                    textBoxPVenta.Text = precioProducto;
                    textBoxDescrip.Text = descripcionProducto;
                    textBoxCantidad.Text = stockProducto.ToString();
                    comboSubCateg.SelectedItem = subcategoriaSeleccionada;
                    comboBoxUnid.SelectedItem = unidadMedidaSeleccionada;

                    // Cambiar el texto del botón de añadir a "Actualizar"
                    buttonAñadirProduc.Text = "Actualizar";
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "EliminarColumna")
                {
                    int idProducto = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este producto?",
                        "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                string query = "DELETE FROM producto WHERE id_producto = @idProducto";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@idProducto", idProducto);
                                    int rowsAffected = command.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("El producto se ha eliminado correctamente.");
                                        CargarProductos();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo eliminar el producto.");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void AgregarColumnasEditarEliminar()
        {
            DataGridViewButtonColumn editarColumna = new DataGridViewButtonColumn();
            editarColumna.Name = "EditarColumna";
            editarColumna.HeaderText = "Editar";
            editarColumna.Text = "Editar";
            editarColumna.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editarColumna);

            DataGridViewButtonColumn eliminarColumna = new DataGridViewButtonColumn();
            eliminarColumna.Name = "EliminarColumna";
            eliminarColumna.HeaderText = "Eliminar";
            eliminarColumna.Text = "Eliminar";
            eliminarColumna.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(eliminarColumna);
        }

        private void LimpiarCampos()
        {
            textBoxNombreProd.Text = "";
            textBoxPVenta.Text = "";
            textBoxDescrip.Text = "";
            textBoxCantidad.Text = "";
            comboSubCateg.SelectedItem = null;
            comboBoxUnid.SelectedItem = null;
        }

        private void textBusque_TextChanged(object sender, EventArgs e)
        {
            // Obtener el texto actual en textBox2
            string textoBusqueda = textBusque.Text.Trim();

            // Realizar la búsqueda en la vista de productos utilizando el texto ingresado
            BuscarProductoPorNombre(textoBusqueda);
        }

        private void BuscarProductoPorNombre(string nombreProducto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string consulta = "SELECT * FROM VistaProductos WHERE NOMBRE  LIKE @nombreProducto";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                    adaptador.SelectCommand.Parameters.AddWithValue("@nombreProducto", "%" + nombreProducto + "%");
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar productos: " + ex.Message);
            }
        }
    }
}