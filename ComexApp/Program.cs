using System;
using ComexLibrary;
using Newtonsoft.Json;

namespace ComexApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto produto = new Produto
            {
                Id = 1,
                Nome = "Notebook",
                Preco = 3000.00m,
                Descricao = "Notebook de alta performance.",
                Categoria = "Eletrônicos"
            };

            decimal precoComDesconto = produto.CalcularPrecoComDesconto(10);

            //Serialização do objeto Produto em uma string JSON
            string json = JsonConvert.SerializeObject(produto);
            Console.WriteLine($"Objeto Produto serializado em JSON: {json}");

            //Desserialização da string JSON de volta para um objeto Produto
            Produto produtoDesserializado = JsonConvert.DeserializeObject<Produto>(json);

            Console.WriteLine("Objeto Produto desserializado do JSON: ");
            Console.WriteLine($"Id: {produtoDesserializado.Id}");
            Console.WriteLine($"Nome: {produtoDesserializado.Nome}");
            Console.WriteLine($"Preço: {produtoDesserializado.Preco}");
            Console.WriteLine($"Descrição: {produtoDesserializado.Descricao}");
            Console.WriteLine($"Categoria: {produtoDesserializado.Categoria}");
        }
    }
}