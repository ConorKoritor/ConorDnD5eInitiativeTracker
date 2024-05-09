namespace DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SpellCastingStat
    {
        public int Id { get; set; }

        public short Level { get; set; }

        [Required]
        public string Ability { get; set; }

        public short DC { get; set; }

        public short Modifier { get; set; }

        
        public string? School { get; set; }

        public short? L1_Slots { get; set; }

        public short? L2_Slots { get; set; }

        public short? L3_Slots { get; set; }

        public short? L4_Slots { get; set; }

        public short? L5_Slots { get; set; }

        public short? L6_Slots { get; set; }

        public short? L7_Slots { get; set; }

        public short? L8_Slots { get; set; }

        public short? L9_Slots { get; set; }

        [Required]
        [StringLength(200)]
        public string MonsterName { get; set; }

        public virtual Monster Monster { get; set; }
    }
}
