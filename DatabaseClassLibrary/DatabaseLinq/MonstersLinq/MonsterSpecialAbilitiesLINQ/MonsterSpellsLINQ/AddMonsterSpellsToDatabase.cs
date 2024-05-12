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
using DatabaseClassLibrary.APIRequests;
using DatabaseClassLibrary.DatabaseLinq.SpellsLinq;
using DatabaseClassLibrary.Databases;

namespace DatabaseClassLibrary.DatabaseLinq.MonstersLinq
{
    internal class AddMonsterSpellsToDatabase
    {
        internal void AddMonsterSpells(MonsterModel monster, InitiativeTrackerDB db, MonsterSpecialAbilityModel specialAbility)
        { 

            foreach(var spell in specialAbility.spellcasting.spells)
            {
                AddEachMonsterSpellToDatabase(monster, db, spell);
            }
        }

        internal void AddEachMonsterSpellToDatabase(MonsterModel monster, InitiativeTrackerDB db, MonsterSpellModel spell)
        {
            MonsterSpellTable monsterSpell = new MonsterSpellTable()
            {
                SpellName = spell.name,
                MonsterName = monster.name,
                IsUsage = false
            };

            if(spell.usage != null)
            {
                monsterSpell.IsUsage = true;
            }

            try
            {
                db.MonsterSpells.Add(monsterSpell);
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
                    if (entry.Entity is MonsterSpellTable)
                    {
                        // Handle the specific entity that caused the exception
                        MonsterSpellTable entity = (MonsterSpellTable)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.SpellName} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }

            if (monsterSpell.IsUsage)
            {
                AddSpellUsage(monster, spell, db);
            }
        }

        internal void AddSpellUsage(MonsterModel monster, MonsterSpellModel spell, InitiativeTrackerDB db)
        {
            Usage usage = new Usage()
            {
                Type = spell.usage.type,
                Times = spell.usage.times,
                MonsterSpellMonsterName = monster.name,
                MonsterSpellSpellName = spell.name
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
                        Console.WriteLine($"Failed to save entity {entity.Type} of Spell {spell.name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }
    }
}
