using ConorDnD5eInitiativeTracker.APIRequests;
using DatabaseModel.Databases;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseLinq.SpellsLinq
{
    internal class AddSpellsToDatabase
    {
        internal void AddSpell(SpellModel spellResult, InitiativeTrackerDB db)
        {
            Spell spell1 = new Spell
            {
                Name = spellResult.name,
                Description = String.Join(",", spellResult.desc),
                Range = spellResult.range,
                Components = String.Join(",", spellResult.components),
                IsRitual = spellResult.ritual,
                Duration = spellResult.duration,
                IsConcentration = spellResult.concentration,
                Casting_Time = spellResult.casting_time,
                Level = spellResult.level,
                School = spellResult.school.name,
                Higher_Level = String.Join(",", spellResult.higher_level),
                Material = String.Join(",", spellResult.components),
                DC_Type = null,
                DC_Success = null,
                Area_Of_Effect_Size = null,
                Area_Of_Effect_Type = null
            };


            if (spellResult.dc != null)
            {
                spell1.DC_Type = spellResult.dc.dc_type.name;
                spell1.DC_Success = spellResult.dc.dc_success;
            }
            if (spellResult.area_of_effect != null)
            {
                spell1.Area_Of_Effect_Type = spellResult.area_of_effect.type;
                spell1.Area_Of_Effect_Size = spellResult.area_of_effect.size;
            }

            try
            {
                db.Spells.Add(spell1);
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
                    if (entry.Entity is Spell)
                    {
                        // Handle the specific entity that caused the exception
                        Spell entity = (Spell)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Name}: {ex.Message}");
                    }
                }

            }


        }
    }
}
