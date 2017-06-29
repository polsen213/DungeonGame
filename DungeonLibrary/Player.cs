using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //New classes default to INTERNAL. We must make it public un order to access it outside of the project.
    public class Player : Character
    {
        //funny/fields
        //only need to create fields for the ones we will have business rules on
        private int _life;

        //people/properties
        //Automatic properties are a shortcut syntax that allows you to create a shortened cersion of a public property.
        //They have an OPEN getter and setter!! The guard is asleep!
        //These automatically create default fields FOR YOU at runtime
        //public string Name { get; set; }
        //public int HitChance { get; set; }
        //public int Block { get; set; }
        //public int MaxLife { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Race CharacterRace { get; set; }

        //You CANNOT have business rules with an automatic property
        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        //business rule, like should NOT be more than MaxLife
        //        if (value <= MaxLife)
        //        {
        //            //good to go!
        //            _life = value;
        //        }//end if
        //        else
        //        {
        //            _life = MaxLife;
        //        }//end else
        //    }//end set
        //}//end Life

        //collect/constructors
        //ONLY make a FQCTOR---we do not want to allow anyone to make a blank player, they must give us all of the info
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            //since Life depends on MaxLife
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }//end Player FQCTOR

        //monkeys/methods
        public override string ToString()
        {
            //return base.ToString();
            string description = "";

            switch (CharacterRace)
            {
                case Race.Orc:
                    description = "Orcs are carnivorous humanoids, standing approximately 5'11\" to 6'2\", weighing from 180 to 280 lbs. They are easily noticeable due to their green to gray skin, lupine ears, lower canines resembling boar tusks, and their muscular builds. Orcs stand in a bent over shape making them appear as ape-like humans.\nBestial and savage, orcs band together as trıbes, living on hunting and raiding. Believing that the only way to survive is by expanding their territories, they have developed enmities wıth many other races, although mainly elves and dwarves, as well as humans, gnomes, halflings, goblins, hobgoblins, and even other orc tribes. Even though they have good relationships with other evil humanoids in times of peace, their chaotic nature stops them from cooperating unless forced to do so by a powerful leader. Orcs live in a patriarchal society, taking pride on how many females and male children they have. Orcs like scars and take pride in exposing them, whether they are of a victory or loss. Their chief deity Gruumsh claims that the orc is the top of the food chain, and that all riches are the property of orcs stolen by others.";
                    break;
                case Race.Vampire:
                    description = "A vampire can be of any evil alignment, and if its alignment was not evil in life it becomes so in undeath. A vampire retains all the abilities it had in life, plus it gains the ability to drain blood and life energy, and to dominate other creatures with its gaze. A vampire can also command rats, bats, and wolves, or take the form of those creatures. They also become superhumanly strong, can heal quickly or even regenerate, and can turn into a gaseous form.";
                    break;
                case Race.Werewolf:
                    description = "Wereworf";
                    break;
                case Race.Human:
                    description = "Human";
                    break;
                case Race.Elf:
                    description = "Elf";
                    break;
                case Race.Minotaur:
                    description = "Minotaur";
                    break;
                case Race.Gnome:
                    description = "Gnome";
                    break;
                default:
                    break;
            }//end switch

            return string.Format("\n-=-= Name: {0} =-=-\n" +
                "Life: {1} of {2}\nHit Chance: {3}%\nWeapon: \n{4}\nDesription: {5}", Name, Life, MaxLife, 
                HitChance, EquippedWeapon, description);
        }//end ToString() override

        //Overriding the CalcDamage in Player to use their Weapon's properties of MinDamage and MaxDamage

        public override int CalcDamage()
        {
            //Create a new Random object
            Random rand = new Random();

            //determine damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            //return damage
            return damage;
        }//end CalcDamage() override

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }//end CalcHitChance() override

    }//end class
}//end namespace
