

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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ScenarioName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string PlayerName { get; set; }

        public Scenario Scenario { get; set; }
        public PlayerCharacterBasic Player { get; set; }
    }
}
