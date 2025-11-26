using LancarMovimentacoes.Entities;
using LancarMovimentacoes.Enums;

namespace LancarMovimentacoes.Services;

public class MenuHandler
{
    private readonly EstoqueService _estoqueService;

    public MenuHandler(List<Produto> produtos)
    {
        _estoqueService = new EstoqueService(produtos);
    }

    public void EntradaProduto()
    {
        int codigo = LerInt("Digite o código do produto: ");
        
        var produto = _estoqueService.GetProdutoByCodigo(codigo);
        if (produto is null)
            throw new Exception("Produto não encontrado.");
        
        int quantidade = LerInt("Digite a quantidade de entrada: ");
        var produtoAtualizado = _estoqueService.RealizarOperacaoEstoque(TipoOperacao.Entrada, codigo, quantidade);

        Console.WriteLine($"Entrada registrada! Novo estoque de {produtoAtualizado.DescricaoProduto}: {produtoAtualizado.Estoque}");
    }

    public void SaidaProduto()
    {
        int codigo = LerInt("Digite o código do produto: ");
        var produto = _estoqueService.GetProdutoByCodigo(codigo);
        if (produto is null)
            throw new Exception("Produto não encontrado.");
        
        int quantidade = LerInt("Digite a quantidade de saída: ");
        var produtoAtualizado = _estoqueService.RealizarOperacaoEstoque(TipoOperacao.Saida, codigo, quantidade);

        Console.WriteLine($"Saída registrada! Novo estoque de {produtoAtualizado.DescricaoProduto}: {produtoAtualizado.Estoque}");
    }

    public void ListarProdutos()
    {
        Console.WriteLine("\nEstoque atual:");
        var produtos = _estoqueService.ObterProdutos();
        foreach (var p in produtos)
            Console.WriteLine($"{p.CodigoProduto} - {p.DescricaoProduto} | Estoque: {p.Estoque}");
    }

    public void ImprimirMenu()
    {
        Console.WriteLine("Selecione alguma das opções:\n" +
                          "1- Entrada em produto\n" +
                          "2- Saída em produto\n" +
                          "3- Listar produtos\n" +
                          "4- Sair");
        Console.Write("> ");
    }

    private int LerInt(string mensagem)
    {
        Console.Write(mensagem);
        int valor;

        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Valor inválido. Digite novamente: ");
        }

        return valor;
    }
}