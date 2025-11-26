namespace CalculaComissao.Dtos;

public class ComissaoDto
{
    public string Vendedor { get; set; }
    public decimal Comissao { get; set; }

    public ComissaoDto(string vendedor, decimal comissao)
    {
        Vendedor = vendedor;
        Comissao = comissao;
    }
}