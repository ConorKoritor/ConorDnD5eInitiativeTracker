using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConorDnD5eInitiativeTracker.APIRequests;

namespace DnDInitiativeTrackerTest
{
    internal class JSONMonsterTests
    {
        [SetUp]
        public void Setup()
        {
            InitializeAPI.InitializeClient();
        }

        [Test]
        public async Task Pulling_Monsters_From_Api_Test()
        {
            //Arange
            List<MonsterDictionaryModel> monsters = new List<MonsterDictionaryModel>();

            //Act
            monsters = await GetMonsters();

            //Assert
            Assert.That(monsters[0].name, Is.EqualTo("Aboleth"));
            Assert.That(monsters[0].url, Is.EqualTo("/api/monsters/aboleth"));
            Assert.That(monsters.Count, Is.EqualTo(334));
        }

        public async Task<List<MonsterDictionaryModel>> GetMonsters()
        {
            MonsterDictionaryAPIRequests monsterDictionaryAPI = new MonsterDictionaryAPIRequests();

            await monsterDictionaryAPI.PullMonsterListFromAPI();

            return monsterDictionaryAPI.GetMonstersAPILinks();
        }
    }
}
