using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day19
    {
        public static void MedicineForRudolph_Part1()
        {

        }

    }

    public class MoleculeReplacement
    {
        public string From;
        public string To;
        public string OriginalMolecule;
        public MoleculeReplacement(string molelculeToReplace, string from, string to)
        {
            OriginalMolecule = molelculeToReplace;
            From = from;
            To = to;
        }

        public List<string> GenerateNewMolecule ()
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
