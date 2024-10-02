using ShapeLibrary;

namespace ShapeLibraryTests;

[TestClass]
public class ColourTests
{
    [TestMethod]
    public void PlusOperator()
    {
        Colour a = new Colour(0, 0, 0);
        Colour b = new Colour(1, 2, 3);

        Colour c = a + b;

        Assert.AreEqual(1, c.Red);
        Assert.AreEqual(2, c.Green);
        Assert.AreEqual(3, c.Blue);
    }

    [TestMethod]
    public void PlusOperatorSaturated()
    {
        Colour a = new Colour(255, 255, 255);
        Colour b = new Colour(1, 2, 3);

        Colour c = a + b;

        Assert.AreEqual(255, c.Red);
        Assert.AreEqual(255, c.Green);
        Assert.AreEqual(255, c.Blue);
    }

    [TestMethod]
    public void MinusOperator()
    {
        Colour a = new Colour(5, 5, 5);
        Colour b = new Colour(1, 2, 3);

        Colour c = a - b;

        Assert.AreEqual(4, c.Red);
        Assert.AreEqual(3, c.Green);
        Assert.AreEqual(2, c.Blue);
    }

    [TestMethod]
    public void MinusOperatorSaturated()
    {
        Colour a = new Colour(5, 5, 5);
        Colour b = new Colour(6, 6, 6);

        Colour c = a - b;

        Assert.AreEqual(0, c.Red);
        Assert.AreEqual(0, c.Green);
        Assert.AreEqual(0, c.Blue);
    }

    [TestMethod]
    public void MultiplierOperator()
    {
        Colour a = new Colour(5, 6, 7);

        Colour c = a * 5;

        Assert.AreEqual(25, c.Red);
        Assert.AreEqual(30, c.Green);
        Assert.AreEqual(35, c.Blue);
    }

    [TestMethod]
    public void MultiplierOperatorSaturated()
    {
        Colour a = new Colour(5, 6, 7);

        Colour c = a * 100;

        Assert.AreEqual(255, c.Red);
        Assert.AreEqual(255, c.Green);
        Assert.AreEqual(255, c.Blue);
    }

    [TestMethod]
    public void EqualsOperator()
    {
        Colour a = new Colour(5, 6, 7);
        Colour b = new Colour(5, 6, 7);
        bool c = a == b;
        Assert.AreEqual(true, c);
    }

    [TestMethod]
    public void NotEqualOperator()
    {
        Colour a = new Colour(5, 3, 6);
        Colour b = new Colour(5, 6, 6);
        bool c = a != b;
        Assert.AreEqual(true, c);
    }

    [TestMethod]
    public void ToStringTest()
    {
        Colour a = new Colour(5, 3, 6);
        Assert.AreEqual("RGB(5,3,6)", a.ToString());
    }
}