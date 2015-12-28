using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public static class Day07
    {

        public static void SomeAssemblyRequired_Part1()
        {
            Circuit bobbyCircuit = new Circuit(new MyOperators().Operators);
            Dictionary<string, string> circuit1 = new Dictionary<string, string>();
            Dictionary<string, string> circuit2 = new Dictionary<string, string>();


            Queue<string> operations = new Queue<string>();

            using (StreamReader sr = new StreamReader("../../Day07.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    string pattern = @"->\s*(?<wire>[a-z])$";
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        string wire = match.Groups["wire"].Value;
                        circuit1.Add(wire, line);
                    }
                    else
                    {
                        pattern = @"->\s*(?<wire>[a-z][a-z])$";
                        regex = new Regex(pattern);
                        match = regex.Match(line);
                        if (match.Success)
                        {
                            string wire = match.Groups["wire"].Value;
                            circuit2.Add(wire, line);
                        }
                    }
                }
            }

            // TODO build a custom comparer to avoid doing two sort (one for one letter, and the other one for two letters)
            List<string> wires1 = circuit1.Keys.ToList();
            List<string> wires2 = circuit2.Keys.ToList();
            wires1.Sort();
            foreach (string wire in wires1)
            {
                string line = circuit1[wire];
                ExecuteOperation(bobbyCircuit, line);
            }
            wires2.Sort();
            foreach (string wire in wires2)
            {

                string line = circuit2[wire];
                ExecuteOperation(bobbyCircuit, line);
            }



                Console.WriteLine("The value of wire a is: {0}", bobbyCircuit.Wires["a"].Value);
        }

        private static void ExecuteOperation (Circuit bobbyCircuit, string line)
        {
            string pattern = @"((?<a1>[0-9]+)|(?<a2>[a-z]+))?\s*(?<operator>AND|OR|RSHIFT|LSHIFT|NOT)?\s*((?<b1>[0-9]+)|(?<b2>[a-z]+))?\s*->\s*(?<result>[a-z]+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(line);
            if (match.Success)
            {
                string op;
                string wire;
                Wire a;
                Wire b;

                a = GetCircuitInputWire(bobbyCircuit, match, "a1", "a2");
                b = GetCircuitInputWire(bobbyCircuit, match, "b1", "b2");
                wire = match.Groups["result"].Value;
                op = match.Groups["operator"].Value;

                if (!bobbyCircuit.Wires.ContainsKey(wire))
                {
                    bobbyCircuit.Wires.Add(wire, new Wire());
                    bobbyCircuit.Wires[wire].Name = wire;
                }

                // No op, it is a pointer
                if (String.IsNullOrEmpty(op))
                {
                    bobbyCircuit.Wires[wire] = a;
                }
                else
                {
                    bobbyCircuit.Operators[op].InputA = a.Value;
                    // VERY UGLY!
                    if (op == "NOT") {
                        bobbyCircuit.Operators[op].InputA = b.Value;
                    }
                    bobbyCircuit.Operators[op].InputB = b.Value;
                    bobbyCircuit.Wires[wire].Value = bobbyCircuit.Operators[op].Execute();
                }

            }
        }

        private static Wire GetCircuitInputWire (Circuit bobbyCircuit, Match match, string name1, string name2)
        {
            Wire input;
            string s;
            uint u;
            UInt32.TryParse(match.Groups[name1].Value, out u);
            s = match.Groups[name2].Value;
            if (!String.IsNullOrEmpty(s))
            {
                if (!bobbyCircuit.Wires.ContainsKey(s))
                {
                    bobbyCircuit.Wires.Add(s, new Wire());
                    bobbyCircuit.Wires[s].Value = u;
                    bobbyCircuit.Wires[s].Name = s;
                }
                input = bobbyCircuit.Wires[s];
            }
            else
            {
                input = new Wire();
                input.Value = u;
                input.Name = s;
            }
            return input;
        }

    }

    public class MyOperators
    {
        public Dictionary<string, Gate> Operators = new Dictionary<string, Gate>();
        public MyOperators()
        {
            Operators.Add("AND", new Gate_AND());
            Operators.Add("OR", new Gate_OR());
            Operators.Add("NOT", new Gate_NOT());
            Operators.Add("LSHIFT", new Gate_LSHIFT());
            Operators.Add("RSHIFT", new Gate_RSHIFT());
        }
    }

    public class Wire
    {
        public string Name
        {
            get; set;
        }
        public uint Value
        {
            get; set;
        }
    }

    public class Circuit
    {
        public Dictionary<string, Wire> Wires = new Dictionary<string, Wire>();
        public Dictionary<string, Gate> Operators = new Dictionary<string, Gate>();
        public List<string> Operations = new List<string>();
        public Circuit (Dictionary<string, Gate> operators)
        {
            Operators = operators;
        }

        public void LoadOperationsFromFile(string listingPath)
        {
            using (StreamReader sr = new StreamReader(listingPath))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    Operations.Add(line);
                }
            }
        }

        public void LoadOperationsFromString(string listing)
        {
            foreach (var line in listing.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                Operations.Add(line);
            }
        }

        public void Run()
        {

        }

    }

    public abstract class Gate
    {
        public uint InputA
        {
            get; set;
        }
        public uint InputB
        {
            get; set;
        }

        public uint Output { get; set; }

        public Gate() { }

        public Gate(uint a, uint b)
        {
            InputA = a;
            InputB = b;
        }

        public Gate(uint a)
        {
            InputA = a;
        }

        public abstract uint Execute();
    }

    public class Gate_AND : Gate
    {
        public Gate_AND() { }
        public Gate_AND (uint a, uint b)
        {
            InputA = a;
            InputB = b;
        }

        public override uint Execute()
        {
            return InputA & InputB;
        }

    }

    public class Gate_OR : Gate
    {
        public Gate_OR() { }
        public Gate_OR(uint a, uint b)
        {
            InputA = a;
            InputB = b;
        }

        public override uint Execute()
        {
            return InputA | InputB;
        }

    }

    public class Gate_RSHIFT : Gate
    {
        public Gate_RSHIFT() { }
        public Gate_RSHIFT(uint a, uint b)
        {
            InputA = a;
            InputB = b;
        }

        public override uint Execute()
        {
            return (InputA >> (int)InputB) & 0xFFFF; // Limit operator to 16 lower bits
        }

    }

    public class Gate_LSHIFT : Gate
    {
        public Gate_LSHIFT() { }
        public Gate_LSHIFT(uint a, uint b)
        {
            InputA = a;
            InputB = b;
        }

        public override uint Execute()
        {
            return (InputA << (int)InputB) & 0xFFFF; // Limit operator to 16 lower bits
        }

    }

    public class Gate_NOT : Gate
    {
        public Gate_NOT() { }
        public Gate_NOT(uint a)
        {
            InputA = a;
        }

        public override uint Execute()
        {
            return ~InputA & 0xFFFF; // Limit operator to 16 lower bits
        }

    }
}
