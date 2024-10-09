namespace ShapeLibrary;
public struct Colour
{
    private int _red;
    private int _green;
    private int _blue;
    public int Red => _red;
    public int Green => _green;
    public int Blue => _blue;

    public Colour(int red, int green, int blue)
    {
        if (red < 0 || red > 255 || green < 0 || green > 255 || blue < 0 || blue > 255)
        {
            throw new ArgumentException("RBG values must be between 0 and 255");
        }

        this._red = red;
        this._green = green;
        this._blue = blue;
    }

    public static Colour operator +(Colour a, Colour b) 
    {
        int newRed = a._red + b._red;
        int newGreen = a._green + b._green;
        int newBlue = a._blue + b._blue;

        if (newRed > 255) newRed = 255;
        if (newGreen > 255) newGreen = 255;
        if (newBlue > 255) newBlue = 255;

        return new Colour(newRed, newGreen, newBlue);
    }

    public static Colour operator -(Colour a, Colour b)
    {
        int newRed = a._red - b._red;
        int newGreen = a._green - b._green;
        int newBlue = a._blue - b._blue;

        if (newRed < 0) newRed = 0;
        if (newGreen < 0) newGreen = 0;
        if (newBlue < 0) newBlue = 0;

        return new Colour(newRed, newGreen, newBlue);
    }

    public static Colour operator *(Colour c, int num)
    {
        int newRed = c._red * num;
        int newGreen = c._green * num;
        int newBlue = c._blue * num;

        if (newRed > 255) newRed = 255;
        if (newGreen > 255) newGreen = 255;
        if (newBlue > 255) newBlue = 255;
        if (newRed < 0) newRed = 0;
        if (newGreen < 0) newGreen = 0;
        if (newBlue < 0) newBlue = 0;

        return new Colour(newRed, newGreen, newBlue);
    }

    public static Colour operator *(int num, Colour c)
    {
        return c * num;
    }

    public static Boolean operator ==(Colour a, Colour b)
    {
        if (a._red == b._red && a._green == b._green && a._blue == b._blue) return true;

        return false;
    }

    public static Boolean operator !=(Colour a, Colour b)
    {
        return !(a == b);
    }

    public override String ToString()
    {
        return $"RGB({this._red},{this._green},{this._blue})";
    }
}
