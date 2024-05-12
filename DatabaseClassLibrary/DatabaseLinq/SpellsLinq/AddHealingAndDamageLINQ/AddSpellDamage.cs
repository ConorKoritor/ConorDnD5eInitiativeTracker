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
using DatabaseClassLibrary.APIRequests;
using DatabaseClassLibrary.Databases;

namespace DatabaseClassLibrary.DatabaseLinq.SpellsLinq
{
    internal class AddSpellDamage
    {
        internal void AddSpellDamageAtSlotLevelLevel(SpellModel spellResult, InitiativeTrackerDB db)
        {
            SpellDamage spellDamage = new SpellDamage
            {
                Damage_Type = null,
                Damage_L1 = spellResult.damage.damage_at_slot_level._1,
                Damage_L2 = spellResult.damage.damage_at_slot_level._2,
                Damage_L3 = spellResult.damage.damage_at_slot_level._3,
                Damage_L4 = spellResult.damage.damage_at_slot_level._4,
                Damage_L5 = spellResult.damage.damage_at_slot_level._5,
                Damage_L6 = spellResult.damage.damage_at_slot_level._6,
                Damage_L7 = spellResult.damage.damage_at_slot_level._7,
                Damage_L8 = spellResult.damage.damage_at_slot_level._8,
                Damage_L9 = spellResult.damage.damage_at_slot_level._9,
                SpellName = spellResult.name
            };

            if (spellResult.damage.damage_type != null)
            {
                spellDamage.Damage_Type = spellResult.damage.damage_type.name;
            }
            try
            {
                db.SpellDamages.Add(spellDamage);
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
                    if (entry.Entity is SpellDamage)
                    {
                        // Handle the specific entity that caused the exception
                        SpellDamage entity = (SpellDamage)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save Damage entity {entity.SpellName}: {ex.Message}");
                    }
                }

            }
        }

        internal void AddSpellDamageAtCharacterLevel(SpellModel spellResult, InitiativeTrackerDB db)
        {
            SpellDamageAtCharacterLevel spellDamage = new SpellDamageAtCharacterLevel
            {
                Damage_Type = null,
                Damage_L1 = spellResult.damage.damage_at_character_level._1,
                Damage_L2 = spellResult.damage.damage_at_character_level._2,
                Damage_L3 = spellResult.damage.damage_at_character_level._3,
                Damage_L4 = spellResult.damage.damage_at_character_level._4,
                Damage_L5 = spellResult.damage.damage_at_character_level._5,
                Damage_L6 = spellResult.damage.damage_at_character_level._6,
                Damage_L7 = spellResult.damage.damage_at_character_level._7,
                Damage_L8 = spellResult.damage.damage_at_character_level._8,
                Damage_L9 = spellResult.damage.damage_at_character_level._9,
                Damage_L10 = spellResult.damage.damage_at_character_level._10,
                Damage_L11 = spellResult.damage.damage_at_character_level._11,
                Damage_L12 = spellResult.damage.damage_at_character_level._12,
                Damage_L13 = spellResult.damage.damage_at_character_level._13,
                Damage_L14 = spellResult.damage.damage_at_character_level._14,
                Damage_L15 = spellResult.damage.damage_at_character_level._15,
                Damage_L16 = spellResult.damage.damage_at_character_level._16,
                Damage_L17 = spellResult.damage.damage_at_character_level._17,
                Damage_L18 = spellResult.damage.damage_at_character_level._18,
                Damage_L19 = spellResult.damage.damage_at_character_level._19,
                Damage_L20 = spellResult.damage.damage_at_character_level._20,
                SpellName = spellResult.name
            };
            if (spellResult.damage.damage_type != null)
            {
                spellDamage.Damage_Type = spellResult.damage.damage_type.name;
            }
            try
            {
                db.SpellDamageAtCharacterLevels.Add(spellDamage);
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
                    if (entry.Entity is SpellDamage)
                    {
                        // Handle the specific entity that caused the exception
                        SpellDamage entity = (SpellDamage)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save Damage entity {entity.SpellName}: {ex.Message}");
                    }
                }

            }
        }
    }
}
