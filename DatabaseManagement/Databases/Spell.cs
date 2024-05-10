namespace DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Spell
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Spell()
        {
            DifficultyClasses = new HashSet<DifficultyClass>();
            SpellDamageAtCharacterLevels = new HashSet<SpellDamageAtCharacterLevel>();
            SpellDamages = new HashSet<SpellDamage>();
            SpellHealings = new HashSet<SpellHealing>();
            SpellMonsters = new HashSet<MonsterSpellTable>();
        }

        [Key]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Range { get; set; }

        [Required]
        public string Components { get; set; }

        public bool IsRitual { get; set; }

        [Required]
        public string Duration { get; set; }

        public bool IsConcentration { get; set; }

        [Required]
        public string Casting_Time { get; set; }

        public int Level { get; set; }

        [Required]
        public string School { get; set; }

        public string Higher_Level { get; set; }

        public string Material { get; set; }

        public string Area_Of_Effect_Type { get; set; }

        public int? Area_Of_Effect_Size { get; set; }

        public string DC_Type { get; set; }

        public string DC_Success { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DifficultyClass> DifficultyClasses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpellDamageAtCharacterLevel> SpellDamageAtCharacterLevels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpellDamage> SpellDamages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpellHealing> SpellHealings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonsterSpellTable> SpellMonsters { get; set; }
    }
}
