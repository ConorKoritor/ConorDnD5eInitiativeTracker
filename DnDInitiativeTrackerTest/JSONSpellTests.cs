using ConorDnD5eInitiativeTracker.APIRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDInitiativeTrackerTest
{
    internal class JSONSpellTests
    {
        [SetUp]
        public void Setup()
        {
            InitializeAPI.InitializeClient();
        }

        [Test]
        public async Task Pulling_Spell_List_From_Api_Test()
        {
            //Arange
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

        [Test]
        public async Task Pulling_Spells_From_Api_Test()
        {
            //Arrange
            List<SpellModel> spells = new List<SpellModel>();

            //Act
            spells = await GetSpells();

            //Assert
            Assert.That(spells[0].index, Is.EqualTo("acid-arrow"));
            Assert.That(spells[0].name, Is.EqualTo("Acid Arrow"));
            Assert.That(spells[0].desc[0], Is.EqualTo("A shimmering green arrow streaks toward a target within range and bursts in a spray of acid. Make a ranged spell attack against the target. On a hit, the target takes 4d4 acid damage immediately and 2d4 acid damage at the end of its next turn. On a miss, the arrow splashes the target with acid for half as much of the initial damage and no damage at the end of its next turn."));
            Assert.That(spells[0].higher_level[0], Is.EqualTo("When you cast this spell using a spell slot of 3rd level or higher, the damage (both initial and later) increases by 1d4 for each slot level above 2nd."));
            Assert.That(spells.Count, Is.EqualTo(319));
        }

        public async Task<List<SpellModel>> GetSpells()
        {
            SpellsAPIRequests spellsDictionaryAPI = new SpellsAPIRequests();

            await spellsDictionaryAPI.PullSpellListFromAPI();

            await spellsDictionaryAPI.PullSpellsFromAPI();

            return spellsDictionaryAPI.GetSpellsAPI();
        }
    }
}
