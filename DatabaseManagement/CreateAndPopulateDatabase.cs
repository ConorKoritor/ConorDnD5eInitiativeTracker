// See https://aka.ms/new-console-template for more information

using DatabaseClassLibrary.APIRequests;
using DatabaseClassLibrary.DatabaseLinq.MonstersLinq;
using DatabaseClassLibrary.DatabaseLinq.SpellsLinq;
using DatabaseClassLibrary.Databases;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace PopulateDatabase
{
    public class CreateAndPopulateDatabase
    {
        
        static void Main(string[] args)
        {
            PopulateDatabase();
            
            Console.ReadLine();
        }

        public static async Task PopulateDatabase()
        {

            InitializeAPI.InitializeClient();

            InitiativeTrackerDB db = new InitiativeTrackerDB("TestDB38");

            GetSpellsForDatabase getSpellsForDatabase = new GetSpellsForDatabase();

            await getSpellsForDatabase.GetSpellsAndInsertToDatabase(db);

            GetMonstersForDatabase getMonstersForDatabase = new GetMonstersForDatabase();

            await getMonstersForDatabase.GetMonstersAndInsertToDatabase(db);

            try
            {
                Console.WriteLine("Trying to save database");
                db.SaveChanges();

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
                    Console.WriteLine($"Inner Exception: {innerException}");
                }
            }
            Console.WriteLine("Database Saved");
        }
    }
}
