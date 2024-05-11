namespace DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usage
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int? Times { get; set; }
        public int? MinDiceValue { get; set; }
        public string? Dice {  get; set; }
        [StringLength(200)]
        public string? ActionMonsterName { get; set; }

        [StringLength(200)]
        public string? ActionName { get; set; }

        [StringLength(200)]
        public string? SpecialAbilityMonsterName { get; set; }

        [StringLength(200)]
        public string? SpecialAbilityName { get; set; }

        [StringLength(200)]
        public string? MonsterSpellMonsterName { get; set; }

        [StringLength(200)]
        public string? MonsterSpellSpellName { get; set; }

        public virtual MonsterSpellTable? SpellMonster { get; set; }

        public virtual SpecialAbility? SpecialAbility { get; set; }

        public virtual CombatAction? Action { get; set; }
    }
}
