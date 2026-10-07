using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.Json;
public class JsonDataFileSource : IPersonSource
{
    private readonly string Filename;
    public JsonDataFileSource(string filename) {
        Filename = filename.Trim();
    }
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    public async Task<List<Person>> GetPeople()
    {
        try
        {
            using var sr = new StreamReader(Filename);

            string content = await sr.ReadToEndAsync();
            List<Person>? people = JsonSerializer.Deserialize<List<Person>>(content, _jsonOptions) ?? new List<Person>();
            return people;
   
        } catch (Exception ex) {
            Console.WriteLine($"Error reading or deserializing JSON file: {ex.Message}");
            return new List<Person>();
        }
    }
}