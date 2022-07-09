namespace FactoryPattern;

public class Program
{
    static void Main(string[] args)
    {
        PersonFactory factory = new PersonFactory();
        Person person = factory.Create("Alberto");
        Person person2 = factory.Create("Ariana");
        Console.WriteLine(person);
        Console.WriteLine(person2);
    }
}