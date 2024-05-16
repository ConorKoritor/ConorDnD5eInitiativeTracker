using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorDnD5eInitiativeTracker.MVVM.Models
{
    public class MonsterListItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size {  get; set; }
        public string Challenge_Rating {  get; set; }
        public string Alignment {  get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
