namespace DatabaseLibrary.Databases
{
    using DatabaseLibrary.APIRequests;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Monster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Monster()
        {
            Abilities = new HashSet<Ability>();
            CombatActions = new HashSet<CombatAction>();
            ArmorClasses = new HashSet<ArmorClass>();
            ConditionImmunities = new HashSet<ConditionImmunity>();
            LegendaryActions = new HashSet<LegendaryAction>();
            Proficiencies = new HashSet<Proficiency>();
            Senses = new HashSet<Sense>();
            SpecialAbilities = new HashSet<SpecialAbility>();
            Speeds = new HashSet<Speed>();
            SpellCastingStats = new HashSet<SpellCastingStat>();
            MonsterScenarios = new HashSet<MonsterScenarioTable>();
            SpellMonsters = new HashSet<MonsterSpellTable>();
        }

        [Key]
        [StringLength(200)]
        public string Name { get; set; }

        public int HP { get; set; }

        public short Initiative_Modifier { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Hit_Dice { get; set; }

        [Required]
        public string Hit_Points_Roll { get; set; }

        [Required]
        public string Alignment { get; set; }

        public string? Languages { get; set; }

        public double Challenge_Rating { get; set; }

        public int XP { get; set; }

        public string Damage_Vulnerabilities { get; set; }

        public string Damage_Resistances { get; set; }

        public string Damage_Immunities { get; set; }

        public bool IsSpellcaster { get; set; }
        
        public string? Image {  get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ability> Abilities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CombatAction> CombatActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArmorClass> ArmorClasses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConditionImmunity> ConditionImmunities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LegendaryAction> LegendaryActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proficiency> Proficiencies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sense> Senses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpecialAbility> SpecialAbilities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Speed> Speeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpellCastingStat> SpellCastingStats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonsterSpellTable> SpellMonsters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonsterScenarioTable> MonsterScenarios { get; set; }
    }
}
