using CalculaComissao.Dtos;
using CalculaComissao.Entities;

namespace CalculaComissao.Services;

public class VendaService
{
    private List<Venda>? Vendas;

    public VendaService(List<Venda>? vendas)
    {
        Vendas = vendas;
    }
    public IEnumerable<ComissaoDto> CalculaComissao()
    {
        if (Vendas == null || Vendas.Count == 0)
            return new List<ComissaoDto>();
        
        var resultado = Vendas
            .GroupBy(v => v.Vendedor)
            .Select(g => new ComissaoDto(
                vendedor: g.Key,
                comissao: Math.Round(g.Sum(v => AplicaRegraComissao(v.Valor)), 2)
            ))
            .ToList();

        return resultado;
    }

    private decimal AplicaRegraComissao(decimal valor)
    {
        if (valor >= 500)
            return valor * 0.05m;
        else if (valor >= 100)
            return valor * 0.01m;

        return 0;
    }
}