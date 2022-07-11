
namespace AdapterPattern;

public static class ExtensionMethods
{
    public static int Area(this IRectangle rectangle) {
        return rectangle.Width * rectangle.Height;
    }
}