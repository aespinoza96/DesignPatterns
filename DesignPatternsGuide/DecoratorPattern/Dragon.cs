namespace DecoratorPattern;

public class Dragon
{
    private Bird _bird;
    private Lizard _lizard;
    private int _age;

    public Dragon()
    {
        _bird = new Bird();
        _lizard = new Lizard();
    }

    public Dragon(Bird bird, Lizard lizard)
    {
        this._bird = bird;
        this._lizard = lizard;
    }

    public int Age
    {
        get => this._age;
        set
        {
            this._bird.Age = value;
            this._lizard.Age = value;
            this._age = value;
        }
    }

    public string Fly()
    {
        return this._bird.Fly();
    }

    public string Crawl()
    {
        return this._lizard.Crawl();
    }
}