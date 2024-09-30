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
        
    }

    [TestMethod]
    public void MultiplierOperator()
    {

    }

    [TestMethod]
    public void MultiplierOperatorSaturated()
    {

    }

    [TestMethod]
    public void EqualsOperator()
    {

    }

    [TestMethod]
    public void NotEqualOperator()
    {

    }

    [TestMethod]
    public void ToStringTest()
    {

    }
}