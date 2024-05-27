using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorDnD5eInitiativeTracker.MVVM.Models
{
    public class PlayerListItem
    {
        public int HP { get; set; }

        public short AC { get; set; }

        public int CR_2_Score { get; set; }

        public short Level { get; set; }

        public string Name { get; set; }
    }
}
