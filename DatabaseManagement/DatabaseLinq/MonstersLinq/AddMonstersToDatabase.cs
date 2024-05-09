using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ConorDnD5eInitiativeTracker.APIRequests;
using DatabaseModel.DatabaseLinq.SpellsLinq;
using DatabaseModel.Databases;

namespace DatabaseModel.DatabaseLinq.MonstersLinq
{
    internal class AddMonstersToDatabase
    {

        List<MonsterModel> monsters = new List<MonsterModel>();
        AddArmorClassesToDatabase addArmorClassesToDatabase = new AddArmorClassesToDatabase();
        AddSpeedsToDatabase addSpeedsToDatabase = new AddSpeedsToDatabase();
        AddAbilitiesToDatabase addAbilitiesToDatabase = new AddAbilitiesToDatabase();
        AddProficienciesToDatabase addProficienciesToDatabase = new AddProficienciesToDatabase();
        AddSensesToDatabase addSensesToDatabase = new AddSensesToDatabase();
        AddConditionImmunitiesToDatabase addConditionImmunitiesToDatabase = new AddConditionImmunitiesToDatabase();
        AddSpecialAbilitiesToDatabase addSpecialAbilitiesToDatabase = new AddSpecialAbilitiesToDatabase();

        public async Task InsertToMonstersTable(InitiativeTrackerDB db)
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
                AddMonster(monster, db);
                addArmorClassesToDatabase.AddArmorClasses(monster, db);
                addSpeedsToDatabase.AddSpeeds(monster, db);
                addAbilitiesToDatabase.AddAbilities(monster, db);
                addProficienciesToDatabase.AddProficiencies(monster, db);
                addSensesToDatabase.AddSenses(monster, db);
                addConditionImmunitiesToDatabase.AddConditionImmunities(monster, db);
                addSpecialAbilitiesToDatabase.CheckSpecialAbilities(monster, db);
            }

            try
            {
                Console.WriteLine("Trying to save database");
                await db.SaveChangesAsync();
                
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
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
            Console.WriteLine("Database Saved");
        }

        internal void AddMonster(MonsterModel monster, InitiativeTrackerDB db)
        {
            double initiativeModifierSetup = (monster.dexterity - 10) / 2;

            Monster monster1 = new Monster
            {
                Name = monster.name,
                HP = monster.hit_points,
                Initiative_Modifier = (short)Math.Floor(initiativeModifierSetup),
                Desc = "Placeholder", //Made a non nullable field for desc but have none from api. TODO: Fix this
                Size = monster.size,
                Type = monster.type,
                Hit_Dice = monster.hit_dice,
                Hit_Points_Roll = monster.hit_points_roll,
                Alignment = monster.alignment,
                Languages = monster.languages,
                Challenge_Rating = monster.challenge_rating,
                XP = monster.xp,
                Damage_Vulnerabilities = String.Join(",", monster.damage_vulnerabilities),
                Damage_Resistances = String.Join(",", monster.damage_resistances),
                Damage_Immunities = String.Join(",", monster.damage_immunities),
                Image = monster.image
            };

            foreach(var ability in monster.special_abilities)
            {
                if(ability.spellcasting != null)
                {
                    monster1.IsSpellcaster = true;
                }
            }

            try
            {
                db.Monsters.Add(monster1);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
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
                    Console.WriteLine($"Inner Exception: {innerException.Message}");
                }
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Monster)
                    {
                        // Handle the specific entity that caused the exception
                        Monster entity = (Monster)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Name}: {ex.Message}");
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
