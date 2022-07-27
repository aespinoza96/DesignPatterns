namespace ProxyPattern;

public class ResponsiblePerson
{
    private readonly Person thePerson;
    public ResponsiblePerson(Person person)
    {
        thePerson = person;
    }

    public string Drink()
    {
        if (Age >= 18)
        {
            return thePerson.Drink();
        }

        return "too young";
    }
    
    public string Drive()
    {
        if (Age > 16)
        {
            return thePerson.Drive();
        }

        return "too young";
    }
    
    public string DrinkAndDrive()
    {
        return "dead";
    }

    public int Age
    {
        get => thePerson.Age;
        set => thePerson.Age = value;
    }
}