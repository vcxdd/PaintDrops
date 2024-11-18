using ShapeLibrary;

namespace ShapeLibraryTests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void VerticesTest()
        {
            IRectangle rectangle = ShapesFactory.CreateRectangle(50, 50, 100, 100, new Colour(0, 0, 255));

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
            IRectangle rectangle = ShapesFactory.CreateRectangle(-1, 0, -100, -50, new Colour(0, 0, 255));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "rectangle must not be null.")]
        public void IntersectTestNull()
        {
            IRectangle rectangle = ShapesFactory.CreateRectangle(0, 0, 50, 50, new Colour(0, 0, 255));
            rectangle.Intersect(null);
        }

        [TestMethod]
        public void IntersectTestTrue()
        {
            IRectangle rectangle1 = ShapesFactory.CreateRectangle(5, 1, 2, 6, new Colour(0, 0, 255));
            IRectangle rectangle2 = ShapesFactory.CreateRectangle(3, 6, 6, 2, new Colour(0, 0, 255));

            bool isIntersect = rectangle1.Intersect(rectangle2);

            Assert.AreEqual(true, isIntersect);
        }

        [TestMethod]
        public void IntersectTestFalse()
        {
            IRectangle rectangle1 = ShapesFactory.CreateRectangle(5, 1, 2, 6, new Colour(0, 0, 255));
            IRectangle rectangle2 = ShapesFactory.CreateRectangle(0, 0, 1, 2, new Colour(0, 0, 255));

            bool isIntersect = rectangle1.Intersect(rectangle2);

            Assert.AreEqual(false, isIntersect);
        }
    }
}
