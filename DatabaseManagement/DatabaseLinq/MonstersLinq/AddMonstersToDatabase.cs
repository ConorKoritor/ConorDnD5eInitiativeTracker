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
                AddArmorClasses(monster, db);
                AddSpeeds(monster, db);
                AddAbilities(monster, db);
                AddProficiencies(monster, db);
                AddSenses(monster, db);
                AddConditionImmunities(monster, db);
                CheckSpecialAbilities(monster, db);
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

        internal void AddArmorClasses(MonsterModel monster, InitiativeTrackerDB db)
        {
            if (monster.armor_class != null)
            {
                foreach (var ac in monster.armor_class)
                {
                    AddArmorClassToDatabase(ac, db, monster);
                }
            }
            
        }

        internal void AddArmorClassToDatabase(MonsterArmorClass ac,InitiativeTrackerDB db, MonsterModel monster)
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
                    if (entry.Entity is ArmorClass)
                    {
                        // Handle the specific entity that caused the exception
                        ArmorClass entity = (ArmorClass)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Ac_Type} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }

        internal void AddSpeeds(MonsterModel monster, InitiativeTrackerDB db)
        {
            List<Speed> speeds = new List<Speed>();
            if(monster.speed.walk != null)
            {
                Speed speed = new Speed
                {
                    Type = "Walk",
                    Distance = monster.speed.walk,
                    MonsterName = monster.name
                };

                speeds.Add(speed);
            }
            if (monster.speed.fly != null)
            {
                Speed speed = new Speed
                {
                    Type = "Fly",
                    Distance = monster.speed.fly,
                    MonsterName = monster.name
                };

                speeds.Add(speed);
            }
            if (monster.speed.burrow != null)
            {
                Speed speed = new Speed
                {
                    Type = "Burrow",
                    Distance = monster.speed.burrow,
                    MonsterName = monster.name
                };

                speeds.Add(speed);
            }
            if (monster.speed.swim != null)
            {
                Speed speed = new Speed
                {
                    Type = "Swim",
                    Distance = monster.speed.swim,
                    MonsterName = monster.name
                };

                speeds.Add(speed);
            }
            if (monster.speed.climb != null)
            {
                Speed speed = new Speed
                {
                    Type = "Climb",
                    Distance = monster.speed.climb,
                    MonsterName = monster.name
                };

                speeds.Add(speed);
            }
            
            foreach(var speed in speeds) 
            {
                AddSpeedToDatabase(speed, monster, db);
            }

        }

        internal void AddSpeedToDatabase(Speed speed, MonsterModel monster, InitiativeTrackerDB db)
        {
            try
            {
                db.Speeds.Add(speed);
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
                    if (entry.Entity is Speed)
                    {
                        // Handle the specific entity that caused the exception
                        Speed entity = (Speed)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Type} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }

        internal void AddAbilities(MonsterModel monster, InitiativeTrackerDB db)
        {
            Ability abilities = new Ability
            {
                Strength = (short)monster.strength,
                Dexterity = (short)monster.dexterity,
                Constitution = (short)monster.constitution,
                Intelligence = (short)monster.intelligence,
                Wisdom = (short)monster.wisdom,
                Charisma = (short)monster.charisma,
                Proficiency_Bonus = (short)monster.proficiency_bonus,
                MonsterName = monster.name
            };

            try
            {
                db.Abilities.Add(abilities);
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
                    if (entry.Entity is Ability)
                    {
                        // Handle the specific entity that caused the exception
                        Ability entity = (Ability)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Id} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }

        internal void AddProficiencies(MonsterModel monster, InitiativeTrackerDB db)
        {
            if (monster.proficiencies != null)
            {
                foreach (var proficiency in monster.proficiencies)
                {
                    AddProficiencyToDatabase(proficiency, monster, db);
                }               
            }
        }

        internal void AddProficiencyToDatabase(MonsterProficiency proficiency, MonsterModel monster, InitiativeTrackerDB db)
        {
            Proficiency proficiency1 = new Proficiency
            {
                Bonus = (short)proficiency.value,
                Name = proficiency.proficiency.name,
                MonsterName = monster.name
            };
            try
            {
                db.Proficiencies.Add(proficiency1);
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
                    if (entry.Entity is Proficiency)
                    {
                        // Handle the specific entity that caused the exception
                        Proficiency entity = (Proficiency)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }

        internal void AddSenses(MonsterModel monster, InitiativeTrackerDB db)
        {
            Sense sense = new Sense()
            {
                Passive_Perception = (short)monster.senses.passive_perception,
                Blindsight = monster.senses.blindsight,
                Tremorsense = monster.senses.tremorsense,
                Truesight = monster.senses.truesight,
                Darkvision = monster.senses.darkvision,
                MonsterName = monster.name
            };

            try
            {
                db.Senses.Add(sense);
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
                    if (entry.Entity is Sense)
                    {
                        // Handle the specific entity that caused the exception
                        Sense entity = (Sense)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Id} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }

        internal void AddConditionImmunities(MonsterModel monster, InitiativeTrackerDB db)
        {
            foreach(var conditionImmunity in monster.condition_immunities)
            {
                AddConditionImmunityToDatabase(conditionImmunity, monster, db);
            }
        }

        internal void AddConditionImmunityToDatabase(MonsterConditionImmunity conditionImmunity, MonsterModel monster, InitiativeTrackerDB db)
        {
            ConditionImmunity conditionImmunity1 = new ConditionImmunity()
            {
                Name = conditionImmunity.name,
                URL = conditionImmunity.url,
                MonsterName = monster.name
            };

            try
            {
                db.ConditionImmunities.Add(conditionImmunity1);
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
                    if (entry.Entity is Sense)
                    {
                        // Handle the specific entity that caused the exception
                        Sense entity = (Sense)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Id} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }

        internal void CheckSpecialAbilities(MonsterModel monster, InitiativeTrackerDB db)
        {
            foreach(var specialAbility in monster.special_abilities)
            {
                if(specialAbility.name == "Spellcasting" || specialAbility.name == "Innate Spellcasting")
                {
                    AddSpecialAbility(monster, db, specialAbility);
                    AddSpellcastingStats(monster, db);
                    AddMonsterSpells(monster, db);
                }
                else
                {
                    AddSpecialAbility(monster, db, specialAbility);
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
