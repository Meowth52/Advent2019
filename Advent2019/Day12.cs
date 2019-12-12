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
            HashSet<string> VectorXSets = new HashSet<string>();
            HashSet<string> VectorYSets = new HashSet<string>();
            HashSet<string> VectorZSets = new HashSet<string>();
            long xs = 0;
            long ys = 0;
            long zs = 0;
            long xls = 0;
            long yls = 0;
            long zls = 0;
            foreach (List<int> l in Instructions)
            {
                Moons.Add(new Moon(l[0], l[1], l[2]));
            }
            long NrOfSteps = 1000000;
            for (long i = 0; i < NrOfSteps; i++)
            {
                foreach(Moon m in Moons)
                {
                    foreach(Moon o in Moons)
                    {
                        m.Gravity(o);
                    }
                }
                string VectorXSet = "";
                string VectorYSet = "";
                string VectorZSet = "";
                foreach (Moon m in Moons)
                {
                    m.Move();
                    VectorXSet = m.X.ToString();
                    VectorYSet = m.Y.ToString();
                    VectorZSet = m.Z.ToString();
                }
                if (!VectorXSets.Contains(VectorXSet))
                {
                    VectorXSets.Add(VectorXSet);
                }
                else
                {
                    xs =  i-xls;
                    xls = i;
                }
                if (!VectorYSets.Contains(VectorYSet))
                {
                    VectorYSets.Add(VectorYSet);
                }
                else
                {
                    ys = i-yls;
                    yls = i;
                }
                if (!VectorZSets.Contains(VectorZSet))
                {
                    VectorZSets.Add(VectorZSet);
                }
                else
                {
                    zs = i-zls;
                    zls = i;
                }
            }
            int Sum = 0;
            foreach (Moon m in Moons)
            {
                Sum += m.Energy();
            }
            int Sum2 = 0;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
    }
    public class Moon
    {
        public int X;
        public int Y;
        public int Z;
        int VX;
        int VY;
        int VZ;
        public Moon(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            VX = 0;
            VY = 0;
            VZ = 0;
        }
        public void Gravity(Moon that)
        {
            VX += OneDimension(this.X, that.X);
            VY += OneDimension(this.Y, that.Y);
            VZ += OneDimension(this.Z, that.Z);
        }
        public void Move()
        {
            X += VX;
            Y += VY;
            Z += VZ;
        }
        public int OneDimension(int ThisPosition, int OtherPosition)
        {
            int ReturnValue = 0;
            if (ThisPosition < OtherPosition)
                ReturnValue=1;
            else if (ThisPosition > OtherPosition)
                ReturnValue=-1;
            return ReturnValue;
        }
        public int Energy()
        {
            return (Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z)) * (Math.Abs(VX) + Math.Abs(VY) + Math.Abs(VZ));
        }
        public string GetVectorString()
        {
            return X.ToString() + Y.ToString() + Z.ToString();
        }
    }
}
