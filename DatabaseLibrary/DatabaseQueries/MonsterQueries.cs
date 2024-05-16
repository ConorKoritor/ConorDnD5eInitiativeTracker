using DatabaseLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.DatabaseQueries
{
    public static class MonsterQueries
    {
        public static List<Monster> GetMonsters(InitiativeTrackerDB db)
        {
            var query = from m in db.Monsters
                        select m;

            return query.ToList();
        }

        public static List<Monster> SearchMonsters(InitiativeTrackerDB db, string search)
        {
            var query = from m in db.Monsters
                        where m.Name.StartsWith(search)
                        select m;
            return query.ToList();
        }

        public static Monster GetAMonster(InitiativeTrackerDB db, string monsterName)
        {
            var query = from m in db.Monsters
                        where m.Name == monsterName
                        select m;

            return query.FirstOrDefault();
        }

        public static List<Speed> GetMonsterSpeeds(InitiativeTrackerDB db, string monsterName)
        {
            var query = from s in db.Speeds
                        where s.MonsterName == monsterName
                        select s;

            return query.ToList();
        }

        public static List<ArmorClass> GetMonsterArmorClasses(InitiativeTrackerDB db, string monsterName)
        {
            var query = from a in db.ArmorClasses
                        where a.MonsterName == monsterName
                        select a;

            return query.ToList();
        }

        public static Ability GetMonsterAbilityScores(InitiativeTrackerDB db, string monsterName)
        {
            var query = from a in db.Abilities
                        where a.MonsterName == monsterName
                        select a;

            return query.FirstOrDefault();
        }

        public static Sense GetMonsterSenses(InitiativeTrackerDB db, string monsterName)
        {
            var query = from s in db.Senses
                        where s.MonsterName == monsterName
                        select s;

            return query.FirstOrDefault();
        }

        public static List<Proficiency> GetMonsterProficiencies(InitiativeTrackerDB db, string monsterName)
        {
            var query = from p in db.Proficiencies
                        where p.MonsterName == monsterName
                        select p;

            return query.ToList();
        }

        public static List<ConditionImmunity> GetMonsterConditionImmunities(InitiativeTrackerDB db, string monsterName)
        {
            var query = from c in db.ConditionImmunities
                        where c.MonsterName == monsterName
                        select c;

            return query.ToList();
        }

        public static List<CombatAction> GetMonsterActions(InitiativeTrackerDB db, string monsterName)
        {
            var query = from ca in db.CombatActions
                        where ca.MonsterName == monsterName
                        orderby ca.ActionOrder
                        select ca;

            return query.ToList();
        }

        public static List<LegendaryAction> GetLegendaryActions(InitiativeTrackerDB db, string monsterName)
        {
            var query = from la in db.LegendaryActions
                        where la.MonsterName == monsterName
                        select la;

            return query.ToList();
        }

        public static List<SpecialAbility> GetMonsterSpecialAbilities(InitiativeTrackerDB db, string monsterName)
        {
            var query = from s in db.SpecialAbilities
                        where s.MonsterName == monsterName
                        select s;

            return query.ToList();
        }

        public static SpellCastingStat GetMonsterSpellCastingStats(InitiativeTrackerDB db, string monsterName)
        {
            var query = from sc in db.SpellCastingStats
                        where sc.MonsterName == monsterName
                        select sc;

            return query.FirstOrDefault();
        }

        public static List<MonsterSpellTable> GetMonsterKnownSpells(InitiativeTrackerDB db, string monsterName)
        {
            var query = from ms in db.MonsterSpells
                        where ms.MonsterName == monsterName
                        select ms;

            return query.ToList();
        }
    }

}
