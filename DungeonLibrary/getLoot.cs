using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class getLoot
    {
        public static Player genLoot(Player thePlayer)
        {

            string largePotion = @"
                 _________
                  `.___,'
                   (___)
                   <   >
                    ) (
                   /`-.\
                  /     \
                 / _    _\
                :,' `-.' `:
                |         |
                :         ;
                 \       /
                  `.___.' 
";
            string smallPotion = @"
           :~:   
           | |   
          .' `.  
        .'  H  `.
        |       |
         `.._..' 
";
            string battleAxeArt = @"
          ,  /\  .  
         //`-||-'\\ 
        (| -=||=- |)
         \\,-||-.// 
          `  ||  '  
             ||     
             ||     
             ||     
             ||     
             ||     
             ()     
";
            string shieldArt = @"
        \_________________/
        |       | |       |
        |       | |       |
        |       | |       |
        |_______| |_______|
        |_______   _______|
        |       | |       |
        |       | |       |
         \      | |      /
          \     | |     /
           \    | |    /
            \   | |   /
             \  | |  /
              \ | | /
               \| |/
                \_/
";
            Weapon battleAxe = new Weapon(2, 16, "Battle Axe", 15, true);


            Random rand = new Random();
            int lootGenNum = rand.Next(4);

            SoundPlayer sndFoundLoot = new SoundPlayer();
            string path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName( path );
            string hitPath = Path.Combine( path, "foundLoot.wav" );
            sndFoundLoot.SoundLocation = hitPath;
            
            switch (lootGenNum)
            {
                case 0:
                    sndFoundLoot.Play();
                    Console.WriteLine("\nYou search the corpse and find a small healing potion!\n" + smallPotion);
                    lootGenNum = rand.Next(1, 11);
                    thePlayer.Life += lootGenNum;
                    Console.WriteLine("The Potion gave you {0} life! Now you have {1} of {2} HP!!", lootGenNum, thePlayer.Life, thePlayer.MaxLife);
                    Console.ReadKey();
                    Console.Clear();
                    return thePlayer;                    

                case 1:
                    sndFoundLoot.Play();
                    Console.WriteLine("\nYou search the corpse and discover a large healing potion!!\n" + largePotion);
                    lootGenNum = rand.Next(5, 21);
                    thePlayer.Life += lootGenNum;
                    Console.WriteLine("The Potion gave you {0} life! Now you have {1} of {2} HP!!", lootGenNum, thePlayer.Life, thePlayer.MaxLife);
                    Console.ReadKey();
                    Console.Clear();
                    return thePlayer;
                    
                case 2:
                    Console.WriteLine("\nYou search the corpse and find a battle axe!\n" + battleAxeArt);
                    Console.WriteLine("Do you wish to keep the Battle Axe?\n1) Yes\n2) No");
                    int keepAxeChoice = int.Parse(Console.ReadLine());
                    if (keepAxeChoice == 1)
                    {
                        thePlayer.EquippedWeapon = battleAxe;
                        Console.Clear();
                        return thePlayer;
                    }
                    else
                    {
                        Console.Clear();
                        return thePlayer;
                    }//end if
                                        
                case 3:
                    Console.WriteLine("\nYou search the corpse and find a peice of armor!\n" + shieldArt);
                    Console.WriteLine("You now have a +1 to your block!");
                    thePlayer.Block += 1;
                    Console.ReadKey();
                    Console.Clear();
                    return thePlayer;
                                        
                case 4:
                    Console.WriteLine("Loot 5");
                    return thePlayer;

                default:
                    return thePlayer;
                    break;
            }

        }//end genLoot()
    }//end getLoot()
}//end namespace
