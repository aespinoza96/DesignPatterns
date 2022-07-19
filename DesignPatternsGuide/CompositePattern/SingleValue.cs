using System.Collections;

namespace CompositePattern;

public class SingleValue : IValueContainer
{
    public int Value;

    public IEnumerator<int> GetEnumerator()
    {
        yield return Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}