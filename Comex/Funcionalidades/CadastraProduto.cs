using Comex.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Funcionalidades
{
    internal class CadastraProduto : Funcionalidade
    {
        public CadastraProduto(string titulo) : base(titulo)
        { }

        public override void Executar(Dictionary<string, Produto> produtos)
        {
            base.Executar(produtos);
            ExibirTitulo();
            /*Console.WriteLine("Digite o Nome do produto");
            string nomeProduto = Console.ReadLine()!;
            Console.WriteLine("Digite o Preço do produto");
            decimal precoProduto = decimal.Parse(Console.ReadLine()!);
            Produto produto = new Produto(nomeProduto, precoProduto);
            produtos.Add(nomeProduto, produto);

            Console.WriteLine($"Produto {nomeProduto} cadastrado com sucesso.");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();*/

        }
    }
}
