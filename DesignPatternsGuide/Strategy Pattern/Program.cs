/*
    Strategy Coding Exercise
    Consider the quadratic equation and its canonical solution:
    
    The part b^2-4*a*c is called the discriminant. Suppose we want to provide an API with two different strategies for 
    calculating the discriminant:
    In OrdinaryDiscriminantStrategy , If the discriminant is negative, we return it as-is. This is OK, since our main 
    API returns Complex  numbers anyway.
    In RealDiscriminantStrategy , if the discriminant is negative, the return value is NaN (not a number). 
    NaN propagates throughout the calculation, so the equation solver gives two NaN values.
    Please implement both of these strategies as well as the equation solver itself. With regards to plus-minus in the 
    formula, please return the + result as the first element and - as the second.
*/

using System.Numerics;

namespace Strategy_Pattern;

public class Program
{
    public static void Main(string[] args)
    {
        
    }
}

public interface IDiscriminantStrategy
{
    double CalculateDiscriminant(double a, double b, double c);
}

public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
{
    public double CalculateDiscriminant(double a, double b, double c)
    {
        return Math.Pow(b, 2) - 4 * a * c;
    }
}

public class RealDiscriminantStrategy : IDiscriminantStrategy
{
    public double CalculateDiscriminant(double a, double b, double c)
    {
        var discriminant = Math.Pow(b, 2) - 4 * a * c;
        return discriminant >= 0 ? discriminant : double.NaN;
    }
}

public class QuadraticEquationSolver
{
    private readonly IDiscriminantStrategy strategy;

    public QuadraticEquationSolver(IDiscriminantStrategy strategy)
    {
        this.strategy = strategy;
    }

    public Tuple<Complex, Complex> Solve(double a, double b, double c)
    {
        var discriminant = new Complex(strategy.CalculateDiscriminant(a, b, c), 0);
        var rootDisc = Complex.Sqrt(discriminant);
        return Tuple.Create(
            (-b + rootDisc) / (2 * a),
            (-b - rootDisc) / (2 * a)
        );
    }
}