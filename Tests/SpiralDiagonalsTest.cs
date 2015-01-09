using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EulerTools.Arrays;

namespace Tests
{
    [TestClass]
    public class SpiralDiagonalsTest
    {
        [TestMethod]
        public void spiral_diagonals_calculated_for_grid_size_of_5()
        {
            const int gridSize = 5;
            const int expected = 101;
            int result = new SpiralDiagonal().CalculateSum(gridSize);
            Assert.AreEqual(expected, result);
        }
    }
}
