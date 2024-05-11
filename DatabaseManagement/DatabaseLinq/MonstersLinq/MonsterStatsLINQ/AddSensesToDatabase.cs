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
    internal class AddSensesToDatabase
    {
        internal void AddSenses(MonsterModel monster, InitiativeTrackerDB db)
        {
            Sense sense = new Sense()
            {
                Passive_Perception = (short)monster.senses.passive_perception,
                Blindsight = monster.senses.blindsight,
                Tremorsense = monster.senses.tremorsense,
                Truesight = monster.senses.truesight,
                Darkvision = monster.senses.darkvision,
                MonsterName = monster.name
            };

            try
            {
                db.Senses.Add(sense);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: " + validationError.PropertyName + "For Monster: " + monster.name  + " Error: " + validationError.ErrorMessage);
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
