using Comex.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Funcionalidades
{
    internal class ConsultaProduto : Funcionalidade
    {
        public ConsultaProduto(string titulo) : base(titulo)
        { }

        public override void Executar(Dictionary<string, Produto> produtos)
        {
            base.Executar(produtos);
            ExibirTitulo();

            Console.WriteLine("Digite a categoria a ser pesquisada: ");
            string categoria = Console.ReadLine();

            foreach(var item in produtos.Values.Where(x => x.Categoria == categoria || categoria == ""))
            {
                Console.WriteLine($"Produto: [{item.Nome}], Preço: {item.Preco}");
            }

            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
