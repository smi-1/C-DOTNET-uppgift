using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.Json;

/// <summary>
/// 
/// This class is used to read the contents of a JSON file and deserialize the content into a list of Person objects.
/// It uses the IPersonSource interface that defines what method is needed (GetPeople)
/// 
/// How it is used:
/// Example to list all Person objects sorted by id
/// service = new PersonService(new JsonDataFileSource("PeopleSample.JSON"));
/// await service.GetAllSortedById();
/// 
/// 
///  </summary>
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
    /// <summary>
    /// The GetPeople() method is a method in the IPersonSource interface
    /// This method is used in this class to read the contents from a JSON file asynchronously with ReadToEndAsync()
    /// It then deserializes the loaded content into a list of Person objects with the PropertyNameCaseInsensitive set to true
    /// With a try / catch to handle errors reading or deserializing the file
    /// </summary>
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