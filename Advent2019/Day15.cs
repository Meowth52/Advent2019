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
        Dictionary<Coordinate, List<Coordinate>> Crossings;
        int Max;
        IntMachine Droid;
        Coordinate CurrentPosition;
        public Day15(string _input) : base(_input)
        {
            Instructions = this.parseListOfInteger(_input);
            Max = 500;
            TheGrid = new Grid(Max, Max, 2.0f);
            Locations = new Dictionary<Coordinate, int>();
            Crossings = new Dictionary<Coordinate, List<Coordinate>>();
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            CurrentPosition = new Coordinate(Max/2, Max/2);
            Locations.Add(CurrentPosition, 1);
            Droid = new IntMachine(Instructions);
            while (true) //until crossings is empty and this is a dead end
            {
                Dictionary<Coordinate, int> Neighbours = GetNeighbours();
                
            }
            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public Dictionary<Coordinate, int> GetNeighbours()
        {
            Dictionary<Coordinate, int> Neighbours = new Dictionary<Coordinate, int>();
            Dictionary<int, char> Directions = new Dictionary<int, char>() { {1, 'N' }, { 4, 'E' }, { 2, 'S' }, { 3, 'W' } };
            foreach(KeyValuePair<int, char> d in Directions)
            {
                Coordinate Next = new Coordinate(CurrentPosition);
                Droid.AddArgument(d.Key);
                Droid.Run();
                int Result = (int)Droid.Outputs.Last();
                Next.MoveOneStep(d.Value);
                List<Coordinate> FoundOpen = new List<Coordinate>();
                if (Result == 0)
                {
                    TheGrid.BlockCell(Next.GetPosition());
                    int NextType = 3;
                    if (Result == 2)
                        NextType = 4;
                    if (!Locations.ContainsKey(Next))
                    {
                        Locations.Add(Next, NextType);
                        FoundOpen.Add(Next);
                    }
                }
                else
                {
                    TheGrid.UnblockCell(Next.GetPosition());
                    if (!Locations.ContainsKey(Next))
                        Locations.Add(Next, 0);
                }

                Neighbours.Add(Next, -1);
            }
        }
    }
}
