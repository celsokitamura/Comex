using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Comex.Modelos
{
    internal class Produto
    {
        public Produto(int id, string nome, decimal preco, string descricao, string categoria)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Categoria = categoria;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("title")] 
        public string Nome { get; set; }
        
        [JsonPropertyName("price")]
        public decimal Preco { get; set; }
        
        [JsonPropertyName("description")] 
        public string Descricao { get; set; }
        
        [JsonPropertyName("category")]
        public string Categoria { get; set; }

        public int Quantidade { get; set; }
    }
}
