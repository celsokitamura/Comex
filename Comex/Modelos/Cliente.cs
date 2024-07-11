using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Modelos
{
    internal class Cliente
    {
        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
