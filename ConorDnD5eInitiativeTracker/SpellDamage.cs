//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConorDnD5eInitiativeTracker
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpellDamage
    {
        public int Id { get; set; }
        public string Damage_Type { get; set; }
        public string Damage_L1 { get; set; }
        public string Damage_L2 { get; set; }
        public string Damage_L3 { get; set; }
        public string Damage_L4 { get; set; }
        public string Damage_L5 { get; set; }
        public string Damage_L6 { get; set; }
        public string Damage_L7 { get; set; }
        public string Damage_L8 { get; set; }
        public string Damage_L9 { get; set; }
        public int SpellId { get; set; }
    
        public virtual Spell Spell { get; set; }
    }
}
