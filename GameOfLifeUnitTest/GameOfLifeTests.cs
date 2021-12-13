using System;
using GameOfLifeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeUnitTest
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void TestGlider()
        {
            var objSUT = new GameOfLifeCore(25, 25);

            objSUT.SetGlider();

            objSUT.LiveLifeSegment();

            var arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[2,1]);
            Assert.IsTrue(arrGameState[2,3]);
            Assert.IsTrue(arrGameState[3,2]);
            Assert.IsTrue(arrGameState[3,3]);
            Assert.IsTrue(arrGameState[4,2]);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[2, 3]);
            Assert.IsTrue(arrGameState[3, 1]);
            Assert.IsTrue(arrGameState[3, 3]);
            Assert.IsTrue(arrGameState[4, 2]);
            Assert.IsTrue(arrGameState[4, 3]);
        }

        [TestMethod]
        public void TestRepeater()
        {
            var objSUT = new GameOfLifeCore(25, 25);

            objSUT.SetRepeater();

            objSUT.LiveLifeSegment();

            var arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[3, 1]);
            Assert.IsTrue(arrGameState[3, 2]);
            Assert.IsTrue(arrGameState[3, 3]);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[2, 2]);
            Assert.IsTrue(arrGameState[3, 2]);
            Assert.IsTrue(arrGameState[4, 2]);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[3, 1]);
            Assert.IsTrue(arrGameState[3, 2]);
            Assert.IsTrue(arrGameState[3, 3]);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[2, 2]);
            Assert.IsTrue(arrGameState[3, 2]);
            Assert.IsTrue(arrGameState[4, 2]);
        }

        [TestMethod]
        public void TestImmortality()
        {
            var objSUT = new GameOfLifeCore(25, 25);

            objSUT.SetTardigrade();

            objSUT.LiveLifeSegment();

            var arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[1, 1]);
            Assert.IsTrue(arrGameState[2, 1]);
            Assert.IsTrue(arrGameState[1, 2]);
            Assert.IsTrue(arrGameState[2, 2]);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[1, 1]);
            Assert.IsTrue(arrGameState[2, 1]);
            Assert.IsTrue(arrGameState[1, 2]);
            Assert.IsTrue(arrGameState[2, 2]);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[1, 1]);
            Assert.IsTrue(arrGameState[2, 1]);
            Assert.IsTrue(arrGameState[1, 2]);
            Assert.IsTrue(arrGameState[2, 2]);
        }

        [TestMethod]
        public void TestExtinctionEvent()
        {
            var objSUT = new GameOfLifeCore(25, 25);

            objSUT.SetDodoBird();

            objSUT.LiveLifeSegment();

            var arrGameState = objSUT.ReturnGameState();

            Assert.IsFalse(arrGameState[2, 2]);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsFalse(arrGameState[2, 2]);
        }
    }
}
