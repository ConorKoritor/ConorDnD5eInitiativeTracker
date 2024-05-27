using DatabaseLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.DatabaseQueries
{
    public static class PlayerQueries
    {
        public static List<PlayerCharacterBasic> GetPlayers(InitiativeTrackerDB db)
        {
            var query = from p in db.PlayerCharacterBasics
                        select p;

            return query.ToList();
        }

        public static List<PlayerCharacterBasic> SearchPlayers(InitiativeTrackerDB db, string search) 
        {
            var query = from p in db.PlayerCharacterBasics
                        where p.Name.StartsWith(search)
                        select p;
            return query.ToList();
        }

        public static PlayerCharacterBasic GetAPlayer(InitiativeTrackerDB db, string name) 
        {
            var query = from p in db.PlayerCharacterBasics
                        where p.Name == name
                        select p;

            return query.FirstOrDefault();
        }
    }
}
