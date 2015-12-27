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
    /// --- Day 6: Probably a Fire Hazard ---
    ///
    /// Because your neighbors keep defeating you in the holiday house decorating contest year after year, you've decided to deploy one million lights in a 1000x1000 grid.
    ///
    /// Furthermore, because you've been especially nice this year, Santa has mailed you instructions on how to display the ideal lighting configuration.
    ///
    /// Lights in your grid are numbered from 0 to 999 in each direction; the lights at each corner are at 0,0, 0,999, 999,999, and 999,0. The instructions include whether to turn on, turn off, or toggle various inclusive ranges given as coordinate pairs.Each coordinate pair represents opposite corners of a rectangle, inclusive; a coordinate pair like 0,0 through 2,2 therefore refers to 9 lights in a 3x3 square.The lights all start turned off.
    ///
    /// To defeat your neighbors this year, all you have to do is set up your lights by doing the instructions Santa sent you in order.
    ///
    /// For example:
    ///
    ///   turn on 0,0 through 999,999 would turn on (or leave on) every light.
    ///   toggle 0,0 through 999,0 would toggle the first line of 1000 lights, turning off the ones that were on, and turning on the ones that were off.
    ///   turn off 499,499 through 500,500 would turn off (or leave off) the middle four lights.
    ///
    /// After following the instructions, how many lights are lit? 400410
    ///
    /// --- Part Two ---
    ///
    /// You just finish implementing your winning light pattern when you realize you mistranslated Santa's message from Ancient Nordic Elvish.
    ///
    /// The light grid you bought actually has individual brightness controls; each light can have a brightness of zero or more.The lights all start at zero.
    ///
    /// The phrase turn on actually means that you should increase the brightness of those lights by 1.
    ///
    /// The phrase turn off actually means that you should decrease the brightness of those lights by 1, to a minimum of zero.
    ///
    /// The phrase toggle actually means that you should increase the brightness of those lights by 2.
    ///
    /// What is the total brightness of all lights combined after following Santa's instructions? 15343601
    ///
    /// For example:
    ///
    ///   turn on 0,0 through 0,0 would increase the total brightness by 1.
    ///   toggle 0,0 through 999,999 would increase the total brightness by 2000000.
    ///
    /// </summary>
    public static class Day06
    {
        private const int GRID_LENGTH = 1000;
        private static bool[,] lightsGrid = new bool[GRID_LENGTH, GRID_LENGTH];
        public static void ProbablyAFireHazard_Part1()
        {
            LightsGrid grid = new BinaryLightsGrid();
            using (StreamReader sr = new StreamReader("../../day06.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    grid.ParseAction(line);
                }
            }
            Console.WriteLine(String.Format("There are {0} lit lights (Binary Grid)", grid.CountLitLights()));
        }

        public static void ProbablyAFireHazard_Part2()
        {
            LightsGrid grid = new GradientLightsGrid();
            using (StreamReader sr = new StreamReader("../../day06.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    grid.ParseAction(line);
                }
            }
            Console.WriteLine(String.Format("There are {0} lit lights (Gradient Grid)", grid.CountLitLights()));
        }
    }

    public abstract class LightsGrid
    {
        public const int GRID_LENGTH = 1000;
        protected int[,] lightsGrid = new int[GRID_LENGTH, GRID_LENGTH];

        public LightsGrid()
        {
            lightsGrid = new int[GRID_LENGTH, GRID_LENGTH];
        }
        public abstract void ToggleLights(int x, int y);
        public abstract void TurnOnLights(int x, int y);
        public abstract void TurnOffLights(int x, int y);

        public void ResetGrid()
        {
            for (int x = 0; x < GRID_LENGTH; x++)
            {
                for (int y = 0; y < GRID_LENGTH; y++)
                {
                    lightsGrid[x, y] = 0;
                }
            }
        }

        public void ParseLights(int startX, int startY, int endX, int endY, Action<int, int> LightAction)
        {
            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    LightAction(x, y);
                }
            }
        }
        public int CountLitLights()
        {
            int litLights = 0;
            for (int x = 0; x < GRID_LENGTH; x++)
            {
                for (int y = 0; y < GRID_LENGTH; y++)
                {
                    litLights += lightsGrid[x, y];
                }
            }
            return litLights;
        }

        public void ParseAction(string actionLine)
        {
            string pattern = @"(?<action>toggle|turn on|turn off) (?<startX>\d+),(?<startY>\d+) through (?<endX>\d+),(?<endY>\d+)";

            int startX;
            int endX;
            int startY;
            int endY;
            string action;
            Action<int, int> actionMethod;

            Regex regex = new Regex(pattern);
            Match match = regex.Match(actionLine);
            if (match.Success)
            {
                Int32.TryParse(match.Groups["startX"].Value, out startX);
                Int32.TryParse(match.Groups["endX"].Value, out endX);
                Int32.TryParse(match.Groups["startY"].Value, out startY);
                Int32.TryParse(match.Groups["endY"].Value, out endY);
                action = match.Groups["action"].Value;

                switch (action)
                {
                    case "turn on":
                        actionMethod = TurnOnLights;
                        break;
                    case "turn off":
                        actionMethod = TurnOffLights;
                        break;
                    default:
                        actionMethod = ToggleLights;
                        break;
                }

                ParseLights(startX, startY, endX, endY, actionMethod);
            }
        }
    } 

    public class BinaryLightsGrid : LightsGrid
    {
        public override void ToggleLights(int x, int y)
        {
            if (lightsGrid[x, y] > 0)
            {
                lightsGrid[x, y] = 0;
            } else
            {
                lightsGrid[x, y] = 1;
            }
        }
        public override void TurnOnLights(int x, int y)
        {
            lightsGrid[x, y] = 1;
        }
        public override void TurnOffLights(int x, int y)
        {
            lightsGrid[x, y] = 0;
        }
    }

    public class GradientLightsGrid : LightsGrid
    {
        public override void ToggleLights(int x, int y)
        {
            lightsGrid[x, y] += 2;
        }
        public override void TurnOnLights(int x, int y)
        {
            lightsGrid[x, y]++;
        }
        public override void TurnOffLights(int x, int y)
        {
            lightsGrid[x, y]--;
            if (lightsGrid[x, y] < 0)
            {
                lightsGrid[x, y] = 0;
            }
        }
    }
}
