using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day08 : Day
    {
        string Instructions;
        int X;
        int Y;
        public Day08(string _input) : base(_input)
        {
            Instructions = parseJustOneLine(_input);
            X = 25;
            Y = 6;
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            List<int[,]> Image = new List<int[,]>();
            int FewestZeroes = 1000000;
            int index = 0;
            for (int i = 0; i * X * Y < Instructions.Length; i++)
            {
                int Zeroes = 0;
                int Ones = 0;
                int Twoes = 0;
                Image.Add(new int[X, Y]);
                for (int y = 0; y < Y; y++) 
                {
                    for (int x = 0; x < X; x++)
                    {
                        int Pixel = Int32.Parse(Instructions[index].ToString());
                        Image.Last()[x, y] = Pixel;
                        switch (Pixel)
                        {
                            case 0:
                                Zeroes++;
                                break;
                            case 1:
                                Ones++;
                                break;
                            case 2:
                                Twoes++;
                                break;
                        }
                        index++;
                    }
                }
                if (Zeroes < FewestZeroes)
                {
                    FewestZeroes = Zeroes;
                    Sum = Ones * Twoes;
                }

            }
            string[,] FinalImage = new string[X, Y];
            for (int i = Image.Count - 1; i >= 0; i--)
            //for (int i = 0; i < Image.Count; i++)
            {
                for (int y = 0; y < Y; y++) 
                {
                    for (int x = 0; x < X; x++)
                    {
                        int Pixel = Image[i][x, y];
                        switch (Pixel)
                        {
                            case 0:
                                FinalImage[x, y] = "#";
                                break;
                            case 1:
                                FinalImage[x, y] = " ";
                                break;
                            case 2:
                                ;
                                break;
                        }
                    }
                }
            }
            string Sum2 = "\n";
            for (int y = 0; y < Y; y++) 
            {
                for (int x = 0; x < X; x++)
                {
                    Sum2 += FinalImage[x, y];
                }
                Sum2 += "\n";
            }
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
    }
}
