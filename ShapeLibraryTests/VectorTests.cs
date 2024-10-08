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
    public void ScalarFloatMultiplicationTest()
    {
        Vector v = new Vector(5, 7);
        float scalar = 3;

        Vector s = v * scalar;

        Assert.AreEqual(15, s.X);
        Assert.AreEqual(21, s.Y);
    }
    public void ScalarIntMultiplicationTest()
    {
        Vector v = new Vector(5, 7);
        int scalar = 3;

        Vector s = v * scalar;

        Assert.AreEqual(15, s.X);
        Assert.AreEqual(21, s.Y);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "NaN values not allowed")]
    public void ScalarMultiplicationNaNExceptionTest()
    {
        Vector v = new Vector(5, 7);
        float scalar = float.NaN;

        Vector s = v * scalar;
    }

    [TestMethod]
    public void ScalarFloatDivisionTest()
    {
        Vector v = new Vector(15, 7);
        float scalar = 3;
        float tolerance = 0.00001f;

        Vector s = v / scalar;

        Assert.AreEqual(5, s.X);
        Assert.AreEqual(2.33333, s.Y, tolerance);
    }

    [TestMethod]
    public void ScalarIntDivisionTest()
    {
        Vector v = new Vector(15, 7);
        int scalar = 3;
        float tolerance = 0.00001f;

        Vector s = v / scalar;

        Assert.AreEqual(5, s.X);
        Assert.AreEqual(2.33333, s.Y, tolerance);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "NaN values not allowed")]
    public void ScalarDivisionNaNExceptionTest()
    {
        Vector v = new Vector(5, 7);
        float scalar = float.NaN;

        Vector s = v * scalar;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "Cannot divide by 0")]
    public void ScalarFloatDivisionZeroExceptionTest()
    {
        Vector v = new Vector(5, 7);
        float scalar = 0;

        Vector s = v / scalar;
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
        String s = v.ToString();

        Assert.AreEqual("(15,7)", s);
    }
}