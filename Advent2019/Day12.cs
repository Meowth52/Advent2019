using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Advent2019
{
    public class Day12 : Day
    {
        List<List<int>> Instructions;
        public Day12(string _input) : base(_input)
        {
            Instructions = this.parseListOfIntegerLists(_input);
        }
        public override Tuple<string, string> getResult()
        {
            List<Moon> Moons = new List<Moon>();
            HashSet<string>[] VectorSets = { new HashSet<string>(), new HashSet<string>(), new HashSet<string>() };
            int[] Match = { 0, 0, 0 };
            string[] MatchString = { "", "", "" };
            foreach (List<int> l in Instructions)
            {
                Moons.Add(new Moon(l[0], l[1], l[2]));
            }
            for (int i = 0; i < 3; i++)
            {
                foreach (Moon m in Moons)
                    MatchString[i] += m.Dimensions[i].ToString() + m.Velocities[i].ToString();
            }
            int NrOfSteps = 1000000;
            for (int i = 0; i < NrOfSteps; i++)
            {
                foreach (Moon m in Moons)
                {
                    foreach (Moon o in Moons)
                    {
                        m.Gravity(o);
                    }
                }
                string[] VectorSet = { "", "", "" };
                foreach (Moon m in Moons)
                {
                    m.Move();
                    for (int n = 0; n < 3; n++)
                        VectorSet[n] += m.Dimensions[n].ToString() + m.Velocities[n].ToString();
                }
                for (int n = 0; n < 3; n++)
                    if (MatchString[n] == VectorSet[n])
                    {
                        if (Match[n] == 0)
                            Match[n] = i + 1;
                    }
            }
            int Sum = 0;
            foreach (Moon m in Moons)
            {
                Sum += m.Energy();
            }
            long Sum2 = determineLCM(determineLCM(Match[0], Match[1]), Match[2]);
            //for (long i = 1; i < 9223372036854775807; i++)
            //    if (i % Match[0] == 0 && i % Match[1] == 0 && i % Match[2] == 0)
            //    {

            //        Sum2 = i;
            //        break;
            //    }

            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public long determineLCM(long a, long b)
        {
            long num1 = Math.Max(a, b);
            long num2 = Math.Min(a, b);
            for (long i = 1; i < num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num1 * num2;
        }
    }
    public class Moon
    {
        public int[] Dimensions;
        public int[] Velocities;
        public Moon(int x, int y, int z)
        {
            Dimensions = new int[3];
            Dimensions[0] = x;
            Dimensions[1] = y;
            Dimensions[2] = z;
            Velocities = new int[3];
            Velocities[0] = 0;
            Velocities[1] = 0;
            Velocities[2] = 0;
        }
        public void Gravity(Moon that)
        {
            for (int i = 0; i < 3; i++)
                Velocities[i] += OneDimension(this.Dimensions[i], that.Dimensions[i]);
        }
        public void Move()
        {
            for (int i = 0; i < 3; i++)
                Dimensions[i] += Velocities[i];
        }
        public int OneDimension(int ThisPosition, int OtherPosition)
        {
            int ReturnValue = 0;
            if (ThisPosition < OtherPosition)
                ReturnValue = 1;
            else if (ThisPosition > OtherPosition)
                ReturnValue = -1;
            return ReturnValue;
        }
        public int Energy()
        {
            return (Math.Abs(Velocities[0]) + Math.Abs(Velocities[1]) + Math.Abs(Velocities[2])) * (Math.Abs(Dimensions[0]) + Math.Abs(Dimensions[1]) + Math.Abs(Dimensions[2]));
        }
        public string GetVectorString()
        {
            return Dimensions[0].ToString() + Dimensions[1].ToString() + Dimensions[2].ToString() + Velocities[0].ToString() + Velocities[1].ToString()+Velocities[2].ToString();
        }
    }
}
