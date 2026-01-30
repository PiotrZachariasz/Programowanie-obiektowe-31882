using System.Text.Json;

namespace DziennikTreningow.Data;

public class JsonDataStore<T>
{
    private readonly string _filePath;

    public JsonDataStore(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(T data)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(data, options);
        File.WriteAllText(_filePath, json);
    }

    public T? Load()
    {
        if (!File.Exists(_filePath)) return default;

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<T>(json);
    }
}