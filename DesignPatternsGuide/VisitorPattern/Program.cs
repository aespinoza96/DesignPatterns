/*
    Visitor Coding Exercise
    You are asked to implement a double-dispatch visitor called ExpressionPrinter  for printing different 
    mathematical expressions. The range of expressions covers addition and multiplication - please put round brackets 
    around addition operations (but not multiplication ones)! Also, please avoid any blank spaces in output.
    Example:
    Input: AdditionExpression(Literal(2), Literal(3)) 
    Output: (2+3) 
    Here is the corresponding unit test:
    [Test]
    public void SimpleAddition()
    {
      var simple = new AdditionExpression(new Value(2), new Value(3));
      var ep = new ExpressionPrinter();
      ep.Visit(simple);
      Assert.That(ep.ToString(), Is.EqualTo("(2+3)"));
    }
 */

using System.Text;

namespace VisitorPattern;

public class Program
{
    public static void Main(string[] args)
    {
        
    }
}

public abstract class ExpressionVisitor
{
    public abstract void Visit(Value value);
    public abstract void Visit(AdditionExpression ae);
    public abstract void Visit(MultiplicationExpression me);
}

public abstract class Expression
{
    public abstract void Accept(ExpressionVisitor ev);
}

public class Value : Expression
{
    public readonly int TheValue;

    public Value(int value)
    {
        TheValue = value;
    }

    public override void Accept(ExpressionVisitor ev)
    {
        ev.Visit(this);
    }
}

public class AdditionExpression : Expression
{
    public readonly Expression LHS, RHS;

    public AdditionExpression(Expression lhs, Expression rhs)
    {
        LHS = lhs;
        RHS = rhs;
    }

    public override void Accept(ExpressionVisitor ev)
    {
        ev.Visit(this);
    }
}

public class MultiplicationExpression : Expression
{
    public readonly Expression LHS, RHS;

    public MultiplicationExpression(Expression lhs, Expression rhs)
    {
        LHS = lhs;
        RHS = rhs;
    }
    
    public override void Accept(ExpressionVisitor ev)
    {
        ev.Visit(this);
    }
}

public class ExpressionPrinter : ExpressionVisitor
{
    private StringBuilder sb = new StringBuilder();
    public override void Visit(Value value)
    {
        sb.Append(value.TheValue);
    }

    public override void Visit(AdditionExpression ae)
    {
        sb.Append("(");
        ae.LHS.Accept(this);
        sb.Append("+");
        ae.RHS.Accept(this);
        sb.Append(")");
    }

    public override void Visit(MultiplicationExpression me)
    {
        me.LHS.Accept(this);
        sb.Append("*");
        me.RHS.Accept(this);
    }

    public override string ToString()
    {
        return sb.ToString();
    }
}