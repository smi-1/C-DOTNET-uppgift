using System.Threading.Tasks;

namespace Register
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] != "list")
                {
                    Console.WriteLine("Invalid command. Available commands: list, --sort, --top5, --search");
                    return;
                }

                // Avkommentera en av dessa tre rader för att välja källa för kommandolinje versionen av programmet.
                PersonService service = new PersonService(new JsonSampleSource());
                // PersonService service = new PersonService(new JsonDataFileSource("PeopleSample.JSON"));
                // PersonService service = new PersonService(new API());

                bool _sort = args.Contains("--sort");
                bool _top5 = args.Contains("--top5");
                int _searchIndex = Array.IndexOf(args, "--search");
                if (_searchIndex != -1)
                {
                    if (_sort || _top5)
                    {
                        Console.WriteLine("--search cannot be used with --sort or --top5");
                    }
                    else if (_searchIndex + 1 < args.Length)
                    {
                        string searchString = args[_searchIndex + 1];
                        await service.SearchPersonByName(searchString);
                    }
                    else
                    {
                        Console.WriteLine("Please provide a search string after --search");
                    }
                }
                else if (_sort && _top5) { await service.GetFirstFiveSortedByName(); }
                else if (_sort) { await service.GetAllSortedByName(); }
                else if (_top5) { await service.GetFirstFiveSortedById(); }
                else { await service.GetAllSortedById(); }
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
1 = GetAllSortedById, 2 = GetFirstFiveSortedById, 3 = GetAllSortedByName, 4 = GetFirstFiveSortedByName, 5 = SearchPersonByName

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
                                await service.GetAllSortedById();
                                break;
                            case "2":
                                await service.GetFirstFiveSortedById();
                                break;
                            case "3":
                                await service.GetAllSortedByName();
                                break;
                            case "4":
                                await service.GetFirstFiveSortedByName();
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