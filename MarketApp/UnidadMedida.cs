using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MarketApp
{
    public partial class UnidadMedida : Form
    {
        // Cadena de conexión a tu base de datos
        private string connectionString = "Data Source=.;Initial Catalog=prueba;Integrated Security=True";

        public UnidadMedida()
        {
            InitializeComponent();
            cargarunidadmedida(); // Carga los datos al iniciar el formulario

            // Suscribe el evento para manejar los clics en los botones de editar y eliminar
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void buttonUnid_Click(object sender, EventArgs e)
        {
            // Obtener los datos de la interfaz de usuario
            string nombreUnidad = textBoxNombreUni.Text;
            string abreviatura = textBoxAbrevia.Text;

            try
            {
                // Establecer la conexión con la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abrir la conexión
                    connection.Open();

                    if (buttonUnid.Text == "Actualizar") // Si se va a actualizar un registro existente
                    {
                        // Obtener el ID de la unidad de medida seleccionada
                        int idUnidad = Convert.ToInt32(buttonUnid.Tag);

                        // Query SQL para actualizar los datos en la tabla unidad_medida
                        string queryUpdate = "UPDATE unidad_medida SET nombre_medida = @nombre, abreviatura = @abreviatura WHERE id_unidad_medida = @idUnidad";
                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection))
                        {
                            // Agregar parámetros al comando SQL
                            commandUpdate.Parameters.AddWithValue("@nombre", nombreUnidad);
                            commandUpdate.Parameters.AddWithValue("@abreviatura", abreviatura);
                            commandUpdate.Parameters.AddWithValue("@idUnidad", idUnidad);

                            // Ejecutar el comando SQL
                            int rowsAffected = commandUpdate.ExecuteNonQuery();

                            // Verificar si se actualizó la fila correctamente
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("La Unidad de Medida se ha actualizado correctamente.");
                                cargarunidadmedida(); // Vuelve a cargar los datos en el DataGridView después de actualizar una unidad de medida
                                LimpiarCampos(); // Limpiar los campos de texto después de la actualización
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar la unidad.");
                            }
                        }
                    }
                    else // Si se va a insertar un nuevo registro
                    {
                        // Query SQL para la inserción de datos en la tabla unidad_medida
                        string queryInsert = "INSERT INTO unidad_medida (nombre_medida, abreviatura) VALUES (@nombre, @abreviatura)";
                        using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                        {
                            // Agregar parámetros al comando SQL
                            commandInsert.Parameters.AddWithValue("@nombre", nombreUnidad);
                            commandInsert.Parameters.AddWithValue("@abreviatura", abreviatura);

                            // Ejecutar el comando SQL
                            int rowsAffected = commandInsert.ExecuteNonQuery();

                            // Verificar si se insertaron filas correctamente
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("La Unidad de Medida se ha añadido correctamente.");
                                cargarunidadmedida(); // Vuelve a cargar los datos en el DataGridView después de agregar una nueva unidad de medida
                                LimpiarCampos(); // Limpiar los campos de texto después de la inserción
                            }
                            else
                            {
                                MessageBox.Show("No se pudo agregar la unidad.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la unidad de medida: " + ex.Message);
            }
        }

        // Método para limpiar los campos de texto
        private void LimpiarCampos()
        {
            textBoxNombreUni.Text = string.Empty;
            textBoxAbrevia.Text = string.Empty;
        }

        private void cargarunidadmedida()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string consulta = "SELECT * FROM VistaUnidadMedida";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    // Agregar columnas para editar y eliminar si aún no existen
                    if (!dt.Columns.Contains("Editar"))
                    {
                        dt.Columns.Add("Editar", typeof(string));
                    }

                    if (!dt.Columns.Contains("Eliminar"))
                    {
                        dt.Columns.Add("Eliminar", typeof(string));
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        row["Editar"] = "Editar";
                        row["Eliminar"] = "Eliminar";
                    }

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la unidad de medida: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si se hizo clic en el botón "Editar"
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Editar" && e.RowIndex >= 0)
            {
                // Obtener el ID de la fila seleccionada
                int idUnidad = (int)dataGridView1.Rows[e.RowIndex].Cells["id_unidad_medida"].Value;

                // Obtener los datos de la fila seleccionada
                string nombreUnidad = dataGridView1.Rows[e.RowIndex].Cells["nombre_medida"].Value.ToString();
                string abreviatura = dataGridView1.Rows[e.RowIndex].Cells["abreviatura"].Value.ToString();

                // Mostrar los datos en los controles de edición
                textBoxNombreUni.Text = nombreUnidad;
                textBoxAbrevia.Text = abreviatura;

                // Cambiar el texto del botón "Agregar" a "Actualizar"
                buttonUnid.Text = "Actualizar";

                // Almacenar el ID de la unidad de medida seleccionada en la propiedad Tag del botón "Agregar"
                buttonUnid.Tag = idUnidad;
            }

            // Verifica si se hizo clic en el botón "Eliminar"
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                // Pregunta al usuario si realmente quiere eliminar la unidad de medida seleccionada
                DialogResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar esta unidad de medida?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Obtener el ID de la fila seleccionada
                    int idUnidad = (int)dataGridView1.Rows[e.RowIndex].Cells["id_unidad_medida"].Value;

                    try
                    {
                        // Establecer la conexión con la base de datos
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            // Abrir la conexión
                            connection.Open();

                            // Query SQL para eliminar la unidad de medida
                            string queryDelete = "DELETE FROM unidad_medida WHERE id_unidad_medida = @idUnidad";
                            using (SqlCommand commandDelete = new SqlCommand(queryDelete, connection))
                            {
                                // Agregar parámetro al comando SQL
                                commandDelete.Parameters.AddWithValue("@idUnidad", idUnidad);

                                // Ejecutar el comando SQL
                                int rowsAffected = commandDelete.ExecuteNonQuery();

                                // Verificar si se eliminó la fila correctamente
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("La Unidad de Medida se ha eliminado correctamente.");
                                    cargarunidadmedida(); // Vuelve a cargar los datos en el DataGridView después de eliminar una unidad de medida
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar la unidad.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la unidad de medida: " + ex.Message);
                    }
                }
            }
        }
    }
}
