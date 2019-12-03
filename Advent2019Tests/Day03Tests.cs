using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advent2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2019.Tests
{
    [TestClass()]
    public class Day03Tests
    {
        [TestMethod()]
        public void Part1_1()
        {
            Day _day03 = new Day03("R75,D30,R83,U83,L12,D49,R71,U7,L72\r\nU62, R66, U55, R34, D71, R55, D58, R83");
            string PartOneExpected = "159";
            string Actual = _day03.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part1_2()
        {
            Day _day03 = new Day03("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51\r\nU98, R91, D20, R16, D67, R40, U7, R15, U6, R7");
            string PartOneExpected = "135";
            string Actual = _day03.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
    }
}