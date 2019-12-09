using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day05 : Day
    {
        List<int> Instructions;
        public Day05(string _input) : base(_input)
        {
            Instructions = this.parseListOfInteger(_input);
        }
        public override Tuple<string, string> getResult()
        {
            IntMachine Diagnostics = new IntMachine(Instructions, 1);
            int Value = -1;
            while (Value == -1)
            {
                Value = Diagnostics.Run();
            }
            long Sum = Diagnostics.Outputs.Last();
            IntMachine Diagnostics2 = new IntMachine(Instructions, 5);
            Diagnostics2.Run();
            long Sum2 = Diagnostics2.Outputs.Last();
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
    }
}
