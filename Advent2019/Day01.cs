using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day01 : Day
    {
        List<int> Instructions;
        public Day01(string _input) : base(_input)
        {
            Instructions = this.parseListOfInteger(_input);
        }
        public override Tuple<string, string> getResult()
        {
            int Sum2 = 0;
            return Tuple.Create(getPartOne(), getPartTwo());
        }
        public string getPartOne()
        {
            int ReturnValue = 0;
            foreach(int i in Instructions)
            {
                ReturnValue += i / 3 - 2;
            }
            return ReturnValue.ToString();
        }
        public string getPartTwo()
        {
            int ReturnValue = 0;
            foreach (int i in Instructions)
            {
                int FuelFuel = i / 3 - 2;
                while (FuelFuel>0)
                {
                    ReturnValue += FuelFuel;
                    FuelFuel = FuelFuel / 3 - 2;
                }
            }
            return ReturnValue.ToString();

        }
    }
}
