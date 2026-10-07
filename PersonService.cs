using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
public class PersonService : IPersonSource
{
    public List<Person> People { get; set; }
    List<string> PersonListXS {get;set;} = new List<string>();
    private readonly IPersonSource _source;

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
    public async Task GetFirstFiveSortedByName()
    {
        List<Person> people = await GetPeople();
        var sortedList = people.OrderBy(g => g.PersonInfo.Name).Take(5);
        foreach (var item in sortedList) { 
            Console.WriteLine($"Sorted order: {item.PersonInfo.Name}\t{item.PersonInfo.IdNumber}");
        }
    }
    public async Task GetFirstFiveSortedById()
    {
        List<Person> people = await GetPeople();
        var sortedList = people.OrderBy(g => g.PersonInfo.IdNumber).Take(5);
        foreach (var item in sortedList) {
            Console.WriteLine($"Sorted order: {item.PersonInfo.Name}\t{item.PersonInfo.IdNumber}");
        }
    }
    public async Task GetAllSortedById()
    {
        List<Person> people = await GetPeople();
        var sortedList = people.OrderBy(g => g.PersonInfo.IdNumber);
        foreach (var item in sortedList) {
            Console.WriteLine($"Sorted order: {item.PersonInfo.Name}\t{item.PersonInfo.IdNumber}");
        }
    }
    public async Task GetAllSortedByName()
    {
        List<Person> people = await GetPeople();
        var sortedList = people.OrderBy(g => g.PersonInfo.Name).ToList();
        foreach (var item in sortedList) {
            Console.WriteLine($"Sorted order: {item.PersonInfo.Name}\t{item.PersonInfo.IdNumber}");
        }
    }
    public async Task SearchPersonByName(string searchString)
    {
        List<Person> people = await GetPeople();
        var searchResults = people.Where(p => p.PersonInfo.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
        foreach (var item in searchResults) {
            Console.WriteLine($"Search result: {item.PersonInfo.Name}\t{item.PersonInfo.IdNumber}");
        }
    }
}