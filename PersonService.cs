using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
public class PersonService : IPersonSource
{
    public List<Person> People { get; set; }
    List<string> PersonListXS {get;set;} = new List<string>();
    private IPersonSource _source;
    private IPersonSource _content;

    public PersonService(IPersonSource source)
    {
        People = new List<Person>();
        _source = source;
    }

    public void AddPerson(Person person)
    {
        People.Add(person);
    }
    public async Task<List<Person>> GetPeople()
    {
        return await _source.GetPeople();
    }
    public void GetAndSortFirst5()
    {

        Console.WriteLine($"SORT THIS: {_source.GetPeople()}");
        
    }
    public void SortById(Sample sample)
    {
        List<Person>? people = JsonSerializer.Deserialize<List<Person>>(sample.PeopleSample) ?? new List<Person>();
        PersonListXS.Clear();

        var sortedList = people.OrderBy(g => g.PersonInfo.IdNumber);
        foreach (var item in sortedList) { 
            Console.WriteLine($"Sorted order: {item.PersonInfo.Name}\t{item.PersonInfo.IdNumber}");
        }
    }
    public void SortByName(Sample sample)
    {
        List<Person>? people = JsonSerializer.Deserialize<List<Person>>(sample.PeopleSample) ?? new List<Person>();
        PersonListXS.Clear();

        var sortedList = people.OrderBy(g => g.PersonInfo.Name).ToList();
        foreach (var item in people.OrderBy(p => p.PersonInfo.Name.ToList())) { 
            Console.WriteLine($"Sorted order: {item.PersonInfo.Name}\t{item.PersonInfo.IdNumber}");
        }
    }
}