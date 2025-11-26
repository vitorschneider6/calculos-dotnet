using LancarMovimentacoes.Entities;
using LancarMovimentacoes.Enums;

namespace LancarMovimentacoes.Services;

public class EstoqueService
{
    private List<Produto>? _produtos;

    public EstoqueService(List<Produto>? produtos)
    {
        _produtos = produtos;
    }

    public Produto? GetProdutoByCodigo(int codigo)
    {
        var produto = _produtos.FirstOrDefault(p => p.CodigoProduto == codigo);
        
        return produto;
    }
    public Produto RealizarOperacaoEstoque(TipoOperacao tipoOperacao, int codigoProduto, int quantidade)
    {
        var produto = _produtos.FirstOrDefault(p => p.CodigoProduto == codigoProduto);

        if (produto == null)
            throw new Exception("Produto não encontrado.");

        if (tipoOperacao == TipoOperacao.Entrada)
        {
            produto.Estoque += quantidade;
        }
        else if (tipoOperacao == TipoOperacao.Saida)
        {
            if (produto.Estoque < quantidade)
                throw new Exception("Estoque insuficiente!");

            produto.Estoque -= quantidade;
        }

        return produto;
    }

    public IEnumerable<Produto>? ObterProdutos()
    {
        return _produtos;
    }
}