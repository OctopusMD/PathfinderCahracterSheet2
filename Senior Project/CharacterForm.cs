using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senior_Project
{
    public partial class CharacterForm : Form
    {
        private PlayerCharacter myCharacter;    //Player character the form represents

        /**/
        /*
        CharacterForm::CharacterForm() CharacterForm::CharacterForm()

        NAME

                CharacterForm::CharacterForm - constructor for the form object

        SYNOPSIS

                CharacterForm::CharacterForm();

        DESCRIPTION

                This function initializes the myCharacter memember variables (creating
                the character) and them intializes the form application.

        RETURNS

                none

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public CharacterForm()
        {
            myCharacter = new PlayerCharacter();

            InitializeComponent();
        }
        /**/
        /* CharacterForm::CharacterForm(); */
        /**/

        /**/
        /*
        CharacterForm::updatePage1_Click() CharacterForm::updatePage1_Click()

        NAME

                CharacterForm::updatePage1_Click - update the page and character when
                    updatePage1 button is clicked

        SYNOPSIS

                void CharacterForm::updatePage1_Click(object sender, EventArgs e);
                    sender  --> object that sent the request
                    e       --> event of the button being clicked

        DESCRIPTION

                This function calls functions to update the character and form page when
                updatePage1 button is clicked by the user.

        RETURNS

                none

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        private void updatePage1_Click(object sender, EventArgs e)
        {
            //call update functions
            updateCharacter();
            updatePage();
        }
        /**/
        /* void CharacterForm::updatePage1_Click( object sender, EventArgs e ); */
        /**/

        /**/
        /*
        CharacterForm::updatePage2_Click() CharacterForm::updatePage2_Click()

        NAME

                CharacterForm::updatePage2_Click - update the page and character when
                    updatePage2 button is clicked

        SYNOPSIS

                void CharacterForm::updatePage2_Click(object sender, EventArgs e);
                    sender  --> object that sent the request
                    e       --> event of the button being clicked

        DESCRIPTION

                This function calls functions to update the character and form page when
                updatePage2 button is clicked by the user.

        RETURNS

                none

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        private void updatePage2_Click(object sender, EventArgs e)
        {
            //call update functions
            updateCharacter();
            updatePage();
        }
        /**/
        /* void CharacterForm::updatePage2_Click( object sender, EventArgs e ); */
        /**/

        /**/
        /*
        CharacterForm::saveBtn_Click() CharacterForm::saveBtn_Click()

        NAME

                CharacterForm::saveBtn_Click - update the page and character when
                    and save current character to file

        SYNOPSIS

                void CharacterForm::saveBtn_Click(object sender, EventArgs e);
                    sender  --> object that sent the request
                    e       --> event of the button being clicked

        DESCRIPTION

                This function calls functions to update the character and form page when
                saveBtn button is clicked by the user. Then it takes the text from 
                savePathText text field and calls the PlayerCharacter save function with
                it.

        RETURNS

                none

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        private void saveBtn_Click(object sender, EventArgs e)
        {
            //call update functions
            updateCharacter();
            updatePage();

            //save to file
            myCharacter.save(this.savePathText.Text);
        }
        /**/
        /* void CharacterForm::saveBtn_Click( object sender, EventArgs e ); */
        /**/

        /**/
        /*
        CharacterForm::loadBtn_Click() CharacterForm::loadBtn_Click()

        NAME

                CharacterForm::loadBtn_Click - load character from fileand then update
                    page

        SYNOPSIS

                void CharacterForm::loadBtn_Click(object sender, EventArgs e);
                    sender  --> object that sent the request
                    e       --> event of the button being clicked

        DESCRIPTION

                This function calls PlayerCharacter's load function using the text from
                text field savePathText and then updates the page to match the character.

        RETURNS

                none

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        private void loadBtn_Click(object sender, EventArgs e)
        {
            //load from file
            myCharacter.load(this.savePathText.Text);

            //call update functions
            updatePage();
        }
        /**/
        /* void CharacterForm::loadBtn_Click( object sender, EventArgs e ); */
        /**/

        /**/
        /*
        CharacterForm::updateCharacter() CharacterForm::updateCharacter()

        NAME

                CharacterForm::updateCharacter - update myCharacter to match what
                    the form states

        SYNOPSIS

                void CharacterForm::updateCharacter();

        DESCRIPTION

                This function assigns the member variables of myCharacter values that 
                match those given by the user via the .NET form. This is done by going
                through each member variable and assigning it the value of its 
                corresponding field on the form and parsing text data when necessary.

        RETURNS

                none

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public void updateCharacter()
        {
            try
            {
                //get character description information
                myCharacter.Name = this.characterName.Text;
                myCharacter.Alignment = this.alignment.Text;
                myCharacter.PlayerName = this.player.Text;
                myCharacter.Level = this.characterLevel.Text;
                myCharacter.God = this.deity.Text;
                myCharacter.Home = this.homeland.Text;
                myCharacter.Race = this.race.Text;
                myCharacter.Size = this.sizeField.Text;
                myCharacter.Gender = this.gender.Text;
                myCharacter.Age = this.age.Text;
                myCharacter.Height = this.height.Text;
                myCharacter.Weight = this.weight.Text;
                myCharacter.Hair = this.hair.Text;
                myCharacter.Eyes = this.eyes.Text;

                //get character stats
                myCharacter.Strength = Convert.ToInt32(this.strAbilityScore.Text);
                myCharacter.StrengthAdjust = Convert.ToInt32(this.strTempAdj.Text);
                myCharacter.Dexterity = Convert.ToInt32(this.dexAbilityScore.Text);
                myCharacter.DexterityAdjust = Convert.ToInt32(this.dexTempAdj.Text);
                myCharacter.Constitution = Convert.ToInt32(this.conAbilityScore.Text);
                myCharacter.ConstitutionAdjust = Convert.ToInt32(this.conTempAdj.Text);
                myCharacter.Intelligence = Convert.ToInt32(this.intAbilityScore.Text);
                myCharacter.IntelligenceAdjust = Convert.ToInt32(this.intTempAdj.Text);
                myCharacter.Wisdom = Convert.ToInt32(this.wisAbilityScore.Text);
                myCharacter.WisdomAdjust = Convert.ToInt32(this.wisTempAdj.Text);
                myCharacter.Charsima = Convert.ToInt32(this.chaAbilityScore.Text);
                myCharacter.CharsimaAdjust = Convert.ToInt32(this.chaTempAdj.Text);

                //get text blocks
                myCharacter.ConditionalModifiers = this.conditionalModifiers.Text;
                myCharacter.Languages = this.languages.Text;
                myCharacter.Feats = this.feats.Text;
                myCharacter.SpecialAbilities = this.specialAbilities.Text;
                myCharacter.Defenses.SavseModifiers = this.savesModifiers.Text;
                myCharacter.Defenses.ACModifiers = this.ACModifiers.Text;
                myCharacter.CMBModifiersText = this.CMBModifiers.Text;

                //get speed stats
                myCharacter.BaseSpeed = Convert.ToInt32(this.baseSpeed.Text);
                myCharacter.ArmorSpeed = Convert.ToInt32(this.armorSpeed.Text);
                myCharacter.FlySpeed = Convert.ToInt32(this.flySpeed.Text);
                myCharacter.SwimSpeed = Convert.ToInt32(this.swimSpeed.Text);
                myCharacter.ClimbSpeed = Convert.ToInt32(this.climbSpeed.Text);
                myCharacter.BurrowSpeed = Convert.ToInt32(this.burrowSpeed.Text);
                myCharacter.TempSpeedModifiers = this.tempSpeed.Text;

                //get other modifiers
                myCharacter.InitiativeModifier = Convert.ToInt32(this.initiativeMiscMod.Text);
                myCharacter.BAB = Convert.ToInt32(this.BAB.Text);
                myCharacter.CMBModifier = Convert.ToInt32(this.CMBSizeMod.Text);
                myCharacter.CMDModifier = Convert.ToInt32(this.CMDSizeMod.Text);

                //get defenses
                myCharacter.Defenses.CurrentHP = Convert.ToInt32(this.currentHP.Text);
                myCharacter.Defenses.TotalHP = Convert.ToInt32(this.totalHP.Text);
                myCharacter.Defenses.NonLethal = Convert.ToInt32(this.nonLethalDam.Text);
                myCharacter.Defenses.Armor = Convert.ToInt32(this.armorBonus.Text);
                myCharacter.Defenses.Shield = Convert.ToInt32(this.shieldBonus.Text);
                myCharacter.Defenses.Size = Convert.ToInt32(this.sizeMod.Text);
                myCharacter.Defenses.NaturalArmor = Convert.ToInt32(this.naturalArmor.Text);
                myCharacter.Defenses.Deflection = Convert.ToInt32(this.deflectionMod.Text);
                myCharacter.Defenses.Misc = Convert.ToInt32(this.armorMiscMod.Text);
                myCharacter.Defenses.DR = this.DR.Text;
                myCharacter.Defenses.SR = this.SR.Text;

                //get saves
                //fortitude save stats
                myCharacter.Defenses.BaseFortitude = Convert.ToInt32(this.baseFortitude.Text);
                myCharacter.Defenses.FortitudeMagicBonus = Convert.ToInt32(this.fortitudeMagicMod.Text);
                myCharacter.Defenses.FortitudeMiscBonus = Convert.ToInt32(this.fortitudeMiscMod.Text);
                myCharacter.Defenses.FortitudeTempBonus = Convert.ToInt32(this.fortitudeTempMod.Text);
                //reflex save stats
                myCharacter.Defenses.BaseReflex = Convert.ToInt32(this.baseReflex.Text);
                myCharacter.Defenses.ReflexMagicBonus = Convert.ToInt32(this.reflexMagicMod.Text);
                myCharacter.Defenses.ReflexMiscBonus = Convert.ToInt32(this.reflexMiscMod.Text);
                myCharacter.Defenses.ReflexTempBonus = Convert.ToInt32(this.reflexTempMod.Text);
                //will save stats
                myCharacter.Defenses.BaseWill = Convert.ToInt32(this.baseWill.Text);
                myCharacter.Defenses.WillMagicBonus = Convert.ToInt32(this.willMagicMod.Text);
                myCharacter.Defenses.WillMiscBonus = Convert.ToInt32(this.willMiscMod.Text);
                myCharacter.Defenses.WillTempBonus = Convert.ToInt32(this.willTempMod.Text);

                //get attacks
                //attack 1
                myCharacter.Attacks[0].Name = this.weaponName1.Text;
                myCharacter.Attacks[0].AttackBonus = Convert.ToInt32(this.attackBonus1.Text);
                myCharacter.Attacks[0].Critical = this.critical1.Text;
                myCharacter.Attacks[0].Type = this.weaponType1.Text;
                myCharacter.Attacks[0].Range = this.range1.Text;
                myCharacter.Attacks[0].Ammunition = Convert.ToInt32(this.ammunition1.Text);
                myCharacter.Attacks[0].Damage = this.damage1.Text;
                //attack 2
                myCharacter.Attacks[1].Name = this.weaponName2.Text;
                myCharacter.Attacks[1].AttackBonus = Convert.ToInt32(this.attackBonus2.Text);
                myCharacter.Attacks[1].Critical = this.critical2.Text;
                myCharacter.Attacks[1].Type = this.weaponType2.Text;
                myCharacter.Attacks[1].Range = this.range2.Text;
                myCharacter.Attacks[1].Ammunition = Convert.ToInt32(this.ammunition2.Text);
                myCharacter.Attacks[1].Damage = this.damage2.Text;
                //attack 3
                myCharacter.Attacks[2].Name = this.weaponName3.Text;
                myCharacter.Attacks[2].AttackBonus = Convert.ToInt32(this.attackBonus3.Text);
                myCharacter.Attacks[2].Critical = this.critical3.Text;
                myCharacter.Attacks[2].Type = this.weaponType3.Text;
                myCharacter.Attacks[2].Range = this.range3.Text;
                myCharacter.Attacks[2].Ammunition = Convert.ToInt32(this.ammunition3.Text);
                myCharacter.Attacks[2].Damage = this.damage3.Text;
                //attack 4
                myCharacter.Attacks[3].Name = this.weaponName4.Text;
                myCharacter.Attacks[3].AttackBonus = Convert.ToInt32(this.attackBonus4.Text);
                myCharacter.Attacks[3].Critical = this.critical4.Text;
                myCharacter.Attacks[3].Type = this.weaponType4.Text;
                myCharacter.Attacks[3].Range = this.range4.Text;
                myCharacter.Attacks[3].Ammunition = Convert.ToInt32(this.ammunition4.Text);
                myCharacter.Attacks[3].Damage = this.damage4.Text;
                //attack 5
                myCharacter.Attacks[4].Name = this.weaponName5.Text;
                myCharacter.Attacks[4].AttackBonus = Convert.ToInt32(this.attackBonus5.Text);
                myCharacter.Attacks[4].Critical = this.critical5.Text;
                myCharacter.Attacks[4].Type = this.weaponType5.Text;
                myCharacter.Attacks[4].Range = this.range5.Text;
                myCharacter.Attacks[4].Ammunition = Convert.ToInt32(this.ammunition5.Text);
                myCharacter.Attacks[4].Damage = this.damage5.Text;

                //get skills
                //acrobatics
                myCharacter.Skills[0].Rank = Convert.ToInt32(this.acrobaticRanks.Text);
                myCharacter.Skills[0].Bonus = Convert.ToInt32(this.acrobaticsMiscMod.Text);
                myCharacter.Skills[0].ClassSkill = this.acrobaticsCheckbox.Checked;
                //appraise
                myCharacter.Skills[1].Rank = Convert.ToInt32(this.appraiseRanks.Text);
                myCharacter.Skills[1].Bonus = Convert.ToInt32(this.appraiseMiscMod.Text);
                myCharacter.Skills[1].ClassSkill = this.appraiseCheckbox.Checked;
                //bluff
                myCharacter.Skills[2].Rank = Convert.ToInt32(this.bluffRanks.Text);
                myCharacter.Skills[2].Bonus = Convert.ToInt32(this.bluffMiscMod.Text);
                myCharacter.Skills[2].ClassSkill = this.bluffCheckbox.Checked;
                //climb
                myCharacter.Skills[3].Rank = Convert.ToInt32(this.climbRanks.Text);
                myCharacter.Skills[3].Bonus = Convert.ToInt32(this.climbMiscMod.Text);
                myCharacter.Skills[3].ClassSkill = this.climbCheckbox.Checked;
                //craft 1
                myCharacter.Skills[4].Name = "Craft(" + this.craftName1.Text + ")";
                myCharacter.Skills[4].Rank = Convert.ToInt32(this.craftRanks1.Text);
                myCharacter.Skills[4].Bonus = Convert.ToInt32(this.craftMiscMod1.Text);
                myCharacter.Skills[4].ClassSkill = this.craftCheckbox1.Checked;
                //craft 2
                myCharacter.Skills[5].Name = "Craft(" + this.craftName2.Text + ")";
                myCharacter.Skills[5].Rank = Convert.ToInt32(this.craftRanks2.Text);
                myCharacter.Skills[5].Bonus = Convert.ToInt32(this.craftMiscMod2.Text);
                myCharacter.Skills[5].ClassSkill = this.craftCheckbox2.Checked;
                //craft 3
                myCharacter.Skills[6].Name = "Craft(" + this.craftName3.Text + ")";
                myCharacter.Skills[6].Rank = Convert.ToInt32(this.craftRanks3.Text);
                myCharacter.Skills[6].Bonus = Convert.ToInt32(this.craftMiscMod3.Text);
                myCharacter.Skills[6].ClassSkill = this.craftCheckbox3.Checked;
                //diplomacy
                myCharacter.Skills[7].Rank = Convert.ToInt32(this.diplomacyRanks.Text);
                myCharacter.Skills[7].Bonus = Convert.ToInt32(this.diplomacyMiscMod.Text);
                myCharacter.Skills[7].ClassSkill = this.diplomacyCheckbox.Checked;
                //disable device
                myCharacter.Skills[8].Rank = Convert.ToInt32(this.disableDeviceRanks.Text);
                myCharacter.Skills[8].Bonus = Convert.ToInt32(this.disableDeviceMiscMod.Text);
                myCharacter.Skills[8].ClassSkill = this.disableDeviceCheckbox.Checked;
                //disguise
                myCharacter.Skills[9].Rank = Convert.ToInt32(this.disguiseRanks.Text);
                myCharacter.Skills[9].Bonus = Convert.ToInt32(this.disguiseMiscMod.Text);
                myCharacter.Skills[9].ClassSkill = this.disguiseCheckbox.Checked;
                //escape artist
                myCharacter.Skills[10].Rank = Convert.ToInt32(this.escapeArtistRanks.Text);
                myCharacter.Skills[10].Bonus = Convert.ToInt32(this.escapeArtistMiscMod.Text);
                myCharacter.Skills[10].ClassSkill = this.escapeArtistCheckbox.Checked;
                //fly
                myCharacter.Skills[11].Rank = Convert.ToInt32(this.flyRanks.Text);
                myCharacter.Skills[11].Bonus = Convert.ToInt32(this.flyMiscMod.Text);
                myCharacter.Skills[11].ClassSkill = this.flyCheckbox.Checked;
                //handle animal
                myCharacter.Skills[12].Rank = Convert.ToInt32(this.handleAnimalRanks.Text);
                myCharacter.Skills[12].Bonus = Convert.ToInt32(this.handleAnimalMiscMod.Text);
                myCharacter.Skills[12].ClassSkill = this.handleAnimalCheckbox.Checked;
                //heal
                myCharacter.Skills[13].Rank = Convert.ToInt32(this.healRanks.Text);
                myCharacter.Skills[13].Bonus = Convert.ToInt32(this.healMiscMod.Text);
                myCharacter.Skills[13].ClassSkill = this.healCheckbox.Checked;
                //intimidate
                myCharacter.Skills[14].Rank = Convert.ToInt32(this.intimidateRanks.Text);
                myCharacter.Skills[14].Bonus = Convert.ToInt32(this.intimidateMiscMod.Text);
                myCharacter.Skills[14].ClassSkill = this.intimidateCheckbox.Checked;
                //knowledge(arcana)
                myCharacter.Skills[15].Rank = Convert.ToInt32(this.arcanaRanks.Text);
                myCharacter.Skills[15].Bonus = Convert.ToInt32(this.arcanaMiscMod.Text);
                myCharacter.Skills[15].ClassSkill = this.arcanaCheckbox.Checked;
                //knowledge(dungeoneering)
                myCharacter.Skills[16].Rank = Convert.ToInt32(this.dungeoneeringRanks.Text);
                myCharacter.Skills[16].Bonus = Convert.ToInt32(this.dungeoneeringMiscMod.Text);
                myCharacter.Skills[16].ClassSkill = this.dungeoneeringCheckbox.Checked;
                //knowledge(engineering)
                myCharacter.Skills[17].Rank = Convert.ToInt32(this.engineeringRanks.Text);
                myCharacter.Skills[17].Bonus = Convert.ToInt32(this.engineeringMiscMod.Text);
                myCharacter.Skills[17].ClassSkill = this.engineeringCheckbox.Checked;
                //knowledge(geography)
                myCharacter.Skills[18].Rank = Convert.ToInt32(this.geographyRanks.Text);
                myCharacter.Skills[18].Bonus = Convert.ToInt32(this.geographyMiscMod.Text);
                myCharacter.Skills[18].ClassSkill = this.geographyCheckbox.Checked;
                //knowledge(history)
                myCharacter.Skills[19].Rank = Convert.ToInt32(this.historyRanks.Text);
                myCharacter.Skills[19].Bonus = Convert.ToInt32(this.historyMiscMod.Text);
                myCharacter.Skills[19].ClassSkill = this.historyCheckbox.Checked;
                //knowledge(local)
                myCharacter.Skills[20].Rank = Convert.ToInt32(this.localRanks.Text);
                myCharacter.Skills[20].Bonus = Convert.ToInt32(this.localMiscMod.Text);
                myCharacter.Skills[20].ClassSkill = this.localCheckbox.Checked;
                //knowledge(nature)
                myCharacter.Skills[21].Rank = Convert.ToInt32(this.natureRanks.Text);
                myCharacter.Skills[21].Bonus = Convert.ToInt32(this.natureMiscMod.Text);
                myCharacter.Skills[21].ClassSkill = this.natureCheckbox.Checked;
                //knowledge(nobility)
                myCharacter.Skills[22].Rank = Convert.ToInt32(this.nobilityRanks.Text);
                myCharacter.Skills[22].Bonus = Convert.ToInt32(this.nobilityMiscMod.Text);
                myCharacter.Skills[22].ClassSkill = this.nobilityCheckbox.Checked;
                //knowledge(planes)
                myCharacter.Skills[23].Rank = Convert.ToInt32(this.planesRanks.Text);
                myCharacter.Skills[23].Bonus = Convert.ToInt32(this.planesMiscMod.Text);
                myCharacter.Skills[23].ClassSkill = this.planesCheckbox.Checked;
                //knowledge(religion)
                myCharacter.Skills[24].Rank = Convert.ToInt32(this.religionRanks.Text);
                myCharacter.Skills[24].Bonus = Convert.ToInt32(this.religionMiscMod.Text);
                myCharacter.Skills[24].ClassSkill = this.religionCheckbox.Checked;
                //linguistics
                myCharacter.Skills[25].Rank = Convert.ToInt32(this.linguisticsRanks.Text);
                myCharacter.Skills[25].Bonus = Convert.ToInt32(this.linguisticsMiscMod.Text);
                myCharacter.Skills[25].ClassSkill = this.linguisticsCheckbox.Checked;
                //perception
                myCharacter.Skills[26].Rank = Convert.ToInt32(this.perceptionRanks.Text);
                myCharacter.Skills[26].Bonus = Convert.ToInt32(this.perceptionMiscMod.Text);
                myCharacter.Skills[26].ClassSkill = this.perceptionCheckbox.Checked;
                //perform 1
                myCharacter.Skills[27].Name = "Perform(" + this.performName1.Text + ")";
                myCharacter.Skills[27].Rank = Convert.ToInt32(this.performRanks1.Text);
                myCharacter.Skills[27].Bonus = Convert.ToInt32(this.performMiscMod1.Text);
                myCharacter.Skills[27].ClassSkill = this.performCheckbox1.Checked;
                //perform 2
                myCharacter.Skills[28].Name = "Perform(" + this.performName2.Text + ")";
                myCharacter.Skills[28].Rank = Convert.ToInt32(this.performRanks2.Text);
                myCharacter.Skills[28].Bonus = Convert.ToInt32(this.performMiscMod2.Text);
                myCharacter.Skills[28].ClassSkill = this.performCheckbox2.Checked;
                //profession 1
                myCharacter.Skills[29].Name = "Profession(" + this.professionName1.Text + ")";
                myCharacter.Skills[29].Rank = Convert.ToInt32(this.professionRanks1.Text);
                myCharacter.Skills[29].Bonus = Convert.ToInt32(this.professionMiscMod1.Text);
                myCharacter.Skills[29].ClassSkill = this.professionCheckbox1.Checked;
                //profession 2
                myCharacter.Skills[30].Name = "Profession(" + this.professionName2.Text + ")";
                myCharacter.Skills[30].Rank = Convert.ToInt32(this.professionRanks2.Text);
                myCharacter.Skills[30].Bonus = Convert.ToInt32(this.professionMiscMod2.Text);
                myCharacter.Skills[30].ClassSkill = this.professionCheckbox2.Checked;
                //ride
                myCharacter.Skills[31].Rank = Convert.ToInt32(this.rideRanks.Text);
                myCharacter.Skills[31].Bonus = Convert.ToInt32(this.rideMiscMod.Text);
                myCharacter.Skills[31].ClassSkill = this.rideCheckbox.Checked;
                //sense motive
                myCharacter.Skills[32].Rank = Convert.ToInt32(this.senseMotiveRanks.Text);
                myCharacter.Skills[32].Bonus = Convert.ToInt32(this.senseMotiveMiscMod.Text);
                myCharacter.Skills[32].ClassSkill = this.senseMotiveCheckbox.Checked;
                //sleight of hand
                myCharacter.Skills[33].Rank = Convert.ToInt32(this.sleightOfHandRanks.Text);
                myCharacter.Skills[33].Bonus = Convert.ToInt32(this.sleightOfHandMiscMod.Text);
                myCharacter.Skills[33].ClassSkill = this.sleightOfHandCheckbox.Checked;
                //spellcraft
                myCharacter.Skills[34].Rank = Convert.ToInt32(this.spellcraftRanks.Text);
                myCharacter.Skills[34].Bonus = Convert.ToInt32(this.spellcraftMiscMod.Text);
                myCharacter.Skills[34].ClassSkill = this.spellcraftCheckbox.Checked;
                //stealth
                myCharacter.Skills[35].Rank = Convert.ToInt32(this.stealthRanks.Text);
                myCharacter.Skills[35].Bonus = Convert.ToInt32(this.stealthMiscMod.Text);
                myCharacter.Skills[35].ClassSkill = this.stealthCheckbox.Checked;
                //survival
                myCharacter.Skills[36].Rank = Convert.ToInt32(this.survivalRanks.Text);
                myCharacter.Skills[36].Bonus = Convert.ToInt32(this.survivalMiscMod.Text);
                myCharacter.Skills[36].ClassSkill = this.survivalCheckbox.Checked;
                //swim
                myCharacter.Skills[37].Rank = Convert.ToInt32(this.swimRanks.Text);
                myCharacter.Skills[37].Bonus = Convert.ToInt32(this.swimMiscMod.Text);
                myCharacter.Skills[37].ClassSkill = this.swimCheckbox.Checked;
                //use magic device
                myCharacter.Skills[38].Rank = Convert.ToInt32(this.useMagicDeviceRanks.Text);
                myCharacter.Skills[38].Bonus = Convert.ToInt32(this.useMagicDeviceMiscMod.Text);
                myCharacter.Skills[38].ClassSkill = this.useMagicDeviceCheckbox.Checked;

                //get AC items
                //names
                myCharacter.Defenses.ACItemNames[0] = this.ACItem1.Text;
                myCharacter.Defenses.ACItemNames[1] = this.ACItem2.Text;
                myCharacter.Defenses.ACItemNames[2] = this.ACItem3.Text;
                myCharacter.Defenses.ACItemNames[3] = this.ACItem4.Text;
                myCharacter.Defenses.ACItemNames[4] = this.ACItem5.Text;
                //bonus
                myCharacter.Defenses.ACItemStats[0, 0] = Convert.ToInt32(this.ACBonus1.Text);
                myCharacter.Defenses.ACItemStats[1, 0] = Convert.ToInt32(this.ACBonus2.Text);
                myCharacter.Defenses.ACItemStats[2, 0] = Convert.ToInt32(this.ACBonus3.Text);
                myCharacter.Defenses.ACItemStats[3, 0] = Convert.ToInt32(this.ACBonus4.Text);
                myCharacter.Defenses.ACItemStats[4, 0] = Convert.ToInt32(this.ACBonus5.Text);
                //type
                myCharacter.Defenses.ACItemStrings[0, 0] = this.ACType1.Text;
                myCharacter.Defenses.ACItemStrings[1, 0] = this.ACType2.Text;
                myCharacter.Defenses.ACItemStrings[2, 0] = this.ACType3.Text;
                myCharacter.Defenses.ACItemStrings[3, 0] = this.ACType4.Text;
                myCharacter.Defenses.ACItemStrings[4, 0] = this.ACType5.Text;
                //check penalty
                myCharacter.Defenses.ACItemStats[0, 1] = Convert.ToInt32(this.ACP1.Text);
                myCharacter.Defenses.ACItemStats[1, 1] = Convert.ToInt32(this.ACP2.Text);
                myCharacter.Defenses.ACItemStats[2, 1] = Convert.ToInt32(this.ACP3.Text);
                myCharacter.Defenses.ACItemStats[3, 1] = Convert.ToInt32(this.ACP4.Text);
                myCharacter.Defenses.ACItemStats[4, 1] = Convert.ToInt32(this.ACP5.Text);
                //spell failure
                myCharacter.Defenses.ACItemStats[0, 2] = Convert.ToInt32(this.ACSpellFailure1.Text);
                myCharacter.Defenses.ACItemStats[1, 2] = Convert.ToInt32(this.ACSpellFailure2.Text);
                myCharacter.Defenses.ACItemStats[2, 2] = Convert.ToInt32(this.ACSpellFailure3.Text);
                myCharacter.Defenses.ACItemStats[3, 2] = Convert.ToInt32(this.ACSpellFailure4.Text);
                myCharacter.Defenses.ACItemStats[4, 2] = Convert.ToInt32(this.ACSpellFailure5.Text);
                //weight
                myCharacter.Defenses.ACItemStats[0, 3] = Convert.ToInt32(this.ACWeight1.Text);
                myCharacter.Defenses.ACItemStats[1, 3] = Convert.ToInt32(this.ACWeight2.Text);
                myCharacter.Defenses.ACItemStats[2, 3] = Convert.ToInt32(this.ACWeight3.Text);
                myCharacter.Defenses.ACItemStats[3, 3] = Convert.ToInt32(this.ACWeight4.Text);
                myCharacter.Defenses.ACItemStats[4, 3] = Convert.ToInt32(this.ACWeight5.Text);
                //properties
                myCharacter.Defenses.ACItemStrings[0, 1] = this.ACProperties1.Text;
                myCharacter.Defenses.ACItemStrings[1, 1] = this.ACProperties2.Text;
                myCharacter.Defenses.ACItemStrings[2, 1] = this.ACProperties3.Text;
                myCharacter.Defenses.ACItemStrings[3, 1] = this.ACProperties4.Text;
                myCharacter.Defenses.ACItemStrings[4, 1] = this.ACProperties5.Text;

                //gear
                //names
                myCharacter.Gear[0] = this.gear1.Text;
                myCharacter.Gear[1] = this.gear2.Text;
                myCharacter.Gear[2] = this.gear3.Text;
                myCharacter.Gear[3] = this.gear4.Text;
                myCharacter.Gear[4] = this.gear5.Text;
                myCharacter.Gear[5] = this.gear6.Text;
                myCharacter.Gear[6] = this.gear7.Text;
                myCharacter.Gear[7] = this.gear8.Text;
                myCharacter.Gear[8] = this.gear9.Text;
                myCharacter.Gear[9] = this.gear10.Text;
                myCharacter.Gear[10] = this.gear11.Text;
                myCharacter.Gear[11] = this.gear12.Text;
                myCharacter.Gear[12] = this.gear13.Text;
                myCharacter.Gear[13] = this.gear14.Text;
                myCharacter.Gear[14] = this.gear15.Text;
                myCharacter.Gear[15] = this.gear16.Text;
                myCharacter.Gear[16] = this.gear17.Text;
                myCharacter.Gear[17] = this.gear18.Text;
                myCharacter.Gear[18] = this.gear19.Text;
                myCharacter.Gear[19] = this.gear20.Text;
                myCharacter.Gear[20] = this.gear21.Text;
                myCharacter.Gear[21] = this.gear22.Text;
                myCharacter.Gear[22] = this.gear23.Text;
                myCharacter.Gear[23] = this.gear24.Text;
                myCharacter.Gear[24] = this.gear25.Text;
                myCharacter.Gear[25] = this.gear26.Text;
                //weight
                myCharacter.GearWeight[0] = Convert.ToInt32(this.gearWeight1.Text);
                myCharacter.GearWeight[1] = Convert.ToInt32(this.gearWeight2.Text);
                myCharacter.GearWeight[2] = Convert.ToInt32(this.gearWeight3.Text);
                myCharacter.GearWeight[3] = Convert.ToInt32(this.gearWeight4.Text);
                myCharacter.GearWeight[4] = Convert.ToInt32(this.gearWeight5.Text);
                myCharacter.GearWeight[5] = Convert.ToInt32(this.gearWeight6.Text);
                myCharacter.GearWeight[6] = Convert.ToInt32(this.gearWeight7.Text);
                myCharacter.GearWeight[7] = Convert.ToInt32(this.gearWeight8.Text);
                myCharacter.GearWeight[8] = Convert.ToInt32(this.gearWeight9.Text);
                myCharacter.GearWeight[9] = Convert.ToInt32(this.gearWeight10.Text);
                myCharacter.GearWeight[10] = Convert.ToInt32(this.gearWeight11.Text);
                myCharacter.GearWeight[11] = Convert.ToInt32(this.gearWeight12.Text);
                myCharacter.GearWeight[12] = Convert.ToInt32(this.gearWeight13.Text);
                myCharacter.GearWeight[13] = Convert.ToInt32(this.gearWeight14.Text);
                myCharacter.GearWeight[14] = Convert.ToInt32(this.gearWeight15.Text);
                myCharacter.GearWeight[15] = Convert.ToInt32(this.gearWeight16.Text);
                myCharacter.GearWeight[16] = Convert.ToInt32(this.gearWeight17.Text);
                myCharacter.GearWeight[17] = Convert.ToInt32(this.gearWeight18.Text);
                myCharacter.GearWeight[18] = Convert.ToInt32(this.gearWeight19.Text);
                myCharacter.GearWeight[19] = Convert.ToInt32(this.gearWeight20.Text);
                myCharacter.GearWeight[20] = Convert.ToInt32(this.gearWeight21.Text);
                myCharacter.GearWeight[21] = Convert.ToInt32(this.gearWeight22.Text);
                myCharacter.GearWeight[22] = Convert.ToInt32(this.gearWeight23.Text);
                myCharacter.GearWeight[23] = Convert.ToInt32(this.gearWeight24.Text);
                myCharacter.GearWeight[24] = Convert.ToInt32(this.gearWeight25.Text);
                myCharacter.GearWeight[25] = Convert.ToInt32(this.gearWeight26.Text);

                //get money
                myCharacter.Copper= Convert.ToInt32(this.copper.Text);
                myCharacter.Silver = Convert.ToInt32(this.silver.Text);
                myCharacter.Gold = Convert.ToInt32(this.gold.Text);
                myCharacter.Platinum = Convert.ToInt32(this.platinum.Text);

                //get experience
                myCharacter.EXP = Convert.ToInt32(this.EXP.Text);
                myCharacter.NextLevelEXP = Convert.ToInt32(this.nextLevel.Text);
            }
            catch(Exception exp)
            {
                //output error
                Console.WriteLine("Error transfering data from view to model " + exp);
                this.savePathText.Text = "Error transfering data from view to model " + exp;
            }
        }
        /**/
        /* void CharacterForm::updateCharacter(); */
        /**/

        /**/
        /*
        CharacterForm::updatePage() CharacterForm::updatePage()

        NAME

                CharacterForm::updatePage - update the page to match myCharacter

        SYNOPSIS

                void CharacterForm::updatePage();

        DESCRIPTION

                This function assigns the text fields, labels, etc. to match the values
                saved in the myCharacter variable. This is done by going through all the
                elements of the .NET form and assinging them corresponding values saved
                in myCharacter and parsing text when necessary.

        RETURNS

                none

        AUTHOR

                Peter Wright

        DATE

                July 23, 2018

        */
        /**/
        public void updatePage()
        {
            int start;  //used to get start index for substrings
            int length; //used to get the length before cutting substrings

            //set description fields
            this.characterName.Text = myCharacter.Name;
            this.alignment.Text = myCharacter.Alignment;
            this.player.Text = myCharacter.PlayerName;
            this.characterLevel.Text = myCharacter.Level;
            this.deity.Text = myCharacter.God;
            this.homeland.Text = myCharacter.Home;
            this.race.Text = myCharacter.Race;
            this.sizeField.Text = myCharacter.Size;
            this.gender.Text = myCharacter.Gender;
            this.age.Text = myCharacter.Age;
            this.height.Text = myCharacter.Height;
            this.weight.Text = myCharacter.Weight;
            this.hair.Text = myCharacter.Hair;
            this.eyes.Text = myCharacter.Eyes;

            //set stat fields
            //strength
            this.strAbilityScore.Text = Convert.ToString(myCharacter.Strength);
            this.strAbilityMod.Text = Convert.ToString(myCharacter.getModifer("str"));
            this.strTempAdj.Text = Convert.ToString(myCharacter.StrengthAdjust);
            this.strTempMod.Text = Convert.ToString(myCharacter.getTempModifer("str"));
            //dexterity
            this.dexAbilityScore.Text = Convert.ToString(myCharacter.Dexterity);
            this.dexAbilityMod.Text = Convert.ToString(myCharacter.getModifer("dex"));
            this.dexTempAdj.Text = Convert.ToString(myCharacter.DexterityAdjust);
            this.dexTempMod.Text = Convert.ToString(myCharacter.getTempModifer("dex"));
            //constitution
            this.conAbilityScore.Text = Convert.ToString(myCharacter.Constitution);
            this.conAbilityMod.Text = Convert.ToString(myCharacter.getModifer("con"));
            this.conTempAdj.Text = Convert.ToString(myCharacter.ConstitutionAdjust);
            this.conTempMod.Text = Convert.ToString(myCharacter.getTempModifer("con"));
            //intelligence
            this.intAbilityScore.Text = Convert.ToString(myCharacter.Intelligence);
            this.intAbilityMod.Text = Convert.ToString(myCharacter.getModifer("int"));
            this.intTempAdj.Text = Convert.ToString(myCharacter.IntelligenceAdjust);
            this.intTempMod.Text = Convert.ToString(myCharacter.getTempModifer("int"));
            //wisdom
            this.wisAbilityScore.Text = Convert.ToString(myCharacter.Wisdom);
            this.wisAbilityMod.Text = Convert.ToString(myCharacter.getModifer("wis"));
            this.wisTempAdj.Text = Convert.ToString(myCharacter.WisdomAdjust);
            this.wisTempMod.Text = Convert.ToString(myCharacter.getTempModifer("wis"));
            //charisma
            this.chaAbilityScore.Text = Convert.ToString(myCharacter.Charsima);
            this.chaAbilityMod.Text = Convert.ToString(myCharacter.getModifer("cha"));
            this.chaTempAdj.Text = Convert.ToString(myCharacter.CharsimaAdjust);
            this.chaTempMod.Text = Convert.ToString(myCharacter.getTempModifer("cha"));

            //set hp fields
            this.totalHP.Text = Convert.ToString(myCharacter.Defenses.TotalHP);
            this.DR.Text = myCharacter.Defenses.DR;
            this.currentHP.Text = Convert.ToString(myCharacter.Defenses.CurrentHP);
            this.nonLethalDam.Text = Convert.ToString(myCharacter.Defenses.NonLethal);

            //set speed fields
            this.baseSpeed.Text = Convert.ToString(myCharacter.BaseSpeed);
            this.armorSpeed.Text = Convert.ToString(myCharacter.ArmorSpeed);
            this.flySpeed.Text = Convert.ToString(myCharacter.FlySpeed);
            this.swimSpeed.Text = Convert.ToString(myCharacter.SwimSpeed);
            this.climbSpeed.Text = Convert.ToString(myCharacter.ClimbSpeed);
            this.burrowSpeed.Text = Convert.ToString(myCharacter.BurrowSpeed);
            this.tempSpeed.Text = myCharacter.TempSpeedModifiers;

            //set initiative fields
            this.initiativeTotal.Text = Convert.ToString(myCharacter.getInitiativeModifier());
            this.initiativeDex.Text = Convert.ToString(myCharacter.getTempModifer("dex"));
            this.initiativeMiscMod.Text = Convert.ToString(myCharacter.InitiativeModifier);

            //set AC fields
            this.armorTotal.Text = Convert.ToString(myCharacter.Defenses.getTotal());
            this.armorBonus.Text = Convert.ToString(myCharacter.Defenses.Armor);
            this.shieldBonus.Text = Convert.ToString(myCharacter.Defenses.Shield);
            this.armorDex.Text = Convert.ToString(myCharacter.Defenses.Dex);
            this.sizeMod.Text = Convert.ToString(myCharacter.Defenses.Size);
            this.naturalArmor.Text = Convert.ToString(myCharacter.Defenses.NaturalArmor);
            this.deflectionMod.Text = Convert.ToString(myCharacter.Defenses.Deflection);
            this.armorMiscMod.Text = Convert.ToString(myCharacter.Defenses.Misc);
            this.touchAC.Text = Convert.ToString(myCharacter.Defenses.getTouch());
            this.flatFootedAC.Text = Convert.ToString(myCharacter.Defenses.getFlatFooted());
            this.ACModifiers.Text = Convert.ToString(myCharacter.Defenses.ACModifiers);

            //set save fields
            //fortitude
            this.fortitudeTotal.Text = Convert.ToString(myCharacter.Defenses.getTotalFortitude());
            this.baseFortitude.Text = Convert.ToString(myCharacter.Defenses.BaseFortitude);
            this.fortitudeCon.Text = Convert.ToString(myCharacter.Defenses.FortitudeAbilityScore);
            this.fortitudeMagicMod.Text = Convert.ToString(myCharacter.Defenses.FortitudeMagicBonus);
            this.fortitudeMiscMod.Text = Convert.ToString(myCharacter.Defenses.FortitudeMiscBonus);
            this.fortitudeTempMod.Text = Convert.ToString(myCharacter.Defenses.FortitudeTempBonus);
            //reflex
            this.reflexTotal.Text = Convert.ToString(myCharacter.Defenses.getTotalReflex());
            this.baseReflex.Text = Convert.ToString(myCharacter.Defenses.BaseReflex);
            this.reflexDex.Text = Convert.ToString(myCharacter.Defenses.ReflexAbilityScore);
            this.reflexMagicMod.Text = Convert.ToString(myCharacter.Defenses.ReflexMagicBonus);
            this.reflexMiscMod.Text = Convert.ToString(myCharacter.Defenses.ReflexMiscBonus);
            this.reflexTempMod.Text = Convert.ToString(myCharacter.Defenses.ReflexTempBonus);
            //will
            this.willTotal.Text = Convert.ToString(myCharacter.Defenses.getTotalWill());
            this.baseWill.Text = Convert.ToString(myCharacter.Defenses.BaseWill);
            this.willWis.Text = Convert.ToString(myCharacter.Defenses.WillAbilityScore);
            this.willMagicMod.Text = Convert.ToString(myCharacter.Defenses.WillMagicBonus);
            this.willMiscMod.Text = Convert.ToString(myCharacter.Defenses.WillMiscBonus);
            this.willTempMod.Text = Convert.ToString(myCharacter.Defenses.WillTempBonus);
            //text modifiers
            this.savesModifiers.Text = myCharacter.Defenses.SavseModifiers;

            //set other fields
            this.BAB.Text = Convert.ToString(myCharacter.BAB);
            this.SR.Text = myCharacter.Defenses.SR;
            //CMB
            this.CMBTotal.Text = Convert.ToString(myCharacter.getCMB());
            this.CMBBAB.Text = Convert.ToString(myCharacter.BAB);
            this.CMBStrMod.Text = Convert.ToString(myCharacter.getTempModifer("str"));
            this.CMBSizeMod.Text = Convert.ToString(myCharacter.CMBModifier);
            this.CMBModifiers.Text = Convert.ToString(myCharacter.CMBModifiersText);
            //CMD
            this.CMDTotal.Text = Convert.ToString(myCharacter.getCMD());
            this.CMDBAB.Text = Convert.ToString(myCharacter.BAB);
            this.CMDStrMod.Text = Convert.ToString(myCharacter.getTempModifer("str"));
            this.CMDDexMod.Text = Convert.ToString(myCharacter.getTempModifer("dex"));
            this.CMDSizeMod.Text = Convert.ToString(myCharacter.CMDModifier);

            //set attack fields
            //1
            this.weaponName1.Text = myCharacter.Attacks[0].Name;
            this.attackBonus1.Text = Convert.ToString(myCharacter.Attacks[0].AttackBonus);
            this.critical1.Text = myCharacter.Attacks[0].Critical;
            this.weaponType1.Text = myCharacter.Attacks[0].Type;
            this.range1.Text = myCharacter.Attacks[0].Range;
            this.ammunition1.Text = Convert.ToString(myCharacter.Attacks[0].Ammunition);
            this.damage1.Text = myCharacter.Attacks[0].Damage;
            //2
            this.weaponName2.Text = myCharacter.Attacks[1].Name;
            this.attackBonus2.Text = Convert.ToString(myCharacter.Attacks[1].AttackBonus);
            this.critical2.Text = myCharacter.Attacks[1].Critical;
            this.weaponType2.Text = myCharacter.Attacks[1].Type;
            this.range2.Text = myCharacter.Attacks[1].Range;
            this.ammunition2.Text = Convert.ToString(myCharacter.Attacks[1].Ammunition);
            this.damage2.Text = myCharacter.Attacks[1].Damage;
            //3
            this.weaponName3.Text = myCharacter.Attacks[2].Name;
            this.attackBonus3.Text = Convert.ToString(myCharacter.Attacks[2].AttackBonus);
            this.critical3.Text = myCharacter.Attacks[2].Critical;
            this.weaponType3.Text = myCharacter.Attacks[2].Type;
            this.range3.Text = myCharacter.Attacks[2].Range;
            this.ammunition3.Text = Convert.ToString(myCharacter.Attacks[2].Ammunition);
            this.damage3.Text = myCharacter.Attacks[2].Damage;
            //4
            this.weaponName4.Text = myCharacter.Attacks[3].Name;
            this.attackBonus4.Text = Convert.ToString(myCharacter.Attacks[3].AttackBonus);
            this.critical4.Text = myCharacter.Attacks[3].Critical;
            this.weaponType4.Text = myCharacter.Attacks[3].Type;
            this.range4.Text = myCharacter.Attacks[3].Range;
            this.ammunition4.Text = Convert.ToString(myCharacter.Attacks[3].Ammunition);
            this.damage4.Text = myCharacter.Attacks[3].Damage;
            //5
            this.weaponName5.Text = myCharacter.Attacks[4].Name;
            this.attackBonus5.Text = Convert.ToString(myCharacter.Attacks[4].AttackBonus);
            this.critical5.Text = myCharacter.Attacks[4].Critical;
            this.weaponType5.Text = myCharacter.Attacks[4].Type;
            this.range5.Text = myCharacter.Attacks[4].Range;
            this.ammunition5.Text = Convert.ToString(myCharacter.Attacks[4].Ammunition);
            this.damage5.Text = myCharacter.Attacks[4].Damage;

            //set skill fields
            //acrobatics
            this.acrobaticsCheckbox.Checked = myCharacter.Skills[0].ClassSkill;
            this.acrobaticsTotalBonus.Text = Convert.ToString(myCharacter.Skills[0].getTotalBonus());
            this.acrobaticsAbilityMod.Text = Convert.ToString(myCharacter.Skills[0].StatBonus);
            this.acrobaticRanks.Text = Convert.ToString(myCharacter.Skills[0].Rank);
            this.acrobaticsMiscMod.Text = Convert.ToString(myCharacter.Skills[0].Bonus);
            //appraise
            this.appraiseCheckbox.Checked = myCharacter.Skills[1].ClassSkill;
            this.appraiseTotalBonus.Text = Convert.ToString(myCharacter.Skills[1].getTotalBonus());
            this.appraiseAbilityMod.Text = Convert.ToString(myCharacter.Skills[1].StatBonus);
            this.appraiseRanks.Text = Convert.ToString(myCharacter.Skills[1].Rank);
            this.appraiseMiscMod.Text = Convert.ToString(myCharacter.Skills[1].Bonus);
            //bluff
            this.bluffCheckbox.Checked = myCharacter.Skills[2].ClassSkill;
            this.bluffTotalBonus.Text = Convert.ToString(myCharacter.Skills[2].getTotalBonus());
            this.bluffAbilityMod.Text = Convert.ToString(myCharacter.Skills[2].StatBonus);
            this.bluffRanks.Text = Convert.ToString(myCharacter.Skills[2].Rank);
            this.bluffMiscMod.Text = Convert.ToString(myCharacter.Skills[2].Bonus);
            //climb
            this.climbCheckbox.Checked = myCharacter.Skills[3].ClassSkill;
            this.climbTotalBonus.Text = Convert.ToString(myCharacter.Skills[3].getTotalBonus());
            this.climbAbilityMod.Text = Convert.ToString(myCharacter.Skills[3].StatBonus);
            this.climbRanks.Text = Convert.ToString(myCharacter.Skills[3].Rank);
            this.climbMiscMod.Text = Convert.ToString(myCharacter.Skills[3].Bonus);
            //craft 1
            this.craftCheckbox1.Checked = myCharacter.Skills[4].ClassSkill;
            //check if skill name has been changed
            if (myCharacter.Skills[4].Name.Equals("Craft"))
            {
                this.craftName1.Text = "";
            }
            else
            {
                start = 6;
                length = myCharacter.Skills[4].Name.Length - 1 - start;
                this.craftName1.Text = myCharacter.Skills[4].Name.Substring(start, length);
            }
            this.craftTotalBonus1.Text = Convert.ToString(myCharacter.Skills[4].getTotalBonus());
            this.craftAbilityMod1.Text = Convert.ToString(myCharacter.Skills[4].StatBonus);
            this.craftRanks1.Text = Convert.ToString(myCharacter.Skills[4].Rank);
            this.craftMiscMod1.Text = Convert.ToString(myCharacter.Skills[4].Bonus);
            //craft 2
            this.craftCheckbox2.Checked = myCharacter.Skills[5].ClassSkill;
            //check if skill name has been changed
            if (myCharacter.Skills[5].Name.Equals("Craft"))
            {
                this.craftName2.Text = "";
            }
            else
            {
                start = 6;
                length = myCharacter.Skills[5].Name.Length - 1 - start;
                this.craftName2.Text = myCharacter.Skills[5].Name.Substring(start, length);
            }
            this.craftTotalBonus2.Text = Convert.ToString(myCharacter.Skills[5].getTotalBonus());
            this.craftAbilityMod2.Text = Convert.ToString(myCharacter.Skills[5].StatBonus);
            this.craftRanks2.Text = Convert.ToString(myCharacter.Skills[5].Rank);
            this.craftMiscMod2.Text = Convert.ToString(myCharacter.Skills[5].Bonus);
            //craft 3
            this.craftCheckbox3.Checked = myCharacter.Skills[6].ClassSkill;
            //check if skill name has been changed
            if (myCharacter.Skills[6].Name.Equals("Craft"))
            {
                this.craftName3.Text = "";
            }
            else
            {
                start = 6;
                length = myCharacter.Skills[6].Name.Length - 1 - start;
                this.craftName3.Text = myCharacter.Skills[6].Name.Substring(start, length);
            }
            this.craftTotalBonus3.Text = Convert.ToString(myCharacter.Skills[6].getTotalBonus());
            this.craftAbilityMod3.Text = Convert.ToString(myCharacter.Skills[6].StatBonus);
            this.craftRanks3.Text = Convert.ToString(myCharacter.Skills[6].Rank);
            this.craftMiscMod3.Text = Convert.ToString(myCharacter.Skills[6].Bonus);
            //diplomacy
            this.diplomacyCheckbox.Checked = myCharacter.Skills[7].ClassSkill;
            this.diplomacyTotalBonus.Text = Convert.ToString(myCharacter.Skills[7].getTotalBonus());
            this.diplomacyAbilityMod.Text = Convert.ToString(myCharacter.Skills[7].StatBonus);
            this.diplomacyRanks.Text = Convert.ToString(myCharacter.Skills[7].Rank);
            this.diplomacyMiscMod.Text = Convert.ToString(myCharacter.Skills[7].Bonus);
            //disable device
            this.disableDeviceCheckbox.Checked = myCharacter.Skills[8].ClassSkill;
            this.disableDeviceTotalBonus.Text = Convert.ToString(myCharacter.Skills[8].getTotalBonus());
            this.disableDeviceAbilityMod.Text = Convert.ToString(myCharacter.Skills[8].StatBonus);
            this.disableDeviceRanks.Text = Convert.ToString(myCharacter.Skills[8].Rank);
            this.disableDeviceMiscMod.Text = Convert.ToString(myCharacter.Skills[8].Bonus);
            //disguise
            this.disguiseCheckbox.Checked = myCharacter.Skills[9].ClassSkill;
            this.disguiseTotalBonus.Text = Convert.ToString(myCharacter.Skills[9].getTotalBonus());
            this.disguiseAbilityMod.Text = Convert.ToString(myCharacter.Skills[9].StatBonus);
            this.disguiseRanks.Text = Convert.ToString(myCharacter.Skills[9].Rank);
            this.disguiseMiscMod.Text = Convert.ToString(myCharacter.Skills[9].Bonus);
            //escape artist
            this.escapeArtistCheckbox.Checked = myCharacter.Skills[10].ClassSkill;
            this.escapeArtistTotalBonus.Text = Convert.ToString(myCharacter.Skills[10].getTotalBonus());
            this.escapeArtistAbilityMod.Text = Convert.ToString(myCharacter.Skills[10].StatBonus);
            this.escapeArtistRanks.Text = Convert.ToString(myCharacter.Skills[10].Rank);
            this.escapeArtistMiscMod.Text = Convert.ToString(myCharacter.Skills[10].Bonus);
            //fly
            this.flyCheckbox.Checked = myCharacter.Skills[11].ClassSkill;
            this.flyTotalBonus.Text = Convert.ToString(myCharacter.Skills[11].getTotalBonus());
            this.flyAbilityMod.Text = Convert.ToString(myCharacter.Skills[11].StatBonus);
            this.flyRanks.Text = Convert.ToString(myCharacter.Skills[11].Rank);
            this.flyMiscMod.Text = Convert.ToString(myCharacter.Skills[11].Bonus);
            //handle animal
            this.handleAnimalCheckbox.Checked = myCharacter.Skills[12].ClassSkill;
            this.handleAnimalTotalBonus.Text = Convert.ToString(myCharacter.Skills[12].getTotalBonus());
            this.handleAnimalAbilityMod.Text = Convert.ToString(myCharacter.Skills[12].StatBonus);
            this.handleAnimalRanks.Text = Convert.ToString(myCharacter.Skills[12].Rank);
            this.handleAnimalMiscMod.Text = Convert.ToString(myCharacter.Skills[12].Bonus);
            //heal
            this.healCheckbox.Checked = myCharacter.Skills[13].ClassSkill;
            this.healTotalBonus.Text = Convert.ToString(myCharacter.Skills[13].getTotalBonus());
            this.healAbilityMod.Text = Convert.ToString(myCharacter.Skills[13].StatBonus);
            this.healRanks.Text = Convert.ToString(myCharacter.Skills[13].Rank);
            this.healMiscMod.Text = Convert.ToString(myCharacter.Skills[13].Bonus);
            //intimidate
            this.intimidateCheckbox.Checked = myCharacter.Skills[14].ClassSkill;
            this.intimidateTotalBonus.Text = Convert.ToString(myCharacter.Skills[14].getTotalBonus());
            this.intimidateAbilityMod.Text = Convert.ToString(myCharacter.Skills[14].StatBonus);
            this.intimidateRanks.Text = Convert.ToString(myCharacter.Skills[14].Rank);
            this.intimidateMiscMod.Text = Convert.ToString(myCharacter.Skills[14].Bonus);
            //knowledge(arcana)
            this.arcanaCheckbox.Checked = myCharacter.Skills[15].ClassSkill;
            this.arcanaTotalBonus.Text = Convert.ToString(myCharacter.Skills[15].getTotalBonus());
            this.arcanaAbilityMod.Text = Convert.ToString(myCharacter.Skills[15].StatBonus);
            this.arcanaRanks.Text = Convert.ToString(myCharacter.Skills[15].Rank);
            this.arcanaMiscMod.Text = Convert.ToString(myCharacter.Skills[15].Bonus);
            //knowledge(dungeoneering)
            this.dungeoneeringCheckbox.Checked = myCharacter.Skills[16].ClassSkill;
            this.dungeoneeringTotalBonus.Text = Convert.ToString(myCharacter.Skills[16].getTotalBonus());
            this.dungeoneeringAbilityMod.Text = Convert.ToString(myCharacter.Skills[16].StatBonus);
            this.dungeoneeringRanks.Text = Convert.ToString(myCharacter.Skills[16].Rank);
            this.dungeoneeringMiscMod.Text = Convert.ToString(myCharacter.Skills[16].Bonus);
            //knowledge(engineering)
            this.engineeringCheckbox.Checked = myCharacter.Skills[17].ClassSkill;
            this.engineeringTotalBonus.Text = Convert.ToString(myCharacter.Skills[17].getTotalBonus());
            this.engineeringAbilityMod.Text = Convert.ToString(myCharacter.Skills[17].StatBonus);
            this.engineeringRanks.Text = Convert.ToString(myCharacter.Skills[17].Rank);
            this.engineeringMiscMod.Text = Convert.ToString(myCharacter.Skills[17].Bonus);
            //knowledge(geography)
            this.geographyCheckbox.Checked = myCharacter.Skills[18].ClassSkill;
            this.geographyTotalBonus.Text = Convert.ToString(myCharacter.Skills[18].getTotalBonus());
            this.geographyAbilityMod.Text = Convert.ToString(myCharacter.Skills[18].StatBonus);
            this.geographyRanks.Text = Convert.ToString(myCharacter.Skills[18].Rank);
            this.geographyMiscMod.Text = Convert.ToString(myCharacter.Skills[18].Bonus);
            //knowledge(history)
            this.historyCheckbox.Checked = myCharacter.Skills[19].ClassSkill;
            this.historyTotalBonus.Text = Convert.ToString(myCharacter.Skills[19].getTotalBonus());
            this.historyAbilityMod.Text = Convert.ToString(myCharacter.Skills[19].StatBonus);
            this.historyRanks.Text = Convert.ToString(myCharacter.Skills[19].Rank);
            this.historyMiscMod.Text = Convert.ToString(myCharacter.Skills[19].Bonus);
            //knowledge(local)
            this.localCheckbox.Checked = myCharacter.Skills[20].ClassSkill;
            this.localTotalBonus.Text = Convert.ToString(myCharacter.Skills[20].getTotalBonus());
            this.localAbilityMod.Text = Convert.ToString(myCharacter.Skills[20].StatBonus);
            this.localRanks.Text = Convert.ToString(myCharacter.Skills[20].Rank);
            this.localMiscMod.Text = Convert.ToString(myCharacter.Skills[20].Bonus);
            //knowledge(nature)
            this.natureCheckbox.Checked = myCharacter.Skills[21].ClassSkill;
            this.natureTotalBonus.Text = Convert.ToString(myCharacter.Skills[21].getTotalBonus());
            this.natureAbilityMod.Text = Convert.ToString(myCharacter.Skills[21].StatBonus);
            this.natureRanks.Text = Convert.ToString(myCharacter.Skills[21].Rank);
            this.natureMiscMod.Text = Convert.ToString(myCharacter.Skills[21].Bonus);
            //knowledge(nobility)
            this.nobilityCheckbox.Checked = myCharacter.Skills[22].ClassSkill;
            this.nobilityTotalBonus.Text = Convert.ToString(myCharacter.Skills[22].getTotalBonus());
            this.nobilityAbilityMod.Text = Convert.ToString(myCharacter.Skills[22].StatBonus);
            this.nobilityRanks.Text = Convert.ToString(myCharacter.Skills[22].Rank);
            this.nobilityMiscMod.Text = Convert.ToString(myCharacter.Skills[22].Bonus);
            //knowledge(planes)
            this.planesCheckbox.Checked = myCharacter.Skills[23].ClassSkill;
            this.planesTotalBonus.Text = Convert.ToString(myCharacter.Skills[23].getTotalBonus());
            this.planesAbilityMod.Text = Convert.ToString(myCharacter.Skills[23].StatBonus);
            this.planesRanks.Text = Convert.ToString(myCharacter.Skills[23].Rank);
            this.planesMiscMod.Text = Convert.ToString(myCharacter.Skills[23].Bonus);
            //knowledge(religion)
            this.religionCheckbox.Checked = myCharacter.Skills[24].ClassSkill;
            this.religionTotalBonus.Text = Convert.ToString(myCharacter.Skills[24].getTotalBonus());
            this.religionAbilityMod.Text = Convert.ToString(myCharacter.Skills[24].StatBonus);
            this.religionRanks.Text = Convert.ToString(myCharacter.Skills[24].Rank);
            this.religionMiscMod.Text = Convert.ToString(myCharacter.Skills[24].Bonus);
            //linguistics
            this.linguisticsCheckbox.Checked = myCharacter.Skills[25].ClassSkill;
            this.linguisticsTotalBonus.Text = Convert.ToString(myCharacter.Skills[25].getTotalBonus());
            this.linguisticsAbilityMod.Text = Convert.ToString(myCharacter.Skills[25].StatBonus);
            this.linguisticsRanks.Text = Convert.ToString(myCharacter.Skills[25].Rank);
            this.linguisticsMiscMod.Text = Convert.ToString(myCharacter.Skills[25].Bonus);
            //perception
            this.perceptionCheckbox.Checked = myCharacter.Skills[26].ClassSkill;
            this.perceptionTotalBonus.Text = Convert.ToString(myCharacter.Skills[26].getTotalBonus());
            this.perceptionAbilityMod.Text = Convert.ToString(myCharacter.Skills[26].StatBonus);
            this.perceptionRanks.Text = Convert.ToString(myCharacter.Skills[26].Rank);
            this.perceptionMiscMod.Text = Convert.ToString(myCharacter.Skills[26].Bonus);
            //peform 1
            this.performCheckbox1.Checked = myCharacter.Skills[27].ClassSkill;
            //check if skill name has been changed
            if (myCharacter.Skills[27].Name.Equals("Perform"))
            {
                this.performName1.Text = "";
            }
            else
            {
                start = 7;
                length = myCharacter.Skills[27].Name.Length - 1 - start;
                this.performName1.Text = myCharacter.Skills[27].Name.Substring(start, length);
            }
            this.performTotalBonus1.Text = Convert.ToString(myCharacter.Skills[27].getTotalBonus());
            this.performAbilityMod1.Text = Convert.ToString(myCharacter.Skills[27].StatBonus);
            this.performRanks1.Text = Convert.ToString(myCharacter.Skills[27].Rank);
            this.performMiscMod1.Text = Convert.ToString(myCharacter.Skills[27].Bonus);
            //peform 2
            this.performCheckbox2.Checked = myCharacter.Skills[28].ClassSkill;
            //check if skill name has been changed
            if (myCharacter.Skills[28].Name.Equals("Perform"))
            {
                this.performName2.Text = "";
            }
            else
            {
                start = 7;
                length = myCharacter.Skills[28].Name.Length - 1 - start;
                this.performName2.Text = myCharacter.Skills[28].Name.Substring(start, length);
            }
            this.performTotalBonus2.Text = Convert.ToString(myCharacter.Skills[28].getTotalBonus());
            this.performAbilityMod2.Text = Convert.ToString(myCharacter.Skills[28].StatBonus);
            this.performRanks2.Text = Convert.ToString(myCharacter.Skills[28].Rank);
            this.performMiscMod2.Text = Convert.ToString(myCharacter.Skills[28].Bonus);
            //profession 1
            this.professionCheckbox1.Checked = myCharacter.Skills[29].ClassSkill;
            //check if skill name has been changed
            if (myCharacter.Skills[29].Name.Equals("Profession"))
            {
                this.professionName1.Text = "";
            }
            else
            {
                start = 11;
                length = myCharacter.Skills[29].Name.Length - 1 - start;
                this.professionName1.Text = myCharacter.Skills[29].Name.Substring(start, length);
            }
            this.professionTotalBonus1.Text = Convert.ToString(myCharacter.Skills[29].getTotalBonus());
            this.professionAbilityMod1.Text = Convert.ToString(myCharacter.Skills[29].StatBonus);
            this.professionRanks1.Text = Convert.ToString(myCharacter.Skills[29].Rank);
            this.professionMiscMod1.Text = Convert.ToString(myCharacter.Skills[29].Bonus);
            //peform 2
            this.professionCheckbox2.Checked = myCharacter.Skills[30].ClassSkill;
            //check if skill name has been changed
            if (myCharacter.Skills[30].Name.Equals("Profession"))
            {
                this.professionName2.Text = "";
            }
            else
            {
                start = 11;
                length = myCharacter.Skills[30].Name.Length - 1 - start;
                this.professionName2.Text = myCharacter.Skills[30].Name.Substring(start, length);
            }
            this.professionTotalBonus2.Text = Convert.ToString(myCharacter.Skills[30].getTotalBonus());
            this.professionAbilityMod2.Text = Convert.ToString(myCharacter.Skills[30].StatBonus);
            this.professionRanks2.Text = Convert.ToString(myCharacter.Skills[30].Rank);
            this.professionMiscMod2.Text = Convert.ToString(myCharacter.Skills[30].Bonus);
            //ride
            this.rideCheckbox.Checked = myCharacter.Skills[31].ClassSkill;
            this.rideTotalBonus.Text = Convert.ToString(myCharacter.Skills[31].getTotalBonus());
            this.rideAbilityMod.Text = Convert.ToString(myCharacter.Skills[31].StatBonus);
            this.rideRanks.Text = Convert.ToString(myCharacter.Skills[31].Rank);
            this.rideMiscMod.Text = Convert.ToString(myCharacter.Skills[31].Bonus);
            //sense motive
            this.senseMotiveCheckbox.Checked = myCharacter.Skills[32].ClassSkill;
            this.senseMotiveTotalBonus.Text = Convert.ToString(myCharacter.Skills[32].getTotalBonus());
            this.senseMotiveAbilityMod.Text = Convert.ToString(myCharacter.Skills[32].StatBonus);
            this.senseMotiveRanks.Text = Convert.ToString(myCharacter.Skills[32].Rank);
            this.senseMotiveMiscMod.Text = Convert.ToString(myCharacter.Skills[32].Bonus);
            //sleight of hand
            this.sleightOfHandCheckbox.Checked = myCharacter.Skills[33].ClassSkill;
            this.sleightOfHandTotalBonus.Text = Convert.ToString(myCharacter.Skills[33].getTotalBonus());
            this.sleightOfHandAbilityMod.Text = Convert.ToString(myCharacter.Skills[33].StatBonus);
            this.sleightOfHandRanks.Text = Convert.ToString(myCharacter.Skills[33].Rank);
            this.sleightOfHandMiscMod.Text = Convert.ToString(myCharacter.Skills[33].Bonus);
            //spellcraft
            this.spellcraftCheckbox.Checked = myCharacter.Skills[34].ClassSkill;
            this.spellcraftTotalBonus.Text = Convert.ToString(myCharacter.Skills[34].getTotalBonus());
            this.spellcraftAbilityMod.Text = Convert.ToString(myCharacter.Skills[34].StatBonus);
            this.spellcraftRanks.Text = Convert.ToString(myCharacter.Skills[34].Rank);
            this.spellcraftMiscMod.Text = Convert.ToString(myCharacter.Skills[34].Bonus);
            //stealth
            this.stealthCheckbox.Checked = myCharacter.Skills[35].ClassSkill;
            this.stealthTotalBonus.Text = Convert.ToString(myCharacter.Skills[35].getTotalBonus());
            this.stealthAbilityMod.Text = Convert.ToString(myCharacter.Skills[35].StatBonus);
            this.stealthRanks.Text = Convert.ToString(myCharacter.Skills[35].Rank);
            this.stealthMiscMod.Text = Convert.ToString(myCharacter.Skills[35].Bonus);
            //survival
            this.survivalCheckbox.Checked = myCharacter.Skills[36].ClassSkill;
            this.survivalTotalBonus.Text = Convert.ToString(myCharacter.Skills[36].getTotalBonus());
            this.survivalAbilityMod.Text = Convert.ToString(myCharacter.Skills[36].StatBonus);
            this.survivalRanks.Text = Convert.ToString(myCharacter.Skills[36].Rank);
            this.survivalMiscMod.Text = Convert.ToString(myCharacter.Skills[36].Bonus);
            //swim
            this.swimCheckbox.Checked = myCharacter.Skills[37].ClassSkill;
            this.swimTotalBonus.Text = Convert.ToString(myCharacter.Skills[37].getTotalBonus());
            this.swimAbilityMod.Text = Convert.ToString(myCharacter.Skills[37].StatBonus);
            this.swimRanks.Text = Convert.ToString(myCharacter.Skills[37].Rank);
            this.swimMiscMod.Text = Convert.ToString(myCharacter.Skills[37].Bonus);
            //use magic device
            this.useMagicDeviceCheckbox.Checked = myCharacter.Skills[38].ClassSkill;
            this.useMagicDeviceTotalBonus.Text = Convert.ToString(myCharacter.Skills[38].getTotalBonus());
            this.useMagicDeviceAbilityMod.Text = Convert.ToString(myCharacter.Skills[38].StatBonus);
            this.useMagicDeviceRanks.Text = Convert.ToString(myCharacter.Skills[38].Rank);
            this.useMagicDeviceMiscMod.Text = Convert.ToString(myCharacter.Skills[38].Bonus);

            //conditional modifiers
            this.conditionalModifiers.Text = myCharacter.ConditionalModifiers;
            //languages
            this.languages.Text = myCharacter.Languages;

            //set AC item fields
            //names
            this.ACItem1.Text = myCharacter.Defenses.ACItemNames[0];
            this.ACItem2.Text = myCharacter.Defenses.ACItemNames[1];
            this.ACItem3.Text = myCharacter.Defenses.ACItemNames[2];
            this.ACItem4.Text = myCharacter.Defenses.ACItemNames[3];
            this.ACItem5.Text = myCharacter.Defenses.ACItemNames[4];
            //bonus
            this.ACBonus1.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[0, 0]);
            this.ACBonus2.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[1, 0]);
            this.ACBonus3.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[2, 0]);
            this.ACBonus4.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[3, 0]);
            this.ACBonus5.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[4, 0]);
            this.ACBonusTotal.Text = Convert.ToString(myCharacter.Defenses.getTotalACItemsBonus());
            //type
            this.ACType1.Text = myCharacter.Defenses.ACItemStrings[0, 0];
            this.ACType2.Text = myCharacter.Defenses.ACItemStrings[1, 0];
            this.ACType3.Text = myCharacter.Defenses.ACItemStrings[2, 0];
            this.ACType4.Text = myCharacter.Defenses.ACItemStrings[3, 0];
            this.ACType5.Text = myCharacter.Defenses.ACItemStrings[4, 0];
            //ACP
            this.ACP1.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[0, 1]);
            this.ACP2.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[1, 1]);
            this.ACP3.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[2, 1]);
            this.ACP4.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[3, 1]);
            this.ACP5.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[4, 1]);
            this.ACPTotal.Text = Convert.ToString(myCharacter.Defenses.getTotalACItemsACP());
            //spell failure
            this.ACSpellFailure1.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[0, 2]);
            this.ACSpellFailure2.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[1, 2]);
            this.ACSpellFailure3.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[2, 2]);
            this.ACSpellFailure4.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[3, 2]);
            this.ACSpellFailure5.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[4, 2]);
            this.ACSpellFailureTotal.Text = Convert.ToString(myCharacter.Defenses.getTotalACItemsSpell());
            //weight
            this.ACWeight1.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[0, 3]);
            this.ACWeight2.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[1, 3]);
            this.ACWeight3.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[2, 3]);
            this.ACWeight4.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[3, 3]);
            this.ACWeight5.Text = Convert.ToString(myCharacter.Defenses.ACItemStats[4, 3]);
            this.ACWeightTotal.Text = Convert.ToString(myCharacter.Defenses.getTotalACItemsWeight());
            //properties
            this.ACProperties1.Text = myCharacter.Defenses.ACItemStrings[0, 1];
            this.ACProperties2.Text = myCharacter.Defenses.ACItemStrings[1, 1];
            this.ACProperties3.Text = myCharacter.Defenses.ACItemStrings[2, 1];
            this.ACProperties4.Text = myCharacter.Defenses.ACItemStrings[3, 1];
            this.ACProperties5.Text = myCharacter.Defenses.ACItemStrings[4, 1];

            //set gear fields
            //names
            this.gear1.Text = myCharacter.Gear[0];
            this.gear2.Text = myCharacter.Gear[1];
            this.gear3.Text = myCharacter.Gear[2];
            this.gear4.Text = myCharacter.Gear[3];
            this.gear5.Text = myCharacter.Gear[4];
            this.gear6.Text = myCharacter.Gear[5];
            this.gear7.Text = myCharacter.Gear[6];
            this.gear8.Text = myCharacter.Gear[7];
            this.gear9.Text = myCharacter.Gear[8];
            this.gear10.Text = myCharacter.Gear[9];
            this.gear11.Text = myCharacter.Gear[10];
            this.gear12.Text = myCharacter.Gear[11];
            this.gear13.Text = myCharacter.Gear[12];
            this.gear14.Text = myCharacter.Gear[13];
            this.gear15.Text = myCharacter.Gear[14];
            this.gear16.Text = myCharacter.Gear[15];
            this.gear17.Text = myCharacter.Gear[16];
            this.gear18.Text = myCharacter.Gear[17];
            this.gear19.Text = myCharacter.Gear[18];
            this.gear20.Text = myCharacter.Gear[19];
            this.gear21.Text = myCharacter.Gear[20];
            this.gear22.Text = myCharacter.Gear[21];
            this.gear23.Text = myCharacter.Gear[22];
            this.gear24.Text = myCharacter.Gear[23];
            this.gear25.Text = myCharacter.Gear[24];
            this.gear26.Text = myCharacter.Gear[25];
            //weight
            this.gearWeight1.Text = Convert.ToString(myCharacter.GearWeight[0]);
            this.gearWeight2.Text = Convert.ToString(myCharacter.GearWeight[1]);
            this.gearWeight3.Text = Convert.ToString(myCharacter.GearWeight[2]);
            this.gearWeight4.Text = Convert.ToString(myCharacter.GearWeight[3]);
            this.gearWeight5.Text = Convert.ToString(myCharacter.GearWeight[4]);
            this.gearWeight6.Text = Convert.ToString(myCharacter.GearWeight[5]);
            this.gearWeight7.Text = Convert.ToString(myCharacter.GearWeight[6]);
            this.gearWeight8.Text = Convert.ToString(myCharacter.GearWeight[7]);
            this.gearWeight9.Text = Convert.ToString(myCharacter.GearWeight[8]);
            this.gearWeight10.Text = Convert.ToString(myCharacter.GearWeight[9]);
            this.gearWeight11.Text = Convert.ToString(myCharacter.GearWeight[10]);
            this.gearWeight12.Text = Convert.ToString(myCharacter.GearWeight[11]);
            this.gearWeight13.Text = Convert.ToString(myCharacter.GearWeight[12]);
            this.gearWeight14.Text = Convert.ToString(myCharacter.GearWeight[13]);
            this.gearWeight15.Text = Convert.ToString(myCharacter.GearWeight[14]);
            this.gearWeight16.Text = Convert.ToString(myCharacter.GearWeight[15]);
            this.gearWeight17.Text = Convert.ToString(myCharacter.GearWeight[16]);
            this.gearWeight18.Text = Convert.ToString(myCharacter.GearWeight[17]);
            this.gearWeight19.Text = Convert.ToString(myCharacter.GearWeight[18]);
            this.gearWeight20.Text = Convert.ToString(myCharacter.GearWeight[19]);
            this.gearWeight21.Text = Convert.ToString(myCharacter.GearWeight[20]);
            this.gearWeight22.Text = Convert.ToString(myCharacter.GearWeight[21]);
            this.gearWeight23.Text = Convert.ToString(myCharacter.GearWeight[22]);
            this.gearWeight24.Text = Convert.ToString(myCharacter.GearWeight[23]);
            this.gearWeight25.Text = Convert.ToString(myCharacter.GearWeight[24]);
            this.gearWeight26.Text = Convert.ToString(myCharacter.GearWeight[25]);
            this.gearWeightTotal.Text = Convert.ToString(myCharacter.getTotalWeight());

            //set money fields
            this.copper.Text = Convert.ToString(myCharacter.Copper);
            this.silver.Text = Convert.ToString(myCharacter.Silver);
            this.gold.Text = Convert.ToString(myCharacter.Gold);
            this.platinum.Text = Convert.ToString(myCharacter.Platinum);

            //feats
            this.feats.Text = myCharacter.Feats;
            //special abilities
            this.specialAbilities.Text = myCharacter.SpecialAbilities;

            //set experience fields
            this.EXP.Text = Convert.ToString(myCharacter.EXP);
            this.nextLevel.Text = Convert.ToString(myCharacter.NextLevelEXP);
        }
        /**/
        /* void CharacterForm::updatePage(); */
        /**/
    }
}
