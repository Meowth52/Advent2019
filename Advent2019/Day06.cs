using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2019
{
    public class Day06 : Day
    {
        string[] Input;
        public Day06(string _input) : base(_input)
        {
            Input = this.parseStringArray(_input);
        }
        public override Tuple<string, string> getResult()
        {
            int Sum = 0;
            Dictionary<string, Planet> AllThePlanets = CleanPlanetList(Input);
            foreach(KeyValuePair< string, Planet> planet in AllThePlanets)
            {
                AllThePlanets[planet.Key].OrbitedPlanets.AddRange(FindOrbits(ref AllThePlanets, planet.Key));
                AllThePlanets[planet.Key].I = AllThePlanets[planet.Key].OrbitedPlanets.Count;
                Sum += AllThePlanets[planet.Key].I;
            }
            int FurhestFromCom = 0;
            string ClosestCommon = "";
            foreach(string s in AllThePlanets["YOU"].OrbitedPlanets)
            {
                if (AllThePlanets["SAN"].OrbitedPlanets.Contains(s) && AllThePlanets[s].I > FurhestFromCom)
                    ClosestCommon = s;
            }
            int Sum2 = (AllThePlanets["YOU"].I - AllThePlanets[ClosestCommon].I)+ (AllThePlanets["SAN"].I - AllThePlanets[ClosestCommon].I)-2;
            return Tuple.Create(Sum.ToString(), Sum2.ToString());
        }
        public Dictionary<string, Planet> CleanPlanetList(string[] _input)
        {
            Dictionary<string, Planet> ReturnValue = new Dictionary<string, Planet>();
            foreach (string s in _input)
            {
                string[] split = s.Split(')');
                ReturnValue.Add(split[1],new Planet(split[0], 0));
            }
            return ReturnValue;
        }

        public List<string> FindOrbits(ref Dictionary<string, Planet> AllThePlanets, string Planet)
        {
            List<string> ReturnValue = new List<string>();
            if (Planet != "COM")
            {
                ReturnValue.AddRange(FindOrbits(ref AllThePlanets, AllThePlanets[Planet].S));
                ReturnValue.Add(Planet);
            }
            return ReturnValue;
        }
        
    }
    public class Planet
    {
        public string S;
        public int I;
        public List<string> OrbitedPlanets;
        public Planet(string s, int i)
        {
            S = s;
            I = i;
            OrbitedPlanets = new List<string>();
        }
    }
}
