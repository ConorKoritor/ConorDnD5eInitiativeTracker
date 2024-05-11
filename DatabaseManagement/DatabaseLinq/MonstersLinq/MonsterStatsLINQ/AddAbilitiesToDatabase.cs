using DatabaseModel.APIRequests;
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
    internal class AddAbilitiesToDatabase
    {
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
    }
}
