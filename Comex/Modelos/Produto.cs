using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Modelos
{
    internal class Produto
    {
        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
