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
                List<int> NextSignal = new List<int>();
                List<int> Pattern = new List<int>(BasePattern);
                for (int i = 0; i < Signal.Count; i++)
                {
                    int Value = 0;
                    for (int n = 0; n < Signal.Count; n++)
                    {
                        Value += Signal[n] * Pattern[(n+1) % Pattern.Count];
                    }
                    NextSignal.Add(Math.Abs(Value) % 10);
                    for(int fuu=1; fuu <= 4; fuu++)
                    {
                        Pattern.Insert((fuu * (i+1))+(fuu-1), BasePattern[fuu-1]);
                    }
                }
                Signal = new List<int>(NextSignal);
            }
            int Sum = GetFirstNumbers(8);

            //Part 2
            List<int> BigSignal = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                BigSignal.AddRange(Instructions);
            }
            int StartIndex =  0;
            for (int i = 0; i <= 6; i++) //Get startIndex
            {
                StartIndex += Instructions[6 - i] * (int)Math.Pow(10, i);
            }
            Signal = new List<int>(BigSignal.GetRange(BigSignal.Count/2, BigSignal.Count/2));
            for (int Phase = 0; Phase < PhaseLimit; Phase++)
            {
                List<int> NextSignal = new List<int>();
                int Value = 0;
                for (int i = Signal.Count-1; i >= 0; i--)
                {
                    Value += Signal[i];
                    NextSignal.Add(Math.Abs(Value) % 10);
                }
                NextSignal.Reverse();
                Signal = new List<int>(NextSignal);
            }
            StartIndex -= Signal.Count;
            Signal = Signal.GetRange(StartIndex,8);
            int Sum2 = GetFirstNumbers(8);
            return Tuple.Create(Sum.ToString("D8"), Sum2.ToString());
        }
        int GetFirstNumbers(int HowMany)
        {
            int ReturnValue = 0;
            for (int i = 0; i < HowMany; i++)
            {
                ReturnValue += Signal[HowMany-1 - i] * (int)Math.Pow(10, i);
            }
            return ReturnValue;
        }
    }
}
