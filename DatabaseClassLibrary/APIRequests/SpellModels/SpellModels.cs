
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClassLibrary.APIRequests
{
    //Models for API /spell/{spellName}
    //Response comes with many JSON Objects that are all represented here. Not all will be needed for program but
    //I would rather it work and have too many properties 

    //This is the root that holds the bulk of the spell
    //Holds the name of the spell, descritption, range, etc.
    //Also has bool values for if it can be ritual cast or if it is a concentration spell
    //It creates objects of the DamageModel, DCModel, Area of Effect Model, School Model, and SpellHealAtSlotLevelModel
    //It also holds a list of the SpellClassModel and SpellSubClassModel
    //These Models are explained below
    public class SpellModel
    {
        //Model for root of API response
        public string index { get; set; }
        public string name { get; set; }
        public List<string> desc { get; set; }
        public List<string> higher_level { get; set; }
        public string range { get; set; }
        public List<string> components { get; set; }
        public bool ritual { get; set; }
        public string duration { get; set; }
        public bool concentration { get; set; }
        public string casting_time { get; set; }
        public int level { get; set; }
        public SpellDamageModel damage { get; set; }
        public SpellDcModel dc { get; set; }
        public SpellAreaOfEffectModel area_of_effect { get; set; }
        public SpellSchoolModel school { get; set; }
        public List<SpellClassModel> classes { get; set; }
        public List<SpellSubclassModel> subclasses { get; set; }
        public string url { get; set; }
        public SpellHealAtSlotLevelModel heal_at_slot_level { get; set; }
    }

    public class SpellAreaOfEffectModel
    {
        public string type { get; set; }
        public int size { get; set; }
    }

    public class SpellClassModel
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class SpellDamageModel
    {
        public SpellDamageTypeModel damage_type { get; set; }
        public SpellDamageAtSlotLevelModel damage_at_slot_level { get; set; }
        public SpellDamageAtCharacterLevelModel damage_at_character_level {  get; set; }
    }

    public class SpellDamageAtCharacterLevelModel
    {
        [JsonProperty("1")]
        public string _1 { get; set; }

        [JsonProperty("2")]
        public string _2 { get; set; }

        [JsonProperty("3")]
        public string _3 { get; set; }

        [JsonProperty("4")]
        public string _4 { get; set; }

        [JsonProperty("5")]
        public string _5 { get; set; }

        [JsonProperty("6")]
        public string _6 { get; set; }

        [JsonProperty("7")]
        public string _7 { get; set; }

        [JsonProperty("8")]
        public string _8 { get; set; }

        [JsonProperty("9")]
        public string _9 { get; set; }

        [JsonProperty("10")]
        public string _10 { get; set; }

        [JsonProperty("11")]
        public string _11 { get; set; }

        [JsonProperty("12")]
        public string _12 { get; set; }

        [JsonProperty("13")]
        public string _13 { get; set; }

        [JsonProperty("14")]
        public string _14 { get; set; }

        [JsonProperty("15")]
        public string _15 { get; set; }

        [JsonProperty("16")]
        public string _16 { get; set; }

        [JsonProperty("17")]
        public string _17 { get; set; }

        [JsonProperty("18")]
        public string _18 { get; set; }

        [JsonProperty("19")]
        public string _19 { get; set; }

        [JsonProperty("20")]
        public string _20 { get; set; }
    }

    public class SpellDamageAtSlotLevelModel
    {
        [JsonProperty("1")]
        public string _1 { get; set; }

        [JsonProperty("2")]
        public string _2 { get; set; }

        [JsonProperty("3")]
        public string _3 { get; set; }

        [JsonProperty("4")]
        public string _4 { get; set; }

        [JsonProperty("5")]
        public string _5 { get; set; }

        [JsonProperty("6")]
        public string _6 { get; set; }

        [JsonProperty("7")]
        public string _7 { get; set; }

        [JsonProperty("8")]
        public string _8 { get; set; }

        [JsonProperty("9")]
        public string _9 { get; set; }
    }

    public class SpellHealAtSlotLevelModel
    {
        [JsonProperty("1")]
        public string _1 { get; set; }

        [JsonProperty("2")]
        public string _2 { get; set; }

        [JsonProperty("3")]
        public string _3 { get; set; }

        [JsonProperty("4")]
        public string _4 { get; set; }

        [JsonProperty("5")]
        public string _5 { get; set; }

        [JsonProperty("6")]
        public string _6 { get; set; }

        [JsonProperty("7")]
        public string _7 { get; set; }

        [JsonProperty("8")]
        public string _8 { get; set; }

        [JsonProperty("9")]
        public string _9 { get; set; }
    }

    public class SpellDamageTypeModel
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class SpellDcModel
    {
        public SpellDcTypeModel dc_type { get; set; }
        public string dc_success { get; set; }
    }

    public class SpellDcTypeModel
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    

    public class SpellSchoolModel
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class SpellSubclassModel
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }


}
