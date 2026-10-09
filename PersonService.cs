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
    public static void Print(IEnumerable<Person> sortedList)
    {
            foreach (var item in sortedList) { 
            Console.WriteLine($"Sorted order: {item.PersonInfo.Name}\t{item.PersonInfo.IdNumber}");
        }
    }

    public async Task GetFirstFiveSortedByName()
    {
        List<Person> people = await GetPeople();
        Print(people.OrderBy(g => g.PersonInfo.Name).Take(5));
    }
    public async Task GetFirstFiveSortedById()
    {
        List<Person> people = await GetPeople();
        Print(people.OrderBy(g => g.PersonInfo.IdNumber).Take(5));
    }
    public async Task GetAllSortedById()
    {
        List<Person> people = await GetPeople();
        Print(people.OrderBy(g => g.PersonInfo.IdNumber));
    }
    public async Task GetAllSortedByName()
    {
        List<Person> people = await GetPeople();
        Print(people.OrderBy(g => g.PersonInfo.Name));
    }
    public async Task SearchPersonByName(string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString)) {
            Console.WriteLine("Search string cannot be empty");
            return;
        }

        List<Person> people = await GetPeople();
        var searchResults = people.Where(p => p.PersonInfo.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).OrderBy(p => p.PersonInfo.IdNumber).ToList();
        if (searchResults.Count == 0) {
            Console.WriteLine($"No results found for search string: {searchString}");
            return;
        }
        else
        {
            Print(searchResults);
        }

    }
}