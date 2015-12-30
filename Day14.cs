using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace AdventOfCode2015
{
    public static class Day14
    {
        public static void ReindeerOlympics_Part1()
        {
            Race race = new Race(2503);
            race.LoadContestantsFromFile("../../Day14.txt");
            race.Run();
            Console.WriteLine(String.Format("The winner of the race is {0} with a traveled distance of {1} kms", race.Winner.Name, race.WinnerTraveledDistance));
            foreach (Reeinder reeinder in race.Contestants)
            {
                Console.WriteLine(String.Format("{0} - {1} kms [{2}]", reeinder.Name, reeinder.Flight(race.Duration), reeinder.ToString()));
            }
        }

    }

    public class Race
    {
        public List<Reeinder> Contestants = new List<Reeinder>();
        public int Duration; // in seconds
        public Reeinder Winner;
        public int WinnerTraveledDistance;
        public Race (int duration)
        {
            Duration = duration;
        }
        public void AddContestant (Reeinder reeinder)
        {
            Contestants.Add(reeinder);
        }

        public void LoadContestantsFromFile(string pathFile)
        {
            using (StreamReader sr = new StreamReader(pathFile))
            {
                while (sr.Peek() >= 0)
                {
                    string reeinderCharacteristics = sr.ReadLine();
                    Contestants.Add(new Reeinder(reeinderCharacteristics));
                }
            }
        }

        public void Run()
        {
            int leadDistance = 0;
            foreach (Reeinder reeinder in Contestants)
            {
                int reeinderTraveledDistance = reeinder.Flight(Duration);
                if (reeinderTraveledDistance >= leadDistance)
                {
                    leadDistance = reeinderTraveledDistance;
                    Winner = reeinder;
                }
            }
            WinnerTraveledDistance = leadDistance;
        }
    }

    public class Reeinder
    {
        public string Name { get; set; }
        public int FlySpeed { get; set; } // in km/s
        public int MaxFlyTime { get; set; } // in seconds
        public int RestingTime { get; set; } // in seconds
        public bool IsResting { get; set; }

        private string originalCharacteristics;

        public Reeinder(string characteristics)
        {
            LoadCharacteristicsFromString(characteristics);
        }

        private void LoadCharacteristicsFromString(string characteristics)
        {
            originalCharacteristics = characteristics;
            string pattern = @"^(?<name>[a-z]+) can fly (?<speed>[0-9]+) km\/s for (?<flying_time>[0-9]+) seconds, but then must rest for (?<resting_time>[0-9]+) seconds\.";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(characteristics);
            if (match.Success)
            {
                int fs;
                int mft;
                int rt;
                Int32.TryParse(match.Groups["speed"].Value, out fs);
                Int32.TryParse(match.Groups["flying_time"].Value, out mft);
                Int32.TryParse(match.Groups["resting_time"].Value, out rt);
                Name = match.Groups["name"].Value;
                FlySpeed = fs;
                MaxFlyTime = mft;
                RestingTime = rt;
                IsResting = false;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="duration">Duration of the flight in seconds</param>
        /// <returns></returns>
        public int Flight(int duration)
        {
            int fullSegments = duration / (MaxFlyTime + RestingTime);
            int fullSegmentsDistance = fullSegments * FlySpeed * MaxFlyTime;

            int lastSegment = duration % (MaxFlyTime + RestingTime);
            int lastSegmentDistance = lastSegment > MaxFlyTime ? MaxFlyTime * FlySpeed : lastSegment * FlySpeed;

            return fullSegmentsDistance + lastSegmentDistance;
        }

        public override string ToString()
        {
            return originalCharacteristics;
        }
    }
}
