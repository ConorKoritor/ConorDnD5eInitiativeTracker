using ConorDnD5eInitiativeTracker.MVVM.Models;
using ConorDnD5eInitiativeTracker.MVVM.Views;
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
    public class ScenarioBuilderViewModel
    {
        public ObservableCollection<MonsterListItem> Monsters { get; set; }
        public ObservableCollection<ScenarioMonsterListItem> ScenarioMonsters { get; set; }
        public InitiativeTrackerDB db { get; set; }

        public ObservableCollection<PlayerListItem> Players { get; set; }
        public ObservableCollection<PlayerListItem> ScenarioPlayers { get; set; }
        public int NumberOfPlayers { get; set; }
        public int PlayersCR2Score { get; set; }
        public int PlayersAverageLevel {  get; set; }

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


        public ScenarioBuilderViewModel()
        {
            db = new InitiativeTrackerDB("TestDatabase16");
            Monsters = new ObservableCollection<MonsterListItem>();
            ScenarioMonsters = new ObservableCollection<ScenarioMonsterListItem>();
            Players = new ObservableCollection<PlayerListItem>();
            ScenarioPlayers = new ObservableCollection<PlayerListItem>();

            GetInitialMonsterList();
            GetInitialPlayerList();
        }

        public void SearchTheMonsterDatabase(string search)
        {

            Monsters.Clear();
            if (search != null)
            {
                var query = MonsterQueries.SearchMonsters(db, search);

                PopulateMonsterList(query);
            }
            else
            {
                GetInitialMonsterList();
            }

        }

        public void GetInitialMonsterList()
        {
            var query = MonsterQueries.GetMonsters(db);

            PopulateMonsterList(query);
        }

        public void SearchThePlayerDatabase(string search)
        {
            Players.Clear();
            if (search != null)
            {
                var query = PlayerQueries.SearchPlayers(db, search);

                PopulatePlayerList(query);
            }
            else
            {
                GetInitialPlayerList();
            }
        }

        public void GetInitialPlayerList()
        {
            var query = PlayerQueries.GetPlayers(db);

            PopulatePlayerList(query);
        }

        public void PopulateMonsterList(List<Monster> query)
        {


            foreach (var m in query)
            {

                if (m.Challenge_Rating < 1)
                {
                    switch (m.Challenge_Rating)
                    {
                        case 0:
                            challengeRatingString = "0";
                            break;

                        case 0.125:
                            challengeRatingString = "1/8";
                            break;

                        case 0.25:
                            challengeRatingString = "1/4";
                            break;

                        case 0.5:
                            challengeRatingString = "1/2";
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    challengeRatingString = m.Challenge_Rating.ToString();
                }

                MonsterListItem monsterListItem = new MonsterListItem()
                {
                    Name = m.Name,
                    Challenge_Rating = challengeRatingString,
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
            usages = MonsterQueries.GetMonsterUsages(db, monsterName);
            usages = MonsterQueries.GetMonsterUsages(db, monsterName);
        }

        public void PopulatePlayerList(List<PlayerCharacterBasic> query)
        {
            foreach (var player in query)
            {
                PlayerListItem playerListItem = new PlayerListItem()
                {
                    Name= player.Name,
                    AC = player.AC,
                    HP = player.HP,
                    CR_2_Score = player.CR_2_Score,
                    Level = player.Level
                };

                Players.Add(playerListItem);
            }
        }

        public void UpdatePlayerStats()
        {
            PlayersAverageLevel = 0;
            PlayersCR2Score = 0;
            NumberOfPlayers = 0;
            decimal playersTotalLevel = 0;

            if (ScenarioPlayers.Count > 0)
            {
                foreach (PlayerListItem player in ScenarioPlayers)
                {
                    NumberOfPlayers++;
                    PlayersCR2Score += player.CR_2_Score;
                    playersTotalLevel += player.Level;
                }

                PlayersAverageLevel = (int)Math.Floor(playersTotalLevel/NumberOfPlayers);
            }

        }
    }
}
