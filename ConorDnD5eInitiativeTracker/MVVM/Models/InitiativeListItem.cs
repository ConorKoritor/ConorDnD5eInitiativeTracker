using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorDnD5eInitiativeTracker.MVVM.Models
{
    public class InitiativeListItem : IComparable<InitiativeListItem>
    {
        public string Name { get; set; }
        public int Initiative { get; set; }
        public int Initiative_Modifier {  get; set; }
        public int HP {  get; set; }
        public int Current_HP { get; set;}
        public bool Is_Monster {  get; set; }

        public int CompareTo(InitiativeListItem other)
        {
            if(other == null) return 1;

            return Initiative.CompareTo(other.Initiative);
        }
    }
}
