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

            //PersonService personList = new PersonService();
            //IPersonSource source = new JsonDataFileSource("PeopleSample.JSON");
            // personList.AddPerson(person);
            Sample sample = new Sample();
            
            // personList.GetPeople(sample);
            SampleAPI api = new SampleAPI();
           
            //personList.GetAndSortFirst5(sample);
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
                    List<Person> people = await service.GetPeople();
                    service.GetAndSortFirst5();
                }
                else if (input == "5") {
                    //SampleAPI.GetPeopleAsync();
                    IPersonSource source = new JsonDataFileSource("PeopleSample.JSON");
                    PersonService service = new PersonService(source);
                    List<Person> people = await service.GetPeople();
                    service.GetAndSortFirst5();

                }
                else if (input == "6") {
                    JsonDataFileSource jsonDataFileSource = new JsonDataFileSource("PeopleSample.JSON");
                }
            }
        }
    }
}