using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    /// <summary>
    /// --- Day 21: RPG Simulator 20XX ---
    ///
    /// Little Henry Case got a new video game for Christmas.It's an RPG, and he's stuck on a boss.He needs to know what equipment to buy at the shop.He hands you the controller.
    ///
    /// In this game, the player (you) and the enemy (the boss) take turns attacking. The player always goes first. Each attack reduces the opponent's hit points by at least 1. The first character at or below 0 hit points loses.
    ///
    /// Damage dealt by an attacker each turn is equal to the attacker's damage score minus the defender's armor score. An attacker always does at least 1 damage. So, if the attacker has a damage score of 8, and the defender has an armor score of 3, the defender loses 5 hit points. If the defender had an armor score of 300, the defender would still lose 1 hit point.
    ///
    /// Your damage score and armor score both start at zero. They can be increased by buying items in exchange for gold. You start with no items and have as much gold as you need. Your total damage or armor is equal to the sum of those stats from all of your items. You have 100 hit points.
    ///
    /// Here is what the item shop is selling:
    ///
    /// Weapons:    Cost Damage Armor
    /// Dagger        8     4       0
    /// Shortsword   10     5       0
    /// Warhammer    25     6       0
    /// Longsword    40     7       0
    /// Greataxe     74     8       0
    ///
    /// Armor:      Cost Damage Armor
    /// Leather      13     0       1
    /// Chainmail    31     0       2
    /// Splintmail   53     0       3
    /// Bandedmail   75     0       4
    /// Platemail   102     0       5
    ///
    /// Rings:      Cost Damage Armor
    /// Damage +1    25     1       0
    /// Damage +2    50     2       0
    /// Damage +3   100     3       0
    /// Defense +1   20     0       1
    /// Defense +2   40     0       2
    /// Defense +3   80     0       3
    ///
    /// You must buy exactly one weapon; no dual-wielding. Armor is optional, but you can't use more than one. You can buy 0-2 rings (at most one for each hand). You must use any items you buy. The shop only has one of each item, so you can't buy, for example, two rings of Damage +3.
    ///
    /// For example, suppose you have 8 hit points, 5 damage, and 5 armor, and that the boss has 12 hit points, 7 damage, and 2 armor:
    ///
    ///    The player deals 5-2 = 3 damage; the boss goes down to 9 hit points.
    ///    The boss deals 7-5 = 2 damage; the player goes down to 6 hit points.
    ///    The player deals 5-2 = 3 damage; the boss goes down to 6 hit points.
    ///    The boss deals 7-5 = 2 damage; the player goes down to 4 hit points.
    ///    The player deals 5-2 = 3 damage; the boss goes down to 3 hit points.
    ///    The boss deals 7-5 = 2 damage; the player goes down to 2 hit points.
    ///    The player deals 5-2 = 3 damage; the boss goes down to 0 hit points.
    ///
    /// In this scenario, the player wins! (Barely.)
    ///
    /// You have 100 hit points. The boss's actual stats are in your puzzle input. What is the least amount of gold you can spend and still win the fight?
    ///
    ///
    /// --- Part Two ---
    ///
    /// Turns out the shopkeeper is working with the boss, and can persuade you to buy whatever items he wants. The other rules still apply, and he still only has one of each item.
    ///
    /// What is the most amount of gold you can spend and still lose the fight?
    ///
    /// </summary>
    public class Day21
    {
        public static void SimulateBattle ()
        {

            Character me = new Character("Elgolfin", 100, 3, 8);
            Character boss = new Character("Boss", 103, 9, 2);
            BattleEngine battle = new BattleEngine(me, boss);
            battle.LetsFight();
            Console.WriteLine(battle.Result);

        }

        public static void RPGSimulator20XXPart1()
        {
            Character me = new Character("Elgolfin", 100, 0, 0);
            Character boss = new Character("Boss", 103, 9, 2);
            BattleEngine battle = new BattleEngine(me, boss);

            int[] weapons = new int[6] { 0, 4, 5, 6, 7, 8 };
            int[] weaponsGold = new int[6] { 0, 8, 10, 25, 40, 74 };

            int[] armors = new int[6] { 0, 1, 2, 3, 4, 5 };
            int[] armorsGold = new int[6] { 0, 13, 31, 53, 75, 102 };

            int[] rings = new int[7] { 0, 1, 2, 3, -1, -2, -3 };
            int[] ringsGold = new int[7] { 0, 25, 50, 100, 20, 40, 80 };

            int gold = 0;
            int minGold = 9999999;

            foreach (int weapon in weapons)
            {
                foreach (int armor in armors)
                {

                    foreach (int ring1 in rings)
                    {
                        foreach (int ring2 in rings)
                        {
                            if (ring1 > 0 && ring1 == ring2)
                            {
                                continue;
                            }

                            battle.Reset();
                            gold = 0;
                            me.WeaponBonus = weapon;
                            me.ArmorBonus = armor;
                            if (ring1 >= 0)
                            {
                                me.WeaponBonus += ring1;
                            }
                            else
                            {
                                me.ArmorBonus += Math.Abs(ring1);
                            }
                            if (ring2 >= 0)
                            {
                                me.WeaponBonus += ring2;
                            }
                            else
                            {
                                me.ArmorBonus += Math.Abs(ring2);
                            }

                            battle.LetsFight();
                            if (battle.winner == me)
                            {
                                gold += weaponsGold[Array.FindIndex(weapons, row => row == weapon)];
                                gold += armorsGold[Array.FindIndex(armors, row => row == armor)];
                                gold += ringsGold[Array.FindIndex(rings, row => row == ring1)];
                                gold += ringsGold[Array.FindIndex(rings, row => row == ring2)];
                                if (gold < minGold)
                                {
                                    minGold = gold;
                                    Console.Write("*** ");
                                    Console.WriteLine(String.Format("{0} (cost: {1} gold)", battle.Result, gold));
                                }
                                
                            }
                        }

                    }
                }
            }
            Console.WriteLine("Minimum Gold to spend to win: {0}", minGold);

        }

        public static void RPGSimulator20XXPart2()
        {
            Character me = new Character("Elgolfin", 100, 0, 0);
            Character boss = new Character("Boss", 103, 9, 2);
            BattleEngine battle = new BattleEngine(me, boss);

            int[] weapons = new int[5] { 4, 5, 6, 7, 8 };
            int[] weaponsGold = new int[5] { 8, 10, 25, 40, 74 };

            int[] armors = new int[6] { 0, 1, 2, 3, 4, 5 };
            int[] armorsGold = new int[6] { 0, 13, 31, 53, 75, 102 };

            int[] rings = new int[7] { 0, 1, 2, 3, -1, -2, -3 };
            int[] ringsGold = new int[7] { 0, 25, 50, 100, 20, 40, 80 };

            int gold = 0;
            int maxGold = 0;

            foreach (int weapon in weapons)
            {
                foreach (int armor in armors)
                {
                    foreach (int ring1 in rings)
                    {
                        foreach (int ring2 in rings)
                        {
                            // Cannot wear the same right twice
                            if (ring1 > 0 && ring1 == ring2)
                            {
                                continue;
                            }

                            battle.Reset();
                            gold = 0;
                            me.WeaponBonus = weapon;
                            me.ArmorBonus = armor;
                            if (ring1 >= 0)
                            {
                                me.WeaponBonus += ring1;
                            }
                            else
                            {
                                me.ArmorBonus += Math.Abs(ring1);
                            }
                            if (ring2 >= 0)
                            {
                                me.WeaponBonus += ring2;
                            }
                            else
                            {
                                me.ArmorBonus += Math.Abs(ring2);
                            }

                            battle.LetsFight();
                            if (battle.looser == me)
                            {
                                gold += weaponsGold[Array.FindIndex(weapons, row => row == weapon)];
                                gold += armorsGold[Array.FindIndex(armors, row => row == armor)];
                                gold += ringsGold[Array.FindIndex(rings, row => row == ring1)];
                                gold += ringsGold[Array.FindIndex(rings, row => row == ring2)];
                                if (gold > maxGold)
                                {
                                    maxGold = gold;
                                    Console.Write("*** ");
                                    Console.WriteLine(String.Format("{0} (cost: {1} gold)", battle.Result, gold));
                                }

                            }
                        }

                    }
                }
            }
            Console.WriteLine("Maximum Gold to spend to still lose: {0}", maxGold);

        }
    


}

    public class BattleEngine
    {
        private Character firstOpp;
        private Character secondOpp;
        public Character winner;
        public Character looser;
        public string Result = String.Empty;

        public BattleEngine(Character opp1, Character opp2)
        {
            firstOpp = opp1;
            secondOpp = opp2;
        }

        public void LetsFight()
        {

            while (true)
            {
                firstOpp.Attack(secondOpp);
                if (secondOpp.IsDead)
                {
                    winner = firstOpp;
                    looser = secondOpp;
                    break;
                }
                secondOpp.Attack(firstOpp);
                if (firstOpp.IsDead)
                {
                    winner = secondOpp;
                    looser = firstOpp;
                    break;
                }
            }

            Result = String.Format("{0} has slained {1}", winner.ToString(), looser.ToString());
        }



        public void Reset()
        {
            firstOpp.Reset();
            secondOpp.Reset();
        }

    }

    public class Character
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int MaxHitPoints { get; set; }
        public int ActualHitPoints { get; set; }
        public int WeaponBonus { get; set; }
        public int ArmorBonus { get; set; }
        public bool IsDead
        {
            get { return ActualHitPoints <= 0 ? true : false; }
            set { }
        }
        public bool IsAlive
        {
            get { return !IsDead; }
            set { }
        }

        public Character(string name, int hitPoints, int damage, int armor)
        {
            Name = name;
            Armor = armor;
            MaxHitPoints = hitPoints;
            ActualHitPoints = hitPoints;
            Damage = damage;
        }

        public void Attack(Character opponent)
        {
            if (opponent.ActualHitPoints > 0)
            {
                int damage = Damage + WeaponBonus - (opponent.Armor + opponent.ArmorBonus);
                if (damage <= 0)
                {
                    damage = 1;
                }
                opponent.ActualHitPoints -= damage;

                //Console.WriteLine(String.Format("{0} deals {1} damage; {2} goes down to {3} hit points", Name, damage, opponent.Name, opponent.ActualHitPoints));
            }
            else { throw new Exception("You cannot attack a dead opponent!"); }
        }

        public void Reset()
        {
            ActualHitPoints = MaxHitPoints;
            ArmorBonus = 0;
            WeaponBonus = 0;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1}/{2} [{3}+{4},{5}+{6}])", Name, ActualHitPoints, MaxHitPoints, Damage, WeaponBonus, Armor, ArmorBonus);
        }
    }


}
