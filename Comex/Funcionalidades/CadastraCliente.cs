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
    internal class CadastraCliente : Funcionalidade
    {
        public CadastraCliente(string titulo) : base(titulo)
        { }

        public override void Executar()
        {
            base.Executar();
            ExibirTitulo();

            string connectionString = "Data Source=kitamurag15;Initial Catalog=COMEX;Integrated Security=True";

            Console.WriteLine("Digite o CPF do cliente");
            string cpfCliente = Console.ReadLine()!;
            Console.WriteLine("Digite o Nome do cliente");
            string nomeCliente = Console.ReadLine()!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("P_INCLUI_CLIENTE", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cpf_cliente", cpfCliente);
                    command.Parameters.AddWithValue("@nm_cliente", nomeCliente);

                    // Executando a Stored Procedure
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine($"Usuário {nomeCliente} ({cpfCliente}) cadastrado com sucesso.");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
