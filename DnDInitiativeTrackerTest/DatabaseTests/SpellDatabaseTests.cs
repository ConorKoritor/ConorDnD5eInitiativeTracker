using DatabaseLibrary.Databases;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DnDInitiativeTrackerTest.DatabaseTests
{
    internal class SpellDatabaseTests
    {
        InitiativeTrackerDB db;

        [OneTimeSetUp]
        public void SetUp()
        {
            //Arrange

            db = new InitiativeTrackerDB("TestDatabase19");
        }

        [Test]
        public void Database_Spell_Test()
        {
            //Act
            var query = from s in db.Spells
                        where s.Name == "Fireball"
                        select s;

            Spell spell = query.First();

            //Assert
            Assert.That(spell.Name, Is.EqualTo("Fireball"));
            Assert.That(spell.Range, Is.EqualTo("150 feet"));
            Assert.That(spell.Level, Is.EqualTo(3));
            Assert.That(spell.IsRitual, Is.False);
        }

        [Test]
        public void Database_Spell_Damage_Test()
        {
            //Act
            var query = from d in db.SpellDamages
                        where d.SpellName == "Fireball"
                        select d;

            SpellDamage damage = query.First();

            //Assert
            Assert.That(damage.SpellName, Is.EqualTo("Fireball"));
            Assert.That(damage.Damage_L1, Is.Null);
            Assert.That(damage.Damage_L3, Is.EqualTo("8d6"));
            Assert.That(damage.Damage_Type, Is.EqualTo("Fire"));
        }

        [Test]
        public void Database_Spell_Damage_At_Character_Level_Test()
        {
            //Act
            var query = from d in db.SpellDamageAtCharacterLevels
                        where d.SpellName == "Eldritch Blast"
                        select d;

            SpellDamageAtCharacterLevel damage = query.First();

            //Assert
            Assert.That(damage.SpellName, Is.EqualTo("Eldritch Blast"));
            Assert.That(damage.Damage_L1, Is.EqualTo("1d10"));
            Assert.That(damage.Damage_L3, Is.Null);
            Assert.That(damage.Damage_Type, Is.EqualTo("Force"));
        }

        [Test]
        public void Database_Spell_Healing_Test()
        {
            //Act
            var query = from h in db.SpellHealings
                        where h.SpellName == "Cure Wounds"
                        select h;

            SpellHealing healing = query.First();

            //Assert
            Assert.That(healing.SpellName, Is.EqualTo("Cure Wounds"));
            Assert.That(healing.Healing_L1, Is.EqualTo("1d8 + MOD"));
        }

        
        
    }
}
