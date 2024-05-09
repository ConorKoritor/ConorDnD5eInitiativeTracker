﻿using ConorDnD5eInitiativeTracker.APIRequests;
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
    internal class AddSpecialAbilitiesToDatabase
    {
        AddSpellcastingStatToDatabase addSpellcastingStatToDatabase = new AddSpellcastingStatToDatabase();
        internal void CheckSpecialAbilities(MonsterModel monster, InitiativeTrackerDB db)
        {
            foreach (var specialAbility in monster.special_abilities)
            {
                if (specialAbility.name == "Spellcasting" || specialAbility.name == "Innate Spellcasting")
                {
                    AddSpecialAbility(monster, db, specialAbility);
                    addSpellcastingStatToDatabase.AddSpellcastingStats(monster, db, specialAbility);
                    //AddMonsterSpells(monster, db);
                }
                else
                {
                    AddSpecialAbility(monster, db, specialAbility);
                }
            }
        }

        internal void AddSpecialAbility(MonsterModel monster, InitiativeTrackerDB db, MonsterSpecialAbility specialAbility)
        {
            SpecialAbility specialAbility1 = new SpecialAbility()
            {
                Name = specialAbility.name,
                Desc = specialAbility.desc,
                MonsterName = monster.name,
            };

            if (specialAbility.dc != null)
            {
                AddSpecialAbilityDifficultyClass(monster, specialAbility, db);
            }

            if (specialAbility.usage != null)
            {
                AddSpecialAbilityUsage(monster, specialAbility, db);
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
        }

        internal void AddSpecialAbilityDifficultyClass(MonsterModel monster, MonsterSpecialAbility specialAbility, InitiativeTrackerDB db)
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

        internal void AddSpecialAbilityUsage(MonsterModel monster, MonsterSpecialAbility specialAbility, InitiativeTrackerDB db)
        {
            Usage usage = new Usage()
            {

            };
        }
    }
}
