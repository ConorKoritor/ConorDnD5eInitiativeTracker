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
    
    public partial class SpellCastingStats
    {
        public int Id { get; set; }
        public short Level { get; set; }
        public string Ability { get; set; }
        public short DC { get; set; }
        public short Modifier { get; set; }
        public string School { get; set; }
        public short L1_Slots { get; set; }
        public Nullable<short> L2_Slots { get; set; }
        public Nullable<short> L3_Slots { get; set; }
        public Nullable<short> L4_Slots { get; set; }
        public Nullable<short> L5_Slots { get; set; }
        public Nullable<short> L6_Slots { get; set; }
        public Nullable<short> L7_Slots { get; set; }
        public Nullable<short> L8_Slots { get; set; }
        public Nullable<short> L9_Slots { get; set; }
    
        public virtual Monster Monster { get; set; }
    }
}
