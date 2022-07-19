namespace CompositePattern;

public static class ExtensionsMethods
{
    public static int Sum(this List<IValueContainer> containers)
    {
        int result = 0;
        foreach (IValueContainer container in containers)
        {
            foreach (int number in container)
            {
                result += number;
            }
        }

        return result;
    }
}