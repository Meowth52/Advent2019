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
        List<long> Instructions;
        public Day09(string _input) : base(_input)
        {
            Instructions = this.parseListOfLong(_input);
        }
        public override Tuple<string, string> getResult()
        {
            IntMachine Boost = new IntMachine(Instructions, 1);
            int GetOut = -1;
            while (GetOut == -1)
            {
                GetOut = Boost.Run();
            }
            long Sum = Boost.Outputs.Last();
            Boost = new IntMachine(Instructions, 2);
            GetOut = -1;
            while (GetOut == -1)
            {
                GetOut = Boost.Run();
            }
            long Sum2 = Boost.Outputs.Last();
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
    }
}
