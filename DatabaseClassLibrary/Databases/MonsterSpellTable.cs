

namespace DatabaseClassLibrary.Databases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class MonsterSpellTable
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        public string MonsterName {  get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string SpellName {  get; set; }

        public bool IsUsage {  get; set; }

        public Monster Monster { get; set; }

        public Spell Spell { get; set; }
    }
}
