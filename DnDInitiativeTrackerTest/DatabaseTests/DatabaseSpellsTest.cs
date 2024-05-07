using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConorDnD5eInitiativeTracker.DatabaseLinq.SpellsLinq;
using ConorDnD5eInitiativeTracker.Databases;
using NUnit.Framework;

namespace DnDInitiativeTrackerTest.DatabaseTests
{
    [SetUpFixture]
    internal class Setup
    {
        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            AddSpellsToDatabase astdb = new AddSpellsToDatabase();
            await astdb.InsertToSpellsTable();
        }
    }

    [TestFixture]
    internal class DatabaseSpellsTest
    {
        [Test]
        public void Test_Database_Spells_Table()
        {
            //Arrange
            InitiativeTrackerDBContainer db = new InitiativeTrackerDBContainer();

            //Act

            //Assert
        }
    }
}
