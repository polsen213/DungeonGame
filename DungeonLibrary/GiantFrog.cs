using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class GiantFrog : Monster
    {
        //fields
        //properties
        public bool IsSlimy { get; set; }

        //constructors
        public GiantFrog(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isSlimy)
            :base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsSlimy = isSlimy;
        }//end GiantFrog() FQCTOR

        public GiantFrog()
        {
            //SET MAX VALUES
            MaxLife = 10;
            MaxDamage = 6;
            Name = "Giant Evil Frog";
            Life = 10;
            HitChance = 50;
            Block = 35;
            MinDamage = 2;
            Description = "A Giant Evil Frog";
            IsSlimy = false;
        }//end default ctor

        //methods
        public override string ToString()
        {
            return base.ToString() + ((IsSlimy ? "Slimy" : ""));
        }//end ToString() overide

        public override int CalcBlock()
        {
            //return base.CalcBlock();
            int calculatedBlock = Block;

            if (IsSlimy)
            {
                calculatedBlock += calculatedBlock / 2;
            }//end if
            return calculatedBlock;
        }//end CalcBlock() overrride
    }//end class
}//end namespace
