

namespace DatabaseLibrary.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class MonsterScenarioTable
    {
        [Key]
        [Column(Order = 0)]
        public int ScenarioID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string MonsterName { get; set; }

        public Monster Monster { get; set; }
        public Scenario Scenario { get; set; }
    }
}
