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
    public class Day01Tests
    {
        [TestMethod()]
        public void Part1_1()
        {
            Day _day01 = new Day01("12");
            string PartOneExpected = "2";
            string Actual = _day01.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part1_2()
        {
            Day _day01 = new Day01("14");
            string PartOneExpected = "2";
            string Actual = _day01.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part1_3()
        {
            Day _day01 = new Day01("1969");
            string PartOneExpected = "654";
            string Actual = _day01.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part1_4()
        {
            Day _day01 = new Day01("100756");
            string PartOneExpected = "33583";
            string Actual = _day01.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part2_1()
        {
            Day _day01 = new Day01("14");
            string PartOneExpected = "2";
            string Actual = _day01.getPartTwo();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part2_2()
        {
            Day _day01 = new Day01("1969");
            string PartOneExpected = "966";
            string Actual = _day01.getPartTwo();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part2_3()
        {
            Day _day01 = new Day01("100756");
            string PartOneExpected = "50346";
            string Actual = _day01.getPartTwo();
            Assert.AreEqual(PartOneExpected, Actual);
        }
    }
}