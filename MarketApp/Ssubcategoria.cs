using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MarketApp
{
    public partial class Ssubcategoria : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=prueba;Integrated Security=True";
        //private static CCategoria CcategoriaForm;

        public Ssubcategoria()
        {
            InitializeComponent();
            CargarCategorias();
            cargarsubcate();

            // Asociar el evento CellContentClick del DataGridView
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void AñadirCategoria_Click(object sender, EventArgs e)
        {
            if (CCategoria.CcategoriaForm == null || CCategoria.CcategoriaForm.IsDisposed)
            {
                CCategoria.CcategoriaForm = new CCategoria();
            }
            CCategoria.CcategoriaForm.Show();
            CCategoria.CcategoriaForm.BringToFront();
        }

        private void buttonSubCAT_Click(object sender, EventArgs e)
        {
            if (comboBoxCat.SelectedItem != null)
            {
                string nombreSubcategoria = textBoxNombreSub.Text;
                string descripcionSubcategoria = textBoxDescriSub.Text;
                string categoriaSeleccionada = comboBoxCat.SelectedItem.ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        int idCategoria = ObtenerIdCategoria(categoriaSeleccionada, connection);

                        if (buttonSubCAT.Text == "Actualizar")
                        {
                            if (!int.TryParse(buttonSubCAT.Tag.ToString(), out int idSubcategoria))
                            {
                                MessageBox.Show("ID de subcategoría no válido.");
                                return;
                            }

                            string queryUpdate = "UPDATE subcategoria SET id_categoria = @idCategoria, nombre_subcategoria = @nombreSubcategoria, descripcion = @descripcionSubcategoria WHERE id_subcategoria = @idSubcategoria";
                            using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection))
                            {
                                commandUpdate.Parameters.AddWithValue("@idCategoria", idCategoria);
                                commandUpdate.Parameters.AddWithValue("@nombreSubcategoria", nombreSubcategoria);
                                commandUpdate.Parameters.AddWithValue("@descripcionSubcategoria", descripcionSubcategoria);
                                commandUpdate.Parameters.AddWithValue("@idSubcategoria", idSubcategoria);

                                int rowsAffected = commandUpdate.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("La subcategoría se ha actualizado correctamente.");
                                    cargarsubcate();
                                    LimpiarCampos();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo actualizar la subcategoría.");
                                }
                            }
                        }
                        else
                        {
                            string queryInsert = "INSERT INTO subcategoria (id_categoria, nombre_subcategoria, descripcion) VALUES (@idCategoria, @nombreSubcategoria, @descripcionSubcategoria)";
                            using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@idCategoria", idCategoria);
                                commandInsert.Parameters.AddWithValue("@nombreSubcategoria", nombreSubcategoria);
                                commandInsert.Parameters.AddWithValue("@descripcionSubcategoria", descripcionSubcategoria);

                                int rowsAffected = commandInsert.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("La subcategoría se ha añadido correctamente.");
                                    cargarsubcate();
                                    LimpiarCampos();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo agregar la subcategoría.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar/actualizar la subcategoría: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una categoría.");
            }
        }

        private int ObtenerIdCategoria(string nombreCategoria, SqlConnection connection)
        {
            int idCategoria = -1;

            string query = "SELECT id_categoria FROM categoria WHERE nombre_categoria = @nombreCategoria";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nombreCategoria", nombreCategoria);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    idCategoria = Convert.ToInt32(result);
                }
            }

            return idCategoria;
        }

        private void CargarCategorias()
        {
            try
            {
                comboBoxCat.Items.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT nombre_categoria FROM categoria";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreCategoria = reader["nombre_categoria"].ToString();
                                comboBoxCat.Items.Add(nombreCategoria);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message);
            }
        }

        private void Ssubcategoria_Load(object sender, EventArgs e)
        {
            cargarsubcate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int idsubcategoria))
            {
                MessageBox.Show("Ingrese un ID de subcategoría válido.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM subcategoria WHERE id_subcategoria = @idsubcategoria";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idsubcategoria", idsubcategoria);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("La subcategoría se ha eliminado correctamente.");
                            cargarsubcate();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la subcategoría. Asegúrese de que el ID de la subcategoría sea válido.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la subcategoría: " + ex.Message);
            }
        }

        private void cargarsubcate()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string consulta = "SELECT id_subcategoria, nombre_subcategoria, descripcion, nombre_categoria FROM VistaSubcategoria";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    // Agregar columnas "Editar" y "Eliminar" si no existen
                    if (!dt.Columns.Contains("Editar"))
                    {
                        dt.Columns.Add("Editar", typeof(string));
                    }

                    if (!dt.Columns.Contains("Eliminar"))
                    {
                        dt.Columns.Add("Eliminar", typeof(string));
                    }

                    // Asignar valores a las columnas "Editar" y "Eliminar" en cada fila
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Editar"] = "Editar";
                        row["Eliminar"] = "Eliminar";
                    }

                    // Asignar el DataTable como origen de datos del DataGridView
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la subcategoría: " + ex.Message);
            }
        }


        private void LimpiarCampos()
        {
            textBoxNombreSub.Text = string.Empty;
            textBoxDescriSub.Text = string.Empty;
            buttonSubCAT.Text = "Agregar"; // Restaurar el texto original del botón
            buttonSubCAT.Tag = null; // Limpiar el Tag del botón
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la celda seleccionada corresponde a la columna "Editar"
            if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID de la subcategoría seleccionada desde el DataGridView
                if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["id_subcategoria"].Value.ToString(), out int idSubcategoria))
                {
                    MessageBox.Show("ID de subcategoría no válido.");
                    return;
                }

                // Obtener otros datos de la subcategoría seleccionada
                string nombreSubcategoria = dataGridView1.Rows[e.RowIndex].Cells["nombre_subcategoria"].Value.ToString();
                string descripcionSubcategoria = dataGridView1.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();
                string nombreCategoria = dataGridView1.Rows[e.RowIndex].Cells["nombre_categoria"].Value.ToString();

                // Mostrar los datos en los campos correspondientes del formulario
                comboBoxCat.SelectedItem = nombreCategoria;
                textBoxNombreSub.Text = nombreSubcategoria;
                textBoxDescriSub.Text = descripcionSubcategoria;

                // Cambiar el texto del botón a "Actualizar" para indicar que se realizará una actualización
                buttonSubCAT.Text = "Actualizar";

                // Asignar el ID de la subcategoría al Tag del botón, para referencia durante la actualización
                buttonSubCAT.Tag = idSubcategoria;
            }
            // Verificar si la celda seleccionada corresponde a la columna "Eliminar"
            else if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Preguntar al usuario si está seguro de eliminar la subcategoría seleccionada
                DialogResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar esta subcategoría?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Obtener el ID de la subcategoría a eliminar desde el DataGridView
                    if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["id_subcategoria"].Value.ToString(), out int idSubcategoria))
                    {
                        MessageBox.Show("ID de subcategoría no válido.");
                        return;
                    }

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Query SQL para eliminar la subcategoría
                            string queryDelete = "DELETE FROM subcategoria WHERE id_subcategoria = @idSubcategoria";
                            using (SqlCommand commandDelete = new SqlCommand(queryDelete, connection))
                            {
                                commandDelete.Parameters.AddWithValue("@idSubcategoria", idSubcategoria);

                                int rowsAffected = commandDelete.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("La subcategoría se ha eliminado correctamente.");
                                    cargarsubcate(); // Actualizar la vista del DataGridView
                                    LimpiarCampos(); // Limpiar los campos del formulario
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar la subcategoría.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la subcategoría: " + ex.Message);
                    }
                }
            }
        }

        private void textBusque_TextChanged(object sender, EventArgs e)
        {
            // Obtener el texto actual en textBox2
            string textoBusqueda = textBusque.Text.Trim();

            // Realizar la búsqueda en la vista de subcategoria utilizando el texto ingresado
            BuscarSubcategoriaPorNombre(textoBusqueda);
        }

        private void BuscarSubcategoriaPorNombre(string nombreSubcategoria)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string consulta = "SELECT * FROM VistaSubcategoria WHERE nombre_subcategoria  LIKE @nombreSubcategoria";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                    adaptador.SelectCommand.Parameters.AddWithValue("@nombreSubcategoria", "%" + nombreSubcategoria + "%");
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar subcategoria: " + ex.Message);
            }
        }
    }
}