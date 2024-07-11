using Comex.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Funcionalidades
{
    internal class ListaCliente : Funcionalidade
    {
        public ListaCliente(string titulo) : base(titulo)
        { }

        public override void Executar(Dictionary<string, Cliente> clientes)
        {
            base.Executar(clientes);
            ExibirTitulo();
            
            foreach (var cliente in clientes.Values)
            {
                Console.WriteLine($"Nome do cliente: {cliente.Nome}, CPF: {cliente.CPF}");

            }
            
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
