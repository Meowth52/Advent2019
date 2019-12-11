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
            Dictionary<double, Coordinate> AllTheAngles = new Dictionary<double, Coordinate>();

            foreach (Coordinate a in Asteroids)
                if (WinningAsteroid != a)
                {
                    bool BadAsteroid = false;
                    Coordinate OtherAstroid = new Coordinate(a);
                    Coordinate RelativePosition = a.RelativePosition(WinningAsteroid);
                    Coordinate Angle = GetAngle(RelativePosition);
                    if (AllTheAngles.ContainsKey(EnumerateAngle(Angle)))
                        AllTheAngles.Add(EnumerateAngle(Angle), Angle);
                }
            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public double EnumerateAngle(Coordinate angle)
        {
            return Math.Tan(angle.x / angle.y);
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
