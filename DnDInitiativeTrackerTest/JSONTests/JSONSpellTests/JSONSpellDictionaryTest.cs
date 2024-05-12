using DatabaseLibrary.APIRequests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDInitiativeTrackerTest.JSONTests
{
    internal class JSONSpellDictionaryTest
    {
        [SetUp]
        public void SetUp()
        {
            InitializeAPI.InitializeClient();
        }

        [Test]
        public async Task Pulling_Spell_List_From_Api_Test()
        {
            //Arrange
            List<SpellDictionaryModel> spellList = new List<SpellDictionaryModel>();

            //Act
            spellList = await GetSpellList();

            //Assert
            Assert.That(spellList[0].name, Is.EqualTo("Acid Arrow"));
            Assert.That(spellList[0].url, Is.EqualTo("/api/spells/acid-arrow"));
            Assert.That(spellList.Count, Is.EqualTo(319));
        }

        public async Task<List<SpellDictionaryModel>> GetSpellList()
        {
            SpellsAPIRequests spellDictionaryAPI = new SpellsAPIRequests();

            await spellDictionaryAPI.PullSpellListFromAPI();

            return spellDictionaryAPI.GetSpellsAPILinks();
        }
    }
}
