using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorDnD5eInitiativeTracker.APIRequests
{
    public class MonsterDictionaryModel
    {
        public string Name {  get; set; }
        public string URL {  get; set; }

        public override string ToString()
        {
            return String.Format("{0},  {1}");
        }
    }
}
