using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ConorDnD5eInitiativeTracker.APIRequests;
using DatabaseModel.Databases;

namespace DatabaseModel.DatabaseLinq.SpellsLinq
{
    public class GetSpellsForDatabase
    {

        CheckHealingOrDamage checkHealingOrDamage = new CheckHealingOrDamage();
        AddSpellsToDatabase addSpellsToDatabase = new AddSpellsToDatabase();
        List<SpellModel> spells = new List<SpellModel>();

        public async Task GetSpellsAndInsertToDatabase(InitiativeTrackerDB db)
        {
            Console.WriteLine("Getting Spells");
            spells = await GetSpells();

            Console.WriteLine("Spells Retrieved, Looping through spells");

            await LoopThroughSpells(db);
        }

        public async Task LoopThroughSpells(InitiativeTrackerDB db)
        {
            foreach (var spellResult in spells)
            {
                Console.WriteLine("Adding Spell " + spellResult.name);
                addSpellsToDatabase.AddSpell(spellResult, db);
                checkHealingOrDamage.CheckSpellHealingOrDamage(spellResult, db);
            }

        }

        public async Task<List<SpellModel>> GetSpells()
        {
            SpellsAPIRequests spellsDictionaryAPI = new SpellsAPIRequests();

            await spellsDictionaryAPI.PullSpellListFromAPI();

            await spellsDictionaryAPI.PullSpellsFromAPI();

            return spellsDictionaryAPI.GetSpellsAPI();
        }
    }
}
 