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
    internal class CadastraCategoria : Funcionalidade
    {
        public CadastraCategoria(string titulo) : base(titulo)
        { }

        public override void Executar()
        {
            base.Executar();
            ExibirTitulo();

            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            Console.WriteLine("Digite a descrição da Categoria: ");
            string dsCategoria = Console.ReadLine()!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_INCLUI_CATEGORIA", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ds_categoria", dsCategoria);
                    
                    // Executando a Stored Procedure
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"Categoria {dsCategoria} cadastrada com sucesso.");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
