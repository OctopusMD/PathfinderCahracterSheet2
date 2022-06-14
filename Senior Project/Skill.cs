using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senior_Project
{
    class Skill
    {
        private string myName;                  //name of the skill
        private string myStatName;              //name of the ascociated character stat
        private bool myClassSkill;              //whether or not the skill is a class skill
        private int myStatBonus;                //value of the ascociated character stat
        private int mySkillRanks;               //number of ranks put in this skill
        private int myBonus;                    //modifiers to the skill roll

        /**/
        /*
        Skill::Skill() Skill::Skill()

        NAME

                Skill::Skill - constructor for the skill class

        SYNOPSIS

                Skilll::Skill( string name, int statBonus, bool classSkill, string statName, 
                    int skillRank );
                    name        --> name of the skill
                    statBonus   --> ability score bonus to skill roll
                    classSkill  --> whether or not skill is a class skill
                    statName    --> name of ability score that gives bonus
                    skillRank   --> number of ranks put into this skill

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
        public Skill(string name="", int statBonus = 0, bool classSkill=false, string statName="", int skillRank=0)
        {
            //assign parameters to member variables
            myName = name;
            myClassSkill = classSkill;
            myStatName = statName;
            myStatBonus = statBonus;
            mySkillRanks = skillRank;
        }
        /**/
        /* Skilll::Skill( string name, int statBonus, bool classSkill, strin statName, int skillRank ); */
        /**/

        /**/
        /*
        Skill::getTotalBonus() Skill::getTotalBonus()

        NAME

                Skill::getTotalBonus - get the total bonus to skill

        SYNOPSIS

                int Skilll::getTotalBonus();

        DESCRIPTION

                This function adds the the skill ranks and stat bonus to
                the total. Then if it's a class skill add 3 to the total.
                Then add the miscelleous bonus to total and return the result

        RETURNS

                Returns the total of bonus to skill roll as an integer value.

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTotalBonus()
        {
            //add stat bonus and skill ranks to total
            int total = myStatBonus + mySkillRanks;

            //add class skill bonus if applicable
            if (myClassSkill)
            {
                total += 3;
            }

            //add bonus to skill
            total += myBonus;

            return total;
        }
        /**/
        /* int Skilll::getTotalBonus(); */
        /**/

        //property for skill name
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

        //property for whether or not skill is a class skill
        public bool ClassSkill
        {
            //mutator
            set
            {
                myClassSkill = value;
            }
            //accessor
            get
            {
                return myClassSkill;
            }
        }

        //property for skill's correponding stat's name
        public string StatName
        {
            //mutator
            set
            {
                myStatName = value;
            }
            //accessor
            get
            {
                return myStatName;
            }
        }

        //property for skill's corresponding stat's modifier
        public int StatBonus
        {
            //mutator
            set
            {
                myStatBonus = value;
            }
            //accessor
            get
            {
                return myStatBonus;
            }
        }

        //property for skill's ranks
        public int Rank
        {
            //mutator
            set
            {
                //make sure the number of ranks isn't a negative number
                if (value >= 0)
                {
                    mySkillRanks = value;
                }
                //if it's negative set it equal to 0
                else
                {
                    mySkillRanks = 0;
                }
            }
            //accessor
            get
            {
                return mySkillRanks;
            }
        }

        //property for skill's bonus
        public int Bonus
        {
            //mutator
            set
            {
                myBonus = value;
            }
            //accessor
            get
            {
                return myBonus;
            }
        }
    }
}
