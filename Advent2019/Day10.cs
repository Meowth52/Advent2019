using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day10 : Day
    {
        public HashSet<Coordinate> Asteroids;
        public string[] Instructions;
        public Day10(string _input) : base(_input)
        {
            Instructions = this.parseStringArray(_input);
            Asteroids = new HashSet<Coordinate>();
            for (int y = 0; y < Instructions.Length; y++)
            {
                for (int x = 0; x < Instructions[y].Length; x++)
                {
                    if (Instructions[y][x] == '#')
                        Asteroids.Add(new Coordinate(x, y));
                }
            }
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            Coordinate WinningAsteroid = new Coordinate(0, 0);
            foreach (Coordinate c in Asteroids)
            {
                int AsteroidCount = 0;
                Coordinate CurrentPosition = new Coordinate(c);
                foreach (Coordinate a in Asteroids)
                    if (c != a)
                    {
                        bool BadAsteroid = false;
                        Coordinate OtherAstroid = new Coordinate(a);
                        Coordinate RelativePosition = a.RelativePosition(CurrentPosition);
                        Coordinate Angle = GetAngle(RelativePosition);
                        OtherAstroid.AddTo(Angle);
                        while (!OtherAstroid.IsOn(CurrentPosition))
                        {
                            if (Asteroids.Contains(OtherAstroid))
                                BadAsteroid = true;
                            OtherAstroid.AddTo(Angle);
                        }
                        if (!BadAsteroid)
                            AsteroidCount++;
                    }
                if (AsteroidCount > Sum)
                {
                    WinningAsteroid = new Coordinate(c);
                    Sum = AsteroidCount;
                }
            }
            int Sum2 = 0;
            int AsteroidsKilled = 0;
            while (AsteroidsKilled<200)
            {
            SortedDictionary<double, Coordinate> AllTheAngles = new SortedDictionary<double, Coordinate>(); // cthulhu fhtagn
                foreach (Coordinate a in Asteroids)
                    if (WinningAsteroid != a)
                    {
                        bool BadAsteroid = false;
                        Coordinate OtherAstroid = new Coordinate(a);
                        Coordinate RelativePosition = a.RelativePosition(WinningAsteroid);
                        Coordinate Angle = GetAngle(RelativePosition);
                        if (!AllTheAngles.ContainsKey(EnumerateAngle(Angle)))
                            AllTheAngles.Add(EnumerateAngle(Angle), a);
                        else if (AllTheAngles[EnumerateAngle(Angle)].ManhattanDistance(WinningAsteroid) > a.ManhattanDistance(WinningAsteroid))
                            AllTheAngles[EnumerateAngle(Angle)] = a;
                    }
                foreach (KeyValuePair<double, Coordinate> a in AllTheAngles)
                {
                    AsteroidsKilled++;
                    if (AsteroidsKilled == 199)
                    {
                        Sum2 = a.Value.x * 100 + a.Value.y;
                        break;
                    }
                    Asteroids.Remove(a.Value);
                }
            }
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public double EnumerateAngle(Coordinate angle)
        {
            return Math.Atan2(angle.x,angle.y*-1);
        }
        public Coordinate GetAngle(Coordinate c)
        {
            int Biggest = Math.Max(Math.Abs(c.x), Math.Abs(c.y));
            Coordinate ReturnCoordinate = c;
            for (int i = Biggest; i >= 1; i--)
            {
                if (c.x % i == 0 && c.y % i == 0)
                {
                    ReturnCoordinate = new Coordinate((c.x / i) * -1, (c.y / i) * -1);
                    break;
                }
            }
            return ReturnCoordinate;
        }
    }
}
