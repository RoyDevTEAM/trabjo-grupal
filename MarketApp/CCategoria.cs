using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MarketApp
{
    public partial class CCategoria : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=prueba;Integrated Security=True";
        public static CCategoria CcategoriaForm;

        public CCategoria()
        {
            InitializeComponent();
            CargarCategorias();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void buttonCat_Click(object sender, EventArgs e)
        {
            string nombreCategoria = textNOMBRECAT.Text;
            string descripcion = textDESCRICAT.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (buttonCat.Text == "Actualizar")
                    {
                        if (!int.TryParse(buttonCat.Tag.ToString(), out int idCategoria))
                        {
                            MessageBox.Show("ID de categoría no válido.");
                            return;
                        }

                        string queryUpdate = "UPDATE categoria SET nombre_categoria = @nombre, descripcion = @descripcion WHERE id_categoria = @idCategoria";
                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection))
                        {
                            commandUpdate.Parameters.AddWithValue("@nombre", nombreCategoria);
                            commandUpdate.Parameters.AddWithValue("@descripcion", descripcion);
                            commandUpdate.Parameters.AddWithValue("@idCategoria", idCategoria);

                            int rowsAffected = commandUpdate.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("La categoría se ha actualizado correctamente.");
                                CargarCategorias();
                                LimpiarCampos();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar la categoría.");
                            }
                        }
                    }
                    else
                    {
                        string queryInsert = "INSERT INTO categoria (nombre_categoria, descripcion) VALUES (@nombre, @descripcion)";
                        using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                        {
                            commandInsert.Parameters.AddWithValue("@nombre", nombreCategoria);
                            commandInsert.Parameters.AddWithValue("@descripcion", descripcion);

                            int rowsAffected = commandInsert.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("La categoría se ha añadido correctamente.");
                                CargarCategorias();
                                LimpiarCampos();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo agregar la categoría.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la categoría: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            textNOMBRECAT.Text = string.Empty;
            textDESCRICAT.Text = string.Empty;
        }

        private void CargarCategorias()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string consulta = "SELECT * FROM VistaCategoria";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

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
                MessageBox.Show("Error al cargar la categoría: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Editar" && e.RowIndex >= 0)
            {
                int idCategoria;
                if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString(), out idCategoria))
                {
                    MessageBox.Show("ID de categoría no válido.");
                    return;
                }

                string nombreCateg = dataGridView1.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
                string descripcion = dataGridView1.Rows[e.RowIndex].Cells["DESCRIPCION"].Value.ToString();

                textNOMBRECAT.Text = nombreCateg;
                textDESCRICAT.Text = descripcion;

                buttonCat.Text = "Actualizar";
                buttonCat.Tag = idCategoria;
            }

            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar esta categoría?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int idCategoria;
                    if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString(), out idCategoria))
                    {
                        MessageBox.Show("ID de categoría no válido.");
                        return;
                    }

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string queryDelete = "DELETE FROM categoria WHERE id_categoria = @idCategoria";
                            using (SqlCommand commandDelete = new SqlCommand(queryDelete, connection))
                            {
                                commandDelete.Parameters.AddWithValue("@idCategoria", idCategoria);

                                int rowsAffected = commandDelete.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("La categoría se ha eliminado correctamente.");
                                    CargarCategorias();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar la categoría.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la categoría: " + ex.Message);
                    }
                }
            }
        }
    }
}
