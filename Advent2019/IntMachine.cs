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
        List<int> Input;
        int InputIndex = 0;
        public List<int> Outputs;
        int Step = 0;
        public IntMachine(List<int> _memory, int _input)
        {
            Input = new List<int>();
            Input.Add(_input);
            Memory = new Dictionary<int, int>();
            for (int i = 0; i < _memory.Count; i++)
            {
                Memory.Add(i, _memory[i]);
            }
            Outputs = new List<int>();
        }
        public void Day2Offset(int Noun, int Verb)
        {
            Memory[1] = Noun;
            Memory[2] = Verb;
        }
        public int Run()
        {
            while(true)
            {
                if (!Memory.ContainsKey(Step + 2))
                    Memory.Add(Step + 2, 0);
                List<int> OpCode = this.IntToList(Memory[Step]);
                //if (Step == 20)
                //    ;
                for(int code = 2; code <5; code++)
                {
                    if (Step + code + 1 > Memory.Count - 1)
                        break;
                    switch (OpCode[code])
                    {
                        case 0:
                            OpCode[code] = Memory[Step+code-1];
                            break;
                        case 1:
                            OpCode[code] = Step+code-1;
                            break;
                        default:
                            return -1; //Doh
                            break;
                    }
                }
                int Case = OpCode[0];
                switch (Case)
                {
                    case 1:
                        Memory[OpCode[4]] = Memory[OpCode[2]] + Memory[OpCode[3]];
                        Step += 4;
                        break;
                    case 2:
                        Memory[OpCode[4]] = Memory[OpCode[2]] * Memory[OpCode[3]];
                        Step += 4;
                        break;
                    case 3:
                        Memory[OpCode[2]] = Input[InputIndex];
                        InputIndex++;
                        Step += 2;
                        break;
                    case 4:
                        Outputs.Add(Memory[OpCode[2]]);
                        Step += 2;
                        return -1;
                        break;
                    case 5:
                        if(Memory[OpCode[2]] != 0)
                            Step = Memory[OpCode[3]];
                        else
                            Step += 3;
                        break;
                    case 6:
                        if (Memory[OpCode[2]] == 0)
                            Step = Memory[OpCode[3]];
                        else
                            Step += 3;
                        break;
                    case 7:
                        if (Memory[OpCode[2]] < Memory[OpCode[3]])
                            Memory[OpCode[4]] = 1;
                        else Memory[OpCode[4]] = 0;
                        Step += 4;
                        break;
                    case 8:
                        if (Memory[OpCode[2]] == Memory[OpCode[3]])
                            Memory[OpCode[4]] = 1;
                        else Memory[OpCode[4]] = 0;
                        Step += 4;
                        break;
                    case 9:
                        return Memory[0];
                        break;
                    default:
                        break; //Uh oh
                }
            }
            return Memory[0];
        }
        public List<int> IntToList(int In)
        {
            string IntAsString = In.ToString("D5");
            List<int> ReturnValue = new List<int>();
            for(int c = IntAsString.Length-1;c>=0;c--)
            {
                int Next = 0;
                Int32.TryParse(IntAsString[c].ToString(), out Next);
                ReturnValue.Add(Next);
            }
            return ReturnValue;
        }
        public void AddArgument(int i)
        {
            Input.Add(i);
        }
    }
}
