namespace DatabaseLibrary.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlayerCharacterBasic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlayerCharacterBasic()
        {
            PlayerScenarios = new HashSet<PlayerScenarioTable>();
        }

        [Key]
        public int Id { get; set; }

        public int HP { get; set; }

        public short AC { get; set; }

        public int CR_2_Score { get; set; }

        [Required]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerScenarioTable> PlayerScenarios { get; set; }
    }
}
