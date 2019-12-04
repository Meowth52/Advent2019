using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day03 : Day
    {
        List<string[]> Instructions;
        Dictionary<Coordinate,int> Grid;
        Dictionary<Coordinate, int> Crossings;
        public Day03(string _input) : base(_input)
        {
            Grid = new Dictionary<Coordinate, int>();
            string[] instructions = this.parseStringArray(_input);
            Instructions = new List<string[]>();
            Instructions.Add(instructions[0].Split(','));
            Instructions.Add(instructions[1].Split(','));
            Wire Wire1 = new Wire(1);
            Wire Wire2 = new Wire(2);
            Crossings = new Dictionary<Coordinate, int>();
            Draw(Instructions[0], Wire1);
            Draw(Instructions[1], Wire2);
            Wire1 = new Wire(1);
            Draw(Instructions[0], Wire1);
        }

        public override Tuple<string, string> getResult()
        {
            int Sum = 2147483647;
            int Sum2 = 2147483647;
            foreach (KeyValuePair<Coordinate, int> coo in Crossings)
            {
                int n = coo.Key.ManhattanDistance(new Coordinate(0, 0));
                if (n < Sum && n != 0)
                    Sum = n;
                if (coo.Value < Sum2)
                    Sum2 = coo.Value;
            }
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public void Draw(string[] Instruction, Wire _wire)
        {
            Dictionary<Coordinate, int> ReturnList = new Dictionary<Coordinate, int>();
            foreach (string s in Instruction)
            {
                _wire.Follow(s, ref Grid, ref Crossings);
            }
        }
        public class Wire
        {
            Coordinate CurrentPosition;
            byte WireNumber;
            int StepCounter;
            public Wire(byte _wireNumber)
            {
                CurrentPosition = new Coordinate(0,0);
                WireNumber = _wireNumber;
                StepCounter = 0;
            }
            internal void Follow(string Instruction, ref Dictionary<Coordinate,int> Grid, ref Dictionary<Coordinate, int> Crossings)
            {
                char Direction = Instruction[0];
                Instruction = Instruction.Substring(1);
                int NumberOfSteps = 0;
                Int32.TryParse(Instruction, out NumberOfSteps);
                for(int i = 0; i < NumberOfSteps; i++)
                {
                    CurrentPosition.MoveOneStep(Direction);
                    StepCounter++;
                    if (!Grid.ContainsKey(CurrentPosition))
                        Grid.Add(new Coordinate(CurrentPosition), WireNumber);
                    else if (Grid[CurrentPosition] != WireNumber)
                    {
                        if (Crossings.ContainsKey(CurrentPosition))
                            Crossings[CurrentPosition] += StepCounter;
                        else
                            Crossings.Add(new Coordinate(CurrentPosition), StepCounter);
                        Grid[CurrentPosition] = 3;
                    }
                }
            }
        }
    }
}
