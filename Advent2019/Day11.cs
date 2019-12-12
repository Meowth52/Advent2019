using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day11 : Day
    {
        List<long> Instructions;
        Dictionary<Coordinate, int> Hull;
        public Day11(string _input) : base(_input)
        {
            Instructions = this.parseListOfLong(_input);
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = RunRobot(0);
            RunRobot(1);
            string Part2 = PrintHull();
            return Tuple.Create(Sum.ToString(), Part2);
        }
        int RunRobot(int FirstColor)
        {
            int Sum = 1;
            Hull = new Dictionary<Coordinate, int>();
            Coordinate CurrentPosition = new Coordinate(0, 0);
            Hull.Add(new Coordinate(CurrentPosition), FirstColor);
            char Heading = 'N';
            IntMachine Walle = new IntMachine(Instructions, 0);
            int Getout = -1;
            while (Getout == -1)
            {
                if (!Hull.ContainsKey(CurrentPosition))
                {
                    Hull.Add(new Coordinate(CurrentPosition), 0);
                    Sum++;
                }
                Walle.Input.Add(Hull[CurrentPosition]);
                Walle.InputIndex = Walle.Input.Count - 1;
                Walle.Run();
                Hull[CurrentPosition] = (int)Walle.Outputs.Last();
                Getout = Walle.Run();
                Heading = UpdateHeading(Heading, (int)Walle.Outputs.Last());
                CurrentPosition.MoveOneStep(Heading);
            }
            return Sum;
        }
        string PrintHull()
        {
            string ReturnString = "";
            int LargestX = 0;
            int LargestY = 0;
            foreach (KeyValuePair<Coordinate, int> c in Hull)
            {
                if (c.Key.x > LargestX)
                    LargestX = c.Key.x;
                if (c.Key.y > LargestY)
                    LargestY = c.Key.y;
            }
            for (int y = 0; y <= LargestY; y++)
            {
                for (int x = 0; x <= LargestX; x++)
                {
                    Coordinate Check = new Coordinate(x, y);
                    if (Hull.ContainsKey(Check) && Hull[Check] == 1)
                        ReturnString += "#";
                    else
                        ReturnString += " ";
                }
                ReturnString += "\n";
            }
            return ReturnString;
        }
        char UpdateHeading(char heading, int Turn)
        {
            List<char> Directions = new List<char>() { 'N', 'E', 'S', 'W' };
            int HeadingInt = Directions.IndexOf(heading);
            if (Turn == 0)
                Turn = -1;
            HeadingInt += Turn;
            if (HeadingInt < 0)
                HeadingInt = 3;
            if (HeadingInt > 3)
                HeadingInt = 0;
            return Directions[HeadingInt];
        }

    }
}
