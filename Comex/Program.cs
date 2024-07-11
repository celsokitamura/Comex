using Comex.Funcionalidades;
using Comex.Modelos;
using System.Collections.Generic;

Dictionary<int, Funcionalidade> funcionalidades = new();

funcionalidades.Add(1, new CadastraCliente("Cadastrar Cliente"));
funcionalidades.Add(2, new ListaCliente("Listar Cliente"));
funcionalidades.Add(3, new CadastraProduto("Cadastrar Produto"));
funcionalidades.Add(4, new AjustaPrecoDeProduto("Ajustar Preço do Produto"));
funcionalidades.Add(5, new AdicionaProdutoNoCarrinho("Adicionar produto no carrinho"));
funcionalidades.Add(-1, new Sair("Sair"));


Dictionary<string, Cliente> clientes = new();
Dictionary<string, Produto> produtos = new();
Dictionary<string, Carrinho> carrinhos = new();


void ExibirMenuDeOpcoes()
{
    Console.WriteLine("BEM VINDO A COMEX!\n");
    Console.WriteLine("Digite 1 para Cadastrar um cliente");
    Console.WriteLine("Digite 2 para Listar clientes");
    Console.WriteLine("Digite 3 para Cadastrar um produto");
    Console.WriteLine("Digite 4 para Ajustar o Preço de um produto");
    Console.WriteLine("Digite 5 para Adicionar produto no carrinho");
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
                menuASerExibido.Executar(produtos);
                break;
            case 5:
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