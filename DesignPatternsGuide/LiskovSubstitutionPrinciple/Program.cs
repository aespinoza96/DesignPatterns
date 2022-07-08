using static System.Console;

/*
 * The idea to demonstrate the Liskov Substitution Principle is using a simple example, let's say there is a class
 * "Rectangle" which has a width and a height. Then, there is a class "Square" that inherits from "Rectangle"
 * because why not?
 * So when there is a declaration of a Rectangle r = new Square(), they should behave the same when the area is
 * calculated (see implementation of the are below). To achieve this, the properties Width and Height should be
 * virtual in the parent class and use the keyword override in the inherited class, in this case Square.
 */

namespace LiskovSubstitutionPrinciple
{
    // using a classic example
    public class Rectangle
    {
        /* Without the virtual keyword.
        public int Width { get; set; }
        public int Height { get; set; }
        */

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {
      
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        /* Without the override keyword
        public new int Width
        {
          set { base.Width = base.Height = value; }
        
        public new int Height
        { 
          set { base.Width = base.Height = value; }
        }
        */

        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        { 
            set { base.Width = base.Height = value; }
        }
    }

    public class Demo
    {
        static public int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(2,3);
            WriteLine($"{rectangle} has area {Area(rectangle)}");

            // should be able to substitute a base type for a subtype
            Rectangle square = new Square();
            square.Width = 4;
            WriteLine($"{square} has area {Area(square)}");
        }
    }
}