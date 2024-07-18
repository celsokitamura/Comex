using Comex.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Funcionalidades
{
    internal class AdicionaProdutoNoCarrinho : Funcionalidade
    {
        public AdicionaProdutoNoCarrinho(string titulo) : base(titulo)
        { }

        public override void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos, Dictionary<string, Carrinho> carrinhos, int[] estoque)
        {
            base.Executar();
            ExibirTitulo();

            Carrinho carrinho = null;
            
            Console.WriteLine("Digite o Nome do Cliente que está comprando: ");
            string nomeCliente = Console.ReadLine()!;

            Cliente clienteComprando = null;
            foreach(var cliente in clientes.Values)
            {
                if (cliente.Nome == nomeCliente)
                    clienteComprando = cliente;
            }
            if (clienteComprando != null)
            {
                carrinho = new Carrinho(clienteComprando);


                Console.WriteLine("Digite o nome do produto a ser adicionado no carrinho: ");
                string nomeProduto = Console.ReadLine()!;

                Produto produtoComprado = null;
                foreach (var produto in produtos.Values)
                {
                    if (produto.Nome == nomeProduto)
                        produtoComprado = produto;
                }
                if (produtoComprado != null)
                {
                    Console.WriteLine("Digite a quantidade que deseja adicionar ao carrinho: ");

                    int quantidadeDesejada;

                    if(!int.TryParse(Console.ReadLine(), out quantidadeDesejada) || quantidadeDesejada <= 0)
                    {
                        Console.WriteLine("Quantidade inválida.");
                        return;
                    }

                    int indiceProduto = Array.IndexOf(produtos.Keys.ToArray(), nomeProduto);

                    if (estoque[indiceProduto] < quantidadeDesejada)
                    {
                        Console.WriteLine($"Quantidade insuficiente no estoque. Disponíveis: {estoque[indiceProduto]}");
                    }
                    else
                    {
                        estoque[indiceProduto] -= quantidadeDesejada;
                        produtoComprado.Quantidade = quantidadeDesejada;
                        carrinho.Produtos.Add(produtoComprado);
                        carrinhos.Add(carrinho.Cliente.Nome, carrinho);
                        Console.WriteLine($"{quantidadeDesejada} unidade(s) de {nomeProduto} adicionada(s) ao carrinho.");
                    }
                }
                else
                {
                    Console.WriteLine("Produto não cadastrado no sistema.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não cadastrado no sistema.");
            }
                       
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
