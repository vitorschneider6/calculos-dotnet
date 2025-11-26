try
{
    CalculoJuros.Services.MenuHandler.Inicializar();
}
catch (Exception ex)
{
    Console.WriteLine("Erro: " + ex.Message);
}