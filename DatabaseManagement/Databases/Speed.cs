namespace DatabaseModel.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Speed
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Distance { get; set; }

        [Required]
        [StringLength(200)]
        public string MonsterName { get; set; }

        public virtual Monster Monster { get; set; }
    }
}
