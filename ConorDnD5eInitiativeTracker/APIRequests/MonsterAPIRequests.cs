using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;


namespace ConorDnD5eInitiativeTracker.APIRequests
{
    class MonsterAPIRequests
    {

        private readonly IAPILink _apilink;

        public MonsterAPIRequests(IAPILink apilink)
        {
            _apilink = apilink;
        }

        private void PullAPIMonsterDictionary()
        {

        }
    }

    class SpellsAPIRequests
    {

        private readonly IAPILink _apilink;

        public SpellsAPIRequests(IAPILink apilink)
        {
            _apilink = apilink;
        }
    }

    class ConditionsAPIRequests
    {

        private readonly IAPILink _apilink;

        public ConditionsAPIRequests(IAPILink apilink)
        {
            _apilink = apilink;
        }
    }
}
