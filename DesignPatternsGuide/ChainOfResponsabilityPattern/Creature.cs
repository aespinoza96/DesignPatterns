namespace ChainOfResponsabilityPattern;

public abstract class Creature
{
    protected Game game;
    protected readonly int baseAttack;
    protected readonly int baseDefense;
    public Creature(Game game, int baseAttack, int baseDefense)
    {
        this.game = game;
        this.baseAttack = baseAttack;
        this.baseDefense = baseDefense;
    }

    public virtual int Attack { get; set; }
    public virtual int Defense { get; set; }

    public abstract void Query(Object source, StatQuery squery);
}