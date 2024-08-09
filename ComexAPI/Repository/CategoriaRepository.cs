using ComexLibrary;
using System.Data.SqlClient;
using System.Data;

namespace ComexAPI.Repository
{
    public class CategoriaRepository
    {
        public IEnumerable<Categoria> ListaCategoria()
        {
            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_LISTA_CATEGORIA", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Executando a Stored Procedure
                    SqlDataReader reader = command.ExecuteReader();

                    List<Categoria> retorno = new List<Categoria>();

                    while (reader.Read())
                    {
                        retorno.Add(new Categoria
                        {
                            id_categoria = int.Parse(reader["id_categoria"].ToString()),
                            ds_categoria = reader["ds_categoria"].ToString()
                        });
                    }

                    return retorno;
                }
            }
        }

        public Categoria ObtemCategoriaPorId(int idCategoria)
        {
            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_CONSULTA_CATEGORIA", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_categoria", idCategoria);
                    // Executando a Stored Procedure
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Categoria
                        {
                            id_categoria = int.Parse(reader["id_categoria"].ToString()),
                            ds_categoria = reader["ds_categoria"].ToString()
                        };
                    }
                    else
                    { 
                        return new Categoria();
                    }

                }
            }
        }

        public void IncluiCategoria(Categoria categoria)
        {
            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_INCLUI_CATEGORIA", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ds_categoria", categoria.ds_categoria);

                    // Executando a Stored Procedure
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AlteraCategoria(Categoria categoria)
        {
            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_ALTERA_CATEGORIA", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_categoria", categoria.id_categoria);
                    command.Parameters.AddWithValue("@ds_categoria", categoria.ds_categoria);

                    // Executando a Stored Procedure
                    command.ExecuteNonQuery();
                }
            }
        }


        public void ExcluiCategoria(int idCategoria)
        {
            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_EXCLUI_CATEGORIA", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_categoria", idCategoria);

                    // Executando a Stored Procedure
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
