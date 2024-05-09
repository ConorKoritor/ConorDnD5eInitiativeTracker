namespace  DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Senses")]
    public partial class Sense
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public short Passive_Perception { get; set; }

        [StringLength(50)]
        public string? Darkvision { get; set; }

        [StringLength(50)]
        public string? Truesight { get; set; }

        [StringLength(50)]
        public string? Blindsight { get; set; }

        [StringLength(50)]
        public string? Tremorsense { get; set; }

        [StringLength(200)]
        public string MonsterName { get; set; }

        public virtual Monster Monster { get; set; }
    }
}
