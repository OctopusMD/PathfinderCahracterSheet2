using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Senior_Project
{
    class PlayerCharacter
    {
        private string myName, myPlayerName;                                                            //name of the player's character and player
        private string myAlignment, myHome, myGod;                                                      //background strings
        private string mySkin, myHair, myEyes, myAge, myGender, myHeight, myWeight, mySize, myRace;     //physical description strings
        private string myCondModifiers;                                                                 //conditions that can cause changes in the character's rolls
        private string myLanguages;                                                                     //languages known by the character
        private string myFeats;                                                                         //feats taken by the character
        private string mySpecialAbilities;                                                              //special abilities gained by class, races, items, etc.
        private string myCMBModifiersText;                                                              //spells the character can cast
        private string myLevel;                                                                         //character's class and level
        private int myExp, myNextLevel;                                                                 //character's level, experience, and experience until next level
        private int myStr, myDex, myCon, myInt, myWis, myCha;                                           //stats for the character
        private int myStrAdjust, myDexAdjust, myConAdjust, myIntAdjust, myWisAdjust, myChaAdjust;       //adjustments for each stat
        private int myBaseSpeed, myArmorSpeed, myFlySpeed, mySwimSpeed, myClimbSpeed, myBurrowSpeed;    //movement speed values
        private string myTempSpeedModifier;                                                             //temporary modifiers to speed
        private int myInitiativeMod;                                                                    //initiative bonus
        private int myBAB, myCMBMod, myCMDMod;                                                          //base attack bonus and combat maneuver stats
        private int myCopper, mySilver, myGold, myPlatinum;                                             //money the character owns
        private List<Skill> mySkills;                                                                   //list of skills the character has
        private List<Attack> myAttacks;                                                                 //list of attacks the character has
        private List<string> myGear;                                                                    //list of items held
        private List<int> myGearWeight;                                                                 //weight of items held
        private Defense myDefense;                                                                      //defense stats for the character

        /**/
        /*
        PlayerCharacter::PlayerCharacter() PlayerCharacter::PlayerCharacter()

        NAME

                PlayerCharacter::PlayerCharacter - constructor for the PlayerCharacter
                    class

        SYNOPSIS

                PlayerCharacter::PlayerCharacter(string name, string level, int str, int dex, 
                    int con, int intel, int wis, int cha);
                    name    --> name of the character
                    level   --> level of the character
                    str     --> strength of the character
                    dex     --> dexterity of the character
                    con     --> constitution of the character
                    intel   --> intelligence of the character
                    wis     --> wisdom of the character
                    cha     --> charisma of the character

        DESCRIPTION

                This function creates an object for the PlayerCharacter class using 
                parameters/default values to fill in member variables. It then proceeds
                to fill in list objects with corresponding objects and variables 
                correlating to fields in the form application. It then intializes the
                skills list to match the ~39 skills in pathfinder.

        RETURNS

                none

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public PlayerCharacter(string name="", string level="1", int str=10, int dex=10, int con=10, int intel=10, int wis=10, int cha = 10)
        {
            //save string parameter to corresponding member variable
            myName = name;
            myLevel = level;

            //save integer parameters to corresponding member variables
            myStr = str;
            myDex = dex;
            myCon = con;
            myInt = intel;
            myWis = wis;
            myCha = cha;

            //default values assigned
            //physical description variables
            myPlayerName = "";
            myAlignment = "";
            myHome = "";
            myGod = "";
            mySkin = "";
            myHair = "";
            myEyes = "";
            myAge = "";
            myGender = "";
            myHeight = "";
            mySize = "";
            myRace = "";

            //non-physical description variables
            myCondModifiers = "";
            myLanguages = "";
            myFeats = "";
            mySpecialAbilities = "";
            myCMBModifiersText = "";

            //experience values
            myExp = 0;
            myNextLevel = 0;

            //stat adjustments
            myStrAdjust = 0;
            myDexAdjust = 0;
            myConAdjust = 0;
            myIntAdjust = 0;
            myWisAdjust = 0;
            myChaAdjust = 0;

            //speed stats
            myBaseSpeed = 30;
            myArmorSpeed = 30;
            myFlySpeed = 0;
            mySwimSpeed = 15;
            myClimbSpeed = 15;
            myBurrowSpeed = 0;
            myTempSpeedModifier = "";

            //other member variables
            myInitiativeMod = 0;
            myBAB = 0;
            myCMBMod = 0;
            myCMDMod = 0;

            //money variables
            myCopper = 0;
            mySilver = 0;
            myGold = 0;
            myPlatinum = 0;
            
            //create object member variables
            myDefense = new Defense();

            //create list objects for member variables
            mySkills = new List<Skill>();
            myAttacks = new List<Attack>();
            myGear = new List<string>();
            myGearWeight = new List<int>();

            //add attacks to attack list
            for(int i = 0; i < 5; i++)
            {
                myAttacks.Add(new Attack());
            }

            for (int i = 0; i < 26; i++)
            {
                myGear.Add("");
                myGearWeight.Add(0);
            }

            //add skills to skill list
            mySkills.Add(new Skill("Acrobatics", getTempModifer("dex"), false, "dex"));
            mySkills.Add(new Skill("Appraise", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Bluff", getTempModifer("cha"), false, "cha"));
            mySkills.Add(new Skill("Climb", getTempModifer("str"), false, "str"));
            mySkills.Add(new Skill("Craft", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Craft", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Craft", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Diplomacy", getTempModifer("cha"), false, "cha"));
            mySkills.Add(new Skill("Disable Device", getTempModifer("dex"), false, "dex"));
            mySkills.Add(new Skill("Disguise", getTempModifer("cha"), false, "cha"));
            mySkills.Add(new Skill("Escape Artist", getTempModifer("dex"), false, "dex"));
            mySkills.Add(new Skill("Fly", getTempModifer("dex"), false, "dex"));
            mySkills.Add(new Skill("Handle Animal", getTempModifer("cha"), false, "cha"));
            mySkills.Add(new Skill("Heal", getTempModifer("wis"), false, "wis"));
            mySkills.Add(new Skill("Intimidate", getTempModifer("cha"), false, "cha"));
            mySkills.Add(new Skill("Knowledge(Arcana)", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Knowledge(Dungeoneering)", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Knowledge(Engineering)", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Knowledge(Geography)", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Knowledge(History)", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Knowledge(Local)", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Knowledge(Nature)", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Knowledge(Nobility)", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Knowledge(Planes)", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Knowledge(Religion)", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Linguistics", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Perception", getTempModifer("wis"), false, "wis"));
            mySkills.Add(new Skill("Perform", getTempModifer("cha"), false, "cha"));
            mySkills.Add(new Skill("Perform", getTempModifer("cha"), false, "cha"));
            mySkills.Add(new Skill("Profession", getTempModifer("wis"), false, "wis"));
            mySkills.Add(new Skill("Profession", getTempModifer("wis"), false, "wis"));
            mySkills.Add(new Skill("Ride", getTempModifer("dex"), false, "dex"));
            mySkills.Add(new Skill("Sense Motive", getTempModifer("wis"), false, "wis"));
            mySkills.Add(new Skill("Sleight of Hand", getTempModifer("dex"), false, "dex"));
            mySkills.Add(new Skill("Spellcraft", getTempModifer("int"), false, "int"));
            mySkills.Add(new Skill("Stealth", getTempModifer("dex"), false, "dex"));
            mySkills.Add(new Skill("Survival", getTempModifer("wis"), false, "wis"));
            mySkills.Add(new Skill("Swim", getTempModifer("str"), false, "str"));
            mySkills.Add(new Skill("Use Magic Device", getTempModifer("cha"), false, "con"));
        }
        /**/
        /* PlayerCharacter::PlayerCharacter(string name, string level, int str, int dex, int con, int intel, int wis, int cha); */
        /**/

        /**/
        /*
        PlayerCharacter::save() PlayerCharacter::save()

        NAME

                PlayerCharacter::save - saves data from PlayerCharacter object to text file

        SYNOPSIS

                bool PlayerCharacter::save(string path);
                    path    --> path to file that will be written in

        DESCRIPTION

                This function attempts to create a stream writer object based on the path
                parameter. If it is able to do this it then starts writing all the 
                member variables of the this object and all objects with it to the file.
                If an exception is thrown it is quickly caught and outputted to the console.

        RETURNS

                True if there were no problems writing to the file, false otherwise.

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public bool save(string path)
        {
            StreamWriter writer;    //stream writer to save file

            //file exists already
            if (File.Exists(path))
            {
                //try to create writer to file
                try
                {
                    writer = new StreamWriter(path);
                    writer.AutoFlush = true;
                }
                catch(Exception exp)
                {
                    Console.WriteLine("Error saving to an existing file. " + exp);
                    return false;
                }
            }
            //need to create to file to save to
            else
            {
                //try to create writer and file
                try
                {
                    writer = File.CreateText(path);
                    writer.AutoFlush = true;
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Error saving to a new file. " + exp);
                    return false;
                }
            }

            //output to file
            //character description information
            writer.WriteLine("Description:");
            writer.WriteLine("\tName: " + this.Name);
            writer.WriteLine("\tAlignment: " + this.Alignment);
            writer.WriteLine("\tPlayer: " + this.PlayerName);
            writer.WriteLine("\tCharacter Level: " + this.Level);
            writer.WriteLine("\tDeity: " + this.God);
            writer.WriteLine("\tHomeland: " + this.Home);
            writer.WriteLine("\tRace: " + this.Race);
            writer.WriteLine("\tSize: " + this.Size);
            writer.WriteLine("\tGender: " + this.Gender);
            writer.WriteLine("\tAge: " + this.Age);
            writer.WriteLine("\tHeight: " + this.Height);
            writer.WriteLine("\tWeight: " + this.Weight);
            writer.WriteLine("\tHair: " + this.Hair);
            writer.WriteLine("\tEyes: " + this.Eyes);
            writer.WriteLine("");

            //stats of the character
            writer.WriteLine("Stats:");
            writer.WriteLine("\tStr: " + this.Strength);
            writer.WriteLine("\tDex: " + this.Dexterity);
            writer.WriteLine("\tCon: " + this.Constitution);
            writer.WriteLine("\tInt: " + this.Intelligence);
            writer.WriteLine("\tWis: " + this.Wisdom);
            writer.WriteLine("\tCha: " + this.Charsima);
            writer.WriteLine("");

            //stat adjustments for the character
            writer.WriteLine("Stat Adjustments:");
            writer.WriteLine("\tStr Adjustment: " + this.StrengthAdjust);
            writer.WriteLine("\tDex Adjustment: " + this.DexterityAdjust);
            writer.WriteLine("\tCon Adjustment: " + this.ConstitutionAdjust);
            writer.WriteLine("\tInt Adjustment: " + this.IntelligenceAdjust);
            writer.WriteLine("\tWis Adjustment: " + this.WisdomAdjust);
            writer.WriteLine("\tCha Adjustment: " + this.CharsimaAdjust);
            writer.WriteLine("");

            //text block fields
            writer.WriteLine("Text Blocks:");
            writer.WriteLine("\tCondition Modifiers: " + this.ConditionalModifiers);
            writer.WriteLine("\tLanguages: " + this.Languages);
            writer.WriteLine("\tFeats: " + this.Feats);
            writer.WriteLine("\tSpecial Abilities: " + this.mySpecialAbilities);
            writer.WriteLine("\tSave Modifiers: " + this.Defenses.SavseModifiers);
            writer.WriteLine("\tAC Modifiers: " + this.Defenses.ACModifiers);
            writer.WriteLine("\tCMB Modifiers: " + this.CMBModifiersText);
            writer.WriteLine("");

            //Speed stats for the character
            writer.WriteLine("Speed:");
            writer.WriteLine("\tBase: " + this.BaseSpeed);
            writer.WriteLine("\tArmor: " + this.ArmorSpeed);
            writer.WriteLine("\tFly: " + this.FlySpeed);
            writer.WriteLine("\tSwim: " + this.SwimSpeed);
            writer.WriteLine("\tClimb: " + this.ClimbSpeed);
            writer.WriteLine("\tBurrow: " + this.BurrowSpeed);
            writer.WriteLine("\tTemp Modifiers: " + this.TempSpeedModifiers);
            writer.WriteLine("");

            //Other Modifiers that don't fit into a category
            writer.WriteLine("Other Modifiers:");
            writer.WriteLine("\tInitiative Modifier: " + this.InitiativeModifier);
            writer.WriteLine("\tBAB: " + this.BAB);
            writer.WriteLine("\tCMB: " + this.CMBModifier);
            writer.WriteLine("\tCMD: " + this.CMDModifier);
            writer.WriteLine("");

            //Defensive stats for the character
            writer.WriteLine("Defenses:");
            writer.WriteLine("\tHP: " + this.Defenses.CurrentHP);
            writer.WriteLine("\tTotal HP: " + this.Defenses.TotalHP);
            writer.WriteLine("\tNon Lethal: " + this.Defenses.NonLethal);
            writer.WriteLine("\tArmor: " + this.Defenses.Armor);
            writer.WriteLine("\tShield: " + this.Defenses.Shield);
            writer.WriteLine("\tSize: " + this.Defenses.Size);
            writer.WriteLine("\tNatural Armor: " + this.Defenses.NaturalArmor);
            writer.WriteLine("\tDeflection: " + this.Defenses.Deflection);
            writer.WriteLine("\tMisc: " + this.Defenses.Misc);
            writer.WriteLine("\tModifiers: " + this.Defenses.ACModifiers);
            writer.WriteLine("\tDR: " + this.Defenses.DR);
            writer.WriteLine("\tSR: " + this.Defenses.SR);
            writer.WriteLine("");

            //Saves for the character
            writer.WriteLine("Saves:");
            writer.WriteLine("\tFortitude:");
            writer.WriteLine("\t\tBase: "+this.Defenses.BaseFortitude);
            writer.WriteLine("\t\tMagic: " + this.Defenses.FortitudeMagicBonus);
            writer.WriteLine("\t\tMisc: " + this.Defenses.FortitudeMiscBonus);
            writer.WriteLine("\t\tTemp: " + this.Defenses.FortitudeTempBonus);
            writer.WriteLine("\tReflex:");
            writer.WriteLine("\t\tBase: " + this.Defenses.BaseReflex);
            writer.WriteLine("\t\tMagic: " + this.Defenses.ReflexMagicBonus);
            writer.WriteLine("\t\tMisc: " + this.Defenses.ReflexMiscBonus);
            writer.WriteLine("\t\tTemp: " + this.Defenses.ReflexTempBonus);
            writer.WriteLine("\tWill:");
            writer.WriteLine("\t\tBase: " + this.Defenses.BaseWill);
            writer.WriteLine("\t\tMagic: " + this.Defenses.WillMagicBonus);
            writer.WriteLine("\t\tMisc: " + this.Defenses.WillMiscBonus);
            writer.WriteLine("\t\tTemp: " + this.Defenses.WillTempBonus);
            writer.WriteLine("");

            //attacks of the character
            writer.WriteLine("Attacks:");
            for(int i = 0; i < Attacks.Count; i++)
            {
                writer.WriteLine("\t" + (i + 1) + ":");
                writer.WriteLine("\t\tName: " + this.Attacks[i].Name);
                writer.WriteLine("\t\tAttack Bonus: " + this.Attacks[i].AttackBonus);
                writer.WriteLine("\t\tCritical: " + this.Attacks[i].Critical);
                writer.WriteLine("\t\tType: " + this.Attacks[i].Type);
                writer.WriteLine("\t\tRange: " + this.Attacks[i].Range);
                writer.WriteLine("\t\tAmmunition: " + this.Attacks[i].Ammunition);
                writer.WriteLine("\t\tDamage: " + this.Attacks[i].Damage);
            }
            writer.WriteLine("");

            //skills of the character
            writer.WriteLine("Skills:");
            for (int i = 0; i < Skills.Count; i++)
            {
                writer.WriteLine("\t" + this.Skills[i].Name + ":");
                writer.WriteLine("\t\tRanks: " + this.Skills[i].Rank);
                writer.WriteLine("\t\tMisc Mod: " + this.Skills[i].Bonus);
                writer.WriteLine("\t\tClass Skill: " + this.Skills[i].ClassSkill);
            }
            writer.WriteLine("");

            //AC Items of the character
            writer.WriteLine("AC Items:");
            for (int i = 0; i < Defenses.ACItemNames.Length; i++)
            {
                writer.WriteLine("\t" + (i + 1) + ":");
                writer.WriteLine("\t\tName: " + this.Defenses.ACItemNames[i]);
                writer.WriteLine("\t\tBonus: " + this.Defenses.ACItemStats[i, 0]);
                writer.WriteLine("\t\tType: " + this.Defenses.ACItemStrings[i, 0]);
                writer.WriteLine("\t\tACP: " + this.Defenses.ACItemStats[i, 1]);
                writer.WriteLine("\t\tSpell Failure: " + this.Defenses.ACItemStats[i, 2]);
                writer.WriteLine("\t\tWeight: " + this.Defenses.ACItemStats[i, 3]);
                writer.WriteLine("\t\tProperties: " + this.Defenses.ACItemStrings[i, 1]);
            }
            writer.WriteLine("");

            //gear for the character
            writer.WriteLine("Gear:");
            for (int i = 0; i < this.Gear.Count; i++)
            {
                writer.WriteLine("\t" + (i + 1) + ":");
                writer.WriteLine("\t\tName: " + this.Gear[i]);
                writer.WriteLine("\t\tWeight: " + this.GearWeight[i]);
            }
            writer.WriteLine("");

            //Character's money
            writer.WriteLine("Money:");
            writer.WriteLine("\tCopper: " + this.Copper);
            writer.WriteLine("\tSilver: " + this.Silver);
            writer.WriteLine("\tGold: " + this.Gold);
            writer.WriteLine("\tPlatinum: " + this.Platinum);
            writer.WriteLine("");

            //Characters Experience
            writer.WriteLine("Character Experience:");
            writer.WriteLine("\tExperience: " + this.EXP);
            writer.WriteLine("\tNext Level: " + this.NextLevelEXP);

            return true;
        }
        /**/
        /* bool PlayerCharacter::save(string path); */
        /**/

        /**/
        /*
        PlayerCharacter::load() PlayerCharacter::load()

        NAME

                PlayerCharacter::load - loads data to PlayerCharacter object from text file

        SYNOPSIS

                bool PlayerCharacter::load(string path);
                    path    --> path to file that will be read

        DESCRIPTION

                This function attempts to create a stream reader object based on the path
                parameter. If it is able to do this it then starts reading all the 
                lines from the file and attempts to parse the data into member variables
                of this object and those it owns. This is done until an exception is thrown
                or the end of the file is reached

        RETURNS

                True if there were no problems reading from the file, false otherwise.

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public bool load(string path)
        {
            //file exists 
            if (File.Exists(path))
            {
                //try to create reader to file
                try
                {
                    //create the reader
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string line;    //holds the current line in file
                        int index;      //holds the index to start reading in string line
                        //loop until end of file
                        while ((line = reader.ReadLine()) != null)
                        {
                            //description section of file
                            if (line.IndexOf("Description:") != -1)
                            {
                                //get character Name
                                line = reader.ReadLine();
                                index = line.IndexOf("Name: ") + 6;
                                this.Name = line.Substring(index);
                                //get alignment
                                line = reader.ReadLine();
                                index = line.IndexOf("Alignment: ") + 11;
                                this.Alignment = line.Substring(index);
                                //get player name
                                line = reader.ReadLine();
                                index = line.IndexOf("Player: ") + 8;
                                this.PlayerName = line.Substring(index);
                                //get character level
                                line = reader.ReadLine();
                                index = line.IndexOf("Character Level: ") + 17;
                                this.Level = line.Substring(index);
                                //get religion
                                line = reader.ReadLine();
                                index = line.IndexOf("Deity: ") + 7;
                                this.God = line.Substring(index);
                                //get home
                                line = reader.ReadLine();
                                index = line.IndexOf("Homeland: ") + 10;
                                this.Home = line.Substring(index);
                                //get race
                                line = reader.ReadLine();
                                index = line.IndexOf("Race: ") + 6;
                                this.Race = line.Substring(index);
                                //get size
                                line = reader.ReadLine();
                                index = line.IndexOf("Size: ") + 6;
                                this.Size = line.Substring(index);
                                //get gender
                                line = reader.ReadLine();
                                index = line.IndexOf("Gender: ") + 8;
                                this.Gender = line.Substring(index);
                                //get age
                                line = reader.ReadLine();
                                index = line.IndexOf("Age: ") + 5;
                                this.Age = line.Substring(index);
                                //get height
                                line = reader.ReadLine();
                                index = line.IndexOf("Height: ") + 8;
                                this.Height = line.Substring(index);
                                //get weight
                                line = reader.ReadLine();
                                index = line.IndexOf("Weight: ") + 8;
                                this.Weight = line.Substring(index);
                                //get hair
                                line = reader.ReadLine();
                                index = line.IndexOf("Hair: ") + 6;
                                this.Hair = line.Substring(index);
                                //get eyes
                                line = reader.ReadLine();
                                index = line.IndexOf("Eyes: ") + 6;
                                this.Eyes = line.Substring(index);
                                //extra line
                                reader.ReadLine();
                            }
                            //stats section of file
                            else if (line.IndexOf("Stats:") != -1)
                            {
                                //get strength
                                line = reader.ReadLine();
                                index = line.IndexOf("Str: ") + 5;
                                this.Strength = Convert.ToInt32(line.Substring(index));
                                //get dexterity
                                line = reader.ReadLine();
                                index = line.IndexOf("Dex: ") + 5;
                                this.Dexterity = Convert.ToInt32(line.Substring(index));
                                //get constitution
                                line = reader.ReadLine();
                                index = line.IndexOf("Con: ") + 5;
                                this.Constitution = Convert.ToInt32(line.Substring(index));
                                //get intelligence
                                line = reader.ReadLine();
                                index = line.IndexOf("Int: ") + 5;
                                this.Intelligence = Convert.ToInt32(line.Substring(index));
                                //get wisdom
                                line = reader.ReadLine();
                                index = line.IndexOf("Wis: ") + 5;
                                this.Wisdom = Convert.ToInt32(line.Substring(index));
                                //get charisma
                                line = reader.ReadLine();
                                index = line.IndexOf("Cha: ") + 5;
                                this.Charsima = Convert.ToInt32(line.Substring(index));
                                //extra line
                                reader.ReadLine();
                            }
                            //stat adjustments section of file
                            else if (line.IndexOf("Stat Adjustments:") != -1)
                            {
                                //get strength adjustment
                                line = reader.ReadLine();
                                index = line.IndexOf("Str Adjustment: ") + 16;
                                this.StrengthAdjust = Convert.ToInt32(line.Substring(index));
                                //get dexterity adjustment
                                line = reader.ReadLine();
                                index = line.IndexOf("Dex Adjustment: ") + 16;
                                this.DexterityAdjust = Convert.ToInt32(line.Substring(index));
                                //get constitution adjustment
                                line = reader.ReadLine();
                                index = line.IndexOf("Con Adjustment: ") + 16;
                                this.ConstitutionAdjust = Convert.ToInt32(line.Substring(index));
                                //get intelligence adjustment
                                line = reader.ReadLine();
                                index = line.IndexOf("Int Adjustment: ") + 16;
                                this.IntelligenceAdjust = Convert.ToInt32(line.Substring(index));
                                //get wisdom adjustment
                                line = reader.ReadLine();
                                index = line.IndexOf("Wis Adjustment: ") + 16;
                                this.WisdomAdjust = Convert.ToInt32(line.Substring(index));
                                //get charisma adjustment
                                line = reader.ReadLine();
                                index = line.IndexOf("Cha Adjustment: ") + 16;
                                this.CharsimaAdjust = Convert.ToInt32(line.Substring(index));
                                //extra line
                                reader.ReadLine();
                            }
                            //text blocks section of file
                            else if (line.IndexOf("Text Blocks:") != -1)
                            {
                                //get condition modifiers
                                line = reader.ReadLine();
                                index = line.IndexOf("Condition Modifiers: ") + 21;
                                this.ConditionalModifiers = line.Substring(index);
                                //while data entry is multiple lines
                                line = reader.ReadLine();
                                while (line.IndexOf("Languages: ") == -1)
                                {
                                    //add extra line to conditional modifiers
                                    this.ConditionalModifiers = this.ConditionalModifiers + "\n" + line;
                                    line = reader.ReadLine();
                                }
                                //get languages
                                index = line.IndexOf("Languages: ") + 11;
                                this.Languages = line.Substring(index);
                                //while data entry is multiple lines
                                line = reader.ReadLine();
                                while (line.IndexOf("Feats: ") == -1)
                                {
                                    //add extra line to languages
                                    this.Languages = this.Languages + "\n" + line;
                                    line = reader.ReadLine();
                                }
                                //get feats
                                index = line.IndexOf("Feats: ") + 7;
                                this.Feats = line.Substring(index);
                                //while data entry is multiple lines
                                line = reader.ReadLine();
                                while (line.IndexOf("Special Abilities: ") == -1)
                                {
                                    //add extra line to feats
                                    this.Feats = this.Feats + "\n" + line;
                                    line = reader.ReadLine();
                                }
                                //get special abilities
                                index = line.IndexOf("Special Abilities: ") + 19;
                                this.SpecialAbilities = line.Substring(index);
                                //while data entry is multiple lines
                                line = reader.ReadLine();
                                while (line.IndexOf("Save Modifiers: ") == -1)
                                {
                                    //add extra line to special abilities
                                    this.SpecialAbilities = this.SpecialAbilities + "\n" + line;
                                    line = reader.ReadLine();
                                }
                                //get save modifiers
                                index = line.IndexOf("Save Modifiers: ") + 16;
                                this.Defenses.SavseModifiers = line.Substring(index);
                                //while data entry is multiple lines
                                line = reader.ReadLine();
                                while (line.IndexOf("AC Modifiers: ") == -1)
                                {
                                    //add extra line to special abilities
                                    this.Defenses.SavseModifiers = this.Defenses.SavseModifiers + "\n" + line;
                                    line = reader.ReadLine();
                                }
                                //get AC modifiers
                                index = line.IndexOf("AC Modifiers: ") + 14;
                                this.Defenses.ACModifiers = line.Substring(index);
                                //get AC modifiers
                                line = reader.ReadLine();
                                index = line.IndexOf("CMB Modifiers: ") + 15;
                                this.CMBModifiersText = line.Substring(index);
                                //extra line
                                reader.ReadLine();
                            }
                            //speed section of file
                            else if (line.IndexOf("Speed:") != -1)
                            {
                                //get base speed
                                line = reader.ReadLine();
                                index = line.IndexOf("Base: ") + 6;
                                this.BaseSpeed = Convert.ToInt32(line.Substring(index));
                                //get speed while wearing armor
                                line = reader.ReadLine();
                                index = line.IndexOf("Armor: ") + 7;
                                this.ArmorSpeed = Convert.ToInt32(line.Substring(index));
                                //get fly speed
                                line = reader.ReadLine();
                                index = line.IndexOf("Fly: ") + 5;
                                this.FlySpeed = Convert.ToInt32(line.Substring(index));
                                //get swim speed
                                line = reader.ReadLine();
                                index = line.IndexOf("Swim: ") + 6;
                                this.SwimSpeed = Convert.ToInt32(line.Substring(index));
                                //get climb speed
                                line = reader.ReadLine();
                                index = line.IndexOf("Climb: ") + 7;
                                this.ClimbSpeed = Convert.ToInt32(line.Substring(index));
                                //get burrow speed
                                line = reader.ReadLine();
                                index = line.IndexOf("Burrow: ") + 8;
                                this.BurrowSpeed = Convert.ToInt32(line.Substring(index));
                                //get temporary speed modifiers
                                line = reader.ReadLine();
                                index = line.IndexOf("Temp Modifiers: ") + 16;
                                this.TempSpeedModifiers = line.Substring(index);
                                //while data entry is multiple lines
                                line = reader.ReadLine();
                                while (line != "")
                                {
                                    //add extra line to temporary speed modifiers
                                    this.TempSpeedModifiers = this.TempSpeedModifiers + "\n" + line;
                                    line = reader.ReadLine();
                                }
                            }
                            //other modifiers section of file
                            else if (line.IndexOf("Other Modifiers:") != -1)
                            {
                                //get initiative modifier
                                line = reader.ReadLine();
                                index = line.IndexOf("Initiative Modifier: ") + 21;
                                this.InitiativeModifier = Convert.ToInt32(line.Substring(index));
                                //get BAB
                                line = reader.ReadLine();
                                index = line.IndexOf("BAB: ") + 5;
                                this.BAB = Convert.ToInt32(line.Substring(index));
                                //get CMB
                                line = reader.ReadLine();
                                index = line.IndexOf("CMB: ") + 5;
                                this.CMBModifier = Convert.ToInt32(line.Substring(index));
                                //get CMD
                                line = reader.ReadLine();
                                index = line.IndexOf("CMD: ") + 5;
                                this.CMDModifier = Convert.ToInt32(line.Substring(index));
                                //extra line
                                reader.ReadLine();
                            }
                            //defense section of file
                            else if (line.IndexOf("Defenses:") != -1)
                            {
                                //get HP
                                line = reader.ReadLine();
                                index = line.IndexOf("HP: ") + 4;
                                this.Defenses.CurrentHP = Convert.ToInt32(line.Substring(index));
                                //get total HP
                                line = reader.ReadLine();
                                index = line.IndexOf("Total HP: ") + 10;
                                this.Defenses.TotalHP = Convert.ToInt32(line.Substring(index));
                                //get non lethal damage
                                line = reader.ReadLine();
                                index = line.IndexOf("Non Lethal: ") + 12;
                                this.Defenses.NonLethal = Convert.ToInt32(line.Substring(index));
                                //get armor bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Armor: ") + 7;
                                this.Defenses.Armor = Convert.ToInt32(line.Substring(index));
                                //get shield bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Shield: ") + 8;
                                this.Defenses.Shield = Convert.ToInt32(line.Substring(index));
                                //get size bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Size: ") + 6;
                                this.Defenses.Size = Convert.ToInt32(line.Substring(index));
                                //get armor bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Natural Armor: ") + 15;
                                this.Defenses.NaturalArmor = Convert.ToInt32(line.Substring(index));
                                //get deflection bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Deflection: ") + 12;
                                this.Defenses.Deflection = Convert.ToInt32(line.Substring(index));
                                //get misc bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Misc: ") + 6;
                                this.Defenses.Misc = Convert.ToInt32(line.Substring(index));
                                //get DR
                                line = reader.ReadLine();
                                index = line.IndexOf("DR: ") + 4;
                                this.Defenses.DR = line.Substring(index);
                                //get SR
                                line = reader.ReadLine();
                                index = line.IndexOf("SR: ") + 4;
                                this.Defenses.SR = line.Substring(index);
                                //extra line
                                reader.ReadLine();
                            }
                            //saves section of file
                            else if (line.IndexOf("Saves:") != -1)
                            {
                                //fortitude section
                                line = reader.ReadLine();
                                //get base value
                                line = reader.ReadLine();
                                index = line.IndexOf("Base: ") + 6;
                                this.Defenses.BaseFortitude = Convert.ToInt32(line.Substring(index));
                                //get magic bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Magic: ") + 7;
                                this.Defenses.FortitudeMagicBonus = Convert.ToInt32(line.Substring(index));
                                //get misc bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Misc: ") + 6;
                                this.Defenses.FortitudeMiscBonus = Convert.ToInt32(line.Substring(index));
                                //get temp bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Temp: ") + 6;
                                this.Defenses.FortitudeTempBonus = Convert.ToInt32(line.Substring(index));

                                //reflex section
                                line = reader.ReadLine();
                                //get base value
                                line = reader.ReadLine();
                                index = line.IndexOf("Base: ") + 6;
                                this.Defenses.BaseReflex = Convert.ToInt32(line.Substring(index));
                                //get magic bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Magic: ") + 7;
                                this.Defenses.ReflexMagicBonus = Convert.ToInt32(line.Substring(index));
                                //get misc bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Misc: ") + 6;
                                this.Defenses.ReflexMiscBonus = Convert.ToInt32(line.Substring(index));
                                //get temp bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Temp: ") + 6;
                                this.Defenses.ReflexTempBonus = Convert.ToInt32(line.Substring(index));

                                //will section
                                line = reader.ReadLine();
                                //get base value
                                line = reader.ReadLine();
                                index = line.IndexOf("Base: ") + 6;
                                this.Defenses.BaseWill = Convert.ToInt32(line.Substring(index));
                                //get magic bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Magic: ") + 7;
                                this.Defenses.WillMagicBonus = Convert.ToInt32(line.Substring(index));
                                //get misc bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Misc: ") + 6;
                                this.Defenses.WillMiscBonus = Convert.ToInt32(line.Substring(index));
                                //get temp bonus
                                line = reader.ReadLine();
                                index = line.IndexOf("Temp: ") + 6;
                                this.Defenses.WillTempBonus = Convert.ToInt32(line.Substring(index));

                                //extra line
                                reader.ReadLine();
                            }
                            //attacks section of file
                            else if (line.IndexOf("Attacks:") != -1)
                            {
                                for(int i = 0; i < this.Attacks.Count; i++)
                                {
                                    //skip number line
                                    reader.ReadLine();
                                    //get attack name
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Name: ") + 6;
                                    this.Attacks[i].Name = line.Substring(index);
                                    //get attack bonus
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Attack Bonus: ") + 14;
                                    this.Attacks[i].AttackBonus = Convert.ToInt32(line.Substring(index));
                                    //get critical
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Critical: ") + 10;
                                    this.Attacks[i].Critical = line.Substring(index);
                                    //get type
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Type: ") + 6;
                                    this.Attacks[i].Type = line.Substring(index);
                                    //get range
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Range: ") + 7;
                                    this.Attacks[i].Range = line.Substring(index);
                                    //get ammunition
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Ammunition: ") + 12;
                                    this.Attacks[i].Ammunition = Convert.ToInt32(line.Substring(index));
                                    //get damage
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Damage: ") + 8;
                                    this.Attacks[i].Damage = line.Substring(index);
                                }

                                //extra line
                                reader.ReadLine();
                            }
                            //skills section of file
                            else if (line.IndexOf("Skills:") != -1)
                            {
                                Match mat;                  //object used for regular expressions
                                string exp = @"[A-z()]+";   //regular expression to test against

                                for (int i = 0; i < this.Skills.Count; i++)
                                {
                                    //get skill name
                                    line = reader.ReadLine();
                                    mat = Regex.Match(line, exp);
                                    this.Skills[i].Name = mat.Value;
                                    //get skill ranks
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Ranks: ") + 6;
                                    this.Skills[i].Rank = Convert.ToInt32(line.Substring(index));
                                    //get misc modifier
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Misc Mod: ") + 10;
                                    this.Skills[i].Bonus = Convert.ToInt32(line.Substring(index));
                                    //get if class skill
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Class Skill: ") + 13;
                                    //if string value is true
                                    if (line.Substring(index).IndexOf("True") != -1)
                                    {
                                        this.Skills[i].ClassSkill = true;
                                    }
                                    //string value is false
                                    else
                                    {
                                        this.Skills[i].ClassSkill = false;
                                    }
                                    
                                }

                                //extra line
                                reader.ReadLine();
                            }
                            //skills section of file
                            else if (line.IndexOf("AC Items:") != -1)
                            {
                                for (int i = 0; i < this.Defenses.ACItemNames.Length; i++)
                                {
                                    //skip number line
                                    reader.ReadLine();
                                    //get item name
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Name: ") + 6;
                                    this.Defenses.ACItemNames[i] = line.Substring(index);
                                    //get item bonus
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Bonus: ") + 7;
                                    this.Defenses.ACItemStats[i, 0] = Convert.ToInt32(line.Substring(index));
                                    //get type
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Type: ") + 6;
                                    this.Defenses.ACItemStrings[i, 0] = line.Substring(index);
                                    //get ACP
                                    line = reader.ReadLine();
                                    index = line.IndexOf("ACP: ") + 5;
                                    this.Defenses.ACItemStats[i, 1] = Convert.ToInt32(line.Substring(index));
                                    //get spell failure
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Spell Failure: ") + 15;
                                    this.Defenses.ACItemStats[i, 2] = Convert.ToInt32(line.Substring(index));
                                    //get weight
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Weight: ") + 8;
                                    this.Defenses.ACItemStats[i, 3] = Convert.ToInt32(line.Substring(index));
                                    //get properties
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Properties: ") + 12;
                                    this.Defenses.ACItemStrings[i, 1] = line.Substring(index);
                                }

                                //extra line
                                reader.ReadLine();
                            }
                            //gear section of file
                            else if (line.IndexOf("Gear:") != -1)
                            {
                                for(int i = 0; i < this.Gear.Count; i++)
                                {
                                    //skip number line
                                    reader.ReadLine();
                                    //get item name
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Name: ") + 6;
                                    this.Gear[i] = line.Substring(index);
                                    //get weight
                                    line = reader.ReadLine();
                                    index = line.IndexOf("Weight: ") + 8;
                                    this.GearWeight[i] = Convert.ToInt32(line.Substring(index));
                                }

                                //extra line
                                reader.ReadLine();
                            }
                            //money section of file
                            else if (line.IndexOf("Money:") != -1)
                            {
                                //get copper
                                line = reader.ReadLine();
                                index = line.IndexOf("Copper: ") + 8;
                                this.Copper = Convert.ToInt32(line.Substring(index));
                                //get silver
                                line = reader.ReadLine();
                                index = line.IndexOf("Silver: ") + 8;
                                this.Silver = Convert.ToInt32(line.Substring(index));
                                //get gold
                                line = reader.ReadLine();
                                index = line.IndexOf("Gold: ") + 6;
                                this.Gold = Convert.ToInt32(line.Substring(index));
                                //get platinum
                                line = reader.ReadLine();
                                index = line.IndexOf("Platinum: ") + 10;
                                this.Platinum = Convert.ToInt32(line.Substring(index));

                                //extra line
                                reader.ReadLine();
                            }
                            //experience section of file
                            else if (line.IndexOf("Character Experience:") != -1)
                            {
                                //get experience
                                line = reader.ReadLine();
                                index = line.IndexOf("Experience: ") + 12;
                                this.EXP = Convert.ToInt32(line.Substring(index));
                                //get platinum
                                line = reader.ReadLine();
                                index = line.IndexOf("Next Level: ") + 12;
                                this.NextLevelEXP = Convert.ToInt32(line.Substring(index));

                                //extra line
                                reader.ReadLine();
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Error loading from file. " + exp);
                    return false;
                }
            }
            //file doesn't exist
            else
            {
                Console.WriteLine("File not Found");
                return false;
            }

            return true;
        }
        /**/
        /* bool PlayerCharacter::load(string path); */
        /**/

        /**/
        /*
        PlayerCharacter::getModifier() PlayerCharacter::getModifier()

        NAME

                PlayerCharacter::getModifier - get the modifier of whichever ability score

        SYNOPSIS

                int PlayerCharacter::getModifier(string stat);
                    stat    --> represents which ability score to get the modifier of

        DESCRIPTION

                This function returns the ability score modifier of whichever ability 
                score is given as a parameter by subtracting 10 from the ability score 
                and dividing it by 2.

        RETURNS

                Modifier of the ability score as an integer

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getModifer(string stat)
        {
            int total = 0;  //total ability score

            if (stat.Equals("str"))
            {
                total = myStr;
            }
            else if (stat.Equals("dex"))
            {
                total = myDex;
            }
            else if (stat.Equals("con"))
            {
                total = myCon;
            }
            else if (stat.Equals("int"))
            {
                total = myInt;
            }
            else if (stat.Equals("wis"))
            {
                total = myWis;
            }
            else if (stat.Equals("cha"))
            {
                total = myCha;
            }
            else
            {
                return 0;
            }

            return (total - 10) / 2;
        }
        /**/
        /* int PlayerCharacter::getModifier(string stat); */
        /**/

        /**/
        /*
        PlayerCharacter::getTempModifier() PlayerCharacter::getTempModifier()

        NAME

                PlayerCharacter::getTempModifier - get the temporary modifier of whichever 
                    ability score

        SYNOPSIS

                int PlayerCharacter::getTempModifier(string stat);
                    stat    --> represents which ability score to get the temporary modifier 
                        of

        DESCRIPTION

                This function returns the ability score temporary modifier of whichever 
                ability score is given as a parameter by subtracting 10 from the ability
                score plus the temporary adjustment and dividing it by 2.

        RETURNS

                Temporary modifier of the ability score as an integer

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTempModifer(string stat)
        {
            int total = 0;  //total ability score + adjustment

            if (stat.Equals("str"))
            {
                total = myStr + myStrAdjust;
            }
            else if (stat.Equals("dex"))
            {
                total = myDex + myDexAdjust;
            }
            else if (stat.Equals("con"))
            {
                total = myCon + myConAdjust;
            }
            else if (stat.Equals("int"))
            {
                total = myInt + myIntAdjust;
            }
            else if (stat.Equals("wis"))
            {
                total = myWis + myWisAdjust;
            }
            else if (stat.Equals("cha"))
            {
                total = myCha + myChaAdjust;
            }
            else
            {
                return 0;
            }

            return (total - 10) / 2;
        }
        /**/
        /* int PlayerCharacter::getTempModifier(string stat); */
        /**/

        /**/
        /*
        PlayerCharacter::getInitiativeModifier() PlayerCharacter::getInitiativeModifier()

        NAME

                PlayerCharacter::getInitiativeModifier - get the total initiative bonus

        SYNOPSIS

                int PlayerCharacter::getInitiativeModifier();

        DESCRIPTION

                This function returns total bonus to intiative by adding the temporary
                modifier of dex and the initiative modifer.

        RETURNS

                Total bonus to initiative of the character as an integer value

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getInitiativeModifier()
        {
            return getTempModifer("dex") + myInitiativeMod;
        }
        /**/
        /* int PlayerCharacter::getTempModifier(); */
        /**/

        /**/
        /*
        PlayerCharacter::getCMB() PlayerCharacter::getCMB()

        NAME

                PlayerCharacter::getCMB - get the total combat manuever bonus

        SYNOPSIS

                int PlayerCharacter::getCMB();

        DESCRIPTION

                This function returns total combat manuever bonus by adding the 
                temporary modifier of str, the CMB modifier and the base attack bonus
                of the character.

        RETURNS

                Total combat manuever bonus of the character as an integer value

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getCMB()
        {
            return getTempModifer("str") + myCMBMod + myBAB;
        }
        /**/
        /* int PlayerCharacter::getCMB(); */
        /**/

        /**/
        /*
        PlayerCharacter::getCMD() PlayerCharacter::getCMD()

        NAME

                PlayerCharacter::getCMD - get the total combat manuever defense

        SYNOPSIS

                int PlayerCharacter::getCMD();

        DESCRIPTION

                This function returns total combat manuever defense by adding the 
                temporary modifier of str, the temporary modifier of dex, the CMD 
                modifier, the base attack bonus and 10.

        RETURNS

                Total combat manuever denfense of the character as an integer value

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getCMD()
        {
            return getTempModifer("str") + getTempModifer("dex") + myCMDMod + myBAB + 10;
        }
        /**/
        /* int PlayerCharacter::getCMD(); */
        /**/

        /**/
        /*
        PlayerCharacter::getTotalWeight() PlayerCharacter::getTotalWeight()

        NAME

                PlayerCharacter::getTotalWeight - get the total weight of all gear

        SYNOPSIS

                int PlayerCharacter::getTotalWeight();

        DESCRIPTION

                This function returns total weight of all the gear held by the character
                by getting the sum the weight of each piece of gear in list.

        RETURNS

                Total weight of items held by the character as an integer value

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public int getTotalWeight()
        {
            int total = 0;  //total wieght of items

            //get the weight of items held
            for(int i = 0; i < myGearWeight.Count; i++)
            {
                total += myGearWeight[i];
            }

            return total;
        }
        /**/
        /* int PlayerCharacter::getTotalWeight(); */
        /**/

        //property for the name of the character
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

        //property for the name of the player controlling the character
        public string PlayerName
        {
            //mutator
            set
            {
                myPlayerName = value;
            }
            //accessor
            get
            {
                return myPlayerName;
            }
        }

        //property for the character alignment
        public string Alignment
        {
            //mutator
            set
            {
                myAlignment = value;
            }
            //accessor
            get
            {
                return myAlignment;
            }
        }

        //property for the homeland of the character
        public string Home
        {
            //mutator
            set
            {
                myHome = value;
            }
            //accessor
            get
            {
                return myHome;
            }
        }

        //property for the religion of the character
        public string God
        {
            //mutator
            set
            {
                myGod = value;
            }
            //accessor
            get
            {
                return myGod;
            }
        }

        //property for skin color of the character
        public string Skin
        {
            //mutator
            set
            {
                mySkin = value;
            }
            //accessor
            get
            {
                return mySkin;
            }
        }

        //property for hair color of the character
        public string Hair
        {
            //mutator
            set
            {
                myHair = value;
            }
            //accessor
            get
            {
                return myHair;
            }
        }
        
        //property for eyes color of the character
        public string Eyes
        {
            //mutator
            set
            {
                myEyes = value;
            }
            //accessor
            get
            {
                return myEyes;
            }
        }

        //property for age of the character
        public string Age
        {
            //mutator
            set
            {
                myAge = value;
            }
            //accessor
            get
            {
                return myAge;
            }
        }

        //property for gender of the character
        public string Gender
        {
            //mutator
            set
            {
                myGender = value;
            }
            //accessor
            get
            {
                return myGender;
            }
        }

        //property for height of the character
        public string Height
        {
            //mutator
            set
            {
                myHeight = value;
            }
            //accessor
            get
            {
                return myHeight;
            }
        }

        //property for weight of the character
        public string Weight
        {
            //mutator
            set
            {
                myWeight = value;
            }
            //accessor
            get
            {
                return myWeight;
            }
        }

        //property for size of the character
        public string Size
        {
            //mutator
            set
            {
                mySize = value;
            }
            //accessor
            get
            {
                return mySize;
            }
        }

        //property for Race of the character
        public string Race
        {
            //mutator
            set
            {
                myRace = value;
            }
            //accessor
            get
            {
                return myRace;
            }
        }

        //property for Conditions of the character
        public string ConditionalModifiers
        {
            //mutator
            set
            {
                myCondModifiers = value;
            }
            //accessor
            get
            {
                return myCondModifiers;
            }
        }

        //property for Languages known by the character
        public string Languages
        {
            //mutator
            set
            {
                myLanguages = value;
            }
            //accessor
            get
            {
                return myLanguages;
            }
        }

        //property for Feats taken by the character
        public string Feats
        {
            //mutator
            set
            {
                myFeats = value;
            }
            //accessor
            get
            {
                return myFeats;
            }
        }

        //property for Special Abilities of the character
        public string SpecialAbilities
        {
            //mutator
            set
            {
                mySpecialAbilities = value;
            }
            //accessor
            get
            {
                return mySpecialAbilities;
            }
        }

        //property for Spells known by the character
        public string CMBModifiersText
        {
            //mutator
            set
            {
                myCMBModifiersText = value;
            }
            //accessor
            get
            {
                return myCMBModifiersText;
            }
        }

        //property for level of the character
        public string Level
        {
            //mutator
            set
            {
                myLevel = value;
            }
            //accessor
            get
            {
                return myLevel;
            }
        }

        //property for experience of the character
        public int EXP
        {
            //mutator
            set
            {
                //make sure EXP is a positve number or 0
                if (value >= 0)
                {
                    myExp = value;
                }
                //if not set to 0
                else
                {
                    myExp = 0;
                }
            }
            //accessor
            get
            {
                return myExp;
            }
        }

        //property for experience needed to level up the character
        public int NextLevelEXP
        {
            //mutator
            set
            {
                //make sure EXP is a positve number or 0
                if (value >= 0)
                {
                    myNextLevel = value;
                }
                //if not set to 0
                else
                {
                    myNextLevel = 0;
                }
            }
            //accessor
            get
            {
                return myNextLevel;
            }
        }

        //property for Strength of the character
        public int Strength
        {
            //mutator
            set
            {
                myStr = value;

                //find strength skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("str"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("str");
                    }
                }
            }
            //accessor
            get
            {
                return myStr;
            }
        }

        //property for Dexterity of the character
        public int Dexterity
        {
            //mutator
            set
            {
                myDex = value;

                //find dexterity skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("dex"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("dex");
                    }
                }

                //add stat bonus to defenses
                this.Defenses.Dex = getTempModifer("dex");
                this.Defenses.ReflexAbilityScore = getTempModifer("dex");
            }
            //accessor
            get
            {
                return myDex;
            }
        }

        //property for Constitution of the character
        public int Constitution
        {
            //mutator
            set
            {
                myCon = value;

                //find constitution skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("con"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("con");
                    }
                }

                //add stat bonus to defenses
                this.Defenses.FortitudeAbilityScore = getTempModifer("con");
            }
            //accessor
            get
            {
                return myCon;
            }
        }

        //property for Intelligence of the character
        public int Intelligence
        {
            //mutator
            set
            {
                myInt = value;

                //find intelligence skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("int"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("int");
                    }
                }
            }
            //accessor
            get
            {
                return myInt;
            }
        }

        //property for Wisdom of the character
        public int Wisdom
        {
            //mutator
            set
            {
                myWis = value;

                //find wisdom skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("wis"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("wis");
                    }
                }

                //add stat bonus to defenses
                this.Defenses.WillAbilityScore = getTempModifer("wis");
            }
            //accessor
            get
            {
                return myWis;
            }
        }

        //property for Charisma of the character
        public int Charsima
        {
            //mutator
            set
            {
                myCha = value;

                //find charisma skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("cha"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("cha");
                    }
                }
            }
            //accessor
            get
            {
                return myCha;
            }
        }

        //property for Strength Adjustment of the character
        public int StrengthAdjust
        {
            //mutator
            set
            {
                myStrAdjust = value;

                //find strength skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("str"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("str");
                    }
                }
            }
            //accessor
            get
            {
                return myStrAdjust;
            }
        }

        //property for Dexterity Adjustment of the character
        public int DexterityAdjust
        {
            //mutator
            set
            {
                myDexAdjust = value;

                //find dexterity skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("dex"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("dex");
                    }
                }

                //add stat bonus to defenses
                this.Defenses.Dex = getTempModifer("dex");
                this.Defenses.ReflexAbilityScore = getTempModifer("dex");
            }
            //accessor
            get
            {
                return myDexAdjust;
            }
        }

        //property for Constitution Adjustment of the character
        public int ConstitutionAdjust
        {
            //mutator
            set
            {
                myConAdjust = value;

                //find constitution skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("con"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("con");
                    }
                }

                //add stat bonus to defenses
                this.Defenses.FortitudeAbilityScore = getTempModifer("con");
            }
            //accessor
            get
            {
                return myConAdjust;
            }
        }

        //property for Intelligence Adjustment of the character
        public int IntelligenceAdjust
        {
            //mutator
            set
            {
                myIntAdjust = value;

                //find intelligence skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("int"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("int");
                    }
                }
            }
            //accessor
            get
            {
                return myIntAdjust;
            }
        }

        //property for Wisdom Adjustment of the character
        public int WisdomAdjust
        {
            //mutator
            set
            {
                myWisAdjust = value;

                //find wisdom skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("wis"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("wis");
                    }
                }

                //add stat bonus to defenses
                this.Defenses.WillAbilityScore = getTempModifer("wis");
            }
            //accessor
            get
            {
                return myWisAdjust;
            }
        }

        //property for Charisma Adjustment of the character
        public int CharsimaAdjust
        {
            //mutator
            set
            {
                myChaAdjust = value;

                //find charisma skills
                for (int i = 0; i < this.Skills.Count; i++)
                {
                    if (this.Skills[i].StatName.Equals("cha"))
                    {
                        //change stat bonus to match new value
                        this.Skills[i].StatBonus = getTempModifer("cha");
                    }
                }
            }
            //accessor
            get
            {
                return myChaAdjust;
            }
        }

        //property for Base Land Speed of the character
        public int BaseSpeed
        {
            //mutator
            set
            {
                myBaseSpeed = value;
            }
            //accessor
            get
            {
                return myBaseSpeed;
            }
        }

        //property for Speed of the character while wearing armor
        public int ArmorSpeed
        {
            //mutator
            set
            {
                myArmorSpeed = value;
            }
            //accessor
            get
            {
                return myArmorSpeed;
            }
        }

        //property for Fly Speed of the character
        public int FlySpeed
        {
            //mutator
            set
            {
                myFlySpeed = value;
            }
            //accessor
            get
            {
                return myFlySpeed;
            }
        }

        //property for Swim Speed of the character
        public int SwimSpeed
        {
            //mutator
            set
            {
                mySwimSpeed = value;
            }
            //accessor
            get
            {
                return mySwimSpeed;
            }
        }

        //property for Climb Speed of the character
        public int ClimbSpeed
        {
            //mutator
            set
            {
                myClimbSpeed = value;
            }
            //accessor
            get
            {
                return myClimbSpeed;
            }
        }

        //property for Burrowing Speed of the character
        public int BurrowSpeed
        {
            //mutator
            set
            {
                myBurrowSpeed = value;
            }
            //accessor
            get
            {
                return myBurrowSpeed;
            }
        }

        //property for temporary modifiers to speed for the character
        public string TempSpeedModifiers
        {
            //mutator
            set
            {
                myTempSpeedModifier = value;
            }
            //accessor
            get
            {
                return myTempSpeedModifier;
            }
        }

        //property for initiative modifier of the character
        public int InitiativeModifier
        {
            //mutator
            set
            {
                myInitiativeMod = value;
            }
            //accessor
            get
            {
                return myInitiativeMod;
            }
        }

        //property for Base Attack bonus of the character
        public int BAB
        {
            //mutator
            set
            {
                myBAB = value;
            }
            //accessor
            get
            {
                return myBAB;
            }
        }

        //property for combat maneuver bonus of the character
        public int CMBModifier
        {
            //mutator
            set
            {
                myCMBMod = value;
            }
            //accessor
            get
            {
                return myCMBMod;
            }
        }

        //property for combat maneuver defense modifier of the character
        public int CMDModifier
        {
            //mutator
            set
            {
                myCMDMod = value;
            }
            //accessor
            get
            {
                return myCMDMod;
            }
        }

        //property for copper pieces owned by the character
        public int Copper
        {
            //mutator
            set
            {
                myCopper = value;
            }
            //accessor
            get
            {
                return myCopper;
            }
        }

        //property for silver pieces owned by the character
        public int Silver
        {
            //mutator
            set
            {
                mySilver = value;
            }
            //accessor
            get
            {
                return mySilver;
            }
        }

        //property for gold pieces owned by the character
        public int Gold
        {
            //mutator
            set
            {
                myGold = value;
            }
            //accessor
            get
            {
                return myGold;
            }
        }

        //property for platinum pieces owned by the character
        public int Platinum
        {
            //mutator
            set
            {
                myPlatinum = value;
            }
            //accessor
            get
            {
                return myPlatinum;
            }
        }

        //property for skills of the character
        public List<Skill> Skills
        {
            //mutator
            set
            {
                mySkills = value;
            }
            //accessor
            get
            {
                return mySkills;
            }
        }

        //property for attacks of the character
        public List<Attack> Attacks
        {
            //mutator
            set
            {
                myAttacks = value;
            }
            //accessor
            get
            {
                return myAttacks;
            }
        }

        //property for items being held by the character
        public List<string> Gear
        {
            //mutator
            set
            {
                myGear = value;
            }
            //accessor
            get
            {
                return myGear;
            }
        }

        //property for the weight of the items being held by the character
        public List<int> GearWeight
        {
            //mutator
            set
            {
                myGearWeight = value;
            }
            //accessor
            get
            {
                return myGearWeight;
            }
        }

        //property for defenses of the character
        public Defense Defenses
        {
            //mutator
            set
            {
                myDefense = value;
            }
            //accessor
            get
            {
                return myDefense;
            }
        }
    }
}
