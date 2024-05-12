namespace DatabaseClassLibrary.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SpecialAbility
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Desc { get; set; }

        public bool IsDC {  get; set; }
        public bool IsUsage {  get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        [StringLength(200)]
        public string MonsterName { get; set; }

        public virtual Monster Monster { get; set; }
    }
}
