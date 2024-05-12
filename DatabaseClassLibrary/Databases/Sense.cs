namespace  DatabaseClassLibrary.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sense
    {
        public int Id { get; set; }

        public short Passive_Perception { get; set; }

        
        public string? Darkvision { get; set; }

        
        public string? Truesight { get; set; }

        
        public string? Blindsight { get; set; }

        
        public string? Tremorsense { get; set; }

        [StringLength(200)]
        public string MonsterName { get; set; }

        public virtual Monster Monster { get; set; }
    }
}
