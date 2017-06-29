using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Koloss : Monster
    {
        //public and a child!
        //created a child monster with at least one unique property, you can use auto properties

        //fields
        //properties
        public bool IsGrown { get; set; }
        
        //constructors / ctors
        //create a FQCTOR that we can use to make a super bad monster and then create a default CTOR
        public Koloss(string name, int life, int maxLife,int hitChance, int block, int minDamage, 
            int maxDamage, string description, bool isGrown)
            :base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsGrown = isGrown;
            //just handle the unique ones
        }//end Koloss FQCTOR

        public Koloss()
        {
            //SET MAX VALUES
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Young Koloss";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "Large and dangerous beasts that the Lord Ruler uses in his army. They are Hemalurgically created, through the use of four hemalurgic spikes stuck through a human body at certain points. ... Koloss are also known for being uncontrollable, except by the Lord Ruler.";
            IsGrown = false;
        }//end default ctor

        //methods
        public override string ToString()
        {
            return base.ToString() + ((IsGrown) ? "Grown" : "Young");
        }//end ToString() override

        //override the block to say if they are grown they get a bonus of 50% to thier block value

        public override int CalcBlock()
        {
            //return base.CalcBlock();
            //typically when dealing with a method that has a return type, you create a variable of the type
            //you need to return with some default value. Then, you write the return line, and then write
            //the code in between
            int calculatedBlock = Block;

            if (IsGrown)
            {
                calculatedBlock += calculatedBlock / 2;
            }//end if
            return calculatedBlock;
        }//end CalcBlock() override
    }//end class
}//end namespace
