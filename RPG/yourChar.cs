using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public static class YourChar
    {
        public static string Type;
        public static string Name;
        public static decimal MaxHp;
        public static decimal CurrentHP;
        public static decimal Mana;
        public static decimal Attack;
        public static decimal intellect;
        public static string portrait;
        public static int turncounter = 1;
        public static int currentcount = 0;
        public static int dodge;
        public static int crit;
        public static int FightCount = 0;
        public static int Gold = 100;
        

        public class PriestAbility
        {
            public static int ProtManaRequired = 12;
            public static int SmiteManaRequired = 14;
            public static int HealManaRequired = 25;
            public static int Prot()
            {
                if (Mana >= ProtManaRequired)
                {
                    currentcount = 3;
                }
               
                return currentcount;
            }

            public static int SelfHeal()
            {
                decimal Heal = 0;
                if (Mana >= HealManaRequired)
                {
                    if (RandomCrit() == 4)
                    {
                        Heal = (intellect * 2.8m) + RandomHealRoll() * 2;
                    }
                    Heal = (intellect * 2.8m) + RandomHealRoll();
                    Math.Round(Heal);
                    Mana -= 25;
                }
               
                return Decimal.ToInt32(Heal);
            }

            public static int Smite()
            {
                decimal smite = 0;
                if (Mana >= SmiteManaRequired)
                {
                    smite = intellect + (intellect * 2) + RandomDamageRoll();
                    Mana -= 14;
                    Math.Round(smite);
                }
               
                return Decimal.ToInt32(smite);
            }

        }
            
        public class RogueAbility
        {
            public static int ShroudSelf()
            {
                var dodgechance = dodge - 3;
                return dodgechance;
            }
        }

        
        public class Potions
        {
            public static int HealthPotionCount = 0;
            public static int ManaPotionCount = 0;
            public static int RevivePotionCount = 0;

            public static int HealthValue = 75;
            public static int ManaValue = 50;
            public static decimal ReviveValue = MaxHp/2;

            public static void UsePotion()
            {
                Console.WriteLine("Which Potion should be used?\n");
                Console.WriteLine("Health for " + HealthValue + " Press H");
                Console.WriteLine("Mana for "  + ManaValue + " Press M");
                var input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "H":
                        CurrentHP += HealthValue;
                        break;
                    case "M":
                        Mana += ManaValue;
                        break;
                    default:
                        UsePotion();
                        break;
                }
            }
            public static void BuyHealthPotion()
            {
                if (HealthPotionCount < 5 && YourChar.Gold >= 50)
                {
                    HealthPotionCount += 1;
                    Gold -= 50;
                    Console.WriteLine("You have {0} Health potions", HealthPotionCount);
                }
                else
                {
                    if (Gold < 50)
                    {
                        Console.WriteLine("You don't have enough gold");
                    }
                    else
                    {
                        Console.WriteLine("Your Already have " + HealthPotionCount + " Health potions.");
                    }    
                }
            }

            public static void BuyManaPotion()
            {
                if (ManaPotionCount < 5 && YourChar.Gold >= 50)
                {
                    ManaPotionCount += 1;
                    Gold -= 50;
                    Console.WriteLine("You have {0} Mana potions", ManaPotionCount);
                }
                else
                {
                    if (Gold < 50)
                    {
                        Console.WriteLine("You don't have enough gold");
                    }
                    else
                    {
                        Console.WriteLine("Your Already have " + ManaPotionCount + " Mana potions.");
                    }
                }
            }

            public static void BuyRevivePotion()
            {
                if (RevivePotionCount < 1 && YourChar.Gold >= 100)
                {
                    RevivePotionCount += 1;
                    Gold -= 100;
                    Console.WriteLine("You have {0} Revive potions", RevivePotionCount);
                }
                else
                {
                    if (Gold < 50)
                    {
                        Console.WriteLine("You don't have enough gold");
                    }
                    else
                    {
                        Console.WriteLine("Your Already have " + RevivePotionCount + " Revive potion.");
                    }
                }
            }
        }
        
      
       

        public static int attack()
        {
            decimal attack = 0;
            if (RandomCrit() == 3)
            {
                
                if (intellect == 0)
                {
                    attack = (Attack * 2) + RandomDamageRoll() * 2;
                    Console.WriteLine("Critical hit!");
                }
                else if (intellect > 0)
                {
                    attack = (intellect * 2) + RandomDamageRoll() * 2;
                    Console.WriteLine("Critical hit!");
                }
            }
            else
            {
                attack = Attack + RandomDamageRoll();
            }

           
            return decimal.ToInt32(attack);
        }

        public static int RandomHealRoll()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 6);
            return num;
        }

        public static int RandomDamageRoll()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 12);
            return num;
        }

        public static int RandomCrit()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, crit);
            return num;
        }

        public static int RandomDodge()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, dodge);
            return num;
        }

        public static bool Dodge()
        {
            if (RandomDodge() == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
