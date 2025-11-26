using LancarMovimentacoes.Entities;
using LancarMovimentacoes.Services;
using Shared.Helpers;

var opcao = 0;
string json = File.ReadAllText("Database/produtos.json");
var estoque = JsonHelper<EstoqueJson>.LoadJson(json);

if (estoque == null || estoque.Estoque.Count == 0)
    throw new Exception("Arquivo inválido");

var menuHandler = new MenuHandler(estoque.Estoque);

while (opcao != 4)
{
    menuHandler.ImprimirMenu();
    int.TryParse(Console.ReadLine(), out opcao);

    try
    {
        switch (opcao)
        {
            case 1:
                menuHandler.EntradaProduto();
                break;
            case 2:
                menuHandler.SaidaProduto();
                break;
            case 3:
                menuHandler.ListarProdutos();
                break;
            case 4:
                Console.WriteLine("Encerrando...");
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
}