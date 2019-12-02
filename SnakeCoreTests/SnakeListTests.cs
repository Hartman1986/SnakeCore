using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeCore.Tests
{
    [TestClass()]
    public class SnakeListTests
    {
        [TestMethod()]
        public void CreateSnakeOnlyHead_Test()
        {
            SnakeList Snake = new SnakeList(1, 3, 3, true);
            Assert.AreEqual(1, Snake.Count);
            Assert.AreEqual(3, Snake.First().X);
            Assert.AreEqual(3, Snake.First().Y);
            Assert.AreEqual(3, Snake.Last().X);
            Assert.AreEqual(3, Snake.Last().Y);
        }

        [TestMethod()]
        public void CreateSnakeThreeSegmentsHor_Test()
        {
            SnakeList Snake = new SnakeList(3, 3, 3, true);
            Assert.AreEqual(3, Snake.Count);

            Assert.AreEqual(3, Snake[0].X);
            Assert.AreEqual(3, Snake[0].Y);
            Assert.AreEqual(Snake[1], Snake[0].NextSegment);

            Assert.AreEqual(2, Snake[1].X);
            Assert.AreEqual(3, Snake[1].Y);
            Assert.AreEqual(Snake[2], Snake[1].NextSegment);

            Assert.AreEqual(1, Snake[2].X);
            Assert.AreEqual(3, Snake[2].Y);
            Assert.AreEqual(null, Snake[2].NextSegment);
        }

        [TestMethod()]
        public void CreateSnakeThreeSegmentsVert_Test()
        {
            SnakeList Snake = new SnakeList(3, 3, 3, false);
            Assert.AreEqual(3, Snake.Count);

            Assert.AreEqual(3, Snake[0].X);
            Assert.AreEqual(3, Snake[0].Y);
            Assert.AreEqual(Snake[1], Snake[0].NextSegment);

            Assert.AreEqual(3, Snake[1].X);
            Assert.AreEqual(2, Snake[1].Y);
            Assert.AreEqual(Snake[2], Snake[1].NextSegment);

            Assert.AreEqual(3, Snake[2].X);
            Assert.AreEqual(1, Snake[2].Y);
            Assert.AreEqual(null, Snake[2].NextSegment);
        }

        [TestMethod()]
        public void CreateSnakeZeroSegments_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SnakeList(0, 3, 3, true));
        }
    }
}