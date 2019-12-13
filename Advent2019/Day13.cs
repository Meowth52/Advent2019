using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows;

namespace Advent2019
{
    public class Day13 : Day
    {
        int Sum = 0;
        List<long> Instructions;
        Dictionary<Coordinate, int> Screen;
        int GlobalMaxY;
        public Day13(string _input) : base(_input)
        {
            Instructions = this.parseListOfLong(_input);
            Screen = new Dictionary<Coordinate, int>();
        }
        public override Tuple<string, string> getResult()
        {
            Play(1);
            foreach (KeyValuePair<Coordinate, int> p in Screen)
            {
                if (p.Value == 2)
                    Sum++;
            }
            int bla = 0;
            Play(2);
            foreach (KeyValuePair<Coordinate, int> p in Screen)
            {
                if (p.Value == 2)
                    bla++;
            }
            int Sum2 = Screen[new Coordinate(-1, 0)];
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        string DrawScreen()
        {
            string ReturnValue = "\n";
            int MaxX = 0;
            int MaxY = 0;
            foreach (KeyValuePair<Coordinate, int> p in Screen)
            {
                if (p.Key.x > MaxX)
                    MaxX = p.Key.x;
                if (p.Key.y > MaxY)
                    MaxY = p.Key.y;
            }
            GlobalMaxY = MaxX;
            for (int y = 0; y <= MaxY; y++)
            {
                for (int x = 0; x <= MaxX; x++)
                {
                    switch (Screen[new Coordinate(x, y)])
                    {
                        case 0:
                            ReturnValue += " ";
                            break;
                        case 1:
                            ReturnValue += "#";
                            break;
                        case 2:
                            ReturnValue += "X";
                            break;
                        case 3:
                            ReturnValue += "_";
                            break;
                        case 4:
                            ReturnValue += "o";
                            break;
                        default:
                            break;
                    }
                }
                ReturnValue += "\n";
            }
            return ReturnValue;
        }
        public void Play(int Mode)
        {
            int LastKey = 0;
            if (Mode==2)
                Cheat();
            IntMachine Cabinet = new IntMachine(Instructions, 0);
            Cabinet.Day13Offset(Mode);
            int GetOut = -1;
            bool DicFull = false;
            while (GetOut == -1)
            {
                GetOut = Cabinet.Run();
                int x = (int)Cabinet.Outputs.Last();
                GetOut = Cabinet.Run();
                int y = (int)Cabinet.Outputs.Last();
                GetOut = Cabinet.Run();
                int Pixel = (int)Cabinet.Outputs.Last();
                Coordinate c = new Coordinate(x, y);
                if (Screen.ContainsKey(c))
                {
                    Screen[c] = Pixel;
                }
                else
                {
                    Screen.Add(c, Pixel);
                    DicFull = true;
                }
                if (Mode == 2 && DicFull&&GetOut==-1)
                {
                    LastKey = 0;
                    //Task.Delay(500).Wait();
                    char key = _mainView.KeyPresses.Last(); //Well this didnt work so.. cheat
                    switch (key)
                    {

                        case 'A':
                            LastKey = -1;
                            break;
                        case 'D':
                            LastKey = 1;
                            break;
                        default:
                            LastKey = 0;
                            break;
                    }
                    _mainView.OutText = DrawScreen();
                    Cabinet.Input= new List<int> {LastKey};
                }
            }
        }
        public void Cheat()
        {
            int TheOne = 0;
            for (int i = 0; i < Instructions.Count-5;i++)
            {
                if (Instructions[i] == 3 && Instructions[i - 1] == 0 && Instructions[i + 1] == 0)
                {
                    TheOne = i;
                }
            }
            int n = TheOne+1;
            while (Instructions[n]==0)
            {
                Instructions[n] = 3;
                n++;
            }
            n = TheOne - 1;
            while (Instructions[n] == 0)
            {
                Instructions[n] = 3;
                n--;
            }
        }
    }
}
