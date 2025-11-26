namespace CalculoJuros.Services;

public static class MenuHandler
{
    public static void Inicializar()
    {
        Console.WriteLine("Sistema de cálculo de juros");

        decimal valor = LerDecimal("Digite algum valor (, para casa decimal): ");
        DateTime data = LerData("Digite alguma data (formato dd/mm/aaaa): ");

        var resultado = JurosService.CalculaJuros(valor, data);
        Console.WriteLine("Juros: R$ " + resultado);
    }

    private static decimal LerDecimal(string mensagem)
    {
        decimal numero;

        while (true)
        {
            Console.Write(mensagem);
            var entrada = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Valor não pode ser vazio!");
                continue;
            }

            if (decimal.TryParse(entrada, out numero))
                return numero;

            Console.WriteLine("Número inválido! Digite novamente.");
        }
    }

    private static DateTime LerData(string mensagem)
    {
        DateTime data;

        while (true)
        {
            Console.Write(mensagem);
            var entrada = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Data não pode ser vazia!");
                continue;
            }

            if (DateTime.TryParseExact(
                    entrada,
                    "dd/MM/yyyy",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out data))
            {
                return data;
            }

            Console.WriteLine("Data inválida! Use o formato dd/mm/aaaa.");
        }
    }
}