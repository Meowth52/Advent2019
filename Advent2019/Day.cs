using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public abstract class Day
    {
        public MainView _mainView;
        public Day(string _input)
        {

        }
        public void SetMainView(MainView mainView)
        {
            this._mainView = mainView;
        }
        public abstract Tuple<string, string> getResult();
        public abstract string getPartOne();
        public abstract string getPartTwo();
        public string parseJustOneLine(string input)
        {
            return input.Replace("\r\n", "");
        }
        public string[] parseStringArray(string input)
        {
            string Input = input.Replace("\r\n", "_");
            return Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public List<string[]> parseListOfStringArrays(string input)
        {
            List<string[]> ReturnList = new List<string[]>();
            string Input = input.Replace("\r\n", "_");
            string[] RawInstructions = Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in RawInstructions)
            {
                ReturnList.Add(s.Split(' '));
            }
            return ReturnList;
        }
        public List<List<int>> parseListOfIntegerLists(string input)
        {
            List<List<int>> ReturnList = new List<List<int>>();
            string Input = input.Replace("\r\n", "_");
            string[] RawInstructions = Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in RawInstructions)
            {
                MatchCollection Matches = Regex.Matches(s, @"-?\d+");
                List<int> IntList = new List<int>();
                foreach (Match m in Matches)
                {
                    int ParseInt = 0;
                    Int32.TryParse(m.Value, out ParseInt);
                    IntList.Add(ParseInt);
                }
                ReturnList.Add(IntList);
            }
            return ReturnList;
        }
    }
}
