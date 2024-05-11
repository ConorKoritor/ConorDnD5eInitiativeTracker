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



                try
                {
                    Console.WriteLine("Trying to save database");
                    db.SaveChanges();
                    Console.WriteLine("Database Saved");

                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Console.WriteLine("Property: " + validationError.PropertyName + "Of Spell: " + spellResult.name + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
                catch (DbUpdateException ex)
                {
                    Exception innerException = ex.InnerException;

                    // Handle the inner exception
                    if (innerException != null)
                    {
                        // Log or handle the inner exception
                        Console.WriteLine($"Inner Exception: {innerException}");
                    }
                }
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
 