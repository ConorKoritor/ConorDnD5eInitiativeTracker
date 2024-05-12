namespace DatabaseLibrary.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConditionImmunity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        [StringLength(200)]
        public string MonsterName { get; set; }

        public virtual Monster Monster { get; set; }
    }
}
