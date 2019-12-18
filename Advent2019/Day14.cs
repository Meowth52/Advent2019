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
        Dictionary<string, int> Materials;
        public Day14(string _input) : base(_input)
        {
            string[] Instructions = this.parseStringArray(_input);
            Reactions = new Dictionary<string, Dictionary<string, int>>();
            Materials = new Dictionary<string, int>();
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
            int Sum = ReCurse("FUEL", 1);

            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public int ReCurse(string that, int wanted)
        {
            int ReturnValue = 0;
            int bla = ((int)Math.Ceiling(wanted / (float)Reactions[that].Last().Value) );
            foreach (KeyValuePair<string,int> eh in Reactions[that])
            {
                if (eh.Key == "ORE")
                    ReturnValue += bla * eh.Value;
                else if (eh.Key != that )
                {
                    ReturnValue += ReCurse(eh.Key, bla * eh.Value - Materials[eh.Key]);
                }
            }
            Materials[that] = (int)Math.Ceiling(wanted / (float)Reactions[that].Last().Value) * Reactions[that].Last().Value - (wanted );
            return ReturnValue;
        }
    }
}
