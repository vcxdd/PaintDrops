using ShapeLibrary;

namespace ShapeLibraryTests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void VerticesTest()
        {
            IRectangle rectangle = new Rectangle(50, 50, 100, 100, new Colour(0, 0, 255));

            Assert.AreEqual(50, rectangle.Vertices[0].X);
            Assert.AreEqual(50, rectangle.Vertices[0].Y);
            Assert.AreEqual(150, rectangle.Vertices[1].X);
            Assert.AreEqual(50, rectangle.Vertices[1].Y);
            Assert.AreEqual(150, rectangle.Vertices[2].X);
            Assert.AreEqual(150, rectangle.Vertices[2].Y);
            Assert.AreEqual(50, rectangle.Vertices[3].X);
            Assert.AreEqual(150, rectangle.Vertices[3].Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Values cannot be 0 or less.")]
        public void VerticesException()
        {
            IRectangle rectangle = new Rectangle(-1, 0, -100, -50, new Colour(0, 0, 255));
        }
    }
}
