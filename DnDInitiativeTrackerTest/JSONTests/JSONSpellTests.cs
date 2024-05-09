using ConorDnD5eInitiativeTracker.APIRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DnDInitiativeTrackerTest.JSONTests
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
        public async Task Pulling_Spell_Model_From_Api_Test()
        {
            //Arrange
            List<SpellModel> spells = new List<SpellModel>();

            //Act
            spells = await GetSpells();

            //Assert
            //Using Acid Arrow which should be the first result pulled
            Assert.That(spells[0].index, Is.EqualTo("acid-arrow"));
            Assert.That(spells[0].name, Is.EqualTo("Acid Arrow"));
            Assert.That(spells[0].desc[0], Is.EqualTo("A shimmering green arrow streaks toward a target within range and bursts in a spray of acid. Make a ranged spell attack against the target. On a hit, the target takes 4d4 acid damage immediately and 2d4 acid damage at the end of its next turn. On a miss, the arrow splashes the target with acid for half as much of the initial damage and no damage at the end of its next turn."));
            Assert.That(spells[0].higher_level[0], Is.EqualTo("When you cast this spell using a spell slot of 3rd level or higher, the damage (both initial and later) increases by 1d4 for each slot level above 2nd."));
            Assert.That(spells.Count, Is.EqualTo(319));
        }

        [Test]
        public async Task Pulling_Spell_AreaOfEffect_From_Api_Test()
        {
            //Arrange
            List<SpellModel> spells = new List<SpellModel>();

            //Act
            spells = await GetSpells();

            //Assert
            //Using Anti Magic Field which should be the 12th result pulled
            Assert.That(spells[11].name, Is.EqualTo("Antimagic Field"));
            Assert.That(spells[11].area_of_effect.type, Is.EqualTo("sphere"));
            Assert.That(spells[11].area_of_effect.size, Is.EqualTo(10));
        }

        [Test]
        public async Task Pulling_Spell_Class_And_Subclass_From_Api_Test()
        {
            //Arrange
            List<SpellModel> spells = new List<SpellModel>();

            //Act
            spells = await GetSpells();

            //Assert
            //Using Acid Arrow which should be the first result pulled
            Assert.That(spells[0].classes[0].name, Is.EqualTo("Wizard"));
            Assert.That(spells[0].subclasses[0].name, Is.EqualTo("Lore"));
        }

        [Test]
        public async Task Pulling_Spell_Damage_From_Api_Test()
        {
            //Arrange
            List<SpellModel> spells = new List<SpellModel>();

            //Act
            spells = await GetSpells();

            //Assert
            //Using Acid Arrow which should be the first result pulled
            Assert.That(spells[0].damage.damage_type.name, Is.EqualTo("Acid"));
            Assert.That(spells[0].damage.damage_at_slot_level._2, Is.EqualTo("4d4"));
        }

        [Test]
        public async Task Pulling_Spell_DC_From_Api_Test()
        {
            //Arrange
            List<SpellModel> spells = new List<SpellModel>();

            //Act
            spells = await GetSpells();

            //Assert
            //Using Acid Splash which should be the second result pulled
            Assert.That(spells[1].dc.dc_type.name, Is.EqualTo("DEX"));
            Assert.That(spells[1].dc.dc_success, Is.EqualTo("none"));
        }

        [Test]
        public async Task Pulling_Spell_School_From_Api_Test()
        {
            //Arrange
            List<SpellModel> spells = new List<SpellModel>();

            //Act
            spells = await GetSpells();

            //Assert
            //Using Acid Splash which should be the second result pulled
            Assert.That(spells[1].school.name, Is.EqualTo("Conjuration"));
        }

        [Test]
        public async Task Pulling_Spell_Heal_From_Api_Test()
        {
            //Arrange
            List<SpellModel> spells = new List<SpellModel>();

            //Act
            spells = await GetSpells();

            //Assert
            //Using Aid which should be the third result pulled
            Assert.That(spells[2].heal_at_slot_level._2, Is.EqualTo("5"));
        }

        public async Task<List<SpellModel>> GetSpells()
        {
            SpellsAPIRequests spellsDictionaryAPI = new SpellsAPIRequests();

            await spellsDictionaryAPI.PullSpellListFromAPI();

            await spellsDictionaryAPI.PullSpellsFromAPI();

            return spellsDictionaryAPI.GetSpellsAPI();
        }
        /*
                [Test]
                public async Task Pulling_Spell_Checking_Nested_Nulls_From_Api_Test()
                {
                    //Arrange
                    List<SpellModel> spells = new List<SpellModel>();

                    //Act
                    spells = await GetSpells();

                    //Assert
                    //Using Acid Arrow which should be the first result pulled
                    Assert.That(spells[0].dc.dc_type.name, Is.EqualTo(null));
                    Assert.That(spells[0].area_of_effect.size, Is.EqualTo(null));
                }


          */
        [Test]
        public async Task Pulling_Spell_Damage_At_Character_Level_From_Api_Test()
        {
            //Arrange
            List<SpellModel> spells = new List<SpellModel>();

            //Act
            spells = await GetSpells();

            //Assert
            //Using acid splash which should be the second result pulled
            Assert.That(spells[1].damage.damage_at_character_level._5, Is.EqualTo("2d6"));
        }
    }
}
