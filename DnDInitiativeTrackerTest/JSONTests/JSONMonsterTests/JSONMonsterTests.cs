﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary.APIRequests;
using NUnit.Framework;

namespace DnDInitiativeTrackerTest.JSONTests
{

    internal class JSONMonsterTests
    {
        List<MonsterModel> monsters = new List<MonsterModel>();

        [OneTimeSetUp]
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
        public void Pulling_Monster_Blindsight_From_Api_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Aboleth which should be the first request made
            //Testing for Senses
            Assert.That(monsters[278].senses.blindsight, Is.EqualTo("120 ft."));
            Assert.That(monsters[278].name, Is.EqualTo("Tarrasque"));
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

        public void Pulling_Monster_Damage_Dc_From_API()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Assassin which should be the 29th request made

            //Testing for Damage
            Assert.That(monsters[28].name, Is.EqualTo("Assassin"));
            Assert.That(monsters[28].actions[1].damage[1].dc.dc_type.name, Is.EqualTo("CON"));
            Assert.That(monsters[28].actions[1].damage[1].dc.dc_value, Is.EqualTo(15));
        }

        [Test]
        public void Pulling_Monster_Damage_Choices_From_API()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Djinni which should be the 82nd request made

            //Testing for Damage
            Assert.That(monsters[81].actions[1].damage[1].from.options[0].damage_type.name, Is.EqualTo("Lightning"));
            Assert.That(monsters[81].name, Is.EqualTo("Djinni"));
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
            Assert.That(monsters[27].special_abilities[1].spellcasting.slots._3, Is.EqualTo(3));
            Assert.That(monsters[27].special_abilities[1].spellcasting.level, Is.EqualTo(18));
            Assert.That(monsters[27].special_abilities[1].spellcasting.modifier, Is.EqualTo(9));
            Assert.That(monsters[27].special_abilities[1].spellcasting.school, Is.EqualTo("wizard"));

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

        [Test]
        public void Pulling_Monster_Condition_Immunities_FromApi_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Deva which should be the the 81st request made

            //Testing for Proficiencies
            Assert.That(monsters[79].condition_immunities[0].name, Is.EqualTo("Charmed"));
            Assert.That(monsters[79].condition_immunities[0].index, Is.EqualTo("charmed"));
        }

        [Test]
        public void Pulling_Monster_Reactions_From_API_Test()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for Bandit Captain which should be the the 38th request made

            //Testing for Reactions
            Assert.That(monsters[37].name, Is.EqualTo("Bandit Captain"));
            Assert.That(monsters[37].reactions[0].name, Is.EqualTo("Parry"));
        }

        [Test]
        public void Pulling_Monster_Usage_Recharge_After_Rest()
        {
            //Arrange and Act taken care of in setup so I dont have to pull from the api multiple times

            //Assert
            //Based on API Data for duergar which should be the the 91st request made

            //Testing for Reactions
            Assert.That(monsters[90].name, Is.EqualTo("Duergar"));
            Assert.That(monsters[90].actions[0].usage.rest_types[0], Is.EqualTo("short"));
        }
    }
}
