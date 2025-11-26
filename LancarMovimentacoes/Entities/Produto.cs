namespace LancarMovimentacoes.Entities;

public class Produto
{
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; } = String.Empty;
    public int Estoque { get; set; }
}