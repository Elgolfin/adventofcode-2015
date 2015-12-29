using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{

    // TODO Refactoring needed:
    // - ExecuteOperation method should be in the Circuit class
    // - Parsing all the operations and put them in the right order should be in the Circuit class as well
    // - add a Get/SetWireValue method in the Circuit class to not manipulate directly the wires collection and so encapsulate the logic within those methods
    //
    /// <summary>
    /// --- Day 7: Some Assembly Required ---
    ///
    /// This year, Santa brought little Bobby Tables a set of wires and bitwise logic gates! Unfortunately, little Bobby is a little under the recommended age range, and he needs help assembling the circuit.
    ///
    /// Each wire has an identifier(some lowercase letters) and can carry a 16-bit signal(a number from 0 to 65535). A signal is provided to each wire by a gate, another wire, or some specific value.Each wire can only get a signal from one source, but can provide its signal to multiple destinations.A gate provides no signal until all of its inputs have a signal.
    ///
    /// The included instructions booklet describes how to connect the parts together: x AND y -> z means to connect wires x and y to an AND gate, and then connect its output to wire z.
    ///
    /// For example:
    ///
    ///    123 -> x means that the signal 123 is provided to wire x.
    ///    x AND y -> z means that the bitwise AND of wire x and wire y is provided to wire z.
    ///    p LSHIFT 2 -> q means that the value from wire p is left-shifted by 2 and then provided to wire q.
    ///    NOT e -> f means that the bitwise complement of the value from wire e is provided to wire f.
    ///
    /// Other possible gates include OR (bitwise OR) and RSHIFT(right-shift). If, for some reason, you'd like to emulate the circuit instead, almost all programming languages (for example, C, JavaScript, or Python) provide operators for these gates.
    ///
    /// For example, here is a simple circuit:
    ///
    ///     123 -> x
    ///     456 -> y
    ///     x AND y -> d
    ///     x OR y -> e
    ///     x LSHIFT 2 -> f
    ///     y RSHIFT 2 -> g
    ///     NOT x -> h
    ///     NOT y -> i
    ///
    /// After it is run, these are the signals on the wires:
    ///
    ///     d: 72
    ///     e: 507
    ///     f: 492
    ///     g: 114
    ///     h: 65412
    ///     i: 65079
    ///     x: 123
    ///     y: 456
    ///
    /// In little Bobby's kit's instructions booklet(provided as your puzzle input), what signal is ultimately provided to wire a?
    ///
    /// Your puzzle answer was 3176.
    ///
    /// The first half of this puzzle is complete! It provides one gold star: *
    /// --- Part Two ---
    ///
    /// Now, take the signal you got on wire a, override wire b to that signal, and reset the other wires (including wire a). What new signal is ultimately provided to wire a? 14710
    ///
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
            Dictionary<string, string> circuitOperations = new Dictionary<string, string>();

            Queue<string> operations = new Queue<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    string pattern = @"->\s*(?<wire>[a-z]+)$";
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        string wire = match.Groups["wire"].Value;
                        circuitOperations.Add(wire, line);
                    }
                }
            }

            List<string> wires = circuitOperations.Keys.ToList();
            IComparer<string> wireNameComparer = new WireNameComparer();
            wires.Sort(wireNameComparer);
            foreach (string wire in wires)
            {
                string line = circuitOperations[wire];
                ExecuteOperation(bobbyCircuit, line);
            }

            Console.WriteLine("The value of wire a is: {0}", bobbyCircuit.Wires["a"].Value);
        }



        // TODO add Unit Tests for each possible combinaison of operation
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

                a = GetCircuitInputWire(bobbyCircuit, match, "a1", "a2"); // a might be null
                b = GetCircuitInputWire(bobbyCircuit, match, "b1", "b2"); // b will never be null
                wire = match.Groups["result"].Value;
                op = match.Groups["operator"].Value;

                // The if statement below will handle operator with an unique input (at its right)
                // i.e. NOT h -> i
                if (!String.IsNullOrEmpty(op) && a == null)
                {
                    a = b;
                }

                if (!bobbyCircuit.Wires.ContainsKey(wire))
                {
                    bobbyCircuit.Wires.Add(wire, new Wire());
                    bobbyCircuit.Wires[wire].Name = wire;
                }

                // No op, it is a wire which points to another wire
                if (String.IsNullOrEmpty(op))
                {
                    bobbyCircuit.Wires[wire] = a;
                }
                else
                {
                    bobbyCircuit.Operators[op].InputA = a.Value;
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

            if (String.IsNullOrEmpty(match.Groups[name1].Value) && String.IsNullOrEmpty(match.Groups[name2].Value))
            { return null; }

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

    /// <summary>
    /// Implements a custom IComparer to sort alphabtically wire names as follow: a, b, c, ..., ab, etc.
    /// (Default sorting is alphabetical as follow: a, aa, ab, ..., b, ba, etc.)
    /// </summary>
    public class WireNameComparer : IComparer<string>
    {
        int IComparer<string>.Compare(string s1, string s2)
        {
            int compareToResult = 0;
            if (s1.Length < s2.Length)
            {
                compareToResult = - 1;
            }
            if (s1.Length > s2.Length)
            {
                compareToResult = 1;
            }
            if (s1.Length == s2.Length)
            {
                compareToResult = s1.CompareTo(s2);
            }
            return compareToResult;
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
