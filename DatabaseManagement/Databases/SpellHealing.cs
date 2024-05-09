namespace DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SpellHealing
    {
        public int Id { get; set; }

        public string? Healing_L1 { get; set; }

        public string? Healing_L2 { get; set; }

        public string? Healing_L3 { get; set; }

        public string? Healing_L4 { get; set; }

        public string? Healing_L5 { get; set; }

        public string? Healing_L6 { get; set; }

        public string? Healing_L7 { get; set; }

        public string? Healing_L8 { get; set; }

        public string? Healing_L9 { get; set; }

        [Required]
        [StringLength(200)]
        public string SpellName { get; set; }

        public virtual Spell Spell { get; set; }
    }
}
