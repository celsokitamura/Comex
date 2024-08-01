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
    internal class ExcluiCliente : Funcionalidade
    {
        public ExcluiCliente(string titulo) : base(titulo)
        { }

        public override void Executar()
        {
            base.Executar();
            ExibirTitulo();

            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_LISTA_CLIENTE", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Executando a Stored Procedure
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID = [{reader["id_cliente"]}] - Nome = [{reader["nm_cliente"]}]");
                    }
                    reader.Close();
                }

                Console.WriteLine("Digite o ID do Cliente que deseja excluir: ");
                int idCliente = int.Parse(Console.ReadLine());

                using (SqlCommand command02 = new SqlCommand("P_EXCLUI_CLIENTE", connection))
                {
                    command02.CommandType = CommandType.StoredProcedure;
                    command02.Parameters.AddWithValue("@id_cliente", idCliente);

                    // Executando a Stored Procedure
                    command02.ExecuteNonQuery();
                }
            }
            
            Console.WriteLine($"Cliente excluído com sucesso.");
            
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
