using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.APIRequests
{
    //Models for Monsters coming out of API /api/monsters/{monsterName}
    //Saves the api responses as objects
    //These are all monsters based off DnD 5e

    
    //In Monster Model it saves the monster, its stats and name
    //It also has lists for armor classes, actions, proficiencies, condition immunities, special abilities
    //and legendary actions
    //It also crates objects of speed and senses
    public class MonsterModel
    {
        public string index { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string alignment { get; set; }
        public List<MonsterArmorClassModel> armor_class { get; set; }
        public int hit_points { get; set; }
        public string hit_dice { get; set; }
        public string hit_points_roll { get; set; }
        public MonsterSpeedModel speed { get; set; }
        public int strength { get; set; }
        public int dexterity { get; set; }
        public int constitution { get; set; }
        public int intelligence { get; set; }
        public int wisdom { get; set; }
        public int charisma { get; set; }
        public List<MonsterProficiencyModel> proficiencies { get; set; }
        public List<object> damage_vulnerabilities { get; set; }
        public List<object> damage_resistances { get; set; }
        public List<object> damage_immunities { get; set; }
        public List<MonsterConditionImmunityModel> condition_immunities { get; set; }
        public MonsterSensesModel senses { get; set; }
        public string languages { get; set; }
        public double challenge_rating { get; set; }
        public int proficiency_bonus { get; set; }
        public int xp { get; set; }
        public List<MonsterSpecialAbilityModel> special_abilities { get; set; }
        public List<MonsterActionModel> actions { get; set; }
        public List<MonsterLegendaryActionModel> legendary_actions { get; set; }
        public string image { get; set; }
        public string url { get; set; }
    }

        //Action Model it saves the Actions for each Monster
        //It creates an object for dc and the usage stats (usage means how many times the monster can use this action)
        //It also holds lists for the damages that an action may have
        public class MonsterActionModel
        {
            public string name { get; set; }
            public string multiattack_type { get; set; }
            public string desc { get; set; }
            public List<MonsterActionModel> actions { get; set; }
            public int attack_bonus { get; set; }
            public MonsterDcModel dc { get; set; }
            public List<MonsterDamageModel> damage { get; set; }
            public MonsterUsageModel usage { get; set; }
            public string action_name { get; set; }
            public string count { get; set; }
            public string type { get; set; }
        }

        //Armor class model holds the type of Armor class (armor or spell) and the AC value for the monster
        public class MonsterArmorClassModel
        {
            public string type { get; set; }
            public int value { get; set; }
        }

        //Monster Damage holds the stats for the damage an action may do.
        //It holds the type of damage (fire, lightning, force, etc.)
        //It also holds the damage Dice (ex. 1d4+5) and DC
        //
        //From holds the possible damage choice that can happen in an action. 
        //Sometimes an action can either do 1 type of damage or another
        //(ex This attack can eiother do 1d6 lightning or radiant)
        public class MonsterDamageModel
        {
            public MonsterDamageTypeModel damage_type { get; set; }
            public string damage_dice { get; set; }
            public int? choose { get; set; }
            public string choice_type { get; set; }
            public MonsterFromModel from { get; set; }
            public MonsterDcModel dc { get; set; }
        }

        //Damage Type holds the type of damage (ex Lightning, Radiant, Force, Fire)
        public class MonsterDamageTypeModel
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        //DC holds the possible difficulty class of an action
        //It holds an object of DC Type that holds what skill the DC checks
        //DC Value holds the amount someone has to roll to beat the DC
        //Success type holds what happens if a person succeeds the DC
        public class MonsterDcModel
        {
            public MonsterDcTypeModel dc_type { get; set; }
            public int dc_value { get; set; }
            public string success_type { get; set; }
        }

        //DC Type holds what skill the DC checks
        public class MonsterDcTypeModel
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        //Similar to Action Model but holds legendary actions of monsters
        public class MonsterLegendaryActionModel
        {
            public string name { get; set; }
            public string desc { get; set; }
            public int attack_bonus { get; set; }
            public MonsterDcModel dc { get; set; }
            public List<MonsterDamageModel> damage { get; set; }
        }

        //Holds what proficiencies the monster has
        //Value is the bonus to that skill the monster has
        //It holds an object of Proficiency type
        public class MonsterProficiencyModel
        {
            public int value { get; set; }
            public MonsterProficiencyTypeModel proficiency { get; set; }
        }

        //Proficiency type holds the name of the skill the monster has proficiency in
        public class MonsterProficiencyTypeModel
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        
        //Monster senses holds the senses a monster
        public class MonsterSensesModel
        {
            public string darkvision { get; set; }
            public int passive_perception { get; set; }
            public string truesight {  get; set; }
            public string blindsight {  get; set; }
            public string tremorsense {  get; set; }
        }

        //Condition Immunity Holds the names of the condition the monster is immune to
        public class MonsterConditionImmunityModel
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        //Similar to action and legendary action this holds the special abilitites of a monster
        //We have Damage and dc which is the same as before
        //We also have an object of spellcasting which holds the possible spellcasting stats of a monster
        public class MonsterSpecialAbilityModel
        {
            public string name { get; set; }
            public string desc { get; set; }
            public MonsterUsageModel usage { get; set; }
            public MonsterDcModel dc { get; set; }
            public MonsterSpellcastingModel spellcasting { get; set; }
        }

        //Speed Model holds the different speeds of a monster
        //(walk will be for most monsters while some can fly/swim/burrow/climb)
        public class MonsterSpeedModel
        {
            public string walk { get; set; }
            public string swim { get; set; }
            public string fly { get; set; }
            public string burrow {  get; set; }
            public string climb { get; set; }
        }

        //The usage model is for if an action/spell can only be used a certain number of times 
        //before the monster runs out of uses
        //Or if the monster has a recharge ability
        //Type is the type of usag (recharge/ per day)
        //Dice is the dice rolled if it is a recharge ability
        //Times is the amount of times it could be used per day if it is per day
        public class MonsterUsageModel
        {
            public string type { get; set; }
            public string dice {  get; set; }
            public int min_value {  get; set; }
            public int times { get; set; }
            public List<object> rest_types { get; set; }
        }

        //SpellCasting ability model holds what ability a monster uses to cast spells
        //(Charisma, Intelligence etc.)
        public class MonsterSpellcastingAbilityModel
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        //Spell Model holds what spells the Monster knows and can cast
        //name holds the name of the spell and level holds the level of the spell
        //It also creates an object of usage because some monsters can only cast spells a certain amount of times a day
        public class MonsterSpellModel
        {
            public string name { get; set; }
            public int level { get; set; }
            public string url { get; set; }
            public MonsterUsageModel usage { get; set; }
        }

        //Spellcasting modwel holds the spellcasting stats of a monster
        //It creates an object of Ability Model top hold what ability the monster casts with
        //It holds the Difficulty Class of the Monsters spellcasting (ex DC 14)
        //Level holds what level spellcaster the monste is (ex 18th Level Wizard)
        //Modifier holds the modifier for spell rolls for the monster (ex +7)
        //School holds what schopol the monster is a part of (ex Sorcerer, Wizard, Bard, etc)
        //Holds an object of Slots which shows what spellslots of each level the monster has
        //Holds a list o spells the monster has
        public class MonsterSpellcastingModel
        {
            public MonsterSpellcastingAbilityModel ability { get; set; }
            public int dc { get; set; }
            public int level { get; set; }
            public int modifier { get; set; }
            public string school { get; set; }
            public MonsterSpellSlotsModel slots { get; set; }
            public List<string> components_required { get; set; }
            public List<MonsterSpellModel> spells { get; set; }
        }

        //Model for the amount of spell slots at each level a monster has
        public class MonsterSpellSlotsModel
        {
            [JsonProperty("1")]
            public int _1 { get; set; }

            [JsonProperty("2")]
            public int _2 { get; set; }

            [JsonProperty("3")]
            public int _3 { get; set; }

            [JsonProperty("4")]
            public int _4 { get; set; }

            [JsonProperty("5")]
            public int _5 { get; set; }

            [JsonProperty("6")]
            public int _6 { get; set; }

            [JsonProperty("7")]
            public int _7 { get; set; }

            [JsonProperty("8")]
            public int _8 { get; set; }

            [JsonProperty("9")]
            public int _9 { get; set; }
        }

    //This is a Model that holds a list of options that sometimes appear in damages
    //For some actions a Dungeon Master may choose what type of damage they can deal
    //Holds a list of options which are just different damage types and amounts
    public class MonsterFromModel
    {
        public string option_set_type { get; set; }
        public List<MonsterOptionModel> options { get; set; }
    }

    //Basically the same as Damage Model but had to be different for the api (read comment above MonsterFromModel)
    public class MonsterOptionModel
    {
        public string option_type { get; set; }
        public MonsterDamageTypeModel damage_type { get; set; }
        public string damage_dice { get; set; }
    }

}
