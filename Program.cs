using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Register
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*
            async Task CommandHelperSearch(PersonService service, string name) 
            {
                await service.SearchPersonByName(name);
            }
            */

            if (args.Length > 0)
            {
                PersonService service = new PersonService(new JsonSampleSource());
                var actions = new List<string> { "list" };
                if (actions.Contains(args[0]))
                {
                    if (args.Length == 1 && args[0] == "list")
                    {
                       await service.GetAllSortedById();
                    }
                    else if (args[0] == "list")
                    {
                        var commands = new Dictionary<string, Func<Task>>
                        {
                            ["--top5"] = service.GetFirstFiveSortedById,
                            ["--sort"] = service.GetAllSortedByName,
                            ["--sort --top5 "] = service.GetFirstFiveSortedByName,
                            ["--search"] = () => service.SearchPersonByName(args[2])
                        };
                        foreach (var arg in args)
                        {
                            if (commands.TryGetValue(arg, out var command)) await command();
                        }
                    } else
                    {
                        Console.WriteLine("Invalid command");
                    }
                }
            }
            else
            {
                PersonService? service = null;

                var run = true;
                int menu = 1;
                while (run)
                {
                    if (menu == 1)
                    {
                        Console.WriteLine(@"
Select the source you want

1 = Json sample data, 2 = JsonDataFile, 3 = API
");
                    }
                    else if (menu == 2)
                    {
                        Console.WriteLine(@"
1 = GetFirstFiveSortedByName, 2 = GetFirstFiveSortedById, 3 = GetAllSortedById, 4 = GetAllSortedByName, 5 = SearchPersonByName

r = return to main menu");
                    }
                    Console.WriteLine("q = exit program");

                    string input = Console.ReadLine()?.Trim() ?? "";
                    if (input == "q")
                    {
                        run = false;
                    }
                    else if (menu == 1)
                    {
                        switch (input)
                        {
                            case "1":
                                service = new PersonService(new JsonSampleSource());
                                Console.WriteLine("Selected JsonSampleSource as source");
                                menu = 2;
                                break;
                            case "2":
                                service = new PersonService(new JsonDataFileSource("PeopleSample.JSON"));
                                Console.WriteLine("Selected JsonDataFileSource as source");
                                menu = 2;
                                break;
                            case "3":
                                service = new PersonService(new API());
                                Console.WriteLine("Selected API as source");
                                menu = 2;
                                break;
                            default:
                                Console.WriteLine("Option not available");
                                break;
                        }
                    }
                    else if (menu == 2 && service != null)
                    {
                        switch (input)
                        {
                            case "1":
                                await service.GetFirstFiveSortedByName();
                                break;
                            case "2":
                                await service.GetFirstFiveSortedById();
                                break;
                            case "3":
                                await service.GetAllSortedById();
                                break;
                            case "4":
                                await service.GetAllSortedByName();
                                break;
                            case "5":
                                Console.Write("Enter name to search: ");
                                string search = Console.ReadLine()?.Trim() ?? "";
                                await service.SearchPersonByName(search);
                                break;
                            case "r":
                                menu = 1;
                                Console.WriteLine("Returned to main menu");
                                break;
                            default:
                                Console.WriteLine("Option not available");
                                break;
                        }
                    }
                }
            }
        }
    }
}