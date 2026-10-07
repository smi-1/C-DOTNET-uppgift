using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Register {
    class Program {
        static async Task Main(string[] args) {
            var run = true;
            while (run) {
                Console.WriteLine("Enter 'q' to quit or numbers to select action");
                var input = Console.ReadLine()?.Trim() ?? "";
                
                if (input == "q") {
                    run = false;
                }
                else if (input == "1") {
                    IPersonSource source = new JsonSampleSource();
                    PersonService service = new PersonService(source);
                    
                    await service.GetFirstFiveSortedByName();
                }
                else if (input == "2") {
                    IPersonSource source = new SampleAPI();
                    PersonService service = new PersonService(source);
                    
                    await service.GetFirstFiveSortedByName();
                }
                else if (input == "3") {
                    IPersonSource source = new JsonDataFileSource("PeopleSample123.JSON");
                    PersonService service = new PersonService(source);
                    
                    await service.GetFirstFiveSortedByName();
                }
                else if (input == "5") {
                    IPersonSource source = new JsonDataFileSource("PeopleSample.JSON");
                    PersonService service = new PersonService(source);
                    
                    await service.GetFirstFiveSortedByName();

                }
                else if (input == "6") {
                    
                }
            }
        }
    }
}