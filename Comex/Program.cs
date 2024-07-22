using Comex.Funcionalidades;
using Comex.Modelos;
using System.Collections.Generic;
using System.Text.Json;

Dictionary<int, Funcionalidade> funcionalidades = new();

funcionalidades.Add(1, new CadastraCliente("Cadastrar Cliente"));
funcionalidades.Add(2, new ListaCliente("Listar Cliente"));
funcionalidades.Add(3, new CadastraProduto("Cadastrar Produto"));
funcionalidades.Add(4, new ConsultaProduto("Listar Produto por Categoria"));
funcionalidades.Add(5, new AjustaPrecoDeProduto("Ajustar Preço do Produto"));
funcionalidades.Add(6, new AdicionaProdutoNoCarrinho("Adicionar produto no carrinho"));
funcionalidades.Add(7, new GerenciaEstoque("Gerenciar Estoque"));
funcionalidades.Add(8, new GerarRelatorioDeVendasPorCategoria("Gerar Relatório de Vendas por Categoria"));
funcionalidades.Add(9, new SalvarListaDeProdutos("Salvar Lista de Produtos"));
funcionalidades.Add(10, new CarregarListaDeProdutos("Carregar Lista de Produtos"));
funcionalidades.Add(-1, new Sair("Sair"));


Dictionary<string, Cliente> clientes = new();
Dictionary<string, Produto> produtos = new();
Dictionary<string, Carrinho> carrinhos = new();

int[] estoque = null;

List<string> categorias = new List<string> { "men's clothing", "jewelery", "electronics", "women's clothing" };

int[,] vendasPorCategoria = new int[4, 2];
//Dados fictícios para simplificação
vendasPorCategoria[0, 0] = 100;
vendasPorCategoria[0, 1] = 50000;
vendasPorCategoria[1, 0] = 200;
vendasPorCategoria[1, 1] = 30000;
vendasPorCategoria[2, 0] = 150;
vendasPorCategoria[2, 1] = 15000;
vendasPorCategoria[3, 0] = 355;
vendasPorCategoria[3, 1] = 55007;


using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://fakestoreapi.com/products");
        var listaProdutos = JsonSerializer.Deserialize<List<Produto>>(resposta);

        foreach (var item in listaProdutos)
        {
            produtos.Add(item.Nome.Trim(), new Produto(item.Id, item.Nome.Trim(), item.Preco, item.Descricao, item.Categoria));
        }
        //INicializa o estoque com base na quantidade de produtos
        estoque = new int[produtos.Count];
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Erro no carregamento dos produtos: {ex.Message}");
    }
}



void ExibirMenuDeOpcoes()
{
    Console.WriteLine("BEM VINDO A COMEX!\n");
    Console.WriteLine("Digite 1 para Cadastrar um cliente");
    Console.WriteLine("Digite 2 para Listar clientes");
    //Console.WriteLine("Digite 3 para Cadastrar um produto");
    Console.WriteLine("Digite 4 para Listar Produto por Categoria");
    Console.WriteLine("Digite 5 para Ajustar o Preço de um produto");
    Console.WriteLine("Digite 6 para Adicionar produto no carrinho");
    Console.WriteLine("Digite 7 para Gerenciar o estoque");
    Console.WriteLine("Digite 8 para Gerar Relatório de Vendas por Categoria");
    Console.WriteLine("Digite 9 para Salvar Lista de Produtos");
    Console.WriteLine("Digite 10 para Carregar Lista de Produtos");
    Console.WriteLine("Digite -1 pra sair");

    Console.WriteLine("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if(funcionalidades.ContainsKey(opcaoEscolhidaNumerica))
    {
        Funcionalidade menuASerExibido = funcionalidades[opcaoEscolhidaNumerica];
        
        switch(opcaoEscolhidaNumerica)
        {
            case 1:
            case 2:
                menuASerExibido.Executar(clientes);
                break;
            case 3:
            case 4:
            case 5:
            case 9:
            case 10:
                menuASerExibido.Executar(produtos);
                break;
            case 6:
                menuASerExibido.Executar(clientes, produtos, carrinhos, estoque);
                break;
            case 7:
                menuASerExibido.Executar(estoque, produtos);
                break;
            case 8:
                menuASerExibido.Executar(categorias, vendasPorCategoria);
                break;
            default:
                menuASerExibido.Executar();
                break;
        }
        
        if (opcaoEscolhidaNumerica > 0) ExibirMenuDeOpcoes();
    }
    else
    {
        Console.WriteLine("Opção inválida!");
    }


}

ExibirMenuDeOpcoes();