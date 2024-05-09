using ConorDnD5eInitiativeTracker.APIRequests;
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
    internal class AddSpellcastingStatToDatabase
    {
        internal void AddSpellcastingStats(MonsterModel monster, InitiativeTrackerDB db, MonsterSpecialAbility specialAbility)
        {
            SpellCastingStat spellCastingStat = new SpellCastingStat()
            {
                Level = (short)specialAbility.spellcasting.level,
                Ability = specialAbility.spellcasting.ability.name,
                DC = (short)specialAbility.spellcasting.level,
                Modifier = (short)specialAbility.spellcasting.modifier,
                School = specialAbility.spellcasting.school,
                L1_Slots = (short)specialAbility.spellcasting.slots._1,
                L2_Slots = (short)specialAbility.spellcasting.slots._2,
                L3_Slots = (short)specialAbility.spellcasting.slots._3,
                L4_Slots = (short)specialAbility.spellcasting.slots._4,
                L5_Slots = (short)specialAbility.spellcasting.slots._5,
                L6_Slots = (short)specialAbility.spellcasting.slots._6,
                L7_Slots = (short)specialAbility.spellcasting.slots._7,
                L8_Slots = (short)specialAbility.spellcasting.slots._8,
                L9_Slots = (short)specialAbility.spellcasting.slots._9,
                MonsterName = monster.name
            };

            try
            {
                db.SpellCastingStats.Add(spellCastingStat);
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
                    if (entry.Entity is SpellCastingStat)
                    {
                        // Handle the specific entity that caused the exception
                        SpellCastingStat entity = (SpellCastingStat)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.School} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }
    }
}
