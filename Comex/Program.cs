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
funcionalidades.Add(-1, new Sair("Sair"));


Dictionary<string, Cliente> clientes = new();
Dictionary<string, Produto> produtos = new();
Dictionary<string, Carrinho> carrinhos = new();

using(HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://fakestoreapi.com/products");
        var listaProdutos = JsonSerializer.Deserialize<List<Produto>>(resposta);

        foreach (var item in listaProdutos)
        {
            produtos.Add(item.Nome.Trim(), new Produto(item.Id, item.Nome.Trim(), item.Preco, item.Descricao, item.Categoria));
        }
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
                menuASerExibido.Executar(produtos);
                break;
            case 6:
                menuASerExibido.Executar(clientes, produtos, carrinhos);
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