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
            CurrentPosition = new Coordinate(Max / 2, Max / 2);
            Locations.Add(CurrentPosition, 1);
            Droid = new IntMachine(Instructions);
            bool GetOut = false;
            Coordinate N = new Coordinate(0, 1);
            Coordinate S = new Coordinate(0, -1);
            Coordinate W = new Coordinate(-1, 0);
            Coordinate E = new Coordinate(1, 0);
            while (!GetOut) //until this is a dead end
            {
                Dictionary<Coordinate, int> Neighbours = GetNeighbours();
                int Case = Neighbours.Count;
                switch (Case)
                {
                    case 0:
                        GetOut = true;
                        Locations[CurrentPosition] -= 2;
                        break;
                    case 1:
                        Locations[CurrentPosition] -= 2;
                        break;
                    default:
                        break;
                }
                if (!GetOut)
                {
                    Coordinate RelativePosition = CurrentPosition.RelativePosition(Neighbours.First().Key);
                    if (RelativePosition.IsOn(N))
                    {
                        Droid.AddArgument(1);
                        Droid.Run();
                    }
                    else if (RelativePosition.IsOn(S))
                    {
                        Droid.AddArgument(2);
                        Droid.Run();
                    }
                    else if (RelativePosition.IsOn(W))
                    {
                        Droid.AddArgument(3);
                        Droid.Run();
                    }
                    else if (RelativePosition.IsOn(E))
                    {
                        Droid.AddArgument(4);
                        Droid.Run();
                    }
                    CurrentPosition.AddTo(RelativePosition);
                }
            }
            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public Dictionary<Coordinate, int> GetNeighbours()
        {
            Dictionary<Coordinate, int> Neighbours = new Dictionary<Coordinate, int>();
            Dictionary<int, char> Directions = new Dictionary<int, char>() { { 1, 'N' }, { 4, 'E' }, { 2, 'S' }, { 3, 'W' } };
            foreach (KeyValuePair<int, char> d in Directions)
            {
                Coordinate Next = new Coordinate(CurrentPosition);
                Droid.AddArgument(d.Key);
                Droid.Run();
                int Result = (int)Droid.Outputs.Last();
                Next.MoveOneStep(d.Value);
                if (Result == 0)
                {
                    TheGrid.BlockCell(Next.GetPosition());
                    if (!Locations.ContainsKey(Next))
                        Locations.Add(Next, 0);
                }
                else
                {
                    TheGrid.UnblockCell(Next.GetPosition());
                    int NextType = 3;
                    if (Result == 2)
                        NextType = 4;
                    if (!Locations.ContainsKey(Next))
                    {
                        Locations.Add(Next, NextType);
                        Neighbours.Add(Next, NextType);
                    }
                    else if (Locations[Next] == 3 || Locations[Next] == 4)
                        Neighbours.Add(Next, NextType); ;
                    int Back = 0; //tillbaka
                    switch (d.Key)
                    {
                        case 1:
                            Back = 2;
                            break;
                        case 2:
                            Back = 1;
                            break;
                        case 3:
                            Back = 4;
                            break;
                        case 4:
                            Back = 3;
                            break;
                        default:
                            break;
                    }
                    Droid.AddArgument(Back);
                    Droid.Run();
                }
            }
            return Neighbours;
        }
    }
}
