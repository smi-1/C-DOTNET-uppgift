using System.Runtime.CompilerServices;

namespace Register {
    class Program {
        static void Main(string[] args) {


            Person person = new Person(
                new PersonInfo(830427, "M", "lagom@lagom.se"),
                new AddressInfo("Legend 3", "Järfälla", 21500),
                new CompanyInfo("Smigg", "Behövs det här verkligen?")
            );

            PersonList personList = new PersonList();
           // personList.AddPerson(person);
            Sample sample = new Sample();
            
            personList.GetPeople(sample);
            /*
            foreach (Person item in personList.People)  
            {
                Console.WriteLine(item.PersonInfo.Name);
            }
            */
        }
    }
}