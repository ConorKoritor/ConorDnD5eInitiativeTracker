using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.APIRequests
{
    //TODO: If I have Time add conditions functionality
    //Pulls down dictionary of Consitions from the API and saves them
    public class ConditionsDictionaryAPIRequests
    {


        private readonly List<string> conditionsAPILinks = new List<string>();

        public ConditionsDictionaryAPIRequests()
        {
        }

        public List<string> GetConditionsAPILinks()
        {
            return conditionsAPILinks;
        }
    }
    public class ConditionsAPIRequests
    {

        public ConditionsAPIRequests()
        {

        }
    }
}
