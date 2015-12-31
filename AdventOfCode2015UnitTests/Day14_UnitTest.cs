using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2015;

namespace AdventOfCode2015UnitTests
{
    [TestClass]
    public class Day14_UnitTest
    {
        [TestMethod][TestCategory("Day14")]
        public void LoadReeinderCharacteristicsFromString_Vixen()
        {
            string characteristics = "Vixen can fly 8 km/s for 8 seconds, but then must rest for 53 seconds.";
            Reeinder reeinder = new Reeinder(characteristics);
            Assert.AreEqual("Vixen", reeinder.Name);
            Assert.AreEqual(8, reeinder.FlySpeed);
            Assert.AreEqual(8, reeinder.MaxFlyTime);
            Assert.AreEqual(53, reeinder.RestingTime);
            Assert.AreEqual(false, reeinder.IsResting);
        }

        [TestMethod]
        [TestCategory("Day14")]
        public void LoadReeinderCharacteristicsFromString_Comet()
        {
            string characteristics = "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.";
            Reeinder reeinder = new Reeinder(characteristics);
            Assert.AreEqual("Comet", reeinder.Name);
            Assert.AreEqual(14, reeinder.FlySpeed);
            Assert.AreEqual(10, reeinder.MaxFlyTime);
            Assert.AreEqual(127, reeinder.RestingTime);
            Assert.AreEqual(false, reeinder.IsResting);
        }

        [TestMethod]
        [TestCategory("Day14")]
        public void LoadReeinderCharacteristicsFromString_Dancer()
        {
            string characteristics = "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.";
            Reeinder reeinder = new Reeinder(characteristics);
            Assert.AreEqual("Dancer", reeinder.Name);
            Assert.AreEqual(16, reeinder.FlySpeed);
            Assert.AreEqual(11, reeinder.MaxFlyTime);
            Assert.AreEqual(162, reeinder.RestingTime);
            Assert.AreEqual(false, reeinder.IsResting);
        }

        [TestMethod]
        [TestCategory("Day14")]
        public void Comet_Flights_1000s_And_Did_1120km()
        {
            string characteristics = "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.";
            Reeinder reeinder = new Reeinder(characteristics);
            Assert.AreEqual(1120, reeinder.Flight(1000));
        }

        [TestMethod]
        [TestCategory("Day14")]
        public void Comet_Flights_2503s_And_Did_2493km()
        {
            string characteristics = "Comet can fly 3 km/s for 37 seconds, but then must rest for 76 seconds.";
            Reeinder reeinder = new Reeinder(characteristics);
            Assert.AreEqual(2493, reeinder.Flight(2503));
        }

        [TestMethod]
        [TestCategory("Day14")]
        public void Dancer_Flights_1000s_And_Did_1056km()
        {
            string characteristics = "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.";
            Reeinder reeinder = new Reeinder(characteristics);
            Assert.AreEqual(1056, reeinder.Flight(1000));
        }



        [TestMethod]
        [TestCategory("Day14")]
        public void Race_2_Duration_2503_Contestants_Dancer_Wins_TraveledDistance()
        {
            string characteristics = "Dancer can fly 37 km/s for 1 seconds, but then must rest for 36 seconds.";
            Reeinder dancer = new Reeinder(characteristics);
            characteristics = "Comet can fly 3 km/s for 37 seconds, but then must rest for 76 seconds.";
            Reeinder comet = new Reeinder(characteristics);
            Race race = new Race(2503);
            race.Type = Race.WinningMethod.TraveledDistance;
            race.AddContestant(dancer);
            race.AddContestant(comet);
            Assert.AreEqual(2, race.Contestants.Count);
            race.Run();
            Assert.AreEqual(2516, race.GetWinnerTraveledLength());
        }

        [TestMethod]
        [TestCategory("Day14")]
        public void Race_2_Duration_2503_Contestants_Dancer_Wins_TotalLeadingSeconds()
        {
            string characteristics = "Dancer can fly 37 km/s for 1 seconds, but then must rest for 36 seconds.";
            Reeinder dancer = new Reeinder(characteristics);
            characteristics = "Comet can fly 3 km/s for 37 seconds, but then must rest for 76 seconds.";
            Reeinder comet = new Reeinder(characteristics);
            Race race = new Race(2503);
            race.AddContestant(dancer);
            race.AddContestant(comet);
            Assert.AreEqual(2, race.Contestants.Count);
            race.Run();
            Assert.AreEqual(1745, race.GetWinnerTotalLeadingSeconds());
        }

        [TestMethod]
        [TestCategory("Day14")]
        public void Race_2_Duration_1000_Contestants_Comet_Wins_TraveledDistance()
        {
            string characteristics = "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.";
            Reeinder dancer = new Reeinder(characteristics);
            characteristics = "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.";
            Reeinder comet = new Reeinder(characteristics);
            Race race = new Race(1000);
            race.Type = Race.WinningMethod.TraveledDistance;
            race.AddContestant(dancer);
            race.AddContestant(comet);
            Assert.AreEqual(2, race.Contestants.Count);
            race.Run();
            Assert.AreEqual(1120, race.GetWinnerTraveledLength());
        }

        [TestMethod]
        [TestCategory("Day14")]
        public void Race_2_Duration_1000_Contestants_Comet_Wins_TotalLeadingSeconds()
        {
            string characteristics = "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.";
            Reeinder dancer = new Reeinder(characteristics);
            characteristics = "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.";
            Reeinder comet = new Reeinder(characteristics);
            Race race = new Race(1000);
            race.AddContestant(dancer);
            race.AddContestant(comet);
            Assert.AreEqual(2, race.Contestants.Count);
            race.Run();
            Assert.AreEqual(689, race.GetWinnerTotalLeadingSeconds());
        }



    }
}
