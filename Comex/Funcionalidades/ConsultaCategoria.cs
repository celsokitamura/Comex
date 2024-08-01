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
    internal class ConsultaCategoria : Funcionalidade
    {
        public ConsultaCategoria(string titulo) : base(titulo)
        { }

        public override void Executar()
        {
            base.Executar();
            ExibirTitulo();

            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_LISTA_CATEGORIA", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    // Executando a Stored Procedure
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        Console.WriteLine($"Código = [{reader["id_categoria"]}] - Descrição = [{reader["ds_categoria"]}]");
                    }
                }
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
