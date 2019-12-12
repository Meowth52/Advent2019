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
        public Day11(string _input) : base(_input)
        {
            Instructions = this.parseListOfLong(_input);
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            Dictionary<Coordinate, int> Hull = new Dictionary<Coordinate, int>();
            Coordinate CurrentPosition = new Coordinate(0, 0);
            char Heading = 'N';
            IntMachine Walle = new IntMachine(Instructions, 0);
            int Getout = -1;
            while (Getout == -1)
            {
                Walle.Run();
                Hull[CurrentPosition] = (int)Walle.Outputs.Last();
                Getout = Walle.Run();
                Heading = UpdateHeading(Heading, (int)Walle.Outputs.Last());
                CurrentPosition.MoveOneStep(Heading);
                if (!Hull.ContainsKey(CurrentPosition))
                {
                    Hull.Add(new Coordinate(CurrentPosition), 0);
                    Sum++;
                }
                Walle.Input.Add(Hull[CurrentPosition]);
            }
            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
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
