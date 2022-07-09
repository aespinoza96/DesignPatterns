namespace FactoryPattern;

public class PersonFactory
{
    private Dictionary<int, Person> persons = new Dictionary<int, Person>(); 
    public Person Create(string name)
    {
        Person newPerson = new Person() { Name = name, Id = persons.Count };
        persons.Add(persons.Count, newPerson);
        return newPerson;
    }
}