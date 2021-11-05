﻿using System;
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
            var objSUT = new GameOfLifeCore(5, 5);

            objSUT.SetGlider();

            objSUT.LiveLifeSegment();

            var arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[2,1].IsAlive);
            Assert.IsTrue(arrGameState[2,3].IsAlive);
            Assert.IsTrue(arrGameState[3,2].IsAlive);
            Assert.IsTrue(arrGameState[3,3].IsAlive);
            Assert.IsTrue(arrGameState[4,2].IsAlive);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[2, 3].IsAlive);
            Assert.IsTrue(arrGameState[3, 1].IsAlive);
            Assert.IsTrue(arrGameState[3, 3].IsAlive);
            Assert.IsTrue(arrGameState[4, 2].IsAlive);
            Assert.IsTrue(arrGameState[4, 3].IsAlive);
        }

        [TestMethod]
        public void TestRepeater()
        {
            var objSUT = new GameOfLifeCore(5, 5);

            objSUT.SetRepeater();

            objSUT.LiveLifeSegment();

            var arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[2, 0].IsAlive);
            Assert.IsTrue(arrGameState[2, 1].IsAlive);
            Assert.IsTrue(arrGameState[2, 2].IsAlive);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[1, 1].IsAlive);
            Assert.IsTrue(arrGameState[2, 1].IsAlive);
            Assert.IsTrue(arrGameState[3, 1].IsAlive);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[2, 0].IsAlive);
            Assert.IsTrue(arrGameState[2, 1].IsAlive);
            Assert.IsTrue(arrGameState[2, 2].IsAlive);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[1, 1].IsAlive);
            Assert.IsTrue(arrGameState[2, 1].IsAlive);
            Assert.IsTrue(arrGameState[3, 1].IsAlive);
        }

        [TestMethod]
        public void TestImmortality()
        {
            var objSUT = new GameOfLifeCore(5, 5);

            objSUT.SetTardigrade();

            objSUT.LiveLifeSegment();

            var arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[1, 1].IsAlive);
            Assert.IsTrue(arrGameState[2, 1].IsAlive);
            Assert.IsTrue(arrGameState[1, 2].IsAlive);
            Assert.IsTrue(arrGameState[2, 2].IsAlive);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[1, 1].IsAlive);
            Assert.IsTrue(arrGameState[2, 1].IsAlive);
            Assert.IsTrue(arrGameState[1, 2].IsAlive);
            Assert.IsTrue(arrGameState[2, 2].IsAlive);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsTrue(arrGameState[1, 1].IsAlive);
            Assert.IsTrue(arrGameState[2, 1].IsAlive);
            Assert.IsTrue(arrGameState[1, 2].IsAlive);
            Assert.IsTrue(arrGameState[2, 2].IsAlive);
        }

        [TestMethod]
        public void TestExtinctionEvent()
        {
            var objSUT = new GameOfLifeCore(5, 5);

            objSUT.SetDodoBird();

            objSUT.LiveLifeSegment();

            var arrGameState = objSUT.ReturnGameState();

            Assert.IsFalse(arrGameState[2, 2].IsAlive);

            objSUT.LiveLifeSegment();

            arrGameState = objSUT.ReturnGameState();

            Assert.IsFalse(arrGameState[2, 2].IsAlive);
        }
    }
}
