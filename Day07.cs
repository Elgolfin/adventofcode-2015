using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    /// <summary>
    /// --- Day 7: Some Assembly Required ---

//    This year, Santa brought little Bobby Tables a set of wires and bitwise logic gates! Unfortunately, little Bobby is a little under the recommended age range, and he needs help assembling the circuit.

//    Each wire has an identifier(some lowercase letters) and can carry a 16-bit signal(a number from 0 to 65535). A signal is provided to each wire by a gate, another wire, or some specific value.Each wire can only get a signal from one source, but can provide its signal to multiple destinations.A gate provides no signal until all of its inputs have a signal.

//The included instructions booklet describes how to connect the parts together: x AND y -> z means to connect wires x and y to an AND gate, and then connect its output to wire z.

//For example:

//    123 -> x means that the signal 123 is provided to wire x.
//    x AND y -> z means that the bitwise AND of wire x and wire y is provided to wire z.
//    p LSHIFT 2 -> q means that the value from wire p is left-shifted by 2 and then provided to wire q.
//    NOT e -> f means that the bitwise complement of the value from wire e is provided to wire f.

//Other possible gates include OR (bitwise OR) and RSHIFT(right-shift). If, for some reason, you'd like to emulate the circuit instead, almost all programming languages (for example, C, JavaScript, or Python) provide operators for these gates.

//For example, here is a simple circuit:

//123 -> x
//456 -> y
//x AND y -> d
//x OR y -> e
//x LSHIFT 2 -> f
//y RSHIFT 2 -> g
//NOT x -> h
//NOT y -> i

//After it is run, these are the signals on the wires:

//d: 72
//e: 507
//f: 492
//g: 114
//h: 65412
//i: 65079
//x: 123
//y: 456

//In little Bobby's kit's instructions booklet(provided as your puzzle input), what signal is ultimately provided to wire a?

//Your puzzle answer was 3176.

//The first half of this puzzle is complete! It provides one gold star: *
//--- Part Two ---

//Now, take the signal you got on wire a, override wire b to that signal, and reset the other wires (including wire a). What new signal is ultimately provided to wire a?

    /// </summary>
    public static class Day07
    {
        public static void SomeAssemblyRequired_Part1()
        {
            SomeAssemblyRequired("../../Day07.txt");
        }

        public static void SomeAssemblyRequired_Part2()
        {
            SomeAssemblyRequired("../../Day07.part2.txt");
        }

        private static void SomeAssemblyRequired(string filePath)
        {
            Circuit bobbyCircuit = new Circuit(new MyOperators().Operators);
            Dictionary<string, string> circuit1 = new Dictionary<string, string>();
            Dictionary<string, string> circuit2 = new Dictionary<string, string>();


            Queue<string> operations = new Queue<string>();

            using (StreamReader sr = new StreamReader(filePath))
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
