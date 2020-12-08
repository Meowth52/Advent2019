using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day17 : Day
    {
        List<int> Instructions;
        public Day17(string _input) : base(_input)
        {
            Instructions = this.parseListOfInteger(_input);
        }
        public override Tuple<string, string> getResult()
        {
            int Sum2 = 0;
            return Tuple.Create(getPartOne(), getPartTwo().ToString());
        }
        public string getPartOne()
        {
            int Sum = 0;
            IntMachine MapProgram = new IntMachine(Instructions);
            int GetOut = -1;
            while (GetOut == -1)
            {
                GetOut = MapProgram.Run();
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            List<List<char>> Scaffolding = new List<List<char>>();
            Scaffolding.Add(new List<char>());
            foreach (int c in MapProgram.Outputs)
            {
                char CharC = (char)c;
                sb.Append(CharC);
                switch (CharC)
                {
                    case '.':
                        Scaffolding.Last().Add(CharC);
                        break;
                    case '#':
                        Scaffolding.Last().Add(CharC);
                        break;
                    case '\n':
                        Scaffolding.Add(new List<char>());
                        break;
                    case '^':
                        Scaffolding.Last().Add(CharC);
                        break;
                    default:
                        break;
                }
            }
            for (int x = 1; x < Scaffolding.Count - 3; x++)
            {
                for (int y = 1; y < Scaffolding.First().Count - 1; y++)
                {
                    if (Scaffolding[x][y] == '#' &&
                        Scaffolding[x - 1][y] == '#' &&
                        Scaffolding[x + 1][y] == '#' &&
                        Scaffolding[x][y - 1] == '#' &&
                        Scaffolding[x][y + 1] == '#')
                    {
                        Sum += x * y;
                    }
                }
            }
            sb.Append("\n " + Sum.ToString());
            return sb.ToString();
        }
        public string getPartTwo()
        {
            int ReturnValue = 0;
            List<int> Path = new List<int> { 65,44,66,44,65,44,67,44,65,44,66,44,67,44,65,44,66,44,67,10, //A,B,A,C,A,B,C,B,A,C
                                            82,44,49,50,44,82,44,52,44,82,44,49,48,44,82,44,49,50,10, //r,12,r,4,r,10,r,12
                                            82,44,54,44,76,44,56,44,82,44,49,48,10, //r,6,l,8,r,10
                                            76,44,56,44,82,44,52,44,82,44,52,44,82,44,54,10, //l,8,r,4,r,4,r,6
                                            110,10 }; //n
            IntMachine VacuumRobot = new IntMachine(Instructions);
            VacuumRobot.Day13Offset(2);
            foreach (int i in Path)
                VacuumRobot.AddArgument(i);
            int GetOut = -1;
            while (GetOut == -1)
            {
                GetOut = VacuumRobot.Run();
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            foreach (int c in VacuumRobot.Outputs)
            {
                char CharC = (char)c;
                sb.Append(CharC);
                ReturnValue = (int)VacuumRobot.Outputs[0];
            }
            sb.Append("\n" + VacuumRobot.Outputs.Last().ToString());
            return sb.ToString();
        }
    }
}
