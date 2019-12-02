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
    public class SegmentTests
    {
        [TestMethod()]
        public void MoveOneSegment_Test()
        {
            Segment segment = new Segment();
            segment.X = 3;
            segment.Y = 3;

            segment.Move(MoveDirection.Down);

            Assert.AreEqual(3, segment.X);
            Assert.AreEqual(2, segment.Y);

            segment.Move(MoveDirection.Right);

            Assert.AreEqual(4, segment.X);
            Assert.AreEqual(2, segment.Y);

            segment.Move(MoveDirection.Up);
            Assert.AreEqual(4, segment.X);
            Assert.AreEqual(3, segment.Y);

            segment.Move(MoveDirection.Left);
            Assert.AreEqual(3, segment.X);
            Assert.AreEqual(3, segment.Y);
        }

        [TestMethod()]
        public void MoveMoreSegments_Test()
        {
            Segment head = new Segment()
            {
                X = 3,
                Y = 3,
                NextSegment = new Segment()
                {
                    X = 2,
                    Y = 3,
                    NextSegment = new Segment()
                    {
                        X = 1,
                        Y = 2
                    }
                }
            };

            head.Move(MoveDirection.Down);

            Assert.AreEqual(3, head.NextSegment.X);
            Assert.AreEqual(3, head.NextSegment.Y);
            Assert.AreEqual(2, head.NextSegment.NextSegment.X);
            Assert.AreEqual(3, head.NextSegment.NextSegment.Y);


            head.Move(MoveDirection.Right);

            Assert.AreEqual(3, head.NextSegment.X);
            Assert.AreEqual(2, head.NextSegment.Y);
            Assert.AreEqual(3, head.NextSegment.NextSegment.X);
            Assert.AreEqual(3, head.NextSegment.NextSegment.Y);


        }
    }
}