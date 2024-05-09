namespace DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DifficultyClass
    {
        public int Id { get; set; }

        [Required]
        public string DC_Type { get; set; }

        public short? DC_Value { get; set; }

        [StringLength(200)]
        public string? SpellName { get; set; }

        [StringLength(200)]
        public string? ActionMonsterName { get; set; }

        [StringLength(200)]
        public string? ActionName { get; set; }

        [StringLength(200)]
        public string? LegendaryActionMonsterName { get; set; }

        [StringLength(200)]
        public string? LegendaryActionName { get; set; }

        [StringLength(200)]
        public string? SpecialAbilityMonsterName { get; set; }

        [StringLength(200)]
        public string? SpecialAbilityName { get; set; }

        public virtual SpecialAbility? SpecialAbility { get; set; }

        public virtual Action? Action { get; set; }

        public virtual LegendaryAction? LegendaryAction { get; set; }

        public virtual Spell? Spell { get; set; }
    }
}
