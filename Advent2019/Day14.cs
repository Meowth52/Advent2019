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
        Dictionary<string, Dictionary<string, int>> Reactions;
        Dictionary<string, long> Materials;
        Dictionary<string, long> MaterialsClean;
        public Day14(string _input) : base(_input)
        {
            string[] Instructions = this.parseStringArray(_input);
            Reactions = new Dictionary<string, Dictionary<string, int>>();
            MaterialsClean = new Dictionary<string, long>();
            foreach (string s in Instructions)
            {
                MatchCollection Matches = Regex.Matches(s, @"(-?\d+) ([A-Z]+)");
                Dictionary<string, int> Row = new Dictionary<string, int>();
                foreach (Match m in Matches)
                {
                    Row.Add(m.Groups[2].Value, Int32.Parse(m.Groups[1].Value));
                }
                Reactions.Add(Row.Last().Key, Row);
                MaterialsClean.Add(Row.Last().Key, 0);
            }
            Materials = new Dictionary<string, long>(MaterialsClean);
        }
        public override Tuple<string, string> getResult()
        {
            long Sum = ReCurse("FUEL", 1);
            long Target = 1000000000000;
            long Fuel = Target;
            long Ore = 0;
            long LastGuess = 1;
            long AnotherLastGuess;
            long SmallestDiff = Target;
            long Sum2 = 0;
            while (Fuel != LastGuess)
            {
                Materials = new Dictionary<string, long>(MaterialsClean);
                Ore = ReCurse("FUEL", Fuel);
                AnotherLastGuess = Fuel;
                if (Ore <= Target)
                {
                    if (Target - Ore < SmallestDiff)
                    {
                        SmallestDiff = Target - Ore;
                        Sum2 = Fuel;
                    }
                }
                if (Ore < Target)
                {
                    Fuel += (long)Math.Ceiling(Math.Abs(Fuel - LastGuess) / (double)2);
                }
                else if (Ore > Target)
                    Fuel -= (long)Math.Floor(Math.Abs(Fuel - LastGuess) / (double)2);
                LastGuess = AnotherLastGuess;
            }
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public long ReCurse(string that, long wanted)
        {
            long ReturnValue = 0;
            long RoundUp = ((long)Math.Ceiling(wanted / (float)Reactions[that].Last().Value));
            foreach (KeyValuePair<string, int> Next in Reactions[that])
            {
                if (Next.Key == "ORE")
                    ReturnValue += RoundUp * Next.Value;
                else if (Next.Key != that)
                {
                    ReturnValue += ReCurse(Next.Key, RoundUp * Next.Value - Materials[Next.Key]);
                }
            }
            Materials[that] = RoundUp * Reactions[that].Last().Value - (wanted);
            return ReturnValue;
        }
    }
}
