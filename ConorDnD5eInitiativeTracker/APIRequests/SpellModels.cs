using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorDnD5eInitiativeTracker.APIRequests
{
    //Models for API /spell/{spellName}
    //Response comes with many JSON Objects that are all represented here. Not all will be needed for program but I would rather it work and have too many properties
    public class AreaOfEffect
    {
        public string type { get; set; }
        public int size { get; set; }
    }

    public class Class
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Damage
    {
        public DamageType damage_type { get; set; }
        public DamageAtSlotLevel damage_at_slot_level { get; set; }
    }

    public class DamageAtSlotLevel
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

    public class DamageType
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Dc
    {
        public DcType dc_type { get; set; }
        public string dc_success { get; set; }
    }

    public class DcType
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

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
        public Damage damage { get; set; }
        public Dc dc { get; set; }
        public AreaOfEffect area_of_effect { get; set; }
        public School school { get; set; }
        public List<Class> classes { get; set; }
        public List<Subclass> subclasses { get; set; }
        public string url { get; set; }
    }

    public class School
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Subclass
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }


}
