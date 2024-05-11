namespace DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Damage
    {
        public int Id { get; set; }

        public string? Damage_Type { get; set; }
        public bool IsOption {  get; set; }

        [Required]
        public string Damage_Dice { get; set; }

        [StringLength(200)]
        public string? ActionMonsterName { get; set; }

        [StringLength(200)]
        public string? ActionName { get; set; }

        [StringLength(200)]
        public string? LegendaryActionMonsterName { get; set; }

        [StringLength(200)]
        public string? LegendaryActionName { get; set; }

        public virtual CombatAction? Action { get; set; }

        public virtual LegendaryAction? LegendaryAction { get; set; }
    }
}
