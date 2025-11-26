using CalculaComissao.Entities;
using CalculaComissao.Services;
using Shared.Helpers;


string json = File.ReadAllText("Database/vendas.json");
var vendas = JsonHelper<VendasJson>.LoadJson(json);

if (vendas == null || vendas.Vendas.Count == 0)
    throw new Exception("Arquivo inválido");

var service = new VendaService(vendas.Vendas);
var resultado = service.CalculaComissao();

Console.WriteLine("Resultado das comissões:");
foreach (var item in resultado)
{
    Console.WriteLine($"Vendedor: {item.Vendedor} - Comissão: R$ {item.Comissao}");
}