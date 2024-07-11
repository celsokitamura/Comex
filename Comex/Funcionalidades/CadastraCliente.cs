using Comex.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Funcionalidades
{
    internal class CadastraCliente : Funcionalidade
    {
        public CadastraCliente(string titulo) : base(titulo)
        { }

        public override void Executar(Dictionary<string, Cliente> clientes)
        {
            base.Executar(clientes);
            ExibirTitulo();
            Console.WriteLine("Digite o CPF do cliente");
            string cpfCliente = Console.ReadLine()!;
            Console.WriteLine("Digite o Nome do cliente");
            string nomeCliente = Console.ReadLine()!;
            Cliente cliente = new Cliente(nomeCliente, cpfCliente);
            clientes.Add(nomeCliente, cliente);

            Console.WriteLine($"Usuário {nomeCliente} ({cpfCliente}) cadastrado com sucesso.");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
