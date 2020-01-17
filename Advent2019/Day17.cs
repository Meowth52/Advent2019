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
            int Sum = 0;
            IntMachine MapProgram = new IntMachine(Instructions);
            int GetOut = -1;
            while (GetOut ==-1)
            {
                GetOut = MapProgram.Run();
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            List<List<char>> Scaffolding = new List<List<char>>();
            Scaffolding.Add(new List<char>());
            foreach(int c in MapProgram.Outputs)
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
            for(int x  = 1; x < Scaffolding.Count-3; x++)
            {
                for(int y = 1; y < Scaffolding.First().Count-1;y++)
                {
                    if (Scaffolding[x][y] == '#' &&
                        Scaffolding[x-1][y] == '#' &&
                        Scaffolding[x+1][y] == '#' &&
                        Scaffolding[x][y-1] == '#' &&
                        Scaffolding[x][y+1] == '#')
                    {
                        Sum += x * y;
                    }
                }
            }
            sb.Append("\n "+ Sum.ToString());
            int Sum2 = 0;
            return Tuple.Create(sb.ToString(), Sum2.ToString());
        }
    }
}
