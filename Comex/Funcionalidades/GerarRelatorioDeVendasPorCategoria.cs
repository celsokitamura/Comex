using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Funcionalidades
{
    internal class GerarRelatorioDeVendasPorCategoria : Funcionalidade
    {
        public GerarRelatorioDeVendasPorCategoria(string titulo) : base(titulo) 
        { }

        public override void Executar(List<string> categorias, int[,] vendasPorCategoria)
        {
            base.Executar(categorias, vendasPorCategoria);
            ExibirTitulo();

            for (int i = 0; i < categorias.Count; i++) 
            {
                Console.WriteLine($"{categorias[i]}: ");
                Console.WriteLine($"Quantidade Vendida: {vendasPorCategoria[i, 0]}");
                Console.WriteLine($"Total de Receitas: R$ {vendasPorCategoria[i, 1]}");
                Console.WriteLine();
            }
        }
    }
}
