using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //first class in a .dll (Class Library) is public by default any susequent classed, we have to make public
    public class Weapon
    {
        //fields
        private string _name;
        private int _minDamage;
        private int _maxDamage;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        

        //properties
        //properties with business rules go LAST
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end Name

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//end MaxDamage

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }//end BonusHitChance

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//end IsTwoHanded

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //CANNOT be more than max damage and CANNNOT be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    //less than the MaxDamage and greater than 0, so let it pass
                    _minDamage = value;
                }//end if
                else
                {
                    //tried to set the value outside out range
                    _minDamage = 1;
                }//end else
            }//end set
        }//end MinDamage


        //constructors
        public Weapon() { } //end default ctor

        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded)
        {
            //If you have ANY properties that have business rules that are based off of any other properties...
            //Set the other properties FIRST!!!
            MaxDamage = maxDamage;
            //since MinDamage business rules depend on the value ot MaxDamage, set it first!!
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }//end FQCTOR


        //methods
        public override string ToString()
        {
            //return base.ToString();
            return string.Format("{0}\t{1} to {2} Damage\nBonus Hit:{3}%\tTwo Handed? {4}",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance,
                (IsTwoHanded) ? "Yes" : "No");
        }//end ToString() override
    }//end class
}//end namespace
