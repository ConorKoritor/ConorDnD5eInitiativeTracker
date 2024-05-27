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
    public class InitiativeViewModel
    {
        public ObservableCollection<InitiativeListItem> Creatures { get; set; }
        public ObservableCollection<Scenario> Scenarios { get; set; }
        public InitiativeTrackerDB db { get; set; }

        public Monster monster { get; set; }
        public List<CombatAction> actionList { get; set; }
        public List<ArmorClass> armorClasses { get; set; }
        public Ability abilityScores { get; set; }
        public List<ConditionImmunity> conditionImmunities { get; set; }
        public List<LegendaryAction> legendaryActions { get; set; }
        public List<Proficiency> proficiencies { get; set; }
        public Sense senses { get; set; }
        public List<SpecialAbility> specialAbilities { get; set; }
        public List<Speed> speeds { get; set; }
        public List<Usage> usages { get; set; }
        public SpellCastingStat spellCastingStat { get; set; }

        public string challengeRatingString { get; set; }


        public InitiativeViewModel()
        {
            db = new InitiativeTrackerDB("TestDatabase19");
            Creatures = new ObservableCollection<InitiativeListItem>();
            Scenarios = new ObservableCollection<Scenario>();

            GetComboBoxList();

        }

        public void GetComboBoxList()
        {
            var query = ScenarioQueries.GetScenarios(db);

            foreach(var item in query)
            {
                Scenarios.Add(item);
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
            usages = MonsterQueries.GetMonsterUsages(db, monsterName);
            usages = MonsterQueries.GetMonsterUsages(db, monsterName);
        }
    }
}
