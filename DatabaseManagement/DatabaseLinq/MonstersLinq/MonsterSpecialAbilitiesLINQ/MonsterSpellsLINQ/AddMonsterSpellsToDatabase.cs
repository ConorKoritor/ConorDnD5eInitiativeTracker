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
    internal class AddMonsterSpellsToDatabase
    {
        internal void AddMonsterSpells(MonsterModel monster, InitiativeTrackerDB db, MonsterSpecialAbility specialAbility)
        { 

            foreach(var spell in specialAbility.spellcasting.spells)
            {
                AddEachMonsterSpellToDatabase(monster, db, spell);
            }
        }

        internal void AddEachMonsterSpellToDatabase(MonsterModel monster, InitiativeTrackerDB db, Monster_Spell spell)
        {
            MonsterSpellTable monsterSpell = new MonsterSpellTable()
            {
                SpellName = spell.name,
                MonsterName = monster.name
            };

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
        }
    }
}
