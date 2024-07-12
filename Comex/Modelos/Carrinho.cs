using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Modelos
{
    internal class Carrinho
    {
        public Carrinho(Cliente cliente)
        {
            Cliente = cliente;
            Produtos = new List<Produto>();
        }

        public Cliente Cliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public string NumeroCartao { get; set; }
    }
}
