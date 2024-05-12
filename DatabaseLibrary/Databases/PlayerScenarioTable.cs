

namespace DatabaseLibrary.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class PlayerScenarioTable
    {
        [Key]
        [Column(Order = 0)]
        public int ScenarioID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PlayerID { get; set; }

        public Scenario Scenario { get; set; }
        public PlayerCharacterBasic Player { get; set; }
    }
}
