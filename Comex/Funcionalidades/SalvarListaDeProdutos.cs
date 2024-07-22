using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comex.Modelos;

namespace Comex.Funcionalidades
{
    internal class SalvarListaDeProdutos : Funcionalidade
    {
        public SalvarListaDeProdutos(string titulo) : base(titulo)
        { }

        public override void Executar(Dictionary<string, Produto> produtos)
        {
            base.Executar(produtos);
            ExibirTitulo();

            using (StreamWriter writer = new StreamWriter("produtos.txt"))
            {
                foreach (var produto in produtos.Values)
                {
                    writer.WriteLine($"{produto.Id}||{produto.Nome}||{produto.Descricao}||{produto.Preco}||{produto.Categoria}");
                }
            }
            Console.WriteLine("Lista de produtos saqlva com sucesso.");

            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
