using Comex.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Funcionalidades
{
    internal class GerenciaEstoque : Funcionalidade
    {
        public GerenciaEstoque(string titulo) : base(titulo) 
        { }

        public override void Executar(int[] estoque, Dictionary<string, Produto> produtos)
        {
            base.Executar(estoque, produtos);
            ExibirTitulo();

            Console.WriteLine("Deseja adicionar ou remover itens do estoque? (adicionar/remover)");
            string acao = Console.ReadLine().ToLower();

            Console.WriteLine("Digite o nome do produto: ");
            string nomeProduto = Console.ReadLine();

            if (!produtos.ContainsKey(nomeProduto)) 
            {
                Console.WriteLine("Produto não cadastrado");
                return;
            }

            Produto produto = produtos[nomeProduto];
            int indiceProduto = Array.IndexOf(produtos.Keys.ToArray(), nomeProduto);

            Console.WriteLine("Digite a quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            if (acao == "adicionar")
            {
                estoque[indiceProduto] += quantidade;
            }
            else if (acao == "remover")
            {
                if (estoque[indiceProduto] < quantidade)
                {
                    Console.WriteLine("Quantidade insuficiente no estoque.");
                    return;
                }
                estoque[indiceProduto] -= quantidade;
            }
            else
            {
                Console.WriteLine("Ação inválida.");
                return;
            }

            Console.WriteLine($"Nova quantidade de {produto.Nome} no estoque: {estoque[indiceProduto]}");

            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
