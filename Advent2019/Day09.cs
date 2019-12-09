using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day09 : Day
    {
        List<int> Instructions;
        public Day09(string _input) : base(_input)
        {
            Instructions = this.parseListOfInteger(_input);
        }
        public override Tuple<string, string> getResult()
        {
            IntMachine Boost = new IntMachine(Instructions, 1);
            Boost.Run();
            int Sum = Boost.Outputs.Last();
            
            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
    }
}
