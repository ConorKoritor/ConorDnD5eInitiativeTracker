using DatabaseLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConorDnD5eInitiativeTracker.MVVM.ViewModels
{
    internal class CharacterBuilderViewModel
    {  
        public static bool AddCharacterToDatabase(PlayerCharacterBasic player)
        {
            InitiativeTrackerDB db = new InitiativeTrackerDB("TestDatabase14");

            try
            {
                db.PlayerCharacterBasics.Add(player);
                db.SaveChanges();
                return true;
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

                return false;
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
                    if (entry.Entity is PlayerCharacterBasic)
                    {
                        // Handle the specific entity that caused the exception
                        Monster entity = (Monster)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Name}: {ex.Message}");
                    }
                }
                return false;

            }
        }
    }
}
