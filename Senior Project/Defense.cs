using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senior_Project
{
    class Defense
    {
        private int myTotalHP;              //total hit points
        private int myCurrentHP;            //current hit points 
        private int myNonLethal;            //non lethal hit point damage
        private int myArmor;                //bonus to AC based on armor AC
        private int myShield;               //bonus to AC based on shield AC
        private int myDex;                  //bonus to AC based on dexterity
        private int mySizeBonus;            //bonus to AC based size
        private int myNaturalArmor;         //bonus to AC based on natural toughness
        private int myDeflection;           //bonus to AC based on cover
        private int myMisc;                 //other bonus to AC
        private int[] myFortitude;          //modifiers that go into fortitude save 0: base, 1: ability, 2: magic, 4: misc, 5: temporary
        private int[] myReflex;             //modifiers that go into reflex save 0: base, 1: ability, 2: magic, 4: misc, 5: temporary
        private int[] myWill;               //modifiers that go into will save 0: base, 1: ability, 2: magic, 4: misc, 5: temporary
        private int[,] myACItemStats;       //matrix for AC items; columns: stats 0: bonus, 1: check penalty, 2: spell failure, 3: weight
        private string myACModifiers;       //description of my modifiers to AC
        private string mySavesModifiers;    //description of my modifiers to saves
        private string myDR;                //damage resistence and type of damage resisted
        private string mySR;                //spell resistance
        private string[] myACItemNames;     //list of the names of the ac items
        private string[,] myACItemStrings;  //non numeric attributes of the ac items 0: Type 1: Properties

        /**/
        /*
        Defense::Defense() Defense::Defense()

        NAME

                Defense::Defense - constructor for the Defense class

        SYNOPSIS

                Defense::Defense( int totalHP, int currentHP, int nonLethal, 
                    int dex, int armor, int shield, int size, int natural, int
                    deflection, int dodge, int misc, string dr, string acMod, 
                    string saveMod );
                    totalHP     --> total hit points of the character
                    currentHP   --> current hit points of the character
                    nonLethal   --> amount of non lethal damage the character has
                    dex         --> dexterity of the character
                    armor       --> armor bonus to Armor Class
                    shield      --> shield bonus to Armor Class
                    size        --> size bonus to Armor Class
                    natural     --> natural armor bonus to Armor Class
                    deflection  --> deflection bonus to Armor Class
                    dodge       --> dodge bonus to Armor Class
                    misc        --> miscellaneous bonus to Armor Class
                    dr          --> damage reduction of the character
                    acMod       --> modifiers to Armor Class
                    saveMod     --> modifiers to saves

        DESCRIPTION

                This function assigns the parameters/default values to the 
                member variables of the object. Then the arrays and matrices 
                are initialize.  

        RETURNS

                none

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public Defense(int totalHP = 0, int currentHP = 0, int nonLethal = 0, int dex = 0, int armor=0, int shield=0, int size=0, int natural=0, int deflection=0, int dodge=0, int misc=0,
            string dr="", string sr="", string acMod = "", string savesMod = "")
        {
            //save integer parameter to corresponding member variable
            myTotalHP = totalHP;
            myCurrentHP = currentHP;
            myNonLethal = nonLethal;
            myArmor = armor;
            myShield = shield;
            myDex = dex;
            mySizeBonus = size;
            myNaturalArmor = natural;
            myDeflection = deflection;
            myMisc = misc;

            //intialize arrays
            myFortitude = new int[5];
            myReflex = new int[5];
            myWill = new int[5];
            myACItemStats = new int[5, 4];
            myACItemNames = new string[5];
            myACItemStrings = new string[5, 2];

            //save string parameter to corresponding member variable
            myACModifiers = acMod;
            mySavesModifiers = savesMod;
            myDR = dr;
            mySR = sr;
        }
        /**/
        /* Defense::Defense( int totalHP, int currentHP, int nonLethal, int dex, int armor, int shield, int size, int natural, int deflection, int dodge, int misc, string dr, string acMod, string saveMod ); */
        /**/

        /**/
        /*
        Defense::getTotal() Defense::getTotal()

        NAME

                Defense::getTotal - get total armor class

        SYNOPSIS

                int Defense::getTotal();

        DESCRIPTION

                This function adds all the bonuses to AC (armor bonus,
                shield, dexterity, size, natural, deflction, and misc)
                to 10 and return the integer value.

        RETURNS

                Total armor class as an integer value.

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTotal()
        {
            return 10 + myArmor + myShield + myDex + mySizeBonus + myNaturalArmor + myDeflection + myMisc;
        }
        /**/
        /* int Defense::getTotal(); */
        /**/

        /**/
        /*
        Defense::getFlatFooted() Defense::getFlatFooted()

        NAME

                Defense::getFlatFooted - get flat footed armor class

        SYNOPSIS

                int Defense::getFlatFooted();

        DESCRIPTION

                This function adds bonuses to AC (armor bonus,
                shield, size, natural, deflction, and misc)
                to 10 and return the integer value.

        RETURNS

                Flat footed armor class as an integer value.

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getFlatFooted()
        {
            return 10 + myArmor + myShield + mySizeBonus + myNaturalArmor + myDeflection + myMisc;
        }
        /**/
        /* int Defense::getFlatFooted(); */
        /**/

        /**/
        /*
        Defense::getTouch() Defense::getTouch()

        NAME

                Defense::getTouch - get touch armor class

        SYNOPSIS

                int Defense::getTouch();

        DESCRIPTION

                This function adds bonuses to AC (dexterity, size,
                natural, deflction, and misc)to 10 and return the 
                integer value.

        RETURNS

                Touch armor class as an integer value.

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTouch()
        {
            return 10 + myDex + mySizeBonus + myNaturalArmor + myDeflection + myMisc;
        }
        /**/
        /* int Defense::getTouch(); */
        /**/

        /**/
        /*
        Defense::getTotalFortitude() Defense::getTotalFortitude()

        NAME

                Defense::getTotalFortitude - get fortitude save

        SYNOPSIS

                int Defense::getTotalFortitude();

        DESCRIPTION

                This function returns the bonus to fortitude saves
                which it gets by adding all the bonuses stored in 
                the myFortitude array.

        RETURNS

                Total fortitude save as an integer value.

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTotalFortitude()
        {
            int total = 0;  //total fortitude modifier

            //get the sum of all the bonuses
            for (int i = 0; i < myFortitude.Length; i++)
            {
                total += myFortitude[i];
            }

            return total;
        }
        /**/
        /* int Defense::getTotalFortitude(); */
        /**/


        /**/
        /*
        Defense::getTotalReflex() Defense::getTotalReflex()

        NAME

                Defense::getTotalReflex - get reflex save

        SYNOPSIS

                int Defense::getTotalReflex();

        DESCRIPTION

                This function returns the bonus to reflex saves
                which it gets by adding all the bonuses stored in 
                the myReflex array.

        RETURNS

                Total reflex save as an integer value.

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTotalReflex()
        {
            int total = 0;  //total reflex modifier

            //get the sum of all the bonuses
            for (int i = 0; i < myReflex.Length; i++)
            {
                total += myReflex[i];
            }

            return total;
        }
        /**/
        /* int Defense::getTotalReflex(); */
        /**/

        /**/
        /*
        Defense::getTotalWill() Defense::getTotalWill)

        NAME

                Defense::getTotalWill - get will save

        SYNOPSIS

                int Defense::getTotalWill();

        DESCRIPTION

                This function returns the bonus to will saves
                which it gets by adding all the bonuses stored in 
                the myWill array.

        RETURNS

                Total will save as an integer value.

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTotalWill()
        {
            int total = 0;  //total will modifier

            //get the sum of all the bonuses
            for (int i = 0; i < myWill.Length; i++)
            {
                total += myWill[i];
            }

            return total;
        }
        /**/
        /* int Defense::getTotalWill(); */
        /**/

        /**/
        /*
        Defense::getTotalACItemsBonus() Defense::getTotalACItemsBonus()

        NAME

                Defense::getTotalACItemsBonus - get total AC bonus for all 
                    items

        SYNOPSIS

                int Defense::getTotalACItemsBonus();

        DESCRIPTION

                This function returns the sum of all bonuses to AC 
                given by each item in matrix myACItemNames.

        RETURNS

                Total AC bonus for all items as integer value

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTotalACItemsBonus()
        {
            int total = 0;  //total bonus

            //get the sum of all the bonuses
            for (int i = 0; i < 5; i++)
            {
                total += myACItemStats[i, 0];
            }

            return total;
        }
        /**/
        /* int Defense::getTotalACItemsBonus(); */
        /**/

        /**/
        /*
        Defense::getTotalACItemsACP() Defense::getTotalACItemsACP()

        NAME

                Defense::getTotalACItemsACP - get total armor check penalty
                    for all items

        SYNOPSIS

                int Defense::getTotalACItemsACP();

        DESCRIPTION

                This function returns the sum of all armor check penalties
                given by each item in matrix myACItemNames.

        RETURNS

                Total armor check penalty for all items as integer value

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTotalACItemsACP()
        {
            int total = 0;  //total penalty

            //get the sum of all the armor check penalties
            for (int i = 0; i < 5; i++)
            {
                total += myACItemStats[i, 1];
            }

            return total;
        }
        /**/
        /* int Defense::getTotalACItemsACP(); */
        /**/

        /**/
        /*
        Defense::getTotalACItemsSpell() Defense::getTotalACItemsSpell()

        NAME

                Defense::getTotalACItemsSpell - get total spell failure
                    chance for all items

        SYNOPSIS

                int Defense::getTotalACItemsSpell();

        DESCRIPTION

                This function returns the sum of all spell failure chance
                given by each item in matrix myACItemNames.

        RETURNS

                Total spell failure chance for all items as integer value

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTotalACItemsSpell()
        {
            int total = 0;  //total spell failure chance

            //get the sum of all the spell failure chances
            for (int i = 0; i < 5; i++)
            {
                total += myACItemStats[i, 2];
            }

            return total;
        }
        /**/
        /* int Defense::getTotalACItemsSpell(); */
        /**/

        /**/
        /*
        Defense::getTotalACItemsWeight() Defense::getTotalACItemsWeight()

        NAME

                Defense::getTotalACItemsWeight - get total weight for all items

        SYNOPSIS

                int Defense::getTotalACItemsWeight();

        DESCRIPTION

                This function returns the sum of all weight given by each item in 
                matrix myACItemNames.

        RETURNS

                Total weight for all items as integer value

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTotalACItemsWeight()
        {
            int total = 0;  //total weight

            //get the sum of all the weights
            for (int i = 0; i < 5; i++)
            {
                total += myACItemStats[i, 3];
            }

            return total;
        }
        /**/
        /* int Defense::getTotalACItemsWeight(); */
        /**/

        //property for the total hit points 
        public int TotalHP
        {
            //mutator
            set
            {
                myTotalHP = value;
            }
            //accessor
            get
            {
                return myTotalHP;
            }
        }

        //property for the current hit points 
        public int CurrentHP
        {
            //mutator
            set
            {
                myCurrentHP = value;
            }
            //accessor
            get
            {
                return myCurrentHP;
            }
        }

        //property for the non lethal hit points damage
        public int NonLethal
        {
            //mutator
            set
            {
                myNonLethal = value;
            }
            //accessor
            get
            {
                return myNonLethal;
            }
        }

        //property for the armor bonus
        public int Armor
        {
            //mutator
            set
            {
                myArmor = value;
            }
            //accessor
            get
            {
                return myArmor;
            }
        }

        //property for the shield bonus
        public int Shield
        {
            //mutator
            set
            {
                myShield = value;
            }
            //accessor
            get
            {
                return myArmor;
            }
        }

        //property for the dexterity bonus
        public int Dex
        {
            //mutator
            set
            {
                myDex = value;
            }
            //accessor
            get
            {
                return myDex;
            }
        }

        //property for the size bonus
        public int Size
        {
            //mutator
            set
            {
                mySizeBonus = value;
            }
            //accessor
            get
            {
                return mySizeBonus;
            }
        }

        //property for the natural armor bonus
        public int NaturalArmor
        {
            //mutator
            set
            {
                myNaturalArmor = value;
            }
            //accessor
            get
            {
                return myNaturalArmor;
            }
        }

        //property for the deflection bonus
        public int Deflection
        {
            //mutator
            set
            {
                myDeflection = value;
            }
            //accessor
            get
            {
                return myDeflection;
            }
        }

        //property for the misc bonus
        public int Misc
        {
            //mutator
            set
            {
                myMisc = value;
            }
            //accessor
            get
            {
                return myMisc;
            }
        }

        //property for the base fortitude save
        public int BaseFortitude
        {
            //mutator
            set
            {
                myFortitude[0] = value;
            }
            //accessor
            get
            {
                return myFortitude[0];
            }
        }

        //property for the fortitude ability score bonus
        public int FortitudeAbilityScore
        {
            //mutator
            set
            {
                myFortitude[1] = value;
            }
            //accessor
            get
            {
                return myFortitude[1];
            }
        }

        //property for the fortitude magic bonus
        public int FortitudeMagicBonus
        {
            //mutator
            set
            {
                myFortitude[2] = value;
            }
            //accessor
            get
            {
                return myFortitude[2];
            }
        }

        //property for the fortitude misc bonus
        public int FortitudeMiscBonus
        {
            //mutator
            set
            {
                myFortitude[3] = value;
            }
            //accessor
            get
            {
                return myFortitude[3];
            }
        }

        //property for the fortitude temp bonus
        public int FortitudeTempBonus
        {
            //mutator
            set
            {
                myFortitude[4] = value;
            }
            //accessor
            get
            {
                return myFortitude[4];
            }
        }

        //property for the base reflex save
        public int BaseReflex
        {
            //mutator
            set
            {
                myReflex[0] = value;
            }
            //accessor
            get
            {
                return myReflex[0];
            }
        }

        //property for the reflex ability score bonus
        public int ReflexAbilityScore
        {
            //mutator
            set
            {
                myReflex[1] = value;
            }
            //accessor
            get
            {
                return myReflex[1];
            }
        }

        //property for the reflex magic bonus
        public int ReflexMagicBonus
        {
            //mutator
            set
            {
                myReflex[2] = value;
            }
            //accessor
            get
            {
                return myReflex[2];
            }
        }

        //property for the reflex misc bonus
        public int ReflexMiscBonus
        {
            //mutator
            set
            {
                myReflex[3] = value;
            }
            //accessor
            get
            {
                return myReflex[3];
            }
        }

        //property for the reflex temp bonus
        public int ReflexTempBonus
        {
            //mutator
            set
            {
                myReflex[4] = value;
            }
            //accessor
            get
            {
                return myReflex[4];
            }
        }

        //property for the base will save
        public int BaseWill
        {
            //mutator
            set
            {
                myWill[0] = value;
            }
            //accessor
            get
            {
                return myWill[0];
            }
        }

        //property for the will ability score bonus
        public int WillAbilityScore
        {
            //mutator
            set
            {
                myWill[1] = value;
            }
            //accessor
            get
            {
                return myWill[1];
            }
        }

        //property for the will magic bonus
        public int WillMagicBonus
        {
            //mutator
            set
            {
                myWill[2] = value;
            }
            //accessor
            get
            {
                return myWill[2];
            }
        }

        //property for the will misc bonus
        public int WillMiscBonus
        {
            //mutator
            set
            {
                myWill[3] = value;
            }
            //accessor
            get
            {
                return myWill[3];
            }
        }

        //property for the will temp bonus
        public int WillTempBonus
        {
            //mutator
            set
            {
                myWill[4] = value;
            }
            //accessor
            get
            {
                return myWill[4];
            }
        }

        //property for the ACItems stats matrix
        public int[,] ACItemStats
        {
            //mutator
            set
            {
                myACItemStats = value;
            }
            //accessor
            get
            {
                return myACItemStats;
            }
        }

        //property for the desciption of AC modifiers
        public string ACModifiers
        {
            //mutator
            set
            {
                myACModifiers = value;
            }
            //accessor
            get
            {
                return myACModifiers;
            }
        }

        //property for the desciption of saves modifiers
        public string SavseModifiers
        {
            //mutator
            set
            {
                mySavesModifiers = value;
            }
            //accessor
            get
            {
                return mySavesModifiers;
            }
        }

        //property for the damage resistance
        public string DR
        {
            //mutator
            set
            {
                myDR = value;
            }
            //accessor
            get
            {
                return myDR;
            }
        }

        //property for the spell resistance
        public string SR
        {
            //mutator
            set
            {
                mySR = value;
            }
            //accessor
            get
            {
                return mySR;
            }
        }

        //property for the ACItems names array
        public string[] ACItemNames
        {
            //mutator
            set
            {
                myACItemNames = value;
            }
            //accessor
            get
            {
                return myACItemNames;
            }
        }

        //property for the ACItems strings matrix
        public string[,] ACItemStrings
        {
            //mutator
            set
            {
                myACItemStrings = value;
            }
            //accessor
            get
            {
                return myACItemStrings;
            }
        }
    }
}
