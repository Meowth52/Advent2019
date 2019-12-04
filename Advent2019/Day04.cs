using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day04 : Day
    {
        int Min;
        int Max;
        public Day04(string _input) : base(_input)
        {
            string[] Splitted = _input.Split('-');
            Min = 0;
            Int32.TryParse(Splitted[0], out Min);
            
            Max = 0;
            Int32.TryParse(Splitted[1], out Max);
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            int Sum2 = 0;
            for (int Number = Min;Number <= Max; Number++)
            {
                List<int> Current = IntToList(Number);
                int Last = -1;
                int EvenLaster = -2;
                bool FoundSame = false;
                bool FoundSamer = false;
                bool NeverDecrease = true;
                for(int i = 0; i<Current.Count;i++)
                {
                    int n = Current[i];
                    if (n == Last)
                    {
                        FoundSame = true;
                        int AndAlsoINeedNext = -3;
                        if (i < Current.Count - 1)
                        {
                            AndAlsoINeedNext = Current[i + 1];
                        }
                        if (EvenLaster != n && AndAlsoINeedNext != n)
                            FoundSamer = true;
                    }
                    if (n < Last)
                        NeverDecrease=false;
                    EvenLaster = Last;
                    Last = n;
                }
                if (FoundSame && NeverDecrease)
                    Sum++;
                if (FoundSame && NeverDecrease && FoundSamer)
                    Sum2++;

            }
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public List<int> IntToList(int In)
        {
            string IntAsString = In.ToString();
            List<int> ReturnValue = new List<int>();
            foreach(char c in IntAsString)
            {
                int Next = 0;
                Int32.TryParse(c.ToString(), out Next);
                ReturnValue.Add(Next);
            }
            return ReturnValue;
        }
        public int ListToInt(List<int> Li)
        {
            int Multiplier = 1;
            int ReturnValue = 0;
            for(int i = Li.Count - 1; i >= 0; i--)
            {
                ReturnValue = Multiplier * Li[i];
                Multiplier *= 10;
            }
            return ReturnValue;
        }
    }
}
