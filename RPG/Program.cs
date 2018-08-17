using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        //Add Shop
        //Add leveling(Enemy and player)
        //add abilities for all characters
        //balance characters
       
        static void Main(string[] args)
        {
            
            Input();
            Console.WriteLine("\nName: " + YourChar.Name + "\n" + "Class: " + YourChar.Type + "\n"+  "Health: " + YourChar.MaxHp + "\n" + "Mana: " + YourChar.Mana  + "\n" + "Attack: " + YourChar.Attack  + "\n" + "Intellect: " + YourChar.intellect);
            FightDecide();
        }

        public static void characterStats()
        {
            Console.WriteLine("\nName: " + YourChar.Name + "\n" + "Health: " + YourChar.CurrentHP + "\n" + "Mana: " + YourChar.Mana);
        }

        public static void EnemyStats()
        {
            Console.WriteLine("\nName: " + Enemy.Type + "\n" + "Health: " + Enemy.HP + "\n");
        }

        public static string ChooseChar(string input, string name, string newChar)
        {
            
            switch (input)
            {
                case "1":
                    newChar = Rogue.Type;
                    break;
                case "2":
                    newChar = Mage.Type;
                    break;
                case "3":
                    newChar = Warrior.Type;
                    break;
                case "4":
                    newChar = Priest.Type;
                    break;
            }
            return newChar;
            
        }

        public static void Input()
        {
            string enemy = null;
            string newChar = null;
            int num = 0;
            Console.WriteLine("Choose your Character\n" + "Press 1 For a Rogue\n" + "Press 2 for a Mage\n" + "Press 3 for a Warrior\n" + "Press 4 for a Priest\n");
            string input = Console.ReadLine();
            ClearScreen();
            Console.WriteLine("Name your character");
            string name = Console.ReadLine();
            ClearScreen();
            newChar = ChooseChar(input, name, newChar);
            CharacterBuild(newChar, name);
            enemy = RandomEncounter(num, enemy);
            EnemyBuild(enemy);
        }

        public static void DisplayAllStats()
        {
            ClearScreen();
            characterStats();
            EnemyStats();
        }

        public static void CharacterBuild(string type, string name)
        {
            switch (type)
            {
                case "Priest":
                    YourChar.Type = type;
                    YourChar.Name = name;
                    YourChar.MaxHp = Priest.MaxHp;
                    YourChar.CurrentHP = Priest.CurrentHP;
                    YourChar.Mana = Priest.Mana;
                    YourChar.intellect = Priest.intellect;
                    YourChar.dodge = Priest.dodge;
                    YourChar.crit = Priest.crit;
                    YourChar.portrait = Priest.portrait;
                    break;
                case "Warrior":
                    YourChar.Type = type;
                    YourChar.Name = name;
                    YourChar.MaxHp = Warrior.MaxHp;
                    YourChar.CurrentHP = Warrior.CurrentHP;
                    YourChar.Mana = Warrior.Mana;
                    YourChar.Attack = Warrior.Attack;
                    YourChar.dodge = Warrior.dodge;
                    YourChar.crit = Warrior.crit;
                    break;
                case "Mage":
                    YourChar.Type = type;
                    YourChar.Name = name;
                    YourChar.MaxHp = Mage.MaxHp;
                    YourChar.CurrentHP = Mage.CurrentHP;
                    YourChar.Mana = Mage.Mana;
                    YourChar.intellect = Mage.intellect;
                    YourChar.dodge = Mage.dodge;
                    YourChar.crit = Mage.crit;
                    break;
                case "Rogue":
                    YourChar.Type = type;
                    YourChar.Name = name;
                    YourChar.MaxHp = Rogue.MaxHp;
                    YourChar.CurrentHP = Rogue.CurrentHP;
                    YourChar.Mana = Rogue.Mana;
                    YourChar.Attack = Rogue.Attack;
                    YourChar.dodge = Rogue.dodge;
                    YourChar.crit = Rogue.crit;
                    break;
                default:
                    break;
            }
        }

        public static void FightDecide()
        {
            
            
            Console.WriteLine("turn: " + YourChar.turncounter);
            
            Console.WriteLine(YourChar.portrait);
            Console.WriteLine("\nPress y to Attack, b to Block, m for Magic, p To use a Potion and r to Run");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "y":
                    attack();
                    break;
                case "b":
                    //block();
                    break;
                case "m":
                    if (YourChar.Type == "Priest")
                    {
                        PriestMagic();
                    }else if (YourChar.Type == "Mage")
                    {
                        MageMagic();
                    }
                    else
                    {
                        Console.WriteLine("This character has no magic.");
                        Console.ReadKey();
                        DisplayAllStats();
                        FightDecide();
                       
                    }
                    break;
                case "p":
                    if (YourChar.Potions.RevivePotionCount == 1 || YourChar.Potions.ManaPotionCount > 0 ||  YourChar.Potions.HealthPotionCount > 0)
                    {
                        YourChar.Potions.UsePotion();
                        damage();
                        statCheck();
                        DisplayAllStats();
                        FightDecide();
                    }
                    else
                    {
                        Console.WriteLine("You possess no potions to use");
                    }
                    FightDecide();
                    break;
                case "r":
                    run();
                    DisplayAllStats();
                    FightDecide();
                    break;
                default:
                    DisplayAllStats();
                    FightDecide();
                    break;
            }
        }

        public static void attack()
        {
            if (YourChar.Type == "Priest" || YourChar.Type == "Mage")
            {
                Enemy.HP -= Decimal.ToInt32(YourChar.intellect);
                statCheck();
                if (Enemy.HP > 0)
                {
                    Console.WriteLine("\n" + Enemy.Type + " was hit for " + YourChar.intellect + ". " + Enemy.Type + " HP is now " + Enemy.HP);
                }
                
                
                statCheck();
                
            }
            else
            {
                if (EnemyCharDodge() == false)
                {
                    var attack = YourChar.attack();
                    Enemy.HP -= attack;
                    statCheck();
                    if (Enemy.HP > 0)
                    {
                        Console.WriteLine(Enemy.Type + " was hit for " + attack + ". " + Enemy.Type + " HP is now " + Enemy.HP);
                    }
                }
                else
                {
                    Console.WriteLine(  Enemy.Type + " dodged your attack");
                }
                
               
                
                statCheck();
            }
            if (YourCharDodge() == false)
            {
                
                damage();
                statCheck();
            }
            else
            {
                Console.WriteLine("You dodged the " + Enemy.Type + "'s attack");
            }
            Console.ReadKey();
            ClearScreen();
            characterStats();
            EnemyStats();
            YourChar.turncounter += 1;
            FightDecide();
        }

        public static void PriestMagic()
        {
            if (YourChar.Type == "Priest")
            {
                Console.Write("Press h to heal Press s to smite or Press p to protect And b to go back\n");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "h":
                        if (YourChar.Mana >= YourChar.PriestAbility.HealManaRequired)
                        {
                            YourChar.CurrentHP += YourChar.PriestAbility.SelfHeal();
                            if (YourChar.CurrentHP >= YourChar.MaxHp)
                            {
                                YourChar.CurrentHP = YourChar.MaxHp;
                            }
                            Console.WriteLine(YourChar.Name + " was healed for " + YourChar.PriestAbility.SelfHeal());
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough Mana to cast this.");
                            FightDecide();
                        }

                        break;
                    case "s":
                        //var smite = YourChar.intellect + YourChar.intellect / 2;
                        if (YourChar.Mana >= YourChar.PriestAbility.SmiteManaRequired)
                        {
                            YourChar.PriestAbility.Smite();
                            Enemy.HP -= YourChar.PriestAbility.Smite();
                            Console.WriteLine(Enemy.Type + " was hit by Smite for " + YourChar.PriestAbility.Smite() + ". " + Enemy.Type + "'s" + " HP is now " + Enemy.HP);
                            statCheck();
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough Mana to cast this.");
                            FightDecide();
                        }
                        
                        break;
                    case "p":
                        if (YourChar.Mana >= YourChar.PriestAbility.ProtManaRequired)
                        {
                            YourChar.PriestAbility.Prot();
                            Console.WriteLine("You are protected.");
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough Mana to cast this.");
                            FightDecide();
                        }

                        break;
                    case "b":
                        FightDecide();
                       
                        break;
                   
                    default:
                        break;
                }
                
                damage();
                statCheck();
                Console.ReadKey();
                DisplayAllStats();
                YourChar.turncounter += 1;
                FightDecide();
            }
        }

        public static void MageMagic()
        {

        }

        public static string RandomEncounter(int num, string enemy)
        {
            num = RandomRoll();
            switch (num)
            {
                case 1:
                    enemy = EvilTurtle.Type;
                    break;
                case 2:
                    enemy = Barbarian.Type;
                    break;
                case 3:
                    enemy = Bandit.Type;
                    break;
                case 4:
                    enemy = Rabid_Dog.Type;
                    break;
                default:
                    enemy = Rabid_Dog.Type;
                    break;
            }
            return enemy;
        }

        public static int RandomRoll()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 5);
            return num;
        }

        public static void EnemyBuild(string type)
        {
            switch (type)
            {
                case "Evil Turtle":
                    Enemy.Type = type;
                    Enemy.HP = EvilTurtle.HP;
                    Enemy.Mana = EvilTurtle.Mana;
                    Enemy.Attack = EvilTurtle.Attack;
                    Enemy.crit  = EvilTurtle.crit;
                    Enemy.dodge = EvilTurtle.dodge;
                    break;
                case "Barbarian":
                    Enemy.Type = type;
                    Enemy.HP = Barbarian.HP;
                    Enemy.Mana = Barbarian.Mana;
                    Enemy.Attack = Barbarian.Attack;
                    Enemy.crit = Barbarian.crit;
                    Enemy.dodge = Barbarian.dodge;
                    break;
                case "Rabid Dog":
                    Enemy.Type = type;
                    Enemy.HP = Rabid_Dog.HP;
                    Enemy.Mana = Rabid_Dog.Mana;
                    Enemy.Attack = Rabid_Dog.Attack;
                    Enemy.crit = Rabid_Dog.crit;
                    Enemy.dodge = Rabid_Dog.dodge;
                    break;
                case "Bandit":
                    Enemy.Type = type;
                    Enemy.HP = Bandit.HP;
                    Enemy.Mana = Bandit.Mana;
                    Enemy.Attack = Bandit.Attack;
                    Enemy.crit = Bandit.crit;
                    Enemy.dodge = Bandit.dodge;
                    break;
                default:
                    break;
            }
            Console.WriteLine("\nYou encounter the " + Enemy.Type);
        }

        public static void run()
        {
            int num = 0;
            string enemy = null;
            string type = null;
            if (RandomRoll() > 1)
            {
                Console.WriteLine("You ran away successfully");
                Console.ReadKey();
                EnemyBuild(RandomEncounter(num, enemy));
            }
            else
            {
                Console.WriteLine("You were unable to run!");
                damage();
                Console.ReadKey();
            }
           
        
        }

        public static void statCheck()
        {
            if (Enemy.HP <= 0)
            {
                Enemy.HP = 0;
                CharacterBuild(YourChar.Type, YourChar.Name);
                Victory();
            }
            else if (YourChar.CurrentHP <= 0)
            {
                Loss();
            }
        }

        public static void damage()
        {
            var attack = Enemy.attack();
            if (YourChar.currentcount > 0)
            {
                var protattack = (attack / 2);
                YourChar.CurrentHP -= protattack;
                Console.WriteLine("You were hit for " + protattack + " through protection");
                if (YourChar.currentcount <= 1)
                {
                    Console.WriteLine((YourChar.currentcount - 1 )+ " More turn of Protection.");

                }
                else
                {
                    Console.WriteLine((YourChar.currentcount - 1) + " More turns of Protection.");
                }
               
                YourChar.Mana -= 27;
                YourChar.currentcount -= 1;
            }
            else
            {
                YourChar.CurrentHP -= attack;
                Console.WriteLine("You were hit for " + attack);
            }
        }

        public static void Victory()
        {
            var enemy = "";
            var num = 0;
            GoldAddition();
            Random rnd = new Random();
            int Ran = rnd.Next(3, 6);
            Console.WriteLine("You win!");
            YourChar.turncounter = 1;
            YourChar.FightCount += 1;
            Console.ReadKey();
            ClearScreen();
            if (YourChar.FightCount == Ran)
            {
                ClearScreen();
                Console.WriteLine("You encounter a store!");
                Console.ReadKey();
                Store();
            }
            characterStats();
            EnemyBuild(RandomEncounter(num, enemy));
            FightDecide();
            Console.ReadKey();
            
            
        }

        public static void Loss()
        {
            if (YourChar.Potions.RevivePotionCount == 1)
            {
                YourChar.CurrentHP = YourChar.Potions.ReviveValue;
                YourChar.Potions.RevivePotionCount -= 1;
                FightDecide();
            }
            Console.WriteLine("You Loss");
            Console.ReadKey();
        }

        public static bool YourCharDodge()
        {
            return YourChar.Dodge();
        }

        public static bool EnemyCharDodge()
        {
            return Enemy.Dodge();
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void Store()
        {
            ClearScreen();
            Console.WriteLine("Welcome to the store!\n");
            Console.WriteLine("You have {0} Gold to spend", YourChar.Gold);
            Console.WriteLine("What would you like to purchase?");
            Console.WriteLine("Mana Potion - 50G Restores {0} Mana Press M", YourChar.Potions.HealthValue);
            Console.WriteLine("Health Potion - 50G Restores {0} Health Press H", YourChar.Potions.ManaValue);
            Console.WriteLine("Revive Potion - 100G Revives your character upon death to half their Max HP Press R");
            Console.WriteLine("Press B to Leave");
            var input = Console.ReadLine();
            Purchasing(input.ToString().ToUpper());
        }

        public static void GoldAddition()
        {
            YourChar.Gold += Enemy.Gold;
        }

        public static void Purchasing(string input)
        {
            var enemy = "";
            var num = 0;
            switch (input)
            {
                case "H":
                    YourChar.Potions.BuyHealthPotion();
                    Console.ReadKey();
                    Store();
                    break;
                case "M":
                    YourChar.Potions.BuyManaPotion();
                    Console.ReadKey();
                    Store();
                    break;
                case "R":
                    YourChar.Potions.BuyRevivePotion();
                    Console.ReadKey();
                    Store();
                    break;
                case "B":
                    ClearScreen();
                    characterStats();
                    EnemyBuild(RandomEncounter(num, enemy));
                    FightDecide();
                    Console.ReadKey();
                    break;
            }
        }
    }
}
