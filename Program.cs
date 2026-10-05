using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Register {
    class Program {
        static async Task Main(string[] args) {

            /*
            Person person = new Person(
                new PersonInfo(830427, "M", "lagom@lagom.se"),
                new AddressInfo("Legend 3", "Järfälla", "21500"),
                new CompanyInfo("Smigg", "Behövs det här verkligen?")
            );
            */

            Sample sample = new Sample();
            SampleAPI api = new SampleAPI();

            var run = true;
            while (run) {
                Console.WriteLine("g = Get and sort first 5, q = Quit");
                var input = Console.ReadLine().Trim();
                if (input == "q") {
                    run = false;
                }
                else if (input == "g") {
                    //personList.GetAndSortFirst5(sample);
                }
                else if (input == "1") {
                    //personList.SortById(sample);
                }
                else if (input == "2") {
                    IPersonSource source = new SampleAPI();
                    PersonService service = new PersonService(source);
                    
                    await service.GetFirstFiveSortedByName();
                }
                else if (input == "3") {
                    IPersonSource source = new JsonDataFileSource("PeopleSample.JSON");
                    PersonService service = new PersonService(source);
                    
                    await service.GetFirstFiveSortedByName();
                }
                else if (input == "5") {
                    IPersonSource source = new JsonDataFileSource("PeopleSample.JSON");
                    PersonService service = new PersonService(source);
                    
                    await service.GetFirstFiveSortedByName();

                }
                else if (input == "6") {
                    JsonDataFileSource jsonDataFileSource = new JsonDataFileSource("PeopleSample.JSON");
                }
            }
        }
    }
}