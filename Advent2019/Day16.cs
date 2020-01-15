using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day16 : Day
    {
        List<int> Instructions;
        List<int> Signal;
        public Day16(string _input) : base(_input)
        {
            Instructions = new List<int>();
            foreach(char c in _input)
            {
                if (char.IsDigit(c))
                    Instructions.Add(Int32.Parse(c.ToString()));
            }
        }
        public override Tuple<string, string> getResult()
        {
            int PhaseLimit = 100;
            List<int> BasePattern = new List<int>() { 0, 1, 0, -1 };
            Signal = new List<int>(Instructions);
            for (int Phase = 0; Phase < PhaseLimit;Phase++)
            {
                List<int> Pattern = new List<int>(BasePattern);
                for (int i = 0; i < Signal.Count; i++)
                {
                    for (int n = 0; n < Signal.Count; n++)
                    {

                    }
                    for(int fuu=1; fuu <= 4; fuu++)
                    {
                        Signal.Insert(fuu * i, Signal[fuu]);
                    }
                }
            }
            int Sum = 0;
            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public int MultiplyAndCrop(int a, int b)
        {
            return Math.Abs(a * b) % 10;
        }
    }
}
