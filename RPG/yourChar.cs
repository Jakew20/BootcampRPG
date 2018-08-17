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

        public class PriestAbility
        {
            public static int Prot()
            {
                currentcount = turncounter + 3;
                return currentcount;
            }

            public static int SelfHeal()
            {
                decimal Heal = 0;
                if (Mana >= 25)
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
                if (Mana >= 14)
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

           
            return Decimal.ToInt32(attack);
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
