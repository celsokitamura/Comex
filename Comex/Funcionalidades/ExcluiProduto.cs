using Comex.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Funcionalidades
{
    internal class ExcluiProduto : Funcionalidade
    {
        public ExcluiProduto(string titulo) : base(titulo)
        { }

        public override void Executar()
        {
            base.Executar();
            ExibirTitulo();

            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_LISTA_PRODUTO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Executando a Stored Procedure
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID = [{reader["id_produto"]}] - Descrição = [{reader["nm_produto"]}]");
                    }
                    reader.Close();
                }

                Console.WriteLine("Digite o ID do Produto que deseja excluir: ");
                int idProduto = int.Parse(Console.ReadLine());

                using (SqlCommand command02 = new SqlCommand("P_EXCLUI_PRODUTO", connection))
                {
                    command02.CommandType = CommandType.StoredProcedure;
                    command02.Parameters.AddWithValue("@id_produto", idProduto);

                    // Executando a Stored Procedure
                    command02.ExecuteNonQuery();
                }
            }
            
            Console.WriteLine($"Produto excluído com sucesso.");
            
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
