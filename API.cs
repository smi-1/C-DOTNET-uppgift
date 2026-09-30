using System.Text.Json;

public class Address
{   
    public string street { get; set; }
    public string city { get; set; }
    public string zipcode { get; set; }

}
public class Company 
{
    public string name { get; set; }
    public string catchPhrase { get; set; }
}

public class SampleAPI : IPersonSource
{   
    public static List<Person> apiPeopleList {get;set;}
    public SampleAPI()
    {
        
    }
    public class APIPerson
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public Company company { get; set; }
    }
    private static HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
    };
    public async Task<List<Person>> GetPeople()
    {
        using HttpResponseMessage response = await _httpClient.GetAsync("users");
        apiPeopleList = new List<Person>();
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        //Console.WriteLine($"API Response: {jsonResponse}");
        List<APIPerson>? people = JsonSerializer.Deserialize<List<APIPerson>>(jsonResponse) ?? new List<APIPerson>();
        Console.WriteLine($"API People Count: {people.Count}");
        foreach (var p in people)
            {
                Person person = new Person(
                    new PersonInfo(p.id, p.name, p.email),
                    new AddressInfo(p.address.street, p.address.city, p.address.zipcode),
                    new CompanyInfo(p.company.name, p.company.catchPhrase));
                apiPeopleList.Add(person);
            }
            /*
            Console.WriteLine($"API People List Count: {apiPeopleList.Count}");
            foreach (var person in apiPeopleList)
            {
                Console.WriteLine($"{person.PersonInfo.IdNumber} {person.PersonInfo.Name} - {person.AddressInfo.City} - {person.CompanyInfo.Name
                }");
            }
        */
        return apiPeopleList;
    }
}
