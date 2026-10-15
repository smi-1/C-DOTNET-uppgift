using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
public class PersonService : IPersonSource
{
    public List<Person> People { get; set; }
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
            Console.WriteLine("Search results:");
            foreach (var item in sortedList) { 
            Console.WriteLine($"{item.PersonInfo.IdNumber,-6}  {item.PersonInfo.Name,-25}{item.PersonInfo.Email,-25}{item.AddressInfo.City,-22}{item.CompanyInfo.Name,-22}{item.CompanyInfo.Slogan,-22}");
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