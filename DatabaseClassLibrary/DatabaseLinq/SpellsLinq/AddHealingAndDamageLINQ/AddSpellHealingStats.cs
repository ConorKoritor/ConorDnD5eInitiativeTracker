using DatabaseClassLibrary.APIRequests;
using DatabaseClassLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClassLibrary.DatabaseLinq.SpellsLinq
{
    internal class AddSpellHealingStats
    {
        internal void AddSpellHealing(SpellModel spellResult, InitiativeTrackerDB db)
        {
            SpellHealing spellHealing = new SpellHealing
            {
                Healing_L1 = spellResult.heal_at_slot_level._1,
                Healing_L2 = spellResult.heal_at_slot_level._2,
                Healing_L3 = spellResult.heal_at_slot_level._3,
                Healing_L4 = spellResult.heal_at_slot_level._4,
                Healing_L5 = spellResult.heal_at_slot_level._5,
                Healing_L6 = spellResult.heal_at_slot_level._6,
                Healing_L7 = spellResult.heal_at_slot_level._7,
                Healing_L8 = spellResult.heal_at_slot_level._8,
                Healing_L9 = spellResult.heal_at_slot_level._9,
                SpellName = spellResult.name
            };
            try
            {
                db.SpellHealings.Add(spellHealing);
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
                    if (entry.Entity is SpellHealing)
                    {
                        // Handle the specific entity that caused the exception
                        SpellHealing entity = (SpellHealing)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save Healing entity {entity.SpellName}: {ex.Message}");
                    }
                }

            }
        }
    }
}
