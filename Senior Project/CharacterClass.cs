using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senior_Project
{
    class CharacterClass
    {
        private int myLevels;                   //levels taken in this class
        private int mySkillsPerLevel;           //skill ranks gained per level
        private int myHitDie;                   //hit die random int range
        private int myBAB;                      //base attack bonus for class
        private int myFort;                     //fortitude save value
        private int myReflex;                   //reflex save value
        private int myWill;                     //will save value
        private string myName;                  //name of the class
        private List<string> myClassSkills;     //list of class skills
        private List<string> myWeaponProf;      //list of weapon profiecencies
        private List<string> myArmorProf;       //list of armor profiecencies
        //private List<Abilities> myAbilities;

        //constructor
        public CharacterClass(int level=1, string name="", int skills = 0, int hitDie=0)
        {
            //set member variables to associated parameters
            myLevels = level;
            myName = name;
            mySkillsPerLevel = skills;
            myHitDie = hitDie;

            //set BAB and saves to default values
            myBAB = 0;
            myFort = 0;
            myReflex = 0;
            myWill = 0;

            //create list objects
            myClassSkills = new List<string>();
            myWeaponProf = new List<string>();
            myArmorProf = new List<string>();
            //myAbilities = new List<string>();
        }

        //get the total number of skill ranks for the character based on class
        public int getTotalSkillRanks()
        {
            return myLevels * mySkillsPerLevel;
        }

        //property for levels in this class
        public int Level
        {
            //mutator
            set
            {
                //make sure level is a positve number
                if (value > 0)
                {
                    myLevels = value;
                }
                //if not set to 1
                else
                {
                    myLevels = 1;
                }
            }
            //accessor
            get
            {
                return myLevels;
            }
        }

        //property for skills gained each level
        public int SkillsPerLevel
        {
            //mutator
            set
            {
                //make sure skills per level is a positve number or 0
                if (value >= 0)
                {
                    mySkillsPerLevel = value;
                }
                //if not set to 1
                else
                {
                    mySkillsPerLevel = 1;
                }
            }
            //accessor
            get
            {
                return mySkillsPerLevel;
            }
        }

        //property for hit die in this class
        public int HitDie
        {
            //mutator
            set
            {
                //make sure hit die are only certain numbers for types of die
                if (value == 4 || value == 6 || value == 8 || value == 10 || value == 12)
                {
                    myHitDie = value;
                }
                //if not set to 6 for d6
                else
                {
                    myHitDie = 6;
                }
            }
            //accessor
            get
            {
                return myHitDie;
            }
        }

        //property for base attack bonus of class
        public int BAB
        {
            //mutator
            set
            {
                //make sure BAB is a positve number or 0
                if (value >= 0)
                {
                    myBAB = value;
                }
                //if not set to 0
                else
                {
                    myBAB = 0;
                }
            }
            //accessor
            get
            {
                return myBAB;
            }
        }

        //property for fortitude save of the class
        public int Fortitude
        {
            //mutator
            set
            {
                //make sure fortitude is a positve number or 0
                if (value >= 0)
                {
                    myFort = value;
                }
                //if not set to 0
                else
                {
                    myFort = 0;
                }
            }
            //accessor
            get
            {
                return myFort;
            }
        }

        //property for reflex save of the class
        public int Reflex
        {
            //mutator
            set
            {
                //make sure reflex is a positve number or 0
                if (value >= 0)
                {
                    myReflex = value;
                }
                //if not set to 0
                else
                {
                    myReflex = 0;
                }
            }
            //accessor
            get
            {
                return myReflex;
            }
        }

        //property for will save of the class
        public int Will
        {
            //mutator
            set
            {
                //make sure will is a positve number or 0
                if (value >= 0)
                {
                    myWill = value;
                }
                //if not set to 0
                else
                {
                    myWill = 0;
                }
            }
            //accessor
            get
            {
                return myWill;
            }
        }

        //property for skills gained each level
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

        //property for the class skills of the class
        public List<string> ClassSkills
        {
            //mutator
            set
            {
                //make sure list is not empty
                if (value.Count != 0)
                {
                    myClassSkills = value;
                }
                //output error message otherwise
                else
                {
                    Console.WriteLine("Could not save list as it was empty.");
                }
            }
            //accessor
            get
            {
                return myClassSkills;
            }
        }

        //property for the weapon proficencies of the class
        public List<string> WeaponProf
        {
            //mutator
            set
            {
                //make sure list is not empty
                if (value.Count != 0)
                {
                    myWeaponProf = value;
                }
                //output error message otherwise
                else
                {
                    Console.WriteLine("Could not save list as it was empty.");
                }
            }
            //accessor
            get
            {
                return myWeaponProf;
            }
        }

        //property for the armor proficencies of the class
        public List<string> ArmorProf
        {
            //mutator
            set
            {
                //make sure list is not empty
                if (value.Count != 0)
                {
                    myArmorProf = value;
                }
                //output error message otherwise
                else
                {
                    Console.WriteLine("Could not save list as it was empty.");
                }
            }
            //accessor
            get
            {
                return myArmorProf;
            }
        }
    }
}
