namespace ShapeLibrary;
public struct Colour
{
    public int Red { get; }
    public int Green { get; }
    public int Blue { get; }
    public Colour(int red, int green, int blue)
    {
        if (red < 0 || red > 255 || green < 0 || green > 255 || blue < 0 || blue > 255)
        {
            throw new ArgumentException("RBG values must be between 0 and 255");
        }

        this.Red = red;
        this.Green = green;
        this.Blue = blue;
    }

    public static Colour operator +(Colour a, Colour b) 
    {
        int newRed = a.Red + b.Red;
        int newGreen = a.Green + b.Green;
        int newBlue = a.Blue + b.Blue;

        if (newRed > 255) newRed = 255;
        if (newGreen > 255) newGreen = 255;
        if (newBlue > 255) newBlue = 255;

        return new Colour(newRed, newGreen, newBlue);
    }

    public static Colour operator -(Colour a, Colour b)
    {
        int newRed = a.Red - b.Red;
        int newGreen = a.Green - b.Green;
        int newBlue = a.Blue - b.Blue;

        if (newRed < 0) newRed = 0;
        if (newGreen < 0) newGreen = 0;
        if (newBlue < 0) newBlue = 0;

        return new Colour(newRed, newGreen, newBlue);
    }

    public static Colour operator *(Colour c, int num)
    {
        int newRed = c.Red * num;
        int newGreen = c.Green * num;
        int newBlue = c.Blue * num;

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
        if (a.Red == b.Red && a.Green == b.Green && a.Blue == b.Blue) return true;

        return false;
    }

    public static Boolean operator !=(Colour a, Colour b)
    {
        return !(a == b);
    }

    public override String ToString()
    {
        return $"RGB({this.Red},{this.Green},{this.Blue})";
    }
}
