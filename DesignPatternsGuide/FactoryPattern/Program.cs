/*
    Factory Coding Exercise
    You are given a class called Person . The person has two fields: Id , and Name .
    Please implement a non-static PersonFactory  that has a CreatePerson()  method that takes a person's name.
    The Id of the person should be set as a 0-based index of the object created. So, the first person the factory makes should have Id=0, second Id=1 and so on.
 */
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