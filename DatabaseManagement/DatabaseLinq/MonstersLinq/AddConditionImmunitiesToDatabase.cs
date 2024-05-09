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
    internal class AddConditionImmunitiesToDatabase
    {
        internal void AddConditionImmunities(MonsterModel monster, InitiativeTrackerDB db)
        {
            foreach (var conditionImmunity in monster.condition_immunities)
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
    }
}
