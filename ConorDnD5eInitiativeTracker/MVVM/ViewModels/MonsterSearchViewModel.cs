using ConorDnD5eInitiativeTracker.MVVM.Models;
using DatabaseLibrary.DatabaseQueries;
using DatabaseLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorDnD5eInitiativeTracker.MVVM.ViewModels
{
    
    public class MonsterSearchViewModel
    {
        public ObservableCollection<MonsterListItem> Monsters { get; set; }
        public InitiativeTrackerDB db { get; set; }
        public MonsterSearchViewModel monsterSearchViewModel { get; set; }

        public Monster monster { get; set; }
        public List<CombatAction> actionList { get; set; }
        public List<ArmorClass> armorClasses { get; set; }
        public Ability abilityScores { get; set; }
        public List<ConditionImmunity> conditionImmunities {get; set; }
        public List<LegendaryAction> legendaryActions { get; set; }
        public List<Proficiency> proficiencies { get; set; }
        public Sense senses { get; set; }
        public List<SpecialAbility> specialAbilities { get; set; }
        public List<Speed> speeds { get; set; }
        public SpellCastingStat spellCastingStat { get; set; }


        public MonsterSearchViewModel()
        {
            db = new InitiativeTrackerDB("TestDatabase11");
            Monsters = new ObservableCollection<MonsterListItem>();

            GetInitialList();

        }

        public void SearchTheDatabase(string search)
        {

            Monsters.Clear();
            if (search != null)
            {
                var query = MonsterQueries.SearchMonsters(db, search);

                PopulateList(query);
            }
            else
            {
                GetInitialList();
            }
          
        }

        public void GetInitialList()
        {
            var query = MonsterQueries.GetMonsters(db);

            PopulateList(query);
        }

        public void PopulateList(List<Monster> query)
        {
            foreach (var m in query)
            {
                MonsterListItem monsterListItem = new MonsterListItem()
                {
                    Name = m.Name,
                    Challenge_Rating = m.Challenge_Rating.ToString(),
                    Size = m.Size,
                    Type = m.Type,
                    Alignment = m.Alignment
                };

                Monsters.Add(monsterListItem);
            }
        }

        public void GetAllMonsterStats(string monsterName)
        {
            monster = MonsterQueries.GetAMonster(db, monsterName);
            armorClasses = MonsterQueries.GetMonsterArmorClasses(db, monsterName);
            abilityScores = MonsterQueries.GetMonsterAbilityScores(db, monsterName);
            conditionImmunities = MonsterQueries.GetMonsterConditionImmunities(db, monsterName);
            proficiencies = MonsterQueries.GetMonsterProficiencies(db, monsterName);
            senses = MonsterQueries.GetMonsterSenses(db, monsterName);
            speeds = MonsterQueries.GetMonsterSpeeds(db, monsterName);
            spellCastingStat = MonsterQueries.GetMonsterSpellCastingStats(db, monsterName);

            actionList = MonsterQueries.GetMonsterActions(db, monsterName);
            legendaryActions = MonsterQueries.GetLegendaryActions(db, monsterName);
            specialAbilities = MonsterQueries.GetMonsterSpecialAbilities(db, monsterName);
        }


    }

    
}
