//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConorDnD5eInitiativeTracker.Databases
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArmorClass
    {
        public int Id { get; set; }
        public string Ac_Type { get; set; }
        public short AC { get; set; }
        public string MonsterName { get; set; }
    
        public virtual Monster Monster { get; set; }
    }
}