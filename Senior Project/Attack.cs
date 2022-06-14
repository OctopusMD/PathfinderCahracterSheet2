using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senior_Project
{
    class Attack
    {
        private string myName;      //name of attack
        private string myRange;     //range of the attack in feet
        private string myType;      //type of the attack
        private string myCrit;      //critical threat range and damage multiplier
        private string myDamage;    //damage equation for attack
        private int myAttackBonus;  //number added to roll to hit
        private int myAmmunition;   //number of uses of attack left

        /**/
        /*
        Attack::Attack() Attack::Attack()

        NAME

                Attack::Attack - constructor for the Attack class

        SYNOPSIS

                Attack::Attack( string name, string range, string type, string crit, 
                    string damage, int attackBonus, int ammunition );
                    name        --> name of the attack
                    range       --> range of the attack
                    type        --> type of attack
                    crit        --> critical hit range
                    damage      --> amount of damage done by attack
                    attackBonus --> bonus to roll to hit
                    ammunition  --> number of times the attack can be used

        DESCRIPTION

                This function assigns the parameters/default values to the member 
                variables of the object. 

        RETURNS

                none

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public Attack(string name = "", string range = "", string type = "", string crit = "", string damage = "", int attackBonus = 0, int ammunition = 0)
        {
            //save string parameter to corresponding member variable
            myName = name;
            myRange = range;
            myType = type;
            myCrit = crit;
            myDamage = damage;

            //save integer parameters to corresponding member variables
            myAttackBonus = attackBonus;
            myAmmunition = ammunition;
        }
        /**/
        /* Attack::Attack( string name, string range, string type, string crit, string damage, int attackBonus, int ammunition ); */
        /**/

        //property for the name of the attack
        public string Name
        {
            //mutator
            set
            {
                myName = value;
            }
            //accessor
            get
            {
                return myName;
            }
        }

        //property for the range of the attack
        public string Range
        {
            //mutator
            set
            {
                myRange = value;
            }
            //accessor
            get
            {
                return myRange;
            }
        }

        //property for the type of the attack
        public string Type
        {
            //mutator
            set
            {
                myType = value;
            }
            //accessor
            get
            {
                return myType;
            }
        }

        //property for the critical threat range and damage multiplier of the attack
        public string Critical
        {
            //mutator
            set
            {
                myCrit = value;
            }
            //accessor
            get
            {
                return myCrit;
            }
        }

        //property for the damage equation of the attack
        public string Damage
        {
            //mutator
            set
            {
                myDamage = value;
            }
            //accessor
            get
            {
                return myDamage;
            }
        }

        //property for the to hit stat
        public int AttackBonus
        {
            //mutator
            set
            {
                myAttackBonus = value;
            }
            //accessor
            get
            {
                return myAttackBonus;
            }
        }

        //property for the number of uses for this attack
        public int Ammunition
        {
            //mutator
            set
            {
                myAmmunition = value;
            }
            //accessor
            get
            {
                return myAmmunition;
            }
        }
    }
}
