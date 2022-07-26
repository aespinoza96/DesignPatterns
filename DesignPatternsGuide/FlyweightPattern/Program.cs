/*
    Flyweight Coding Exercise
    You are given a class called Sentence , which takes a string such as "hello world". 
    You need to provide an interface such that the indexer returns a WordToken  which can be used to capitalize 
    a particular word in the sentence.
    Typical use would be something like:
    var sentence = new Sentence("hello world");
    sentence[1].Capitalize = true;
    WriteLine(sentence); // writes "hello WORLD"
 */

using FlyweightPattern;

public class Program
{
    public static void Main(string[] args)
    {
        var s = new Sentence("C# developers are awesome");
        s[2].Capitalize = true;
        Console.WriteLine(s.ToString());
    }
}
