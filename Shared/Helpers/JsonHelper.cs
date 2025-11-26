using System.Text.Json;

namespace Shared.Helpers;

public static class JsonHelper<T>
{
    public static T? LoadJson(string json)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        var entities = JsonSerializer.Deserialize<T>(json, options);
        return entities;
    }
}