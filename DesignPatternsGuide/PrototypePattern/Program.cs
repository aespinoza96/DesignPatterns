/*
    Given the definitions above, you are asked to implement Line.DeepCopy() to perform a deep copy of the current
    Line object.
 */
namespace PrototypePattern;

public class Program {
    public static void Main(string[] args)
    {
        Point A = new Point() { X = 1, Y = 8 };
        Point B = new Point() { X = 2, Y = 16 };
        Point C = new Point() { X = 3, Y = 32 };
        Point D = new Point() { X = 4, Y = 64 };
        
        Line line = new Line() { A = A, B = B };
        Line lineCopy = line.DeepCopy();
        lineCopy.A = C;
        lineCopy.B = D;

        Console.WriteLine(line.ToString());
        Console.WriteLine(lineCopy.ToString());
    }
}