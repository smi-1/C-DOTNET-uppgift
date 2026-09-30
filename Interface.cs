public interface IPersonSource
{
    Task<List<Person>> GetPeople();
}