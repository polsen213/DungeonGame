using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //make it public
    //The abstract modifier indicates that the thing being modified has an incomplete implementation.
    //The abstract modifier can be used with classes, methods and properties. Use the abstract modifier
    //in a class declaration to indicate that the class is intended to only be a base (parent) class of 
    //other classes.
    public abstract class Character
    {
        private int _life;

        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                //business rule, like should NOT be more than MaxLife
                if (value <= MaxLife)
                {
                    //good to go!
                    _life = value;
                }//end if
                else
                {
                    _life = MaxLife;
                }//end else
            }//end set
        }//end Life

        //CTORs
        //Since we don't inherit constructors and we already did a lot of work defining the Player FQCTOR, 
        //we will not create any here. We still get the free default one, but we will be unable to use it 
        //since this class is abstract

        //methods
        //No need to override the ToString(). We will bever create a Character object, it will always be
        //a Player or a Monster

        //Below are methods we want to be inherited by Player and Monster, so we are creating default 
        //versions of each method here, that the child classes will use if they do NOT override it
        public virtual int CalcBlock()
        {
            //To be able to override this in a child class make it VIRTUAL

            //This basic version just returns block, but this will give us the option to do something 
            //different in child classes
            return Block;
        }//end CalcBlock()

        //MINI LAB!
        //Make CalcHitChanceMethod and make it overridable

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance

        //make CalcDamage and just return 0
        public virtual int CalcDamage()
        {
            return 0;
            //Starting this with just returning 0. So that we can use the method from an instance of
            //a Character, we will override the method in Monster and Player.
            //Later, we will learn about abstract methods, which is another way to accomplich this.
        }//end CalcDamage()

    }//end class
}//end namespace
