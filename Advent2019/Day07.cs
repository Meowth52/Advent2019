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
            Sum = GetPartOne();
            int Sum2 = 0;
            Sum2 = GetPartTwo();
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public int GetPartOne()
        {
            int ReturnValue = 0;
            string PhaseSequenceSeed = "01234";
            StringPermutator permutator = new StringPermutator();
            List<string> AllThePhases = permutator.GetStrings(PhaseSequenceSeed);
            foreach (string s in AllThePhases)
            {
                List<int> PhaseSequence = new List<int>();
                foreach (char c in s)
                {
                    int parse = 0;
                    Int32.TryParse(c.ToString(), out parse);
                    PhaseSequence.Add(parse);
                }
                int IntPut = 0;
                for (int i = 0; i < 5; i++)
                {
                    IntMachine Amp = new IntMachine(Instructions, PhaseSequence[i]);
                    Amp.AddArgument(IntPut);
                    Amp.Run();
                    IntPut = Amp.Outputs.Last();
                }
                if (IntPut > ReturnValue)
                    ReturnValue = IntPut;
            }
            return ReturnValue;
        }
        public int GetPartTwo()
        {
            int ReturnValue = 0;
            string PhaseSequenceSeed = "56789";
            StringPermutator permutator = new StringPermutator();
            List<string> AllThePhases = permutator.GetStrings(PhaseSequenceSeed);
            foreach (string s in AllThePhases)
            {
                List<int> PhaseSequence = new List<int>();
                foreach (char c in s)
                {
                    int parse = 0;
                    Int32.TryParse(c.ToString(), out parse);
                    PhaseSequence.Add(parse);
                }
                int IntPut = 0;
                List<IntMachine> Amps = new List<IntMachine>();
                for (int i = 0; i < 5; i++)
                {
                    Amps.Add(new IntMachine(Instructions, PhaseSequence[i]));
                }
                if (s == "79586")
                    ;
                int Done = -1;
                while (Done == -1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Amps[i].AddArgument(IntPut);
                        Done = Amps[i].Run();
                        IntPut = Amps[i].Outputs.Last();
                    }                    
                }
                if (IntPut > ReturnValue)
                    ReturnValue = IntPut;
                if (s == "79586")
                    ;
            }
            return ReturnValue;
        }
    }
}
