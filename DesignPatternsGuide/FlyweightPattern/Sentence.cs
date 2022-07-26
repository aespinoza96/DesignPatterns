namespace FlyweightPattern;

public class Sentence
{
    private string[] words;
    private Dictionary<int, WordToken> tokens = new Dictionary<int, WordToken>();
    public Sentence(string plainText)
    {
        this.words = plainText.Split();
    }

    public WordToken this[int index]
    {
        get
        {
            WordToken token = new WordToken();
            this.tokens.Add(index, token);
            return tokens[index];
        }
    }

    public override string ToString()
    {
        var wordTokens = new List<string>();
        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            if (tokens.ContainsKey(i) && tokens[i].Capitalize)
            {
                word = word.ToUpperInvariant();
            }

            wordTokens.Add(word);
        }
        return string.Join(" ", wordTokens);
    }
}