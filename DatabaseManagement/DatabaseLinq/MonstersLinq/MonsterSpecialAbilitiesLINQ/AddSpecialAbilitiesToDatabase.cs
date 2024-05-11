using DatabaseModel.APIRequests;
using DatabaseModel.Databases;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DatabaseModel.DatabaseLinq.MonstersLinq
{
    internal class AddSpecialAbilitiesToDatabase
    {
        AddSpellcastingStatToDatabase addSpellcastingStatToDatabase = new AddSpellcastingStatToDatabase();
        AddMonsterSpellsToDatabase addMonsterSpellsToDatabase = new AddMonsterSpellsToDatabase();    

        internal void CheckSpecialAbilities(MonsterModel monster, InitiativeTrackerDB db)
        {
            foreach (var specialAbility in monster.special_abilities)
            {
                if (specialAbility.name == "Spellcasting" || specialAbility.name == "Innate Spellcasting")
                {
                    AddSpecialAbility(monster, db, specialAbility);
                    addSpellcastingStatToDatabase.AddSpellcastingStats(monster, db, specialAbility);
                    addMonsterSpellsToDatabase.AddMonsterSpells(monster, db, specialAbility);
                }
                else
                {
                    AddSpecialAbility(monster, db, specialAbility);
                }
            }
        }

        internal void AddSpecialAbility(MonsterModel monster, InitiativeTrackerDB db, MonsterSpecialAbilityModel specialAbility)
        {
            SpecialAbility specialAbility1 = new SpecialAbility()
            {
                Name = specialAbility.name,
                Desc = specialAbility.desc,
                MonsterName = monster.name,
                IsDC = false,
                IsUsage = false
            };

            if (specialAbility.dc != null)
            {
                specialAbility1.IsDC = true;
            }

            if (specialAbility.usage != null)
            {
                specialAbility1.IsUsage = true;
            }

            try
            {
                db.SpecialAbilities.Add(specialAbility1);
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
                    if (entry.Entity is SpecialAbility)
                    {
                        // Handle the specific entity that caused the exception
                        SpecialAbility entity = (SpecialAbility)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }


            if (specialAbility.dc != null)
            {
                AddSpecialAbilityDifficultyClass(monster, specialAbility, db);
            }

        }

        internal void AddSpecialAbilityDifficultyClass(MonsterModel monster, MonsterSpecialAbilityModel specialAbility, InitiativeTrackerDB db)
        {
            DifficultyClass difficultyClass = new DifficultyClass
            {
                DC_Type = specialAbility.dc.dc_type.name,
                DC_Value = (short)specialAbility.dc.dc_value,
                SpecialAbilityMonsterName = monster.name,
                SpecialAbilityName = specialAbility.name
            };

            try
            {
                db.DifficultyClasses.Add(difficultyClass);
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
                    if (entry.Entity is DifficultyClass)
                    {
                        // Handle the specific entity that caused the exception
                        DifficultyClass entity = (DifficultyClass)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.DC_Type} of SpecialAbility {specialAbility.name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }

        internal void AddSpecialAbilityUsage(MonsterModel monster, MonsterSpecialAbilityModel specialAbility, InitiativeTrackerDB db)
        {
            Usage usage = new Usage()
            {
                Type = specialAbility.usage.type,
                Times = specialAbility.usage.times,
                Dice = specialAbility.usage.dice,
                MinDiceValue = specialAbility.usage.min_value,
                SpecialAbilityName = specialAbility.name,
                SpecialAbilityMonsterName = monster.name
            };

            try
            {
                db.Usages.Add(usage);
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
                    if (entry.Entity is Usage)
                    {
                        // Handle the specific entity that caused the exception
                        Usage entity = (Usage)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Type} of SpecialAbility {specialAbility.name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }
    }
}
