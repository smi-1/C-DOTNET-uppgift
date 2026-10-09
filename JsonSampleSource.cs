using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.Json;
public class JsonSampleSource : IPersonSource
{
    public string PeopleSample { get; set; }
    public JsonSampleSource()
    {

        PeopleSample =
        """
        [
                {
                "PersonInfo": {
                    "IdNumber": 100000,
                    "Name": "Luke Skywalker",
                    "Email": "luke@starwars.se"
                },
                "AddressInfo": {
                    "Street": "Galaxvägen 1",
                    "PostalCode": "1",
                    "City": "Citadel"
                },
                "CompanyInfo": {
                    "Name": "Rymdutforskarna AB",
                    "Slogan": "May the force be with you"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 583214,
                    "Name": "Bubblan B",
                    "Email": "bubblan.b@smurf.se"
                },
                "AddressInfo": {
                    "Street": "Smurfstigen 12",
                    "PostalCode": "11123",
                    "City": "Smurfbyn"
                },
                "CompanyInfo": {
                    "Name": "BubbelSmurf AB",
                    "Slogan": "Blått, bubbligt och bäst"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 123456,
                    "Name": "Bubblan A",
                    "Email": "bubblan.a@smurf.se"
                },
                "AddressInfo": {
                    "Street": "Smurfstigen 12",
                    "PostalCode": "11123",
                    "City": "Smurfbyn"
                },
                "CompanyInfo": {
                    "Name": "BubbelSmurf AB",
                    "Slogan": "Blått, bubbligt och bäst"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 147829,
                    "Name": "Zippra Z",
                    "Email": "zippra.z@svamp.se"
                },
                "AddressInfo": {
                    "Street": "Svampvägen 7",
                    "PostalCode": "22234",
                    "City": "Svampstad"
                },
                "CompanyInfo": {
                    "Name": "Zippra Svamp AB",
                    "Slogan": "Vi växer snabbt"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 926351,
                    "Name": "Mufflan M",
                    "Email": "mufflan.m@raket.se"
                },
                "AddressInfo": {
                    "Street": "Raketgatan 99",
                    "PostalCode": "44456",
                    "City": "Raketstan"
                },
                "CompanyInfo": {
                    "Name": "Mufflan Rocket AB",
                    "Slogan": "Mjuk landning, snabb start"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 314768,
                    "Name": "Plingis P",
                    "Email": "plingis.p@moln.se"
                },
                "AddressInfo": {
                    "Street": "Molnvägen 21",
                    "PostalCode": "99901",
                    "City": "Loopcity"
                },
                "CompanyInfo": {
                    "Name": "Pling & Fluff AB",
                    "Slogan": "Vi löser det på molnet"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 751493,
                    "Name": "Krutis K",
                    "Email": "krutis.k@tomte.se"
                },
                "AddressInfo": {
                    "Street": "Tomtestigen 24",
                    "PostalCode": "55567",
                    "City": "Tomtebyn"
                },
                "CompanyInfo": {
                    "Name": "Krutis Verkstad AB",
                    "Slogan": "Små tomtar, stora idéer"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 862047,
                    "Name": "Fnurra F",
                    "Email": "fnurra.f@blixt.se"
                },
                "AddressInfo": {
                    "Street": "Åskvägen 13",
                    "PostalCode": "66678",
                    "City": "Molnstaden"
                },
                "CompanyInfo": {
                    "Name": "Fnurra & Dunder AB",
                    "Slogan": "Snurrar snabbare än blixten"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 295683,
                    "Name": "Tjoffan T",
                    "Email": "tjoffan.t@fika.se"
                },
                "AddressInfo": {
                    "Street": "Fikavägen 5",
                    "PostalCode": "77789",
                    "City": "Kakstaden"
                },
                "CompanyInfo": {
                    "Name": "Tjoffans Kex AB",
                    "Slogan": "Tjoff in, fika ut"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 638521,
                    "Name": "Krabbel K",
                    "Email": "krabbel.k@pirat.se"
                },
                "AddressInfo": {
                    "Street": "Piratskärsvägen 8",
                    "PostalCode": "88890",
                    "City": "Piratskär"
                },
                "CompanyInfo": {
                    "Name": "Krabbel & Krokar AB",
                    "Slogan": "Alltid på jakt efter skatten"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 409176,
                    "Name": "Vimsan V",
                    "Email": "vimsan.v@anka.se"
                },
                "AddressInfo": {
                    "Street": "Ankstigen 42",
                    "PostalCode": "33345",
                    "City": "Ankeborg"
                },
                "CompanyInfo": {
                    "Name": "Vimsiga Ankan AB",
                    "Slogan": "Kvack med stil"
                }
            },
            {
                "PersonInfo": {
                    "IdNumber": 975302,
                    "Name": "Pluppra P",
                    "Email": "pluppra.p@kod.se"
                },
                "AddressInfo": {
                    "Street": "Kodstigen 10",
                    "PostalCode": "10012",
                    "City": "Kodköping"
                },
                "CompanyInfo": {
                    "Name": "Pluppra Code AB",
                    "Slogan": "Kod som bara pluppar på"
                }
            }
        ]
        """;
    }

    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    public async Task<List<Person>> GetPeople()
    {
        try
        {

            List<Person>? people = JsonSerializer.Deserialize<List<Person>>(PeopleSample, _jsonOptions) ?? new List<Person>();
            return people;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deserializing JSON string: {ex.Message}");
            return new List<Person>();
        }
    }

}