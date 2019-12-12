using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2019
{
    class IntMachine
    {
        Dictionary<long, long> Memory;
        public List<int> Input;
        public int InputIndex = 0;
        public List<long> Outputs;
        long Step = 0;
        long RelativeStep;
        public IntMachine(List<long> _memory, int _input)
        {
            Construct(_memory, _input);
        }
        public IntMachine(List<int> _memory, int _input)
        {
            List<long> LongMem = new List<long>();
            foreach (int i in _memory)
                LongMem.Add((long)i);
            Construct(LongMem, _input);
        }
        public void Construct(List<long> _memory, int _input)
        {
            Input = new List<int>();
            Input.Add(_input);
            Memory = new Dictionary<long, long>();
            for (int i = 0; i < _memory.Count; i++)
            {
                Memory.Add(i, _memory[i]);
            }
            Outputs = new List<long>();
        }
        public void Day2Offset(int Noun, int Verb)
        {
            Memory[1] = Noun;
            Memory[2] = Verb;
        }
        public int Run()
        {
            while (true)
            {
                for (int i = 1;i<4;i++)
                {
                    if (!Memory.ContainsKey(Step + i))
                    Memory.Add(Step + i, 0);
                }
                List<long> OpCode = this.IntToList(Memory[Step]);
                //if (Step == 20)
                //    ;
                for (int code = 2; code < 5; code++)
                {
                    if (Step + code + 1 > Memory.Count - 1)
                        break;
                    switch (OpCode[code])
                    {
                        case 0:
                            OpCode[code] = Memory[Step + code - 1];
                            break;
                        case 1:
                            OpCode[code] = Step + code - 1;
                            break;
                        case 2:
                            if (!Memory.ContainsKey(RelativeStep + Memory[Step + code - 1]))
                                Memory.Add(RelativeStep + Memory[Step + code - 1], 0);
                            OpCode[code] = RelativeStep + Memory[Step + code - 1];
                            break;
                        default:
                            return -1; //Doh
                            break;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    if (!Memory.ContainsKey(OpCode[i]))
                    {
                        Memory.Add(OpCode[i], 0);
                    }
                }
                int Case = (int)OpCode[0];
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
                        //if (InputIndex >= Input.Count)
                        //    InputIndex = Input.Count - 1;
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
                        if (Memory[OpCode[2]] != 0)
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
                        if (OpCode[1] == 9)
                            return (int)Memory[0];
                        RelativeStep += Memory[OpCode[2]];
                        Step += 2;
                        break;
                    default:
                        break; //Uh oh
                }
            }
            return (int)Memory[0];
        }
        public List<long> IntToList(long In)
        {
            string IntAsString = In.ToString("D5");
            List<long> ReturnValue = new List<long>();
            for (long c = IntAsString.Length - 1; c >= 0; c--)
            {
                long Next = 0;
                Int64.TryParse(IntAsString[(int)c].ToString(), out Next);
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
