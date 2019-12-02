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
    public class Day02Tests
    {
        [TestMethod()]
        public void Part1_1()
        {
            Day _day02 = new Day02("1,9,10,3,2,3,11,0,99,30,40,50");
            string PartOneExpected = "3500";
            string Actual = _day02.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part1_2()
        {
            Day _day02 = new Day02("1,0,0,0,99");
            string PartOneExpected = "2";
            string Actual = _day02.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part1_3()
        {
            Day _day02 = new Day02("2,3,0,3,99");
            string PartOneExpected = "2";
            string Actual = _day02.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part1_4()
        {
            Day _day02 = new Day02("2,4,4,5,99,0");
            string PartOneExpected = "2";
            string Actual = _day02.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
        [TestMethod()]
        public void Part1_5()
        {
            Day _day02 = new Day02("1,1,1,4,99,5,6,0,99");
            string PartOneExpected = "30";
            string Actual = _day02.getPartOne();
            Assert.AreEqual(PartOneExpected, Actual);
        }
    }
}