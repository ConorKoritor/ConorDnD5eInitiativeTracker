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
    
    public partial class CharacterScenarioTable
    {
        public int Id { get; set; }
        public int ScenarioId { get; set; }
        public int PlayerCharacterBasicId { get; set; }
    
        public virtual Scenario Scenario { get; set; }
        public virtual PlayerCharacterBasic PlayerCharacterBasic { get; set; }
    }
}
