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
        private bool myClassSkill;              //whether or not the skill is a class skill
        private string myStatName;              //name of the ascociated character stat
        private int myStatBonus;                //value of the ascociated character stat
        private int mySkillRanks;               //number of ranks put in this skill
        private int[] myBonuses = new int[5];   //stat modifiers from 0:feats, 1:Race, 2:Traits, 3:items, 4:other

        //constructor
        public Skill(string name="", bool classSkill=false, string statName="", int statBonus=0, int skillRank=0)
        {
            //assign parameters to member variables
            myName = name;
            myClassSkill = classSkill;
            myStatName = statName;
            myStatBonus = statBonus;
            mySkillRanks = skillRank;
        }

        //calculate the total bonus for this skill
        public int getTotalBonus()
        {
            //add stat bonus and skill ranks to total
            int total = myStatBonus + mySkillRanks;

            //add class skill bonus if applicable
            if (myClassSkill)
            {
                total += 4;
            }

            //add other bonus to total
            for (int i = 0; i < myBonuses.Length; i++)
            {
                total += myBonuses[i];
            }

            return total;
        }

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

        //property for skill's feat bonus
        public int FeatBonus
        {
            //mutator
            set
            {
                myBonuses[0] = value;
            }
            //accessor
            get
            {
                return myBonuses[0];
            }
        }

        //property for skill's race bonus
        public int RaceBonus
        {
            //mutator
            set
            {
                myBonuses[1] = value;
            }
            //accessor
            get
            {
                return myBonuses[1];
            }
        }

        //property for skill's trait bonus
        public int TraitBonus
        {
            //mutator
            set
            {
                myBonuses[2] = value;
            }
            //accessor
            get
            {
                return myBonuses[2];
            }
        }

        //property for skill's item bonus
        public int ItemBonus
        {
            //mutator
            set
            {
                myBonuses[3] = value;
            }
            //accessor
            get
            {
                return myBonuses[3];
            }
        }

        //property for skill's other bonus
        public int OtherBonus
        {
            //mutator
            set
            {
                myBonuses[4] = value;
            }
            //accessor
            get
            {
                return myBonuses[4];
            }
        }
    }
}
