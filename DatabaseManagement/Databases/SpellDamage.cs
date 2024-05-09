namespace DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SpellDamage
    {
        public int Id { get; set; }

        public string? Damage_Type { get; set; }

        public string? Damage_L1 { get; set; }

        public string? Damage_L2 { get; set; }

        public string? Damage_L3 { get; set; }

        public string? Damage_L4 { get; set; }

        public string? Damage_L5 { get; set; }

        public string? Damage_L6 { get; set; }

        public string? Damage_L7 { get; set; }

        public string? Damage_L8 { get; set; }

        public string? Damage_L9 { get; set; }

        [Required]
        [StringLength(200)]
        public string SpellName { get; set; }

        public virtual Spell Spell { get; set; }
    }
}
