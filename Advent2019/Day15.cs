using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using RoyT.AStar;

namespace Advent2019
{
    public class Day15 : Day
    {
        List<int> Instructions;
        Grid TheGrid;
        Dictionary<Coordinate, int> Locations; //0 = wall, 1 = open, 2 = Oxygen, 3 = open not final, 4 = oxygen not final
        int Max;
        IntMachine Droid;
        Coordinate CurrentPosition;
        public Day15(string _input) : base(_input)
        {
            Instructions = this.parseListOfInteger(_input);
            Max = 500;
            TheGrid = new Grid(Max, Max, 2.0f);
            Locations = new Dictionary<Coordinate, int>();
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            CurrentPosition = new Coordinate(Max/2, Max/2);
            Locations.Add(CurrentPosition, 1);
            Droid = new IntMachine(Instructions);
            while (true)
            {
                Dictionary<Coordinate, int> Neighbours = GetNeighbours();
                
            }
            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public Dictionary<Coordinate, int> GetNeighbours()
        {
            Dictionary<Coordinate, int> Neighbours = new Dictionary<Coordinate, int>();
            List<char> Directions = new List<char>() {'N', 'E', 'S', 'W' };
            foreach(char c in Directions)
            {
                Coordinate Next = new Coordinate(CurrentPosition);
                Next.MoveOneStep(c);

                Neighbours.Add(Next, -1)
            }
        }
    }
}
