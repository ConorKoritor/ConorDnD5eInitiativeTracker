using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.APIRequests
{
    //These are models for pulling down from the api /spells
    public class SpellDictionaryResponseModel
    {
        //Model for the root response
        public int count { get; set; }
        public List<SpellDictionaryModel> results { get; set; }
    }

    public class SpellDictionaryModel
    {
        //Model for each individual spell response
        public string index { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public string url { get; set; }
    }
}
