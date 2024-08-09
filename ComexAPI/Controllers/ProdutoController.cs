using ComexAPI.Repository;
using ComexLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ComexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        public ProdutoController() { }

        CategoriaRepository categoriaRepository = new CategoriaRepository();

        [HttpGet(Name = "GetProduto")]
        public IEnumerable<Produto> Get()
        {
            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_LISTA_PRODUTO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Executando a Stored Procedure
                    SqlDataReader reader = command.ExecuteReader();

                    List<Produto> retorno = new List<Produto>();

                    while (reader.Read())
                    {
                        retorno.Add(new Produto
                        {
                            id_produto = int.Parse(reader["id_produto"].ToString()),
                            nm_produto = reader["nm_produto"].ToString(),
                            vl_preco = decimal.Parse(reader["vl_preco"].ToString()),
                            ds_descricao = reader["ds_descricao"].ToString(),
                            id_categoria = int.Parse(reader["id_categoria"].ToString())
                        });
                    }

                    return retorno;
                }
            }
        }

        [HttpPost(Name = "Inclui")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public void Inclui([FromBody] ProdutoRequest produto)
        {
            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_INCLUI_PRODUTO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nm_produto", produto.Nome);
                    command.Parameters.AddWithValue("@vl_preco", produto.Preco);
                    command.Parameters.AddWithValue("@ds_descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@id_categoria", produto.IdCategoria);
                    command.Parameters.AddWithValue("@url_imagem", "");

                    // Executando a Stored Procedure
                    command.ExecuteNonQuery();
                }
            }
        }

        [HttpPut(Name = "Altera")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public void Altera([FromBody] ProdutoRequest produto)
        {
            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_ALTERA_PRODUTO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_produto", produto.Id);
                    command.Parameters.AddWithValue("@nm_produto", produto.Nome);
                    command.Parameters.AddWithValue("@vl_preco", produto.Preco);
                    command.Parameters.AddWithValue("@ds_descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@id_categoria", produto.IdCategoria);
                    command.Parameters.AddWithValue("@url_imagem", "");

                    // Executando a Stored Procedure
                    command.ExecuteNonQuery();
                }
            }
        }

        [HttpDelete("{id}")]
        public void Exclui(int id)
        {
            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_EXCLUI_PRODUTO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_produto", id);

                    // Executando a Stored Procedure
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
