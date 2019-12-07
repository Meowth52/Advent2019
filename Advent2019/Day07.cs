using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day07 : Day
    {
        List<int> Instructions;
        public Day07(string _input) : base(_input)
        {
            Instructions = this.parseListOfInteger(_input);
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            int IntPut = 0;
            List<int> PhaseSequence = new List<int>() { 0, 1, 2, 3, 4 };

            for (int i = 0; i < 5; i++)
            {
                IntMachine Amp = new IntMachine(Instructions, PhaseSequence[i]);
                Amp.AddArgument(IntPut);
                Amp.Run();
                IntPut = Amp.Outputs.Last();
            }
            Sum = IntPut;
            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
    }
}
