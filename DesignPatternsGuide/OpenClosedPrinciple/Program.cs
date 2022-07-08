using static System.Console;

/*
 * The idea to demonstrate the Open-Closed Principle is to suppose there is a webpage that sells products,
 * and customers want to filter their products.
 * So the first implementation is a class "ProductFilter" that filters by Color, Size, and then a combination of these
 * two. What about if new filters come up?
 * The solution to respect the principle is to create interfaces. In this case, ISpecification and IFilter are created
 * and open for modifications as demonstrated below.
 */

namespace OpenClosedPrinciple
{
  public enum Color
  {
    Red, Green, Blue
  }

  public enum Size
  {
    Small, Medium, Large, Yuge
  }

  public class Product
  {
    public string Name;
    public Color Color;
    public Size Size;

    public Product(string name, Color color, Size size)
    {
      Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
      Color = color;
      Size = size;
    }
  }

  // This is not the correct implementation
  public class ProductFilter
  {
    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    {
      foreach (var p in products)
        if (p.Color == color)
          yield return p;
    }
    
    public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    {
      foreach (var p in products)
        if (p.Size == size)
          yield return p;
    }

    public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
    {
      foreach (var p in products)
        if (p.Size == size && p.Color == color)
          yield return p;
    } // state space explosion
      // 3 criteria = 7 methods

    // OCP = open for extension but closed for modification
  }

  // we introduce two new interfaces that are open for extension

  public interface ISpecification<T>
  {
    bool IsSatisfied(Product p);
  }

  public interface IFilter<T>
  {
    IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
  }

  public class ColorSpecification : ISpecification<Product>
  {
    private Color color;

    public ColorSpecification(Color color)
    {
      this.color = color;
    }

    public bool IsSatisfied(Product p)
    {
      return p.Color == color;
    }
  }

  public class SizeSpecification : ISpecification<Product>
  {
    private Size size;

    public SizeSpecification(Size size)
    {
      this.size = size;
    }

    public bool IsSatisfied(Product p)
    {
      return p.Size == size;
    }
  }

  public class AndSpecification<T> : ISpecification<T>
  {
    private ISpecification<T> first, second;

    public AndSpecification(ISpecification<T> first, ISpecification<T> second)
    {
      this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
      this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
    }

    public bool IsSatisfied(Product p)
    {
      return first.IsSatisfied(p) && second.IsSatisfied(p);
    }
  }

  // This is the correct implementation
  public class BetterFilter : IFilter<Product>
  {
    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
    {
      foreach (Product product in items)
        if (spec.IsSatisfied(product))
          yield return product;
    }
  }

  public class Demo
  {
    static void Main(string[] args)
    {
      var apple = new Product("Apple", Color.Green, Size.Small);
      var tree = new Product("Tree", Color.Green, Size.Large);
      var house = new Product("House", Color.Blue, Size.Large);

      Product[] products = {apple, tree, house};

      var filter = new ProductFilter();
      WriteLine("Green products (using the incorrect implementation):");
      foreach (Product p in filter.FilterByColor(products, Color.Green))
        WriteLine($" - {p.Name} is green");

      // ^^ Incorrect implementation

      // vv Correct implementation
      var correctFilter = new BetterFilter();
      WriteLine("Green products (new):");
      foreach (Product p in correctFilter.Filter(products, new ColorSpecification(Color.Green)))
        WriteLine($" - {p.Name} is green");

      WriteLine("Large products");
      foreach (Product p in correctFilter.Filter(products, new SizeSpecification(Size.Large)))
        WriteLine($" - {p.Name} is large");

      WriteLine("Large blue items");
      foreach (Product p in correctFilter.Filter(products,
        new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large)))
      )
      {
        WriteLine($" - {p.Name} is big and blue");
      }
    }
  }
}
