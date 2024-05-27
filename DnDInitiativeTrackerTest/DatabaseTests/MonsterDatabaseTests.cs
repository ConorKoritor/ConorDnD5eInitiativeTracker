using System;
using System.Collections.Generic;
using DatabaseLibrary.Databases;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using System.Threading;
using System.Data.Entity.Core.Common.CommandTrees;

namespace DnDInitiativeTrackerTest.DatabaseTests.MonsterDatabaseTests
{
    internal class MonsterDatabaseTests
    {
        InitiativeTrackerDB db;

        [OneTimeSetUp]
        public void SetUp() 
        {
            //Arrange

            db = new InitiativeTrackerDB("TestDatabase19");
        }

        [Test]
        public void Database_Monster_Test()
        {
            //Act
            var query = from m in db.Monsters
                        where m.Name == "Aboleth"
                        select m;

            Monster monster = query.FirstOrDefault();

            //Assert
            Assert.That(monster.Name, Is.EqualTo("Aboleth"));
            Assert.That(monster.HP, Is.EqualTo(135));
            Assert.That(monster.Hit_Dice, Is.EqualTo("18d10"));
            Assert.That(monster.Hit_Points_Roll, Is.EqualTo("18d10+36"));
        }

        [Test]
        public void Database_Actions_Test()
        {
            //Act
            var query = from ca in db.CombatActions
                        where ca.MonsterName == "Aboleth"
                        select ca;

            List<CombatAction> actions = query.ToList();

            //Assert
            //Actions come out in Alphabetical Order!!! Noted! TODO: Fix this
            Assert.That(actions[0].Name, Is.EqualTo("Enslave"));
            Assert.That(actions[1].Name, Is.EqualTo("Multiattack"));
            Assert.That(actions[2].Name, Is.EqualTo("Tail"));
            Assert.That(actions[3].Name, Is.EqualTo("Tentacle"));
        }

        [Test]
        public void Database_Special_Abilities_Test()
        {
            //Act
            var query = from s in db.SpecialAbilities
                        where s.MonsterName == "Aboleth"
                        select s;

            List<SpecialAbility> abilities = query.ToList();

            //Assert
            //Special Abilities come out in Alphabetical Order!!! Noted! TODO: Fix this
            Assert.That(abilities[0].Name, Is.EqualTo("Amphibious"));
            Assert.That(abilities[1].Name, Is.EqualTo("Mucous Cloud"));
            Assert.That(abilities[2].Name, Is.EqualTo("Probing Telepathy"));
        }

        [Test]
        public void Database_Abilities_Test()
        {
            //Act
            var query = from a in db.Abilities
                        where a.MonsterName == "Aboleth"
                        select a;

            Ability ability = query.FirstOrDefault();

            //Assert
            Assert.That(ability.Intelligence, Is.EqualTo(18));
            Assert.That(ability.Strength, Is.EqualTo(21));
            Assert.That(ability.Constitution, Is.EqualTo(15));
        }

        [Test]
        public void Database_Legendary_Actions_Test()
        {
            //Act
            var query = from la in db.LegendaryActions
                        where la.MonsterName == "Aboleth"
                        select la;

            List<LegendaryAction> actions = query.ToList();

            //Assert
            //Legendary Actions come out in Alphabetical Order!!! Noted! TODO: Fix this
            Assert.That(actions[0].Name, Is.EqualTo("Detect"));
            Assert.That(actions[1].Name, Is.EqualTo("Psychic Drain (Costs 2 Actions)"));
            Assert.That(actions[2].Name, Is.EqualTo("Tail Swipe"));
        }

        [Test]
        public void Database_Armor_Classes_Test()
        {
            //Act
            var query = from ac in db.ArmorClasses
                        where ac.MonsterName == "Aboleth"
                        select ac;

            ArmorClass armorClass = query.FirstOrDefault();

            //Assert
            Assert.That(armorClass.Ac_Type, Is.EqualTo("natural"));
            Assert.That(armorClass.AC, Is.EqualTo(17));
        }

        [Test]
        public void Database_Condition_Immunity_Test()
        {
            //Act
            var query = from ci in db.ConditionImmunities
                        where ci.MonsterName == "Animated Armor"
                        select ci;

            List<ConditionImmunity> conditions = query.ToList();

            //Assert
            Assert.That(conditions[0].Name, Is.EqualTo("Blinded"));
            Assert.That(conditions[1].Name, Is.EqualTo("Charmed"));
            Assert.That(conditions[2].Name, Is.EqualTo("Deafened"));
        }

