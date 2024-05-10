using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorDnD5eInitiativeTracker.APIRequests
{
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

        public class MonsterArmorClassModel
        {
            public string type { get; set; }
            public int value { get; set; }
        }

        public class MonsterDamageModel
        {
            public MonsterDamageTypeModel damage_type { get; set; }
            public string damage_dice { get; set; }
        }

        public class MonsterDamageTypeModel
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class MonsterDcModel
        {
            public MonsterDcTypeModel dc_type { get; set; }
            public int dc_value { get; set; }
            public string success_type { get; set; }
        }

        public class MonsterDcTypeModel
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class MonsterLegendaryActionModel
        {
            public string name { get; set; }
            public string desc { get; set; }
            public int attack_bonus { get; set; }
            public MonsterDcModel dc { get; set; }
            public List<MonsterDamageModel> damage { get; set; }
        }

        public class MonsterProficiencyModel
        {
            public int value { get; set; }
            public MonsterProficiencyTypeModel proficiency { get; set; }
        }

        public class MonsterProficiencyTypeModel
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

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

        public class MonsterSensesModel
        {
            public string darkvision { get; set; }
            public int passive_perception { get; set; }
            public string truesight {  get; set; }
            public string blindsight {  get; set; }
            public string tremorsense {  get; set; }
        }

        public class MonsterConditionImmunityModel
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class MonsterSpecialAbilityModel
        {
            public string name { get; set; }
            public string desc { get; set; }
            public MonsterUsageModel usage { get; set; }
            public MonsterDcModel dc { get; set; }
            public MonsterSpellcastingModel spellcasting { get; set; }
        }

        public class MonsterSpeedModel
        {
            public string walk { get; set; }
            public string swim { get; set; }
            public string fly { get; set; }
            public string burrow {  get; set; }
            public string climb { get; set; }
        }

        public class MonsterUsageModel
        {
            public string type { get; set; }
            public int times { get; set; }
            public List<object> rest_types { get; set; }
        }

        public class MonsterSpellcastingAbilityModel
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class MonsterSpellModel
        {
            public string name { get; set; }
            public int level { get; set; }
            public string url { get; set; }
            public MonsterUsageModel usage { get; set; }
        }

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




    
}
