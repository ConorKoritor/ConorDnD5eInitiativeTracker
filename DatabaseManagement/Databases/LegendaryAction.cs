namespace DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LegendaryAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LegendaryAction()
        {
            Damages = new HashSet<Damage>();
            DifficultyClasses = new HashSet<DifficultyClass>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public string Desc { get; set; }

        public short? Attack_Bonus { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string MonsterName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Damage> Damages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DifficultyClass> DifficultyClasses { get; set; }

        public virtual Monster Monster { get; set; }
    }
}
