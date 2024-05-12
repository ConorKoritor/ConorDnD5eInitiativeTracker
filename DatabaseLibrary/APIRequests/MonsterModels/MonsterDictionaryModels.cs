using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.APIRequests
{
    //Models for API /monsters
    public class MonsterDictionaryResponseModel
    {
        //Model for root of API response
        public int count { get; set; }
        public List<MonsterDictionaryModel> results { get; set; }
    }

    public class MonsterDictionaryModel
    {
        //Model for each individual Monster
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return String.Format("{0},  {1}");
        }
    }
}
