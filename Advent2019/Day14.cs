using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day14 : Day
    {
        Dictionary<string, Dictionary<string,int>> Reactions;
        public Day14(string _input) : base(_input)
        {
            string[] Instructions = this.parseStringArray(_input);
            Reactions = new Dictionary<string, Dictionary<string, int>>();
            foreach(string s in Instructions)
            {
                MatchCollection Matches = Regex.Matches(s, @"(-?\d+) ([A-Z]+)");
                Dictionary<string, int> Row = new Dictionary<string, int>();
                foreach(Match m in Matches)
                {
                    Row.Add(m.Groups[2].Value, Int32.Parse(m.Groups[1].Value));
                }
                Reactions.Add(Row.Last().Key, Row);
            }
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
    }
    //public class Schmenum
    //{
    //    int I;
    //    string S;
    //    public Schmenum(int _i, string _s)
    //    {
    //        I = _i;
    //        S = _s;
    //    }
    //    class CoordinateEqualityComparer : IEqualityComparer<Coordinate>
    //    {
    //        public bool Equals(Coordinate b1, Coordinate b2)
    //        {
    //            if (b2 == null && b1 == null)
    //                return true;
    //            else if (b1 == null | b2 == null)
    //                return false;
    //            else if (b1.x == b2.x && b1.y == b2.y)
    //                return true;
    //            else
    //                return false;
    //        }
    //        public override int GetHashCode()
    //        {
    //            string hCode = I ^ y;
    //            return hCode.GetHashCode();
    //        }
    //        public override bool Equals(object obj)
    //        {
    //            return Equals(obj as Coordinate);
    //        }
    //        public bool Equals(Coordinate obj)
    //        {
    //            return obj != null && obj.x == x && obj.y == y;
    //        }
    //        public int CompareTo(Coordinate other)
    //        {
    //            if (this.x == other.x)
    //            {
    //                return this.y.CompareTo(other.y);
    //            }
    //            return this.x.CompareTo(other.x);
    //        }

    //        public int GetHashCode(Coordinate bx)
    //        {
    //            int hCode = bx.x ^ bx.y;
    //            return hCode.GetHashCode();
    //        }
    //    }
    //}
}
