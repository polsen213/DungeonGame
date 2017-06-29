using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //fields
        private int _minDamage;
        //since we will have a business rule on MinDamage property, we must create a full field and full property
        //properties        
        //auto properties first (the ones that don't have business rules)
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than the max damage, cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    //lee than the Max and greater than 0, so let it pass
                    _minDamage = value;
                }//end if
                else
                {
                    //tried to set the value outside of our range
                    _minDamage = 1;
                }//end else
            }//end set
        }//end MinDamage


        //constructors(ctors)
        public Monster() { } //end default

        public Monster(string name, int life, int maxLife, int hitChance, int block, 
            int minDamage, int maxDamage, string description)
        {
            //NO FQCTO in the parent, so we have to handle it all here
            //Remember to SET MAX DAMAGE AND MAXLIFE FIRST!! because other properties depend on them
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }//end Monster FQCTOR


        //methods
        public override string ToString()
        {
            //return base.ToString();
            return string.Format("\n******MONSTER******\n{0}\nLife: {1} of {2}\nDamage: {3} to {4}\n" +
                "Block: {5}\nDescription:\n{6}\n", Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }//end ToString() override

        //Overriding the CalcDamage() to use the properties MinDamage and MaxDamage
        public override int CalcDamage()
        {
            //return base.CalcDamage();
            //base returns 0, not what we want
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
            //If we had a monster that had a min of 2 and a max of 8, if we passed MinDamage, MaxDamage to the Next method
            //it would actually return a random number between 2-7 because the MaxValue is EXCLUSIVE
        }//end CalcDamage() override






    }//end class
}//end namespace
