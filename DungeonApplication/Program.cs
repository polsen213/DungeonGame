using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using System.Speech.Synthesis;
using System.Media;
using System.Reflection;
using System.IO;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DUNGEON OF DOOM!";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;

            //Speech synth test
            SpeechSynthesizer speaker = new SpeechSynthesizer();
            speaker.Rate = 1;
            speaker.Volume = 100;
            speaker.SelectVoice( "Microsoft Zira Desktop" );
            //speaker.SpeakAsync("Welcome to the Dungeon of Doom!");

            //Output information about all of the installed voices. 
            //Console.WriteLine("Installed voices -");
            //foreach (InstalledVoice voice in speaker.GetInstalledVoices())
            //{
            //    VoiceInfo info = voice.VoiceInfo;
            //    Console.WriteLine(" Voice Name: " + info.Name);
            //}

            Console.WriteLine( @"



                                    ▄ ▄   ▄███▄   █     ▄█▄    ████▄ █▀▄▀█ ▄███▄   
                                   █   █  █▀   ▀  █     █▀ ▀▄  █   █ █ █ █ █▀   ▀  
                                  █ ▄   █ ██▄▄    █     █   ▀  █   █ █ ▄ █ ██▄▄    
                                  █  █  █ █▄   ▄▀ ███▄  █▄  ▄▀ ▀████ █   █ █▄   ▄▀ 
                                   █ █ █  ▀███▀       ▀ ▀███▀           █  ▀███▀   
                                    ▀ ▀                                ▀           " );
            Console.WriteLine( @"
                                                ╔╦╗╔═╗  ╔╦╗╦ ╦╔═╗
                                                 ║ ║ ║   ║ ╠═╣║╣ 
                                                 ╩ ╚═╝   ╩ ╩ ╩╚═╝" );
            Console.WriteLine( @"

          ▄ ▄ ██▄     ▄      ▄     ▄▀  ▄███▄   ████▄    ▄       ████▄ ▄████      ██▄   ████▄ ████▄ █▀▄▀█   ▄ ▄ 
         █ █  █  █     █      █  ▄▀    █▀   ▀  █   █     █      █   █ █▀   ▀     █  █  █   █ █   █ █ █ █  █ █  
        █ █   █   █ █   █ ██   █ █ ▀▄  ██▄▄    █   █ ██   █     █   █ █▀▀        █   █ █   █ █   █ █ ▄ █ █ █   
        █ █   █  █  █   █ █ █  █ █   █ █▄   ▄▀ ▀████ █ █  █     ▀████ █          █  █  ▀████ ▀████ █   █ █ █   
              ███▀  █▄ ▄█ █  █ █  ███  ▀███▀         █  █ █            █         ███▀                 █        
        ▀ ▀          ▀▀▀  █   ██                     █   ██             ▀                            ▀   ▀ ▀   
                                                                                                       " );

            Console.WriteLine( @"                                              PRESS ANY KEY TO START" );
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();

            //Create a Player
            Weapon sword = new Weapon( 1, 8, "Long Sword", 10, false );
            Weapon battleAxe = new Weapon( 2, 16, "Battle Axe", 15, true );

            #region UserCustomization to the player
            speaker.SpeakAsync( "Please enter your name" );
            Console.WriteLine( "\nWhat is your name?" );
            string playerName = Console.ReadLine();

            Race playerRace = new Race();
            bool goodMenuChoice = true;

            do
            {
                Console.Clear();
                Console.WriteLine( "\nChoose your race:\n1) Orc\n2) Vampire\n3) Human\n4) Elf\n5) Minotaur\n6) Gnome\n" );

                try
                {
                    int raceMenu = int.Parse( Console.ReadLine() );

                    switch ( raceMenu )
                    {
                        case 1:
                            playerRace = Race.Orc;
                            goodMenuChoice = true;
                            break;
                        case 2:
                            playerRace = Race.Vampire;
                            goodMenuChoice = true;
                            break;
                        case 3:
                            playerRace = Race.Human;
                            goodMenuChoice = true;
                            break;
                        case 4:
                            playerRace = Race.Elf;
                            goodMenuChoice = true;
                            break;
                        case 5:
                            playerRace = Race.Minotaur;
                            goodMenuChoice = true;
                            break;
                        case 6:
                            playerRace = Race.Gnome;
                            goodMenuChoice = true;
                            break;
                        default:
                            Console.WriteLine( "Invalid selection, press any key to choose again..." );
                            Console.ReadKey();
                            goodMenuChoice = false;
                            break;
                    }//end switch()

                }
                catch ( Exception )
                {
                    Console.WriteLine("Please enter a valid option.\nPress any key to continue...");
                    Console.ReadKey();
                    goodMenuChoice = false;
                }

            } while ( !goodMenuChoice );//end do while()

            #endregion

            Player player = new Player( playerName, 70, 5, 40, 40, playerRace, sword );

            //TODO Create a loop for the room

            bool exit = false;

            Console.Clear();

            do
            {
                //TODO Write a () for entering a room
                Console.WriteLine( GetRoom() );

                //TODO Create Monster in the room
                //new Random to pick a monster for each room
                Random rand = new Random();
                //generated monsters
                Koloss koloss = new Koloss();
                GiantFrog giantFrog1 = new GiantFrog();
                GiantFrog kermit = new GiantFrog( "Kermit the Frog", 10, 10, 40, 3, 3, 10, "Uh oh, it's Kermit the Frog", true );
                //list for monsters with monsters placed in it
                List<Monster> monsterList = new List<Monster>() { koloss, giantFrog1, kermit };
                //new int to hold random number for monster list                
                int monstGen = rand.Next( monsterList.Capacity - 1 );
                //created temporary holder for current rooms monster
                //and assigned the randomly generated monster from the list
                //tempMonster is used in all of the battle related calls.
                Monster tempMonster;
                tempMonster = monsterList[monstGen];
                Console.WriteLine( "\nIn this room: " + tempMonster.Name );


                //First attempt used the below if else with random number of 0 or 1
                //to determine monster

                //if (monstGen == 0)
                //{
                //    Koloss koloss = new Koloss();
                //    tempMonster = koloss;
                //}//end if
                //else
                //{
                //    GiantFrog monster2 = new GiantFrog();
                //    tempMonster = monster2;
                //}//end else



                //TODO Create a loop for the menu
                bool reload = false;

                do
                {

                    //TODO Create the menu of options
                    #region Menu
                    Console.Write( "\nWhat would you like to do?\nA) Attact\nR) Run Away\nC) Character Info\nM) Monter Info\nX) Exit" +
                        "\n\nEnter your choice: " );

                    string userChoice = Console.ReadLine().ToUpper();

                    Console.Clear();

                    switch ( userChoice )
                    {
                        case "A":
                            //TODO Need to handle if Player wins
                            //TODO Handle if player loses
                            Console.WriteLine( "You attack the " + tempMonster.Name + "!" );
                            Combat.DoBattle( player, tempMonster );
                            if ( tempMonster.Life <= 0 )
                            {
                                //its dead!
                                //you could put some logic here to have the player get some items, life, etc.
                                Console.WriteLine( "\nYou defeated {0}!!", tempMonster.Name );
                                player.MaxLife += (int)( tempMonster.MaxLife * .3 );
                                Console.WriteLine( "\nYou now have {0} Max HP!", player.MaxLife );

                                //TODO make a getLoot() method
                                Random randLootGen = new Random();
                                int yesNoLoot = randLootGen.Next( 10 );
                                if ( yesNoLoot < 3 )
                                {
                                    SoundPlayer sndNoLoot = new SoundPlayer();
                                    string path = Assembly.GetExecutingAssembly().Location;
                                    path = Path.GetDirectoryName( path );
                                    string hitPath = Path.Combine( path, "noLoot.wav" );
                                    sndNoLoot.SoundLocation = hitPath;
                                    sndNoLoot.Play();
                                    Console.WriteLine( "\nYou search the corpse but find nothing\nPress any key to continue..." );
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    //Call getLoot()
                                    player = getLoot.genLoot( player );
                                }

                                //now get new room!
                                reload = true;
                            }//end it monster dead
                            break;

                        case "R":
                            Console.WriteLine( "RUN AWAY!!!" );
                            //TODO Handle getting a new room
                            //Monster gets a free attack.
                            Combat.DoAttack( tempMonster, player );//free attack!
                            Console.WriteLine();
                            reload = true;
                            break;

                        case "C":
                            Console.WriteLine( "Player Info" );
                            Console.WriteLine( player );
                            break;

                        case "M":
                            Console.WriteLine( "Monster Info" );
                            Console.WriteLine( tempMonster );
                            break;

                        case "E":
                        case "X":
                            Console.WriteLine( "No one likes a quitter..." );
                            exit = true;
                            break;

                        default:
                            Console.WriteLine( "Invalid choice. Try again." );
                            break;
                    }//end switch
                    #endregion

                    //Address Player's life
                    if ( player.Life <= 0 )
                    {
                        SoundPlayer sndDied = new SoundPlayer();
                        string path = Assembly.GetExecutingAssembly().Location;
                        path = Path.GetDirectoryName( path );
                        string hitPath = Path.Combine( path, "playerDie.wav" );
                        sndDied.SoundLocation = hitPath;
                        sndDied.Play();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Clear();
                        Console.WriteLine( @"







                          ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄  ▐██▌  ▐██▌ 
                          ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌ ▐██▌  ▐██▌ 
                          ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌ ▐██▌  ▐██▌ 
                          ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌ ▓██▒  ▓██▒ 
                          ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓  ▒▄▄   ▒▄▄  
                           ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒  ░▀▀▒  ░▀▀▒ 
                         ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒  ░  ░  ░  ░ 
                         ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░     ░     ░ 
                         ░ ░         ░ ░     ░           ░     ░     ░  ░   ░     ░     ░    
                         ░ ░                           ░                  ░                 
" );
                        Console.WriteLine( @"
                                            Better Luck Next Time..." );
                        Console.ReadKey();
                        reload = true;
                        exit = true;
                    }//end if


                } while ( !reload && !exit );



            } while ( !exit );//exit == false



        }//end Main()


        private static string GetRoom()
        {
            string[] rooms =
            {
                "You gaze into the room and hundreds of skulls gaze coldly back at you. They're set in niches in the walls in a checkerboard pattern, each skull bearing a half-melted candle on its head. The grinning bones stare vacantly into the room, which otherwise seems empty.",
                "This chamber holds an odd contraption of metal and wood. It's a 20-foot-diameter circular platform that is tilted heavily to one side. Beneath it you can discern mechanisms that seem to attach to a large crank not far away. Above the platform hang metal weights on thin chains, which in turn are attached to discs and belts that are attached to other winches. It seems as though turning the winches turns and tilts the platform and sets the weights to moving. ",
                "Several white marble busts that rest on white pillars dominate this room. Most appear to be male or female humans of middle age, but one clearly bears small horns projecting from its forehead and another is spread across the floor in a thousand pieces, leaving one pillar empty.",
                "You've opened the door to a torture chamber. Several devices of degradation, pain, and death stand about the room, all of them showing signs of regular use. The wood of the rack is worn smooth by struggling bodies, and the iron maiden appears to be occupied by a corpse.",
                "Corpses and pieces of corpses hang from hooks that dangle from chains attached to thick iron rings. Most appear humanoid but a few of the body parts appear more monstrous. You don't see any heads, hands, or feet -- all seem to have been chopped or torn off. Neither do you see any guts in the horrible array, but several thick leather sacks hang from hooks in the walls, and they are suspiciously wet and the leather looks extremely taut -- as if it' under great strain.",
                "There's a hiss as you open this door, and you smell a sour odor, like something rotten or fermented. Inside you see a small room lined with dusty shelves, crates, and barrels. It looks like someone once used this place as a larder, but it has been a long time since anyone came to retrieve food from it.",
                "The door to this room swings open easily on well-oiled hinges. Beyond it you see that the chamber walls have been disguised by wood paneling, and the stone ceiling and floor are hidden by bright marble tiles. Several large and well-stuffed chairs are arranged about the room along with some small reading tables.",
                "A huge iron cage lies on its side in this room, and its gate rests open on the floor. A broken chain lies under the door, and the cage is on a rotting corpse that looks to be a hobgoblin. Another corpse lies a short distance away from the cage. It lacks a head.",
                "You round the corner of the hall to confront a passage nearly blocked with crates, barrels, and chests. It seems someone set them up to barricade the hall. Three barrels are set up as seats near gaps in the barricade, no doubt the place where archers waited for foes. A rusting and torn breastplate hangs from a rope near the wall. ",
                "This chamber holds one occupant: the statue of a male figure with elven features but the broad, muscular body of a hale human. It kneels on the floor as though fallen to that posture. Both its arms reach upward in supplication, and its face is a mask of grief. Two great feathered wings droop from its back, both sculpted to look broken. The statue is skillfully crafted.",
                "Fire crackles and pops in a small cooking fire set in the center of the room. The smoke from a burning rat on a spit curls up through a hole in the ceiling. Around the fire lie several fur blankets and a bag. It looks like someone camped here until not long ago, but then left in a hurry.",
                "This room looks like it was designed by drow. Rusted metal tiles create a huge mosaic of a spider in the floor, and someone set up rusted gratings like draperies of webs. At the far end of the chamber, the carving of a spider squats on the floor. It's about 3 feet tall and seems molded into the floor. Beyond it stands tall double doors of stone, their surface covered in a glittering web of gold."
            };

            Random Rand = new Random();

            int indexNbr = Rand.Next( rooms.Length );

            string room = rooms[indexNbr];

            return room;
        }//end GetRoom()
    }//end class
}//end namespace
