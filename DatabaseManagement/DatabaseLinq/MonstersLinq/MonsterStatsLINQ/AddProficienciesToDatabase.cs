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
    internal class AddProficienciesToDatabase
    {
        internal void AddProficiencies(MonsterModel monster, InitiativeTrackerDB db)
        {
            if (monster.proficiencies != null)
            {
                foreach (var proficiency in monster.proficiencies)
                {
                    AddProficiencyToDatabase(proficiency, monster, db);
                }
            }
        }

        internal void AddProficiencyToDatabase(MonsterProficiency proficiency, MonsterModel monster, InitiativeTrackerDB db)
        {
            Proficiency proficiency1 = new Proficiency
            {
                Bonus = (short)proficiency.value,
                Name = proficiency.proficiency.name,
                MonsterName = monster.name
            };
            try
            {
                db.Proficiencies.Add(proficiency1);
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
                    if (entry.Entity is Proficiency)
                    {
                        // Handle the specific entity that caused the exception
                        Proficiency entity = (Proficiency)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }
    }
}
