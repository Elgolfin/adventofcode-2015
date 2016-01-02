using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace AdventOfCode2015
{
    public class Day19
    {
        public static void MedicineForRudolph_Part1()
        {
            string originalMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
            MoleculeConstructionMachine machine = new MoleculeConstructionMachine(originalMolecule);
            using (StreamReader sr = new StreamReader("../../Day19.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string input = sr.ReadLine();
                    string from = String.Empty;
                    string to = String.Empty;
                    string pattern = @"^(?<from>[a-z]+) => (?<to>[a-z]+)$";
                    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    Match match = regex.Match(input);
                    if (match.Success)
                    {
                        from = match.Groups["from"].Value;
                        to = match.Groups["to"].Value;
                        MoleculeReplacement mr = new MoleculeReplacement(originalMolecule, from, to);
                        machine.AddMoleculeReplacement(mr);
                    }
                }
                int results = machine.Calibrate();
                Console.WriteLine(String.Format("{0} distinct molecules can be created.", results));
            }
        }

    }

    public class MoleculeConstructionMachine
    {
        List<MoleculeReplacement> replacements = new List<MoleculeReplacement>();
        List<string> possiblesMoleculesReplacements = new List<string>();
        public string OriginalMolecule;

        public MoleculeConstructionMachine(string originalMolecule)
        {
            OriginalMolecule = originalMolecule;
        }

        public void AddMoleculeReplacement (MoleculeReplacement mr)
        {
            if (!replacements.Contains(mr))
            {
                replacements.Add(mr);
            }
        }

        public int Calibrate()
        {
            foreach (MoleculeReplacement mr in replacements)
            {
                possiblesMoleculesReplacements.AddRange(mr.GenerateNewMolecules());
            }
            List<string> tmp = new List<string>();
            tmp.AddRange(possiblesMoleculesReplacements.Distinct());
            possiblesMoleculesReplacements = tmp;
            return possiblesMoleculesReplacements.Count;
        }
    }

    public class MoleculeReplacement
    {
        public string From;
        public string To;
        public string OriginalMolecule;
        public List<string> ReplacedPossibleMolecules = new List<string>();
        public MoleculeReplacement(string molelculeToReplace, string from, string to)
        {
            OriginalMolecule = molelculeToReplace;
            From = from;
            To = to;
        }

        public List<string> GenerateNewMolecules ()
        {
            string pattern = String.Format("({0})", From);
            List<string> replacedMolecules = new List<string>();
            foreach (Match m in Regex.Matches(OriginalMolecule, pattern))
            {
                StringBuilder newString = new StringBuilder();
                newString.Append(OriginalMolecule.Substring(0, m.Index));
                newString.Append(To);
                newString.Append(OriginalMolecule.Substring(m.Index + From.Length));
                if (!replacedMolecules.Contains(newString.ToString()))
                {
                    replacedMolecules.Add(newString.ToString());
                }
            }
            return replacedMolecules;
        }
    }
}
