using ConorDnD5eInitiativeTracker.MVVM.Models;
using ConorDnD5eInitiativeTracker.MVVM.ViewModels;
using DatabaseLibrary.DatabaseQueries;
using DatabaseLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConorDnD5eInitiativeTracker.MVVM.Views
{
    /// <summary>
    /// Interaction logic for InitiativeView.xaml
    /// </summary>
    public partial class InitiativeView : UserControl
    {
        public InitiativeView()
        {
            InitializeComponent();

        }


        InitiativeViewModel initiativeViewModel = new InitiativeViewModel();
        FontFamily Vinque = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#vinque rg");
        double descAndStatsFontSize = 16;
        double headingFontSize = 27;
        double nameFontSize = 18;
        Thickness sectionMarginTop = new Thickness(0, 10, 0, 0);
        Thickness sectionMarginBottom = new Thickness(0, 0, 0, 10);
        Thickness sectionMarginBoth = new Thickness(0, 10, 0, 10);
        InitiativeTrackerDB db = new InitiativeTrackerDB("TestDatabase19")
;
        private void cmbxSelectScenario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Scenario scenario = cmbxSelectScenario.SelectedItem as Scenario;
            initiativeViewModel.Creatures.Clear();

            var monsterScenarioQuery = ScenarioQueries.GetMonsterScenarios(db, scenario.Scenario_Name);

            foreach (MonsterScenarioTable monsterScenario in monsterScenarioQuery)
            {
                Monster monsterQuery = MonsterQueries.GetAMonster(db, monsterScenario.MonsterName);

                InitiativeListItem listItem = new InitiativeListItem()
                {
                    Name = monsterQuery.Name,
                    HP = monsterQuery.HP,
                    Initiative_Modifier = monsterQuery.Initiative_Modifier,
                    Is_Monster = true
                };

                initiativeViewModel.Creatures.Add(listItem);

                lstbxCreatureList.ItemsSource = initiativeViewModel.Creatures;
            }

            var playerScenarioQuery = ScenarioQueries.GetPlayerScenarios(db, scenario.Scenario_Name);

            foreach (PlayerScenarioTable playerScenario in playerScenarioQuery)
            {
                PlayerCharacterBasic playerQuery = PlayerQueries.GetAPlayer(db, playerScenario.PlayerName);

                InitiativeListItem listItem = new InitiativeListItem()
                {
                    Name = playerQuery.Name,
                    HP = playerQuery.HP,
                    Is_Monster = false
                };

                initiativeViewModel.Creatures.Add(listItem);
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitiativeListItem initiativeListItem = lstbxCreatureList.SelectedItem as InitiativeListItem;
            txtblkMonsterStatsName.Text = "";
            txtblkMonsterStatsAlignmentSizeAndType.Text = "";
            rctMonsterNameSizeAlignmentTypeBottomBorder.Fill = Brushes.Transparent;
            rctMonsterAbilityScoresBottomBorder.Fill = Brushes.Transparent;

            stkpnlACHPandSpeed.Children.Clear();
            stkpnlMonsterAbilityNames.Children.Clear();
            stkpnlMonsterAbilityScores.Children.Clear();
            stkpnlMonsterStats.Children.Clear();
            stkpnlSpecialAbilities.Children.Clear();
            stkpnlCombatActions.Children.Clear();
            stkpnlLegendaryActions.Children.Clear();

            if (initiativeListItem != null)
            {
                if (initiativeListItem.Is_Monster)
                {
                    initiativeViewModel.GetAllMonsterStats(initiativeListItem.Name);

                    txtblkMonsterStatsName.Text = initiativeListItem.Name;
                    txtblkMonsterStatsAlignmentSizeAndType.Text = String.Format("{0} {1}, {2}", initiativeViewModel.monster.Size, initiativeViewModel.monster.Type, initiativeViewModel.monster.Alignment);
                    rctMonsterNameSizeAlignmentTypeBottomBorder.Fill = Brushes.Red;

                    AddACHPAndSpeed();
                    AddAbilityScores();
                    AddMonsterStats();
                    AddSpecialAbilities();
                    AddCombatActions();
                    AddReactions();
                    AddLegendaryActions();
                }
            }
        }

        private void AddACHPAndSpeed()
        {

            TextBlock ac = new TextBlock();
            TextBlock hp = new TextBlock();
            TextBlock speeds = new TextBlock();
            int acCount = 0;
            int speedCount = 0;

            ac.Text = "Armor Class: ";
            speeds.Text = "Speed: ";

            foreach (ArmorClass armorClass in initiativeViewModel.armorClasses)
            {
                if (acCount == 0)
                {
                    ac.Text += String.Format("{0} ({1})", armorClass.AC, armorClass.Ac_Type);
                }
                else
                {
                    ac.Text += String.Format(", {0} ({1})", armorClass.AC, armorClass.Ac_Type);
                }

                acCount++;
            }

            hp.Text = String.Format("Hit Points: {0}", initiativeViewModel.monster.HP.ToString());

            foreach (Speed speed in initiativeViewModel.speeds)
            {
                if (speedCount == 0)
                {
                    speeds.Text += String.Format("{0} {1}", speed.Type, speed.Distance);
                }
                else
                {
                    speeds.Text += String.Format(", {0} {1}", speed.Type, speed.Distance);
                }
                speedCount++;
            }

            ac.FontSize = descAndStatsFontSize;
            ac.Foreground = Brushes.Black;
            ac.FontFamily = Vinque;

            hp.FontSize = descAndStatsFontSize;
            hp.Foreground = Brushes.Black;
            hp.FontFamily = Vinque;

            speeds.FontSize = descAndStatsFontSize;
            speeds.Foreground = Brushes.Black;
            speeds.FontFamily = Vinque;
            speeds.Margin = sectionMarginBottom;

            Rectangle border = new Rectangle()
            {
                Height = 3,
                Fill = Brushes.Red
            };

            stkpnlACHPandSpeed.Margin = sectionMarginTop;
            stkpnlACHPandSpeed.Children.Add(ac);
            stkpnlACHPandSpeed.Children.Add(hp);
            stkpnlACHPandSpeed.Children.Add(speeds);
            stkpnlACHPandSpeed.Children.Add(border);
        }

        private void AddAbilityScores()
        {
            decimal strengthModifier = Math.Floor((decimal)(initiativeViewModel.abilityScores.Strength - 10) / 2);
            decimal dexterityModifier = Math.Floor((decimal)(initiativeViewModel.abilityScores.Dexterity - 10) / 2);
            decimal constitutionModifier = Math.Floor((decimal)(initiativeViewModel.abilityScores.Constitution - 10) / 2);
            decimal intelligenceModifier = Math.Floor((decimal)(initiativeViewModel.abilityScores.Intelligence - 10) / 2);
            decimal wisdomModifier = Math.Floor((decimal)(initiativeViewModel.abilityScores.Wisdom - 10) / 2);
            decimal charismaModifier = Math.Floor((decimal)(initiativeViewModel.abilityScores.Charisma - 10) / 2);

            string strengthModifierString;
            string dexterityModifierString;
            string constitutionModifierString;
            string intelligenceModifierString;
            string wisdomModifierString;
            string charismaModifierString;

            if (initiativeViewModel.abilityScores.Strength >= 10)
            {
                strengthModifierString = "+" + strengthModifier;
            }
            else
            {
                strengthModifierString = strengthModifier.ToString();
            }

            if (initiativeViewModel.abilityScores.Dexterity >= 10)
            {
                dexterityModifierString = "+" + dexterityModifier;
            }
            else
            {
                dexterityModifierString = dexterityModifier.ToString();
            }

            if (initiativeViewModel.abilityScores.Constitution >= 10)
            {
                constitutionModifierString = "+" + constitutionModifier;
            }
            else
            {
                constitutionModifierString = constitutionModifier.ToString();
            }

            if (initiativeViewModel.abilityScores.Intelligence >= 10)
            {
                intelligenceModifierString = "+" + intelligenceModifier;
            }
            else
            {
                intelligenceModifierString = intelligenceModifier.ToString();
            }

            if (initiativeViewModel.abilityScores.Wisdom >= 10)
            {
                wisdomModifierString = "+" + wisdomModifier;
            }
            else
            {
                wisdomModifierString = wisdomModifier.ToString();
            }

            if (initiativeViewModel.abilityScores.Charisma >= 10)
            {
                charismaModifierString = "+" + charismaModifier;
            }
            else
            {
                charismaModifierString = charismaModifier.ToString();
            }

            List<string> abilities = new List<string>()
            {
                "STR",
                "DEX",
                "CON",
                "INT",
                "WIS",
                "CHA"
            };
            List<string> scores = new List<string>()
            {
                String.Format("{0} ({1})", initiativeViewModel.abilityScores.Strength.ToString(), strengthModifierString),
                String.Format("{0} ({1})", initiativeViewModel.abilityScores.Dexterity.ToString(), dexterityModifierString),
                String.Format("{0} ({1})", initiativeViewModel.abilityScores.Constitution.ToString(), constitutionModifierString),
                String.Format("{0} ({1})", initiativeViewModel.abilityScores.Intelligence.ToString(), intelligenceModifierString),
                String.Format("{0} ({1})", initiativeViewModel.abilityScores.Wisdom.ToString(), wisdomModifierString),
                String.Format("{0} ({1})", initiativeViewModel.abilityScores.Charisma.ToString(), charismaModifierString)
            };

            foreach (var ability in abilities)
            {
                TextBlock textBlock = new TextBlock();

                textBlock.FontSize = descAndStatsFontSize;
                textBlock.Foreground = Brushes.Red;
                textBlock.FontFamily = Vinque;
                textBlock.FontWeight = FontWeights.Bold;
                textBlock.Text = ability;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Width = 95;

                stkpnlMonsterAbilityNames.Margin = new Thickness(0, 10, 0, 4);
                stkpnlMonsterAbilityNames.Children.Add(textBlock);
            }

            foreach (var score in scores)
            {
                TextBlock textBlock = new TextBlock();

                textBlock.FontSize = descAndStatsFontSize;
                textBlock.Foreground = Brushes.Black;
                textBlock.FontFamily = Vinque;
                textBlock.Text = score;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Width = 95;

                stkpnlMonsterAbilityScores.Margin = sectionMarginBottom;
                stkpnlMonsterAbilityScores.Children.Add(textBlock);
            }

            rctMonsterAbilityScoresBottomBorder.Fill = Brushes.Red;
        }

        private void AddMonsterStats()
        {

            if (initiativeViewModel.proficiencies.Count != 0)
            {
                AddProficiencies();
            }
            if (initiativeViewModel.monster.Damage_Vulnerabilities != "")
            {
                AddDamageVulnerabilities();
            }
            if (initiativeViewModel.monster.Damage_Resistances != "")
            {
                AddDamageResistances();
            }
            if (initiativeViewModel.monster.Damage_Immunities != "")
            {
                AddDamageImmunities();
            }
            if (initiativeViewModel.conditionImmunities.Count != 0)
            {
                AddConditionImmunities();
            }
            if (initiativeViewModel.senses != null)
            {
                AddSenses();
            }
            if (initiativeViewModel.monster.Languages != null)
            {
                AddLanguages();
            }

            AddChallengeRating();

            Rectangle rect = new Rectangle();

            rect.Height = 3;
            rect.Fill = Brushes.Red;
            stkpnlMonsterStats.Children.Add(rect);
            stkpnlMonsterStats.Margin = sectionMarginTop;
        }

        private void AddProficiencies()
        {
            List<Proficiency> savingThrows = new List<Proficiency>();
            List<Proficiency> skills = new List<Proficiency>();
            TextBlock savingThrowProficiencies = new TextBlock();
            TextBlock skillProficiencies = new TextBlock();


            foreach (var proficiency in initiativeViewModel.proficiencies)
            {
                if (proficiency.Name.Contains("Saving Throw"))
                {
                    savingThrows.Add(proficiency);
                }
                else if (proficiency.Name.Contains("Skill"))
                {
                    skills.Add(proficiency);
                }
            }

            if (savingThrows.Count > 0)
            {
                savingThrowProficiencies.Text = "Saving Throws: ";
                savingThrowProficiencies.FontSize = descAndStatsFontSize;
                savingThrowProficiencies.Foreground = Brushes.Black;
                savingThrowProficiencies.FontFamily = Vinque;

                int savingThrowCount = 0;

                foreach (var saves in savingThrows)
                {
                    string saveType = saves.Name.Remove(0, 14);
                    string saveModifier;

                    if (saves.Bonus >= 0)
                    {
                        saveModifier = "+" + saves.Bonus.ToString();
                    }
                    else
                    {
                        saveModifier = saves.Bonus.ToString();
                    }

                    if (savingThrowCount == 0)
                    {
                        savingThrowProficiencies.Text += String.Format("{0} {1}", saveType, saveModifier);
                    }
                    else
                    {
                        savingThrowProficiencies.Text += String.Format(", {0} {1}", saveType, saveModifier);
                    }
                    savingThrowCount++;
                }

                stkpnlMonsterStats.Children.Add(savingThrowProficiencies);
            }

            if (skills.Count > 0)
            {
                skillProficiencies.Text = "Skills: ";
                skillProficiencies.FontSize = descAndStatsFontSize;
                skillProficiencies.Foreground = Brushes.Black;
                skillProficiencies.FontFamily = Vinque;

                int skillCount = 0;
                foreach (var skill in skills)
                {
                    string skillType = skill.Name.Remove(0, 7);
                    string skillModifier;

                    if (skill.Bonus >= 0)
                    {
                        skillModifier = "+" + skill.Bonus.ToString();
                    }
                    else
                    {
                        skillModifier = skill.Bonus.ToString();
                    }

                    if (skillCount == 0)
                    {
                        skillProficiencies.Text += String.Format("{0} {1}", skillType, skillModifier);
                    }
                    else
                    {
                        skillProficiencies.Text += String.Format(", {0} {1}", skillType, skillModifier);
                    }

                    skillCount++;
                }

                stkpnlMonsterStats.Children.Add(skillProficiencies);
            }
        }

        private void AddDamageVulnerabilities()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = "Damage Vulnerabilities: " + initiativeViewModel.monster.Damage_Vulnerabilities;
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddDamageResistances()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = "Damage Resistances: " + initiativeViewModel.monster.Damage_Resistances;
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddDamageImmunities()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = "Damage Immunities: " + initiativeViewModel.monster.Damage_Immunities;
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddConditionImmunities()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = "Condition Immunities: ";
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;

            int immunityCount = 0;

            foreach (var immunity in initiativeViewModel.conditionImmunities)
            {
                if (immunityCount == 0)
                {
                    textBlock.Text += immunity.Name;
                }
                else
                {
                    textBlock.Text += ", " + immunity.Name;
                }
            }

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddSenses()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = "Senses: ";
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;

            int sensesCount = 0;

            if (initiativeViewModel.senses.Passive_Perception > 0)
            {
                textBlock.Text += "Passive Perception " + initiativeViewModel.senses.Passive_Perception;
                sensesCount++;
            }

            if (initiativeViewModel.senses.Darkvision != null)
            {
                if (sensesCount > 0)
                {
                    textBlock.Text += ", Darkvision " + initiativeViewModel.senses.Darkvision;
                }
                else
                {
                    textBlock.Text += "Darkvision " + initiativeViewModel.senses.Darkvision;
                }
            }

            if (initiativeViewModel.senses.Blindsight != null)
            {
                if (sensesCount > 0)
                {
                    textBlock.Text += ", Blindsight " + initiativeViewModel.senses.Blindsight;
                }
                else
                {
                    textBlock.Text += "Blindsight " + initiativeViewModel.senses.Blindsight;
                }
            }

            if (initiativeViewModel.senses.Truesight != null)
            {
                if (sensesCount > 0)
                {
                    textBlock.Text += ", Truesight " + initiativeViewModel.senses.Truesight;
                }
                else
                {
                    textBlock.Text += "Truesight " + initiativeViewModel.senses.Truesight;
                }
            }

            if (initiativeViewModel.senses.Tremorsense != null)
            {
                if (sensesCount > 0)
                {
                    textBlock.Text += ", Tremorsense " + initiativeViewModel.senses.Tremorsense;
                }
                else
                {
                    textBlock.Text += "Tremorsense " + initiativeViewModel.senses.Tremorsense;
                }
            }

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddLanguages()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = "Languages: " + initiativeViewModel.monster.Languages;
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddChallengeRating()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = String.Format("Challenge: {0} ({1} XP)", initiativeViewModel.challengeRatingString, initiativeViewModel.monster.XP);
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;
            textBlock.Margin = sectionMarginBottom;

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddSpecialAbilities()
        {
            if (initiativeViewModel.monster.SpecialAbilities.Count > 0)
            {
                foreach (var specialAbility in initiativeViewModel.monster.SpecialAbilities)
                {
                    TextBlock textBlockTitle = new TextBlock();
                    TextBlock textBlockDescription = new TextBlock();

                    textBlockTitle.FontFamily = Vinque;
                    textBlockTitle.FontSize = nameFontSize;
                    textBlockTitle.FontWeight = FontWeights.Medium;
                    textBlockTitle.Foreground = Brushes.Red;

                    textBlockDescription.MaxWidth = 540;
                    textBlockDescription.Margin = new Thickness(10, 0, 0, 0);
                    textBlockDescription.FontFamily = Vinque;
                    textBlockDescription.FontSize = descAndStatsFontSize;
                    textBlockDescription.Foreground = Brushes.Black;
                    textBlockDescription.HorizontalAlignment = HorizontalAlignment.Left;
                    textBlockDescription.TextWrapping = TextWrapping.Wrap;

                    textBlockTitle.Text = specialAbility.Name;
                    textBlockDescription.Text = specialAbility.Desc;

                    if (specialAbility.IsUsage)
                    {
                        foreach (var usage in initiativeViewModel.usages)
                        {
                            AddSpecialAbilityUsage(textBlockTitle, specialAbility, usage);
                        }
                    }

                    stkpnlSpecialAbilities.Margin = sectionMarginTop;
                    stkpnlSpecialAbilities.Children.Add(textBlockTitle);
                    stkpnlSpecialAbilities.Children.Add(textBlockDescription);
                }
            }
        }

        private void AddSpecialAbilityUsage(TextBlock textBlockTitle, SpecialAbility specialAbility, Usage usage)
        {
            if (usage.SpecialAbilityName == specialAbility.Name)
            {
                switch (usage.Type)
                {
                    case "per day":
                        textBlockTitle.Text += String.Format(" ({0}/Day)", usage.Times);
                        break;

                    case "recharge on roll":
                        if (usage.MinDiceValue < 6)
                        {
                            textBlockTitle.Text += String.Format(" (Recharge {0} - 6)", usage.MinDiceValue);
                        }
                        else
                        {
                            textBlockTitle.Text += String.Format(" (Recharge 6)");
                        }
                        break;

                    case "recharge after rest":
                        if (usage.Rest_Types.Contains("short"))
                        {
                            textBlockTitle.Text += String.Format(" (Recharge after a Short or Long Rest)");
                        }
                        else
                        {
                            textBlockTitle.Text += String.Format(" (Recharge after a Long Rest)");
                        }
                        break;
                }
            }

        }

        private void AddCombatActions()
        {
            if (initiativeViewModel.monster.CombatActions.Count > 0)
            {
                TextBlock textBlockActionsHeader = new TextBlock();
                textBlockActionsHeader.FontFamily = Vinque;
                textBlockActionsHeader.FontSize = headingFontSize;
                textBlockActionsHeader.FontWeight = FontWeights.Bold;
                textBlockActionsHeader.Foreground = Brushes.Red;
                textBlockActionsHeader.Text = "Actions";


                Rectangle rect = new Rectangle();

                rect.Height = 1;
                rect.Fill = Brushes.Red;

                stkpnlCombatActions.Margin = sectionMarginTop;
                stkpnlCombatActions.Children.Add(textBlockActionsHeader);
                stkpnlCombatActions.Children.Add(rect);

                foreach (var combatAction in initiativeViewModel.monster.CombatActions)
                {
                    TextBlock textBlockTitle = new TextBlock();
                    TextBlock textBlockDescription = new TextBlock();

                    textBlockTitle.FontFamily = Vinque;
                    textBlockTitle.FontSize = nameFontSize;
                    textBlockTitle.FontWeight = FontWeights.Medium;
                    textBlockTitle.Foreground = Brushes.Red;


                    textBlockDescription.MaxWidth = 540;
                    textBlockDescription.Margin = new Thickness(10, 0, 0, 0);
                    textBlockDescription.FontFamily = Vinque;
                    textBlockDescription.FontSize = descAndStatsFontSize;
                    textBlockDescription.Foreground = Brushes.Black;
                    textBlockDescription.HorizontalAlignment = HorizontalAlignment.Left;
                    textBlockDescription.TextWrapping = TextWrapping.Wrap;

                    textBlockTitle.Text = combatAction.Name;
                    textBlockDescription.Text = combatAction.Desc;

                    if (combatAction.IsUsage)
                    {
                        foreach (var usage in initiativeViewModel.usages)
                        {
                            AddCombatActionUsage(textBlockTitle, combatAction, usage);

                        }
                    }


                    stkpnlCombatActions.Children.Add(textBlockTitle);
                    stkpnlCombatActions.Children.Add(textBlockDescription);
                }

            }
        }

        private void AddCombatActionUsage(TextBlock textBlockTitle, CombatAction combatAction, Usage usage)
        {
            if (usage.ActionName == combatAction.Name)
            {
                switch (usage.Type)
                {
                    case "per day":
                        textBlockTitle.Text += String.Format(" ({0}/Day)", usage.Times);
                        break;

                    case "recharge on roll":
                        if (usage.MinDiceValue < 6)
                        {
                            textBlockTitle.Text += String.Format(" (Recharge {0} - 6)", usage.MinDiceValue);
                        }
                        else
                        {
                            textBlockTitle.Text += String.Format(" (Recharge 6)");
                        }
                        break;

                    case "recharge after rest":
                        if (usage.Rest_Types.Contains("short"))
                        {
                            textBlockTitle.Text += String.Format(" (Recharge after a Short or Long Rest)");
                        }
                        else
                        {
                            textBlockTitle.Text += String.Format(" (Recharge after a Long Rest)");
                        }
                        break;
                }
            }

        }

        private void AddReactions()
        {
            if (initiativeViewModel.monster.Reactions.Count > 0)
            {
                TextBlock textBlockActionsHeader = new TextBlock();
                textBlockActionsHeader.FontFamily = Vinque;
                textBlockActionsHeader.FontSize = headingFontSize;
                textBlockActionsHeader.FontWeight = FontWeights.Bold;
                textBlockActionsHeader.Foreground = Brushes.Red;
                textBlockActionsHeader.Text = "Reactions";


                Rectangle rect = new Rectangle();

                rect.Height = 1;
                rect.Fill = Brushes.Red;

                stkpnlReactions.Margin = sectionMarginTop;
                stkpnlReactions.Children.Add(textBlockActionsHeader);
                stkpnlReactions.Children.Add(rect);

                foreach (var reaction in initiativeViewModel.monster.Reactions)
                {
                    TextBlock textBlockTitle = new TextBlock();
                    TextBlock textBlockDescription = new TextBlock();

                    textBlockTitle.FontFamily = Vinque;
                    textBlockTitle.FontSize = nameFontSize;
                    textBlockTitle.FontWeight = FontWeights.Medium;
                    textBlockTitle.Foreground = Brushes.Red;


                    textBlockDescription.MaxWidth = 540;
                    textBlockDescription.Margin = new Thickness(10, 0, 0, 0);
                    textBlockDescription.FontFamily = Vinque;
                    textBlockDescription.FontSize = descAndStatsFontSize;
                    textBlockDescription.Foreground = Brushes.Black;
                    textBlockDescription.HorizontalAlignment = HorizontalAlignment.Left;
                    textBlockDescription.TextWrapping = TextWrapping.Wrap;

                    textBlockTitle.Text = reaction.Name;
                    textBlockDescription.Text = reaction.Description;


                    stkpnlReactions.Children.Add(textBlockTitle);
                    stkpnlReactions.Children.Add(textBlockDescription);
                }

            }
        }

        private void AddLegendaryActions()
        {
            if (initiativeViewModel.monster.LegendaryActions.Count > 0)
            {
                TextBlock textBlockActionsHeader = new TextBlock();
                textBlockActionsHeader.FontFamily = Vinque;
                textBlockActionsHeader.FontSize = headingFontSize;
                textBlockActionsHeader.FontWeight = FontWeights.Bold;
                textBlockActionsHeader.Foreground = Brushes.Red;
                textBlockActionsHeader.Text = "LegendaryActions";

                TextBlock legendaryActionRulesText = new TextBlock();
                legendaryActionRulesText.FontFamily = Vinque;
                legendaryActionRulesText.FontSize = descAndStatsFontSize;
                legendaryActionRulesText.Text = String.Format("{0} can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature’s turn. {0} regains spent legendary actions at the start of their turn.", initiativeViewModel.monster.Name);
                legendaryActionRulesText.TextWrapping = TextWrapping.Wrap;
                legendaryActionRulesText.Margin = sectionMarginBottom;

                Rectangle rect = new Rectangle();

                rect.Height = 1;
                rect.Fill = Brushes.Red;

                stkpnlLegendaryActions.Margin = sectionMarginTop;
                stkpnlLegendaryActions.Children.Add(textBlockActionsHeader);
                stkpnlLegendaryActions.Children.Add(rect);
                stkpnlLegendaryActions.Children.Add(legendaryActionRulesText);

                foreach (var legendaryAction in initiativeViewModel.monster.LegendaryActions)
                {
                    TextBlock textBlockTitle = new TextBlock();
                    TextBlock textBlockDescription = new TextBlock();

                    textBlockTitle.FontFamily = Vinque;
                    textBlockTitle.FontSize = nameFontSize;
                    textBlockTitle.FontWeight = FontWeights.Medium;
                    textBlockTitle.Foreground = Brushes.Red;


                    textBlockDescription.MaxWidth = 540;
                    textBlockDescription.Margin = new Thickness(10, 0, 0, 0);
                    textBlockDescription.FontFamily = Vinque;
                    textBlockDescription.FontSize = descAndStatsFontSize;
                    textBlockDescription.Foreground = Brushes.Black;
                    textBlockDescription.HorizontalAlignment = HorizontalAlignment.Left;
                    textBlockDescription.TextWrapping = TextWrapping.Wrap;

                    textBlockTitle.Text = legendaryAction.Name;
                    textBlockDescription.Text = legendaryAction.Desc;


                    stkpnlLegendaryActions.Children.Add(textBlockTitle);
                    stkpnlLegendaryActions.Children.Add(textBlockDescription);
                }

            }
        }

        private void btnRollInitiative_Click(object sender, RoutedEventArgs e)
        {
            List<InitiativeListItem> initiativeListItems = new List<InitiativeListItem>();
            EnterPlayerInitiatives enterPlayerInitiatives = new EnterPlayerInitiatives(initiativeViewModel);

            foreach(var creature in initiativeViewModel.Creatures)
            {
                if (creature.Is_Monster)
                {
                    creature.Initiative = ThreadSafeRandom.ThisThreadsRandom.Next(1 , 21) + creature.Initiative_Modifier;
                }

                initiativeListItems.Add(creature);
                initiativeListItems.Sort();
                initiativeListItems.Reverse();
            }

            initiativeViewModel.Creatures.Clear();

            foreach (var creature in initiativeListItems)
            {
                initiativeViewModel.Creatures.Add(creature);
            }

            foreach (var creature in initiativeViewModel.Creatures)
            {
                if (!creature.Is_Monster)
                {
                    enterPlayerInitiatives.Show();
                    break;
                }
            }

            initiativeListItems.Clear();
        }

        private void btnaveScenario_MouseEnter(object sender, MouseEventArgs e)
        {
            brdRollInitiative.Background = Brushes.LightGreen;
        }

        private void btnaveScenario_MouseLeave(object sender, MouseEventArgs e)
        {
            brdRollInitiative.Background = Brushes.Green;
        }
    }
}

    public static class ThreadSafeRandom
    {
        /*Creates a new random object so that shuffle can randomize the order of the cards
        * This new random is created with a seed equal to the amount of ticks
        * the program has run for times 31 plus the ID of the current thread
        * This increases the randomness compared to a new random object with no seed
        */
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
