using Comex.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Funcionalidades
{
    internal class AjustaPrecoDeProduto : Funcionalidade
    {
        public AjustaPrecoDeProduto(string titulo) : base(titulo)
        { }

        public override void Executar(Dictionary<string, Produto> produtos)
        {
            base.Executar(produtos);
            ExibirTitulo();
            
            Console.WriteLine("Digite o Nome do produto que deseja alterar");
            string nomeProduto = Console.ReadLine()!;

            Produto produtoParaAlteracao = null;
            foreach(var produto in produtos.Values)
            {
                if (produto.Nome == nomeProduto)
                {
                    produtoParaAlteracao = produto;
                    produtos.Remove(nomeProduto);
                }
            }
            if (produtoParaAlteracao != null)
            {
                Console.WriteLine("Digite o novo preço do produto");
                decimal precoProduto = decimal.Parse(Console.ReadLine()!);
                produtoParaAlteracao.Preco = precoProduto;
                produtos.Add(nomeProduto, produtoParaAlteracao);
                Console.WriteLine($"Preço do produto {nomeProduto} alterado com sucesso.");
            }
            else
            {
                Console.WriteLine("Produto não cadastrado no sistema.");
            }
                       
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
