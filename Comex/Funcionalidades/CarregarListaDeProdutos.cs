using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comex.Modelos;

namespace Comex.Funcionalidades
{
    internal class CarregarListaDeProdutos : Funcionalidade
    {
        public CarregarListaDeProdutos(string titulo) : base(titulo)
        { }

        public override void Executar(Dictionary<string, Produto> produtos)
        {
            base.Executar(produtos);
            ExibirTitulo();

            if (!File.Exists("CargaProdutos.txt"))
            {
                Console.WriteLine("Arquivo de produtos não encontrado.");
                return;
            }

            produtos.Clear();

            using (StreamReader reader = new StreamReader("CargaProdutos.txt"))
            {
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    string[] partes = linha.Split("||"); //id;title;price;description;category

                    if (partes.Length == 5)
                    {
                        int id;
                        string nome = partes[1];
                        string descricao = partes[2];
                        decimal preco;
                        string categoria = partes[4];

                        if (int.TryParse(partes[0], out id) && decimal.TryParse(partes[3], out preco))
                        {
                            produtos.Add(nome, new Produto(id, nome, preco, descricao, categoria));
                        }
                    }
                }
            }

            Console.WriteLine("Lista de produtos carregada com sucesso.");

            Console.WriteLine("Digite um tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
