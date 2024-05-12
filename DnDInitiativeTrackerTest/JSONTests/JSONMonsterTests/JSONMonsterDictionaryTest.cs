using DatabaseLibrary.APIRequests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDInitiativeTrackerTest.JSONTests
{
    internal class JSONMonsterDictionaryTest
    {
        [SetUp] 
        public void SetUp() 
        {
            InitializeAPI.InitializeClient();
        }

        [Test]
        public async Task Pulling_Monster_List_From_Api_Test()
        {
            //Arange
            List<MonsterDictionaryModel> monsterDictionaryModels;

            //Act\
            monsterDictionaryModels = await GetMonsterList();

            //Assert
            Assert.That(monsterDictionaryModels[0].name, Is.EqualTo("Aboleth"));
            Assert.That(monsterDictionaryModels[0].url, Is.EqualTo("/api/monsters/aboleth"));
            Assert.That(monsterDictionaryModels.Count, Is.EqualTo(334));
        }

        public async Task<List<MonsterDictionaryModel>> GetMonsterList()
        {
            MonsterAPIRequests monsterDictionaryAPI = new MonsterAPIRequests();

            await monsterDictionaryAPI.PullMonsterListFromAPI();

            return monsterDictionaryAPI.GetMonstersAPILinks();
        }
    }
}
