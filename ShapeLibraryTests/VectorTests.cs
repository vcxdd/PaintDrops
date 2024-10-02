using ShapeLibrary;

namespace ShapeLibraryTests;

[TestClass]
public class VectorTests
{
    [TestMethod]
    public void PlusOperatorTest()
    {
        Vector a = new Vector(0, 0);
        Vector b = new Vector(1, 2);

        Vector c = a + b;

        Assert.AreEqual(1, c.X);
        Assert.AreEqual(2, c.Y);
    }

    [TestMethod]
    public void MinusOperatorTest()
    {
        Vector a = new Vector(0, 0);
        Vector b = new Vector(1, 2);

        Vector c = a - b;

        Assert.AreEqual(-1, c.X);
        Assert.AreEqual(-2, c.Y);
    }

    [TestMethod]
    public void ScalarMultiplicationTest()
    {
        Vector v = new Vector(5, 7);
        float scalar = 3;

        Vector s = v * scalar;

        Assert.AreEqual(15, s.X);
        Assert.AreEqual(21, s.Y);
    }

    [TestMethod]
    public void ScalarDivisionTest()
    {
        Vector v = new Vector(15, 7);
        float scalar = 3;
        float tolerance = 0.00001f;

        Vector s = v / scalar;

        Assert.AreEqual(5, s.X);
        Assert.AreEqual(2.33333, s.Y, tolerance);
    }

    [TestMethod]
    public void MagnitudeTest()
    {
        Vector v = new Vector(15, 7);
        Double length = Vector.Magnitude(v);
        float tolerance = 0.000001f;

        Assert.AreEqual(16.552945, length, tolerance);
    }

    [TestMethod]
    public void NormalizeTest()
    {
        Vector v = new Vector(15, 7);
        Vector n = Vector.Normalize(v);
        float tolerance = 0.000001f;

        Assert.AreEqual(0.906183, n.X, tolerance);
        Assert.AreEqual(0.422885, n.Y, tolerance);
    }

    [TestMethod]
    public void ToStringTest()
    {
        Vector v = new Vector(15, 7);
        Vector n = Vector.Normalize(v);
        float tolerance = 0.000001f;

        Assert.AreEqual(0.906183, n.X, tolerance);
        Assert.AreEqual(0.422885, n.Y, tolerance);
    }
}