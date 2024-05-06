using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorDnD5eInitiativeTracker.APIRequests
{
    public class MonsterDictionaryResponseModel
    {
        public int count { get; set; }
        public List<MonsterDictionaryModel> results { get; set; }
    }

    public class MonsterDictionaryModel
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return String.Format("{0},  {1}");
        }
    }
}
