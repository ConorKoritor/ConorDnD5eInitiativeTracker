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
    
    public partial class Action
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Action()
        {
            this.Damages = new HashSet<Damage>();
            this.DifficultyClasses = new HashSet<DifficultyClass>();
        }
    
        public string Name { get; set; }
        public string Desc { get; set; }
        public Nullable<short> Attack_Bonus { get; set; }
        public string Usage_Type { get; set; }
        public Nullable<short> Usage_Times { get; set; }
        public string MonsterName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Damage> Damages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DifficultyClass> DifficultyClasses { get; set; }
        public virtual Monster Monster { get; set; }
    }
}