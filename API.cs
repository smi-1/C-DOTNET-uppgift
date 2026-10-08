using System.Text.Json;

public class Address
{   
    public string? Street { get; private set; }
    public string? City { get; private set; }
    public string? Zipcode { get; private set; }
}
public class Company
{
    public string? Name { get; private set; }
    public string? CatchPhrase { get; private set; }
}

public class API : IPersonSource
{   
    public static List<Person>? apiPeopleList {get;set;}
    public API()
    {
        
    }
    public class APIPerson
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Address? Address { get; set; }
        public Company? Company { get; set; }
        public Person ToPerson() => new Person(
            new PersonInfo(Id, Name ?? "", Email ?? ""),
            new AddressInfo(Address?.Street ?? "", Address?.City ?? "", Address?.Zipcode ?? ""),
            new CompanyInfo(Company?.Name ?? "", Company?.CatchPhrase ?? ""));
    }
    private static HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
    };
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    public async Task<List<Person>> GetPeople()
    {
        using HttpResponseMessage response = await _httpClient.GetAsync("users");
        apiPeopleList = new List<Person>();
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var people = JsonSerializer.Deserialize<List<APIPerson>>(jsonResponse, _jsonOptions) ?? new List<APIPerson>();
        Console.WriteLine($"API People Count: {people.Count}");
        apiPeopleList = people.Select(p => p.ToPerson()).ToList();
        return apiPeopleList;
    }
}
