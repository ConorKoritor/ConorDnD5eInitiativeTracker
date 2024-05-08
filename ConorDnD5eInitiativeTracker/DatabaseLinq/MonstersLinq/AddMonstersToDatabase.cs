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
using ConorDnD5eInitiativeTracker.Databases;

namespace ConorDnD5eInitiativeTracker.DatabaseLinq.MonstersLinq
{
    internal class AddMonstersToDatabase
    {

        List<MonsterModel> monsters = new List<MonsterModel>();
        InitiativeTrackerDBEntities db = new InitiativeTrackerDBEntities();

        public async Task InsertToMonstersTable()
        {
            monsters = await GetMonsters();

            await LoopThroughMonstersAndSaveToDatabase();
        }

        public async Task LoopThroughMonstersAndSaveToDatabase()
        {
            foreach (var monster in monsters)
            {
                AddMonster(monster);
                AddArmorClasses(monster);
                AddSpeeds(monster);
            }

            try
            {
                MessageBox.Show("Trying to save database");
                await db.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
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
                    MessageBox.Show($"Inner Exception: {innerException}");
                }
            }
        }

        internal void AddMonster(MonsterModel monster)
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
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
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
                    MessageBox.Show($"Inner Exception: {innerException.Message}");
                }
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Monster)
                    {
                        // Handle the specific entity that caused the exception
                        Monster entity = (Monster)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        MessageBox.Show($"Failed to save entity {entity.Name}: {ex.Message}");
                    }
                }

            }

        }

        internal void AddArmorClasses(MonsterModel monster)
        {
            foreach(var ac in monster.armor_class)
            {
                ArmorClass armorClass = new ArmorClass
                {
                    AC = (short)ac.value,
                    Ac_Type = ac.type,
                    MonsterName = monster.name
                };
                try
                {
                    db.ArmorClasses.Add(armorClass);
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
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
                        MessageBox.Show($"Inner Exception: {innerException.Message}");
                    }
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is ArmorClass)
                        {
                            // Handle the specific entity that caused the exception
                            ArmorClass entity = (ArmorClass)entry.Entity;
                            // Log or handle the failed entity (e.g., display an error message)
                            MessageBox.Show($"Failed to save entity {entity.Ac_Type} of Monster {monster.name}: {ex.Message}");
                        }
                    }

                }
            }

            
        }

        internal void AddSpeeds(MonsterModel monster)
        {
            if(monster.speed.walk != null)
            {
                Speed speed = new Speed
                {

                };
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
