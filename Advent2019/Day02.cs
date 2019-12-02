using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day02 : Day
    {
        List<int> Instructions;
        public Day02(string _input) : base(_input)
        {
            Instructions = this.parseListOfInteger(_input);
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            int Sum2 = 0;
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public override string getPartOne()
        {
        IntMachine _intMachine = new IntMachine(Instructions, 4);
            _intMachine.Day2Offset(12, 2);
            return _intMachine.Run().ToString();
        }
        public override string getPartTwo()
        {
            for (int Noun = 0; Noun < Instructions.Count; Noun++)
            {
                for (int Verb = 0; Verb < Instructions.Count; Verb++)
                {
                    IntMachine _intMachine = new IntMachine(Instructions, 4);
                    _intMachine.Day2Offset(Noun, Verb);
                    if (_intMachine.Run() == 19690720)
                        return (Noun * 100 + Verb).ToString();
                }
                Noun++;
            }
            return "0";
        }
    }
}
