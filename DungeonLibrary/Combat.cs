using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Reflection;
using System.IO;

namespace DungeonLibrary
{
    public class Combat
    {
        //This class will NOT have fields, properties or any custom constructors as it is just
        //a "warehouse" for different methods

        //methods
        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100 as our dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(45);
            //could have also done
            //int diceRoll = rand.Next(0, 100);
            if(diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //if the attacker hit
                //calculate the damage
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //write to the screen the result
                SoundPlayer sndHit = new SoundPlayer();
                string path = Assembly.GetExecutingAssembly().Location;
                path = Path.GetDirectoryName( path );
                string hitPath = Path.Combine(path, "swing.wav");
                sndHit.SoundLocation = hitPath;
                sndHit.Play();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("{0} hit {1} for {2} damage!",attacker.Name, defender.Name, damageDealt);
                System.Threading.Thread.Sleep(150);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                System.Threading.Thread.Sleep(150);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                System.Threading.Thread.Sleep(150);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                System.Threading.Thread.Sleep(150);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }//end if
            else
            {
                //the attacker missed!
                SoundPlayer sndMiss = new SoundPlayer();
                string path = Assembly.GetExecutingAssembly().Location;
                path = Path.GetDirectoryName( path );
                string hitPath = Path.Combine( path, "swing.wav" );
                sndMiss.SoundLocation = hitPath;
                sndMiss.Play();
                Console.WriteLine("{0} missed!", attacker.Name);
            }//end else
        }//end DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            //player attacks first
            DoAttack(player, monster);

            //monster attacks second if they are alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }//end if
        }//end DoBattle()


    }//end class
}//end namespace
