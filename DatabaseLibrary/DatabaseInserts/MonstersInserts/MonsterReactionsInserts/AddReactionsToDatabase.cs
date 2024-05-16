using DatabaseLibrary.APIRequests;
using DatabaseLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.DatabaseLinq.MonstersLinq
{
    internal class AddReactionsToDatabase
    {
        internal void AddReactions(MonsterModel monster, InitiativeTrackerDB db)
        {
            foreach (var reaction in monster.reactions)
            {
                AddReactionToDatabase(monster, db, reaction);
            }

        }

        internal void AddReactionToDatabase(MonsterModel monster, InitiativeTrackerDB db, MonsterReactionModel reaction)
        {
            Reaction reaction1 = new Reaction()
            {
                Name = reaction.name,
                Description = reaction.desc,
                MonsterName = monster.name
            };

            try
            {
                db.Reactions.Add(reaction1);
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
                    if (entry.Entity is Reaction)
                    {
                        // Handle the specific entity that caused the exception
                        Reaction entity = (Reaction)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }
    }
}
