using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConorDnD5eInitiativeTracker.DatabaseLinq.SpellsLinq;
using ConorDnD5eInitiativeTracker.Databases;
using NUnit.Framework;
using System.Data.SqlClient;

namespace DnDInitiativeTrackerTest.DatabaseTests
{

    [TestFixture]
    internal class DatabaseSpellsTest
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {

        }

        [Test]
        public void Test_Database_Spells_Table()
        {
            //Arrange
            InitiativeTrackerDBEntities db = new InitiativeTrackerDBEntities();

            //Act
            var query = from s in db.Spells
                        where s.Name == "Fireball"
                        select s.Level;

            //Assert
            Assert.That(query.First(), Is.EqualTo(3));
        }
    }
}
