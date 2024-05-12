namespace DatabaseClassLibrary.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ability
    {
        public int Id { get; set; }

        public short Strength { get; set; }

        public short Dexterity { get; set; }

        public short Constitution { get; set; }

        public short Intelligence { get; set; }

        public short Wisdom { get; set; }

        public short Charisma { get; set; }

        public short Proficiency_Bonus { get; set; }

        [Required]
        [StringLength(200)]
        public string MonsterName { get; set; }

        public virtual Monster Monster { get; set; }
    }
}
