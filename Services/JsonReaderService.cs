using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SudokuHacker.Services;

public static class JsonReaderService
{
    private static string StaticData => "StaticData";
    public static string ReadJson(string fileName)
    {
		try
		{
            var jsonFilePath = Path.Combine(StaticData, fileName);
            var jsonContent = File.ReadAllText(jsonFilePath);
            return jsonContent;
        }
		catch(Exception ex)
		{
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
     
    public static T ReadDictionaryData<T>(string fileName, string key)
        where T : class
    {
        var json = ReadJson(fileName);
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        }; 
        var data = JsonSerializer
            .Deserialize<Dictionary<string, T>>(json, options);
        data!.TryGetValue(key, out var value);
        return value!;
    }
}
