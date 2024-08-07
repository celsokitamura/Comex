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
    internal class ListaCliente : Funcionalidade
    {
        public ListaCliente(string titulo) : base(titulo)
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
                        Console.WriteLine($"Id = [{reader["id_cliente"]}] - Nome = [{reader["nm_cliente"]}] - CPF = [{reader["cpf_cliente"]}]");
                    }
                }
            }

            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
