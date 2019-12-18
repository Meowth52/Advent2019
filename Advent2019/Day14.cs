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
        Dictionary<string, long> Materials;
        public Day14(string _input) : base(_input)
        {
            string[] Instructions = this.parseStringArray(_input);
            Reactions = new Dictionary<string, Dictionary<string, int>>();
            Materials = new Dictionary<string, long>();
            foreach(string s in Instructions)
            {
                MatchCollection Matches = Regex.Matches(s, @"(-?\d+) ([A-Z]+)");
                Dictionary<string, int> Row = new Dictionary<string, int>();
                foreach(Match m in Matches)
                {
                    Row.Add(m.Groups[2].Value, Int32.Parse(m.Groups[1].Value));
                }
                Reactions.Add(Row.Last().Key, Row);
                Materials.Add(Row.Last().Key, 0);
            }
        }
        public override Tuple<string, string> getResult()
        {
            long Sum = ReCurse("FUEL", 1);
            long Sum2 = 0;
            while (Sum2 != 1000000000000)
            {

            }
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public long ReCurse(string that, long wanted)
        {
            long ReturnValue = 0;
            long RoundUp = ((long)Math.Ceiling(wanted / (float)Reactions[that].Last().Value) );
            foreach (KeyValuePair<string,int> Next in Reactions[that])
            {
                if (Next.Key == "ORE")
                    ReturnValue += RoundUp * Next.Value;
                else if (Next.Key != that )
                {
                    ReturnValue += ReCurse(Next.Key, RoundUp * Next.Value - Materials[Next.Key]);
                }
            }
            Materials[that] = RoundUp * Reactions[that].Last().Value - (wanted );
            return ReturnValue;
        }
    }
}
