using System.Text.Json;
public class PersonList
{
    public List<Person> People { get; set; }

    public PersonList()
    {
        People = new List<Person>();
    }

    public void AddPerson(Person person)
    {
        People.Add(person);
    }
    public void GetPeople(Sample sample)
    {
        List<Person>? people = JsonSerializer.Deserialize<List<Person>>(sample.PeopleSample);
        foreach (var person in people)
        {
            Console.WriteLine($"{person.PersonInfo.Name} - {person.AddressInfo.City} - {person.CompanyInfo.Name}");
        }
    }
}

public class Sample
{
    public string PeopleSample { get; set; }
    public Sample()
    {
        PeopleSample =
        """
        [
            {
            "PersonInfo": {
            "IdNumber": 123456,
            "Name": "Namn 1",
            "Email": "mail1@exempel.se"
            },
            "AddressInfo": {
            "Street": "Storgatan 12",
            "PostalCode": 11123,
            "City": "Stockholm"
            },
            "CompanyInfo": {
            "Name": "Exempel 1 AB",
            "Slogan": "AHA! moment"
            }
        },
        {
            "PersonInfo": {
            "IdNumber": 123457,
            "Name": "Namn 2",
            "Email": "mail2@exempel.se"
            },
            "AddressInfo": {
            "Street": "Storgatan 12",
            "PostalCode": 11123,
            "City": "Stockholm"
            },
            "CompanyInfo": {
            "Name": "Exempel 2 AB",
            "Slogan": "VA?! moment"
            }
        }
        ]
        """;
    }
}