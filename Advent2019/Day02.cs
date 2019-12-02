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
        List<int> _instructions;
        Dictionary<long, long> RawInstructions;
        public Day02(string _input) : base(_input)
        {
            _instructions = this.parseListOfInteger(_input);
            RawInstructions = new Dictionary<long, long>();
            int Counter = 0;
            int LargestNumber = 0;
            foreach (int i in _instructions)
            {
                RawInstructions.Add(Counter, i);
                if (i > LargestNumber)
                    LargestNumber = i;
                Counter++;
            }
            for (int i = RawInstructions.Count; i <= 100000; i++)
            {
                RawInstructions.Add(i, 0);
            }
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            int Sum2 = 0;
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public override string getPartOne()
        {
            return GetPartOneInt(12, 2).ToString();
        }
        public override string getPartTwo()
        {
            int IsThisIt = 0;
            while (true)
            {
                try
                {
                    int attempt = (int)GetPartOneInt(IsThisIt, 54);
                    if (attempt == 19690720)
                        return IsThisIt.ToString();
                }
                catch
                {

                }
                IsThisIt++;
            }
            return "0";
        }
        public long GetPartOneInt(int Noun, int Verb)
        {
            Dictionary<long, long> Instructions = new Dictionary<long, long>(RawInstructions);
            Instructions[1] = Noun;
            Instructions[2] = Verb;
            int CurrentPosition = 0;
            bool GetOut = false;
            while (!GetOut) //Brr
            {
                long Case = Instructions[CurrentPosition];
                switch (Case)
                {
                    case 1:
                        Instructions[Instructions[CurrentPosition + 3]] = Instructions[Instructions[CurrentPosition + 1]] + Instructions[Instructions[CurrentPosition + 2]];
                        break;
                    case 2:
                        Instructions[ Instructions[CurrentPosition + 3]] = Instructions[Instructions[CurrentPosition + 1]] * Instructions[Instructions[CurrentPosition + 2]];
                        break;
                    case 99:
                        GetOut = true;
                        break;
                    default:
                        break;
                }
                CurrentPosition += 4;
            }
            return Instructions[0];
        }
    }
}
