using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2019
{
    class IntMachine
    {
        Dictionary<int, int> Memory;
        int NumberOfInstructions;
        public IntMachine(List<int> _memory, int _numberOfInstructions)
        {
            NumberOfInstructions = _numberOfInstructions;
            Memory = new Dictionary<int, int>();
            for (int i = 0; i < _memory.Count; i++)
            {
                Memory.Add(i, _memory[i]);
            }
        }
        public void Day2Offset(int Noun, int Verb)
        {
            Memory[1] = Noun;
            Memory[2] = Verb;
        }
        public int Run()
        {
            bool GetOut = false;
            for (int i = 0; i < Memory.Count; i += NumberOfInstructions)
            {
                if (!Memory.ContainsKey(i + 2))
                    Memory.Add(i + 2, 0);
                long Case = Memory[i];
                switch (Case)
                {
                    case 1:
                        Memory[Memory[i + 3]] = Memory[Memory[i + 1]] + Memory[Memory[i + 2]];
                        break;
                    case 2:
                        Memory[Memory[i + 3]] = Memory[Memory[i + 1]] * Memory[Memory[i + 2]];
                        break;
                    case 99:
                        return Memory[0];
                        break;
                    default:
                        break;
                }
                if (GetOut)
                    break;
            }
            return Memory[0];

        }
    }
}
