// See https://aka.ms/new-console-template for more information

using ConorDnD5eInitiativeTracker.APIRequests;
using DatabaseModel.DatabaseLinq.MonstersLinq;
using DatabaseModel.DatabaseLinq.SpellsLinq;
using DatabaseModel.Databases;

namespace DatabaseModel
{
    public class DatabaseModelExecution
    {
        
        static void Main(string[] args)
        {
            PopulateDatabase();
            
            Console.ReadLine();
        }

        public static async Task PopulateDatabase()
        {

            InitializeAPI.InitializeClient();

            InitiativeTrackerDB db = new InitiativeTrackerDB("TestDB2");

            AddSpellsToDatabase astb = new AddSpellsToDatabase();

            await astb.InsertToSpellsTable(db);
        }
    }
}
