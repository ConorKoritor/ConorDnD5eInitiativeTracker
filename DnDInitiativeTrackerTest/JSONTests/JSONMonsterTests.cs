using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConorDnD5eInitiativeTracker.APIRequests;
using NUnit.Framework;

namespace DnDInitiativeTrackerTest.JSONTests
{

    internal class JSONMonsterTests
    {
        List<MonsterModel> monsters = new List<MonsterModel>();

        [SetUp]
        public async Task Setup()
        {
            InitializeAPI.InitializeClient();

            monsters = await GetMonsters();
        }

        public async Task<List<MonsterModel>> GetMonsters()
        {
            MonsterAPIRequests monstersDictionaryAPI = new MonsterAPIRequests();

            await monstersDictionaryAPI.PullMonsterListFromAPI();

            await monstersDictionaryAPI.PullMonstersFromAPI();

            return monstersDictionaryAPI.GetMonstersAPI();
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

        [Test]
        public void Pulling_Monster_Name_Index_Count_From_Api_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Aboleth which should be the first request made
            //Testing the name, index, and amount of monsters pulled
            Assert.That(monsters[0].index, Is.EqualTo("aboleth"));
            Assert.That(monsters[0].name, Is.EqualTo("Aboleth"));
            Assert.That(monsters.Count, Is.EqualTo(334));
        }
        [Test]
        public void Pulling_Monster_Senses_From_Api_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Aboleth which should be the first request made
            //Testing for Senses
            Assert.That(monsters[0].senses.darkvision, Is.EqualTo("120 ft."));
        }
        [Test]
        public void Pulling_Monster_Actions_From_Api_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Aboleth which should be the first request made
            //Testing for Actions
            Assert.That(monsters[0].actions[1].name, Is.EqualTo("Tentacle"));
            Assert.That(monsters[0].actions[1].attack_bonus, Is.EqualTo(9));
        }
        [Test]
        public void Pulling_Monster_Damage_From_Api_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Aboleth which should be the first request made

            //Testing for Damage
            Assert.That(monsters[0].actions[1].damage[0].damage_dice, Is.EqualTo("2d6+5"));
            Assert.That(monsters[0].actions[1].damage[0].damage_type.name, Is.EqualTo("Bludgeoning"));
        }

        [Test]
        public void Pulling_Monster_Spellcasting_FromApi_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Archmage which should be the the 28th request made

            //Testing for spellcasting
            Assert.That(monsters[27].special_abilities[1].name, Is.EqualTo("Spellcasting"));
            Assert.That(monsters[27].special_abilities[1].spellcasting.ability.name, Is.EqualTo("INT"));
            Assert.That(monsters[27].special_abilities[1].spellcasting.spells.Count, Is.EqualTo(27));
            Assert.That(monsters[27].special_abilities[1].spellcasting.spells[0].name, Is.EqualTo("Disguise Self"));
        }

        [Test]
        public void Pulling_Monster_Armor_Classes_FromApi_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Archmage which should be the the 28th request made
            //Testing for Multiple Armor Classes
            Assert.That(monsters[27].armor_class[0].type, Is.EqualTo("dex"));
            Assert.That(monsters[27].armor_class[1].type, Is.EqualTo("spell"));
            Assert.That(monsters[27].armor_class[0].value, Is.EqualTo(12));
            Assert.That(monsters[27].armor_class[1].value, Is.EqualTo(15));
        }

        [Test]
        public void Pulling_Monster_Legendary_Actions_FromApi_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Adult Black Dragon which should be the the 3rd request made

            //Testing for Legendary Actions
            Assert.That(monsters[2].legendary_actions.Count, Is.EqualTo(3));
            Assert.That(monsters[2].legendary_actions[0].name, Is.EqualTo("Detect"));
        }

        [Test]
        public void Pulling_Monster_DC_FromApi_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Adult Black Dragon which should be the the 3rd request made

            //Testing for Monster_DC
            Assert.That(monsters[2].legendary_actions[2].dc.dc_type.name, Is.EqualTo("DEX"));
            Assert.That(monsters[2].legendary_actions[2].dc.dc_value, Is.EqualTo(19));
        }

        [Test]
        public void Pulling_Monster_Proficiencies_FromApi_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Adult Black Dragon which should be the the 3rd request made

            //Testing for Proficiencies
            Assert.That(monsters[2].proficiencies.Count, Is.EqualTo(6));
            Assert.That(monsters[2].proficiencies[0].value, Is.EqualTo(7));
            Assert.That(monsters[2].proficiencies[0].proficiency.name, Is.EqualTo("Saving Throw: DEX"));
        }

        [Test]
        public void Pulling_Monster_Spell_Usage_FromApi_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Deva which should be the the 81st request made

            //Testing for Proficiencies
            Assert.That(monsters[79].special_abilities[1].spellcasting.spells[1].usage.type, Is.EqualTo("per day"));
            Assert.That(monsters[79].special_abilities[1].spellcasting.spells[1].usage.times, Is.EqualTo(1));
        }

        [Test]
        public void Pulling_Monster_Speed_FromApi_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Deva which should be the the 81st request made

            //Testing for Proficiencies
            Assert.That(monsters[79].speed.walk, Is.EqualTo("30 ft."));
            Assert.That(monsters[79].speed.fly, Is.EqualTo("90 ft."));
        }
    }
}
