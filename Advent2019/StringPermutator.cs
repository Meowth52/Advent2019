using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2019
{
    class StringPermutator
    //Stolen from the internets
    {
        List<string> ForFuckSake;
        public StringPermutator()
        {
            ForFuckSake = new List<string>();
        }
        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public static void GetPer(char[] CharArray, ref List<string> ResultList)
        {
            int x = CharArray.Length - 1;
            GetPer(CharArray, 0, x, ref ResultList);
        }

        private static void GetPer(char[] CharArray, int RecursionDepth, int MaxDepth, ref List<string> ResultList)
        {
            if (RecursionDepth == MaxDepth)
            {
                string s = "";
                foreach (char c in CharArray)
                    s += c;
                ResultList.Add(s);
                Console.Write(CharArray);
            }
            else
                for (int i = RecursionDepth; i <= MaxDepth; i++)
                {
                    Swap(ref CharArray[RecursionDepth], ref CharArray[i]);
                    GetPer(CharArray, RecursionDepth + 1, MaxDepth, ref ResultList);
                    Swap(ref CharArray[RecursionDepth], ref CharArray[i]);
                }
        }

        public List<string> GetStrings(string str)
        {
            char[] arr = str.ToCharArray();
            GetPer(arr, ref ForFuckSake);
            return ForFuckSake;
        }
    }
}
