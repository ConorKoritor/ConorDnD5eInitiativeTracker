using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.Databases
{
    public partial class Reaction
    {
        [Key]
        public int ID {  get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string MonsterName {  get; set; }

        public virtual Monster Monster { get; set; }
    }
}