        [Test]
        public void Database_Damage_Test()
        {
            //Act
            var query = from d in db.Damages
                        where d.ActionMonsterName == "Animated Armor"  &&  d.ActionName == "Slam"
                        select d;

            Damage damage = query.FirstOrDefault();

            //Assert
            Assert.That(damage.Damage_Type, Is.EqualTo("Bludgeoning"));
            Assert.That(damage.Damage_Dice, Is.EqualTo("1d6+2"));
        }

        [Test]
        public void Database_Monster_Spell_Test()
        {
            //Act
            var query = from ms in db.MonsterSpells
                        join s in db.Spells on ms.SpellName equals s.Name
                        where ms.MonsterName == "Deva"
                        select s;

            List<Spell> spells = query.ToList();
            List<string> spellNames = new List<string>()
            {
                "Commune",
                "Detect Evil and Good",
                "Raise Dead"
            };

            //Assert
            for(int i = 0; i < spells.Count; i++)
            {
                Assert.That(spells[i].Name, Is.EqualTo(spellNames[i]));
            }

        }

        [Test]
        public void Database_Proficiency_Test()
        {
            //Act
            var query = from p in db.Proficiencies
                        where p.MonsterName == "Deva"
                        select p;

            List<Proficiency> proficiencies = query.ToList();

            //Assert
            //This comes in order that it is taken from API not Alphabetical order
            Assert.That(proficiencies[0].Bonus, Is.EqualTo(9));
            Assert.That(proficiencies[0].Name, Is.EqualTo("Saving Throw: WIS"));
        }

        [Test]
        public void Database_Senses_Test()
        {
            //Act
            var query = from s in db.Senses
                        where s.MonsterName == "Deva"
                        select s;

            Sense sense = query.FirstOrDefault();

            //Assert
            Assert.That(sense.Darkvision, Is.EqualTo("120 ft."));
            Assert.That(sense.Passive_Perception, Is.EqualTo(19));
        }

        [Test]
        public void Database_Speeds_Test() 
        {
            //Act
            var query = from s in db.Speeds
                        where s.MonsterName == "Deva"
                        select s;

            List<Speed> speeds = query.ToList();

            //Assert
            Assert.That(speeds[0].Type, Is.EqualTo("Walk"));
            Assert.That(speeds[0].Distance, Is.EqualTo("30 ft."));
        }

        [Test]
        public void Database_Usage_Test()
        {
            //Act
            var query = from ms in db.MonsterSpells
                        join u in db.Usages 
                        on new {MonName = ms.MonsterName, SpellName = ms.SpellName} equals new { MonName = u.MonsterSpellMonsterName, SpellName = u.MonsterSpellSpellName}
                        where ms.MonsterName == "Deva" && ms.SpellName == "Commune"
                        select u;

            Usage usage = query.FirstOrDefault();

            //Assert
            Assert.That(usage.Type, Is.EqualTo("per day"));
            Assert.That(usage.Times, Is.EqualTo(1));
        }

        [Test]
        public void Database_Special_Ability_Usage_Test()
        {
            //Act
            var query = from sa in db.SpecialAbilities
                        join u in db.Usages
                        on sa.Name equals u.SpecialAbilityName
                        where sa.Name == "Legendary Resistance"
                        select u;

            Usage usage = query.FirstOrDefault();


            //Assert
            Assert.That(usage.SpecialAbilityName != null);
        }

        [Test]
        public void Database_SpellcastingStat_Test() 
        {
            //Act
            var query = from s in db.SpellCastingStats
                        where s.MonsterName == "Archmage"
                        select s;

            SpellCastingStat stat = query.FirstOrDefault();

            //Assert
            Assert.That(stat.School, Is.EqualTo("wizard"));
            Assert.That(stat.Ability, Is.EqualTo("INT"));
            Assert.That(stat.Level, Is.EqualTo(18));
            Assert.That(stat.DC, Is.EqualTo(17));
            Assert.That(stat.L1_Slots, Is.EqualTo(4));
        }

        [Test]
        public void Database_DifficultyClasses_Test()
        {
            //Act
            var query = from dc in db.DifficultyClasses
                        where dc.ActionMonsterName == "Adult Black Dragon" && dc.ActionName == "Acid Breath"
                        select dc;

            DifficultyClass difficultyClass = query.FirstOrDefault();

            //Assert
            Assert.That(difficultyClass.DC_Value, Is.EqualTo(18));
            Assert.That(difficultyClass.DC_Type, Is.EqualTo("DEX"));
        }

    }
}
