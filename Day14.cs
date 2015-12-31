using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace AdventOfCode2015
{
    /// <summary>
    /// --- Day 14: Reindeer Olympics ---
    ///
    /// This year is the Reindeer Olympics! Reindeer can fly at high speeds, but must rest occasionally to recover their energy.Santa would like to know which of his reindeer is fastest, and so he has them race.
    ///
    /// Reindeer can only either be flying (always at their top speed) or resting(not moving at all), and always spend whole seconds in either state.
    ///
    /// For example, suppose you have the following Reindeer:
    ///
    ///     Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
    ///     Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
    ///
    /// After one second, Comet has gone 14 km, while Dancer has gone 16 km.After ten seconds, Comet has gone 140 km, while Dancer has gone 160 km.On the eleventh second, Comet begins resting (staying at 140 km), and Dancer continues on for a total distance of 176 km.On the 12th second, both reindeer are resting.They continue to rest until the 138th second, when Comet flies for another ten seconds.On the 174th second, Dancer flies for another 11 seconds.
    ///
    /// In this example, after the 1000th second, both reindeer are resting, and Comet is in the lead at 1120 km (poor Dancer has only gotten 1056 km by that point). So, in this situation, Comet would win (if the race ended at 1000 seconds).
    ///
    /// Given the descriptions of each reindeer (in your puzzle input), after exactly 2503 seconds, what distance has the winning reindeer traveled? 2655
    ///
    /// --- Part Two ---
    ///
    /// Seeing how reindeer move in bursts, Santa decides he's not pleased with the old scoring system.
    ///
    /// Instead, at the end of each second, he awards one point to the reindeer currently in the lead. (If there are multiple reindeer tied for the lead, they each get one point.) He keeps the traditional 2503 second time limit, of course, as doing otherwise would be entirely ridiculous.
    ///
    /// Given the example reindeer from above, after the first second, Dancer is in the lead and gets one point. He stays in the lead until several seconds into Comet's second burst: after the 140th second, Comet pulls into the lead and gets his first point. Of course, since Dancer had been in the lead for the 139 seconds before that, he has accumulated 139 points by the 140th second.
    ///
    /// After the 1000th second, Dancer has accumulated 689 points, while poor Comet, our old champion, only has 312.So, with the new scoring system, Dancer would win(if the race ended at 1000 seconds).
    ///
    /// Again given the descriptions of each reindeer(in your puzzle input), after exactly 2503 seconds, how many points does the winning reindeer have? 1059
    ///
    /// </summary>
    public static class Day14
    {
        public static void ReindeerOlympics_Part1()
        {
            Race race = new Race(2503);
            race.Type = Race.WinningMethod.TraveledDistance;
            race.LoadContestantsFromFile("../../Day14.txt");
            race.Run();
            Console.WriteLine(String.Format("{0} is the winner of the race and has traveled {1} kms.", race.GetWinnerNames(), race.GetWinnerTraveledLength()));
            foreach (Reeinder reeinder in race.Contestants.Keys)
            {
                Console.WriteLine(String.Format("{0} - {1} kms [{2}]", reeinder.Name, race.Contestants[reeinder].TraveledDistance, reeinder.ToString()));
            }
            Console.WriteLine(String.Empty);
            Console.WriteLine("***********************************");
            Console.WriteLine(String.Empty);
        }
        public static void ReindeerOlympics_Part2()
        {
            Race race = new Race(2503);
            race.LoadContestantsFromFile("../../Day14.txt");
            race.Run();
            Console.WriteLine(String.Format("{0} is the winner of the race and has a total of {1} leading seconds.", race.GetWinnerNames(), race.GetWinnerTotalLeadingSeconds()));
            foreach (Reeinder reeinder in race.Contestants.Keys)
            {
                Console.WriteLine(String.Format("{0} - total of {1} leading seconds [{2}]", reeinder.Name, race.Contestants[reeinder].TotalLeadingSeconds, reeinder.ToString()));
            }
        }

    }

    public class Result
    {
        public int TraveledDistance;
        public int TotalLeadingSeconds;

        public Result()
        {
            TraveledDistance = 0;
            TotalLeadingSeconds = 0;
        }
    }

    // TODO build a Custom Comparer to sort list of Contestants by traveled distance or total leading seconds
    public class Race
    {
        public int Duration; /// in seconds
        private List<Reeinder> winners = new List<Reeinder>();
        public Dictionary<Reeinder, Result> Contestants = new Dictionary<Reeinder, Result>();
        public WinningMethod Type;


        public enum WinningMethod  {
            TraveledDistance,
            TotalLeadingSeconds
        }

        public Race (int duration)
        {
            Duration = duration;
            Type = WinningMethod.TotalLeadingSeconds;
        }
        public void AddContestant (Reeinder reeinder)
        {
            Contestants.Add(reeinder, new Result());
        }

        public void LoadContestantsFromFile(string pathFile)
        {
            using (StreamReader sr = new StreamReader(pathFile))
            {
                while (sr.Peek() >= 0)
                {
                    string reeinderCharacteristics = sr.ReadLine();
                    Reeinder reeinder = new Reeinder(reeinderCharacteristics);
                    Contestants.Add(reeinder, new Result());
                }
            }
        }

        public void Reset()
        {
            winners = new List<Reeinder>();
            List<Reeinder> reeinders = Contestants.Keys.ToList();
            foreach (Reeinder reeinder in reeinders)
            {
                Contestants[reeinder] = new Result();
            }
        }

        public void Run()
        {
            Reset();
            Dictionary<Reeinder, Result> tempPoints = new Dictionary<Reeinder, Result>();
            tempPoints = Contestants;
            for (int seconds = 1; seconds <= Duration; seconds++)
            {
                Run(seconds);
            }
            SetWinners();
        }

        public int GetWinnerTraveledLength()
        {
            return winners[0].Flight(Duration);
        }

        public int GetWinnerTotalLeadingSeconds()
        {
            return Contestants[winners[0]].TotalLeadingSeconds;
        }

        public string GetWinnerNames()
        {
            StringBuilder winnerNames = new StringBuilder();
            foreach (Reeinder reeinder in winners)
            {
                winnerNames.Append(reeinder.Name);
                winnerNames.Append(", ");
            }
            return winnerNames.ToString().Remove(winnerNames.ToString().LastIndexOf(", "));
        }

        private void SetWinners()
        {
            int methodPoints = 0;
            List<Result> reeinderPoints = Contestants.Values.ToList();
            foreach (Result result in reeinderPoints)
            {
                int currentReeinderPoints = result.TotalLeadingSeconds;
                if (Type == WinningMethod.TraveledDistance)
                {
                    currentReeinderPoints = result.TraveledDistance;
                }

                if (currentReeinderPoints > methodPoints)
                {
                    methodPoints = currentReeinderPoints;
                }
            }
            foreach (KeyValuePair<Reeinder, Result> kvp in Contestants)
            {
                int currentReeinderPoints = kvp.Value.TotalLeadingSeconds;
                if (Type == WinningMethod.TraveledDistance)
                {
                    currentReeinderPoints = kvp.Value.TraveledDistance;
                }
                if (currentReeinderPoints == methodPoints)
                {
                    winners.Add(kvp.Key);
                }
            }
        }

        public void Run(int duration)
        {
            int leadDistance = 0;
            Dictionary<Reeinder, Result> contestantTmpScores = new Dictionary<Reeinder, Result>();
            List<Reeinder> reeinders = Contestants.Keys.ToList();
            foreach (Reeinder reeinder in reeinders)
            {
                int reeinderTraveledDistance = reeinder.Flight(duration);
                Result r = new Result();
                r.TraveledDistance = reeinderTraveledDistance;
                contestantTmpScores.Add(reeinder, r);
                if (reeinderTraveledDistance >= leadDistance)
                {
                    leadDistance = reeinderTraveledDistance;
                }
            }

            foreach (KeyValuePair<Reeinder, Result> kvp in contestantTmpScores)
            {
                if (kvp.Value.TraveledDistance == leadDistance)
                {
                    Contestants[kvp.Key].TotalLeadingSeconds++;
                    Contestants[kvp.Key].TraveledDistance = kvp.Key.Flight(duration);
                }
            }
        }
    }

    public class Reeinder
    {
        public string Name { get; set; }
        public int FlySpeed { get; set; } /// in km/s
        public int MaxFlyTime { get; set; } /// in seconds
        public int RestingTime { get; set; } /// in seconds
        public bool IsResting { get; set; } // Unused

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

        //// <summary>
        //// 
        //// </summary>
        //// <param name="duration">Duration of the flight in seconds</param>
        //// <returns></returns>
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
