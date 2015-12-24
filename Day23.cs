using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    /// <summary>
    /// --- Day 23: Opening the Turing Lock ---
    ///
    /// Little Jane Marie just got her very first computer for Christmas from some unknown benefactor.It comes with instructions and an example program, but the computer itself seems to be malfunctioning.She's curious what the program does, and would like you to help her run it.
    ///
    /// The manual explains that the computer supports two registers and six instructions(truly, it goes on to remind the reader, a state-of-the-art technology). The registers are named a and b, can hold any non-negative integer, and begin with a value of 0. The instructions are as follows:
    ///
    ///    hlf r sets register r to half its current value, then continues with the next instruction.
    ///    tpl r sets register r to triple its current value, then continues with the next instruction.
    ///    inc r increments register r, adding 1 to it, then continues with the next instruction.
    ///    jmp offset is a jump; it continues with the instruction offset away relative to itself.
    ///    jie r, offset is like jmp, but only jumps if register r is even ("jump if even").
    ///    jio r, offset is like jmp, but only jumps if register r is 1 ("jump if one", not odd).
    ///
    /// All three jump instructions work with an offset relative to that instruction.The offset is always written with a prefix + or - to indicate the direction of the jump (forward or backward, respectively). For example, jmp +1 would simply continue with the next instruction, while jmp +0 would continuously jump back to itself forever.
    ///
    /// The program exits when it tries to run an instruction beyond the ones defined.
    ///
    /// For example, this program sets a to 2, because the jio instruction causes it to skip the tpl instruction:
    ///
    ///     inc a
    ///     jio a, +2
    ///     tpl a
    ///     inc a
    ///
    ///
    /// What is the value in register b when the program in your puzzle input is finished executing?
    ///
    /// --- Part Two ---
    ///
    /// The unknown benefactor is very thankful for releasi-- er, helping little Jane Marie with her computer.Definitely not to distract you, what is the value in register b after the program is finished executing if register a starts as 1 instead?
    /// </summary>
    public static class Day23
    {
        public static void OpeningTheTuringLock_Part1()
        {
            Computer turingMachine = new Computer();
            turingMachine.LoadProgramFromFile("../../Day23.txt");
            turingMachine.Run();
            Console.WriteLine(String.Format("After finishing excuting the program, the value of the register B is {0}", turingMachine.RegisterB.ToString()));
        }

        public static void OpeningTheTuringLock_Part2()
        {
            Computer turingMachine = new Computer(1);
            turingMachine.LoadProgramFromFile("../../Day23.txt");
            turingMachine.Run();
            Console.WriteLine(String.Format("After finishing excuting the program, the value of the register B is {0} (Register A has started to 1 instead of 0)", turingMachine.RegisterB.ToString()));
        }
    }

    public class Computer {

        public Dictionary<int,string> Program = new Dictionary<int, string>();
        public ProgramCursor Cursor
        {
            get; private set;
        }
        private Dictionary<string, Instruction> instructions = new Dictionary<string, Instruction>();
        private Dictionary<string, Register> registers = new Dictionary<string, Register>();

        public int RegisterA
        {
            get { return registers["a"].Value;  }
            set { }
        }

        public int RegisterB
        {
            get { return registers["b"].Value; }
            set { }
        }
        public Computer()
        {
            Initialize();
        }

        public Computer(int registerAValue)
        {
            Initialize();
            registers["a"].Value = 1;
        }

        private void Initialize ()
        {
            // Should use depedency injection to inject a collection of registers to the computer class
            registers.Add("a", new Register("a"));
            registers.Add("b", new Register("b"));
            // Should use depedency injection to inject a set of instructions to the computer class
            // So when we would like to add a new instruction to the computer, no need to modify the Computer class
            instructions.Add("hlf", new Instruction_HLF());
            instructions.Add("inc", new Instruction_INC());
            instructions.Add("tpl", new Instruction_TPL());
            instructions.Add("jmp", new Instruction_JMP());
            instructions.Add("jie", new Instruction_JIE());
            instructions.Add("jio", new Instruction_JIO());

            Cursor = new ProgramCursor();
        }

        public void LoadProgramFromFile (string listingPath)
        {
            using (StreamReader sr = new StreamReader(listingPath))
            {
                int cpt = 0;
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    Program.Add(cpt++, line);
                }
            }
        }

        public void LoadProgramFromString(string listing)
        {
            Program = new Dictionary<int, string>();
            int cpt = 0;
            foreach (var programLine in listing.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                Program.Add(cpt++, programLine);
            }
        }

        public void Reset()
        {
            registers["a"].Value = 0;
            registers["b"].Value = 0;
            Cursor.Position = 0; ;
        }

        public void Run()
        {
            while (Program.ContainsKey(Cursor.Position)) {
                string programLine = Program[Cursor.Position]; 
                string code = programLine.Substring(0,3);
                Register register = GetRegisterFromProgramLine(programLine);
                int offset = GetJumpOffsetFromProgramLine(programLine);
                instructions[code].Execute(register, Cursor, offset);
            }
        }

        private Register GetRegisterFromProgramLine (string programLine)
        {
            Regex regex = new Regex(@"[a-z]{3} ([ab])");
            Match match = regex.Match(programLine);
            if (match.Success)
            {
                return registers[match.Groups[1].Value];
            }

            return null; // We should handle an error at this point and not return null
        }

        private int GetJumpOffsetFromProgramLine(string programLine)
        {
            int offset = 0;
            Regex regex = new Regex(@"[a-z]{3}( [ab],)? \+?(-?[0-9]+)");
            Match match = regex.Match(programLine);
            if (match.Success)
            {
                Int32.TryParse(match.Groups[2].Value, out offset);
            }

            return offset;
        }
    }

    public class Register
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public Register(string name)
        {
            Name = name;
            Value = 0;
        }
    }

    public class ProgramCursor
    {
        public int Position { get; set; }
    }

    public abstract class Instruction
    {
        public string Name;
        public string Help;
        public string Code;
        public abstract void Execute(Register register, ProgramCursor cursor, int offset);
    }

    public class Instruction_HLF : Instruction
    {
        public Instruction_HLF()
        {
            Name = "Half";
            Help = "Sets register r to half its current value, then continues with the next instruction.";
            Code = "hlf";
        }
        public override void Execute(Register register, ProgramCursor cursor, int offset)
        {
            register.Value /= 2;
            cursor.Position++;
        }
    }

    public class Instruction_INC : Instruction
    {
        public Instruction_INC()
        {
            Name = "Increment";
            Help = "Increments register r, adding 1 to it, then continues with the next instruction.";
            Code = "inc";
        }
        public override void Execute(Register register, ProgramCursor cursor, int offset)
        {
            register.Value++;
            cursor.Position++;
        }
    }

    public class Instruction_TPL : Instruction
    {
        public Instruction_TPL()
        {
            Name = "Triple";
            Help = "Sets register r to triple its current value, then continues with the next instruction.";
            Code = "tpl";
        }
        public override void Execute(Register register, ProgramCursor cursor, int offset)
        {
            register.Value *= 3;
            cursor.Position++;
        }
    }

    public class Instruction_JMP : Instruction
    {
        public Instruction_JMP()
        {
            Name = "Jump";
            Help = "Is a jump; it continues with the instruction offset away relative to itself.";
            Code = "jmp";
        }
        public override void Execute(Register register, ProgramCursor cursor, int offset)
        {
            cursor.Position += offset;
        }
    }

    public class Instruction_JIE : Instruction
    {
        public Instruction_JIE()
        {
            Name = "Jump If Even";
            Help = "Is like jmp, but only jumps if register r is even (\"jump if even\").";
            Code = "jie";
        }
        public override void Execute(Register register, ProgramCursor cursor, int offset)
        {
            if (register.Value % 2 == 0) { 
                cursor.Position += offset;
            } else
            {
                cursor.Position++;
            }
        }
    }

    public class Instruction_JIO : Instruction
    {
        public Instruction_JIO()
        {
            Name = "Jump If One";
            Help = "Is like jmp, but only jumps if register r is even (\"jump if even\").";
            Code = "jio";
        }
        public override void Execute(Register register, ProgramCursor cursor, int offset)
        {
            if (register.Value == 1)
            {
                cursor.Position += offset;
            }
            else
            {
                cursor.Position++;
            }
        }
    }
}
