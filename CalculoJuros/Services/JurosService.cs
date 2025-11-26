using Shared.ExtensionMethods;

namespace CalculoJuros.Services;

public static class JurosService
{
    private static readonly decimal MultaPorDia = 0.025m;
    public static decimal CalculaJuros(decimal valor, DateTime dataVencimento)
    {
        DateTime hoje = DateTime.Now.GetBrazilianTimeStamp();

        if (hoje <= dataVencimento)
            return 0m;

        int diasAtraso = (hoje - dataVencimento).Days;
        decimal juros = valor * MultaPorDia * diasAtraso;
        
        return Math.Round(juros, 2);
    }
}