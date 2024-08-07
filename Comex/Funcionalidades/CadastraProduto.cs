﻿using Comex.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Funcionalidades
{
    internal class CadastraProduto : Funcionalidade
    {
        public CadastraProduto(string titulo) : base(titulo)
        { }

        public override void Executar()
        {
            base.Executar();
            ExibirTitulo();

            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            Console.WriteLine("Digite o Nome do produto");
            string nomeProduto = Console.ReadLine()!;
            Console.WriteLine("Digite o Preço do produto");
            decimal precoProduto = decimal.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite a Descrição do produto");
            string descricaoProduto = Console.ReadLine()!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_LISTA_CATEGORIA", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Executando a Stored Procedure
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID = [{reader["id_categoria"]}] - Descrição = [{reader["ds_categoria"]}]");
                    }
                    reader.Close();
                }

                Console.WriteLine("Digite o ID da Categoria: ");
                int idCategoria = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a URL da Imagem do produto");
                string urlImagem = Console.ReadLine()!;

                using (SqlCommand command02 = new SqlCommand("P_INCLUI_PRODUTO", connection))
                {
                    command02.CommandType = CommandType.StoredProcedure;
                    command02.Parameters.AddWithValue("@nm_produto", nomeProduto);
                    command02.Parameters.AddWithValue("@vl_preco", precoProduto);
                    command02.Parameters.AddWithValue("@ds_descricao", descricaoProduto);
                    command02.Parameters.AddWithValue("@id_categoria", idCategoria);
                    command02.Parameters.AddWithValue("@url_imagem", urlImagem);

                    // Executando a Stored Procedure
                    command02.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"Produto {nomeProduto} cadastrado com sucesso.");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
