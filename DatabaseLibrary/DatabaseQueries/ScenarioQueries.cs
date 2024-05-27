using DatabaseLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.DatabaseQueries
{
    public static class ScenarioQueries
    {
        public static List<Scenario> GetScenarios(InitiativeTrackerDB db)
        {
            var query = from s in db.Scenarios
                        select s;

            return query.ToList();
        }

        public static List<MonsterScenarioTable> GetMonsterScenarios(InitiativeTrackerDB db, string scenarioName) 
        {
            var query = from s in db.MonsterScenarios
                        where s.ScenarioName == scenarioName
                        select s;

            return query.ToList();
        }

        public static List<PlayerScenarioTable> GetPlayerScenarios(InitiativeTrackerDB db, string scenarioName)
        {
            var query = from s in db.PlayerScenarios
                        where s.ScenarioName == scenarioName
                        select s;

            return query.ToList();
        }
    }
}
