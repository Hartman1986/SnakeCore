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
    public class GameFieldTests
    {
        [TestMethod()]
        public void CreateGame_Test()
        {
            GameField game = new GameField(10, 5);

            Assert.AreEqual(10, game.SizeX);
            Assert.AreEqual(5, game.SizeY);
            Assert.AreEqual(MoveDirection.Right, game.CurrentMoveDirection);
            Assert.AreEqual(3, game.Snake.Count());
            Assert.AreEqual(5, game.Snake.First().X);
            Assert.AreEqual(2, game.Snake.First().Y);

        }
    }
}