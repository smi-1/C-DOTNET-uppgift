using System.Text.Json;
public class JsonDataFileSource : IPersonSource
{
    public static string Filename {get;set;}
    public JsonDataFileSource(string filename) {
        Filename = filename.Trim();
        GetPeople();
    }
    
    public async Task<List<Person>> GetPeople()
    {
        using (StreamReader sr = new StreamReader(Filename))
        {
            string content = await sr.ReadToEndAsync();
            List<Person>? people = JsonSerializer.Deserialize<List<Person>>(content) ?? new List<Person>();
            return people;
        }
    }
}