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
    
    public partial class SpecialAbility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int MonsterId { get; set; }
    
        public virtual Monster Monster { get; set; }
    }
}
