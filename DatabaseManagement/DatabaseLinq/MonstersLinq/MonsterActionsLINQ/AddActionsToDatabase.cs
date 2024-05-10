using ConorDnD5eInitiativeTracker.APIRequests;
using DatabaseModel.Databases;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseLinq.MonstersLinq
{
    internal class AddActionsToDatabase
    {
        internal void AddActions(MonsterModel monster, InitiativeTrackerDB db)
        {
            foreach(var action in monster.actions)
            {
                AddEachActionToDatabase(monster, db, action);
            }
            
        }

        internal void AddEachActionToDatabase(MonsterModel monster, InitiativeTrackerDB db, MonsterAction action) 
        {
            
        }
    }
}
