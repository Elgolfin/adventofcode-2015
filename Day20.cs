using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    /// <summary>
    /// --- Day 20: Infinite Elves and Infinite Houses ---

    //    To keep the Elves busy, Santa has them deliver some presents by hand, door-to-door.He sends them down a street with infinite houses numbered sequentially: 1, 2, 3, 4, 5, and so on.

    //   Each Elf is assigned a number, too, and delivers presents to houses based on that number:

    //    The first Elf(number 1) delivers presents to every house: 1, 2, 3, 4, 5, ....
    //    The second Elf(number 2) delivers presents to every second house: 2, 4, 6, 8, 10, ....
    //    Elf number 3 delivers presents to every third house: 3, 6, 9, 12, 15, ....

    //There are infinitely many Elves, numbered starting with 1. Each Elf delivers presents equal to ten times his or her number at each house.

    //So, the first nine houses on the street end up like this:

    //House 1 got 10 presents.
    //House 2 got 30 presents.
    //House 3 got 40 presents.
    //House 4 got 70 presents.
    //House 5 got 60 presents.
    //House 6 got 120 presents.
    //House 7 got 80 presents.
    //House 8 got 150 presents.
    //House 9 got 130 presents.

    //The first house gets 10 presents: it is visited only by Elf 1, which delivers 1 * 10 = 10 presents.The fourth house gets 70 presents, because it is visited by Elves 1, 2, and 4, for a total of 10 + 20 + 40 = 70 presents.

    //What is the lowest house number of the house to get at least as many presents as the number in your puzzle input?

    /// </summary>
    public class Day20
    {
        public static void InfiniteElvesAndInfiniteHouses(int minPresents)
        {
            int numPresentPerHouse = 0;
            int cptNumHouse = 0;
            while (numPresentPerHouse < minPresents)
            {
                numPresentPerHouse = CalculatePresents(cptNumHouse);
                cptNumHouse += 10; // Too slow if we are gonna do it one by one; there are better solutions for sure
            }
            cptNumHouse -= 10;

            while (numPresentPerHouse > minPresents)
            {
                cptNumHouse--;
                numPresentPerHouse = CalculatePresents(cptNumHouse); 
            }
            cptNumHouse++;
            Console.WriteLine(String.Format("We need {0} houses to deliver at minimum {1} presents per house ({2} presents exactly)", cptNumHouse, minPresents, CalculatePresents(cptNumHouse)));

            //int total = 0;
            //foreach (int value in ComputeHouses(minPresents))
            //{
            //    total = value;
            //}

            //Console.WriteLine(String.Format("We need {0} houses to deliver at minimum {1} presents", total, minPresents));

            //int cptHouse = 0;
            //total = 0;
            //foreach (int value in ComputeMinPresents(minPresents))
            //{
            //    total += value;
            //    cptHouse++;
            //    //Console.WriteLine(String.Format("House {0}: {1} presents (Total: {2})", ++cptHouse, value, total));
            //}

            //Console.WriteLine(String.Format("{0} presents will be delivered to reach the minimum required of {1} presents delivered per house.", total, minPresents));
            //Console.WriteLine(String.Format("We need {0} houses to deliver at minimum {1} presents per house", cptHouse, minPresents));
        }

        

        public static IEnumerable<int> ComputePresents(int minPresents)
        {
            int numHouse = 0;
            int presents = 0;
            int housePresents = 0;
            //
            // Continue loop until the minimum presents count is reached.
            //
            while (presents < minPresents)
            {
                numHouse++;
                housePresents = CalculatePresents(numHouse);
                presents += housePresents;
                yield return presents;
            }
        }

        public static IEnumerable<int> ComputeHouses(int minPresents)
        {
            int numHouse = 0;
            int presents = 0;
            int housePresents = 0;
            //
            // Continue loop until the minimum presents count is reached.
            //
            while (presents < minPresents)
            {
                numHouse++;
                presents += CalculatePresents(numHouse);
                yield return numHouse;
            }
        }

        public static IEnumerable<int> ComputeMinPresents(int minPresents)
        {
            int numHouse = 0;
            int housePresents = 0;
            //
            // Continue loop until the minimum presents delivered per house count is reached.
            //
            while (housePresents < minPresents)
            {
                numHouse++;
                housePresents = CalculatePresents(numHouse);
                yield return housePresents;
            }
        }

        public static int CalculatePresents(int numHouses)
        {
            int cptElves = 1;
            int countPresents = 0;
            int presentPerElf = 10;
            while (cptElves <= numHouses)
            {
                bool elveMustDeliverPresents = (numHouses % cptElves == 0);
                if (elveMustDeliverPresents)
                {
                    countPresents += cptElves * presentPerElf;
                }
                cptElves++;
            }
            return countPresents;
        }

        
    }
}
