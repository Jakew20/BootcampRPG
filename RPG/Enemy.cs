using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace RPG
{
    class Enemy
    {
        public static string Type = "";
        public static int HP;
        public static int Mana;
        public static int Attack;
        public static int crit;
        public static int dodge;
        public static int Gold;
        public static int EXP;


        
        //synth.SetOutputToDefaultAudioDevice();  
        

        public static int attack()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            var attack = 0;
            if (RandomCrit() == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                    attack = (Attack * 2) + RandomDamageRoll() * 2;
                    Console.WriteLine( Type + " Scored a Critical hit!");
                synth.Speak("BLAAHHHHHHHHHHHHHHHHHHHHHHHHHH");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                attack = Attack + RandomDamageRoll();
            }


            return attack;
        }

        public static int RandomCrit()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, crit);
            return num;
        }

        public static int RandomDamageRoll()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 12);
            return num;
        }


        public static int RandomRoll()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 6);
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
