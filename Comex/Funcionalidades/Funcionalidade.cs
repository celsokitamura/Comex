using Comex.Modelos;

namespace Comex.Funcionalidades
{
    internal class Funcionalidade
    {
        public string Titulo { get; set; }

        public Funcionalidade(string titulo)
        {
            Titulo = titulo;
        }

        public void ExibirTitulo()
        {
            Console.WriteLine($"****{Titulo}****\n");
        }

        public virtual void Executar(Dictionary<string, Cliente> clientes)
        {
            Console.Clear();
        }

        public virtual void Executar()
        {
            Console.Clear();
        }
        public virtual void Executar(Dictionary<string, Produto> produtos)
        {
            Console.Clear();
        }
        public virtual void Executar(Dictionary<string, Cliente> clientes, Dictionary<string, Produto> produtos, Dictionary<string, Carrinho> carrinhos, int[] estoque)
        {
            Console.Clear();
        }
        public virtual void Executar(int[] estoque, Dictionary<string, Produto> produtos)
        {
            Console.Clear();
        }
        public virtual void Executar(List<string> categorias, int[,] vendasPorCategoria)
        {
            Console.Clear();
        }


    }
}
