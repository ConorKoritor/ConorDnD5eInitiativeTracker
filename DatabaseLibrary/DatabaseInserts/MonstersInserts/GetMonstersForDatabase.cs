using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using DatabaseLibrary.APIRequests;
using DatabaseLibrary.Databases;

namespace DatabaseLibrary.DatabaseLinq.MonstersLinq
{
    public class GetMonstersForDatabase
    {

        List<MonsterModel> monsters = new List<MonsterModel>();
        AddArmorClassesToDatabase addArmorClassesToDatabase = new AddArmorClassesToDatabase();
        AddSpeedsToDatabase addSpeedsToDatabase = new AddSpeedsToDatabase();
        AddAbilitiesToDatabase addAbilitiesToDatabase = new AddAbilitiesToDatabase();
        AddProficienciesToDatabase addProficienciesToDatabase = new AddProficienciesToDatabase();
        AddSensesToDatabase addSensesToDatabase = new AddSensesToDatabase();
        AddConditionImmunitiesToDatabase addConditionImmunitiesToDatabase = new AddConditionImmunitiesToDatabase();
        AddSpecialAbilitiesToDatabase addSpecialAbilitiesToDatabase = new AddSpecialAbilitiesToDatabase();
        AddActionsToDatabase addActionsToDatabase = new AddActionsToDatabase();
        AddMonstersToDatabase addMonstersToDatabase = new AddMonstersToDatabase();
        AddLegendaryActionsToDatabase addLegendaryActionsToDatabase = new AddLegendaryActionsToDatabase();
        AddReactionsToDatabase addReactionsToDatabase = new AddReactionsToDatabase();

        public async Task GetMonstersAndInsertToDatabase(InitiativeTrackerDB db)
        {
            Console.WriteLine("Getting Monsters");
            monsters = await GetMonsters();

            Console.WriteLine("Monsters Retrieved, Looping through spells");
            await LoopThroughMonstersAndSaveToDatabase(db);
        }

        public async Task LoopThroughMonstersAndSaveToDatabase(InitiativeTrackerDB db)
        {
            foreach (var monster in monsters)
            {
                Console.WriteLine("Adding Monster " + monster.name);
                addMonstersToDatabase.AddMonster(monster, db);
                addArmorClassesToDatabase.AddArmorClasses(monster, db);
                addSpeedsToDatabase.AddSpeeds(monster, db);
                addAbilitiesToDatabase.AddAbilities(monster, db);
                addProficienciesToDatabase.AddProficiencies(monster, db);
                addSensesToDatabase.AddSenses(monster, db);
                addConditionImmunitiesToDatabase.AddConditionImmunities(monster, db);
                addSpecialAbilitiesToDatabase.CheckSpecialAbilities(monster, db);
                addActionsToDatabase.AddActions(monster, db);
                addLegendaryActionsToDatabase.AddLegendaryActions(monster, db);
                if (monster.reactions != null)
                {
                    addReactionsToDatabase.AddReactions(monster, db);
                }


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
                            Console.WriteLine("Property: " + validationError.PropertyName + "Of Monster: " + monster.name + " Error: " + validationError.ErrorMessage);
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


 
        public async Task<List<MonsterModel>> GetMonsters()
        {
            MonsterAPIRequests monstersDictionaryAPI = new MonsterAPIRequests();

            await monstersDictionaryAPI.PullMonsterListFromAPI();

            await monstersDictionaryAPI.PullMonstersFromAPI();

            return monstersDictionaryAPI.GetMonstersAPI();
        }
    }
}
