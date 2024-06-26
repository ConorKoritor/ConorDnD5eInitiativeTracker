﻿using ConorDnD5eInitiativeTracker.MVVM.Models;
using ConorDnD5eInitiativeTracker.MVVM.ViewModels;
using DatabaseLibrary.APIRequests;
using DatabaseLibrary.DatabaseLinq.MonstersLinq;
using DatabaseLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
    /// Interaction logic for MonsterSearchView.xaml
    /// </summary>
    public partial class MonsterSearchView : UserControl
    {
        MonsterSearchViewModel monsterSearchViewModel;
        FontFamily Vinque = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#vinque rg");
        double descAndStatsFontSize = 16;
        double headingFontSize = 27;
        double nameFontSize = 18;
        Thickness sectionMarginTop = new Thickness(0, 10, 0, 0);
        Thickness sectionMarginBottom = new Thickness(0, 0, 0, 10);
        Thickness sectionMarginBoth = new Thickness(0, 10, 0, 10)
;        

        public MonsterSearchView()
        {
            InitializeComponent();

            string search = txtbxSearch.Text;
            monsterSearchViewModel = this.DataContext as MonsterSearchViewModel;
            monsterSearchViewModel.SearchTheDatabase(search);

        }

        private void txtbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txtbxSearch.Text;
            monsterSearchViewModel.SearchTheDatabase(search);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MonsterListItem monsterListItem = lstbxMonsterList.SelectedItem as MonsterListItem;
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

            if (monsterListItem != null)
            {
                monsterSearchViewModel.GetAllMonsterStats(monsterListItem.Name);

                txtblkMonsterStatsName.Text = monsterListItem.Name;
                txtblkMonsterStatsAlignmentSizeAndType.Text = String.Format("{0} {1}, {2}", monsterListItem.Size, monsterListItem.Type, monsterListItem.Alignment);
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

        private void AddACHPAndSpeed()
        {

            TextBlock ac = new TextBlock();
            TextBlock hp = new TextBlock();
            TextBlock speeds = new TextBlock();
            int acCount = 0;
            int speedCount = 0;

            ac.Text = "Armor Class: ";
            speeds.Text = "Speed: ";

            foreach(ArmorClass armorClass in monsterSearchViewModel.armorClasses)
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

            hp.Text =String.Format("Hit Points: {0}", monsterSearchViewModel.monster.HP.ToString());

            foreach(Speed speed in monsterSearchViewModel.speeds)
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
            decimal strengthModifier = Math.Floor((decimal)(monsterSearchViewModel.abilityScores.Strength - 10) / 2);
            decimal dexterityModifier = Math.Floor((decimal)(monsterSearchViewModel.abilityScores.Dexterity - 10) / 2);
            decimal constitutionModifier = Math.Floor((decimal)(monsterSearchViewModel.abilityScores.Constitution - 10) / 2);
            decimal intelligenceModifier = Math.Floor((decimal)(monsterSearchViewModel.abilityScores.Intelligence - 10) / 2);
            decimal wisdomModifier = Math.Floor((decimal)(monsterSearchViewModel.abilityScores.Wisdom - 10) / 2);
            decimal charismaModifier = Math.Floor((decimal)(monsterSearchViewModel.abilityScores.Charisma - 10) / 2);

            string strengthModifierString;
            string dexterityModifierString;
            string constitutionModifierString;
            string intelligenceModifierString;
            string wisdomModifierString;
            string charismaModifierString;

            if(monsterSearchViewModel.abilityScores.Strength >= 10) 
            {
                strengthModifierString = "+" + strengthModifier;
            }
            else
            {
                strengthModifierString = strengthModifier.ToString();
            }

            if (monsterSearchViewModel.abilityScores.Dexterity >= 10)
            {
                dexterityModifierString = "+" + dexterityModifier;
            }
            else
            {
                dexterityModifierString = dexterityModifier.ToString();
            }

            if (monsterSearchViewModel.abilityScores.Constitution >= 10)
            {
                constitutionModifierString = "+" + constitutionModifier;
            }
            else
            {
                constitutionModifierString = constitutionModifier.ToString();
            }

            if (monsterSearchViewModel.abilityScores.Intelligence >= 10)
            {
                intelligenceModifierString = "+" + intelligenceModifier;
            }
            else
            {
                intelligenceModifierString = intelligenceModifier.ToString();
            }

            if (monsterSearchViewModel.abilityScores.Wisdom >= 10)
            {
                wisdomModifierString = "+" + wisdomModifier;
            }
            else
            {
                wisdomModifierString = wisdomModifier.ToString();
            }

            if (monsterSearchViewModel.abilityScores.Charisma >= 10)
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
                String.Format("{0} ({1})", monsterSearchViewModel.abilityScores.Strength.ToString(), strengthModifierString),
                String.Format("{0} ({1})", monsterSearchViewModel.abilityScores.Dexterity.ToString(), dexterityModifierString),
                String.Format("{0} ({1})", monsterSearchViewModel.abilityScores.Constitution.ToString(), constitutionModifierString),
                String.Format("{0} ({1})", monsterSearchViewModel.abilityScores.Intelligence.ToString(), intelligenceModifierString),
                String.Format("{0} ({1})", monsterSearchViewModel.abilityScores.Wisdom.ToString(), wisdomModifierString),
                String.Format("{0} ({1})", monsterSearchViewModel.abilityScores.Charisma.ToString(), charismaModifierString)     
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

                stkpnlMonsterAbilityNames.Margin = new Thickness(0,10,0,4);
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

            if (monsterSearchViewModel.proficiencies.Count !=0)
            {
                AddProficiencies();
            }
            if (monsterSearchViewModel.monster.Damage_Vulnerabilities != "")
            {
                AddDamageVulnerabilities();
            }
            if (monsterSearchViewModel.monster.Damage_Resistances != "")
            {
                AddDamageResistances();
            }
            if (monsterSearchViewModel.monster.Damage_Immunities != "")
            {
                AddDamageImmunities();
            }
            if (monsterSearchViewModel.conditionImmunities.Count != 0)
            {
                AddConditionImmunities();
            }
            if(monsterSearchViewModel.senses != null)
            {
                AddSenses();
            }
            if(monsterSearchViewModel.monster.Languages != null)
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


            foreach (var proficiency in monsterSearchViewModel.proficiencies)
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

            textBlock.Text = "Damage Vulnerabilities: " + monsterSearchViewModel.monster.Damage_Vulnerabilities;
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddDamageResistances()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = "Damage Resistances: " + monsterSearchViewModel.monster.Damage_Resistances;
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddDamageImmunities()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = "Damage Immunities: " + monsterSearchViewModel.monster.Damage_Immunities;
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

            foreach(var immunity in monsterSearchViewModel.conditionImmunities)
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

            if(monsterSearchViewModel.senses.Passive_Perception > 0) 
            {
                textBlock.Text += "Passive Perception " + monsterSearchViewModel.senses.Passive_Perception;
                sensesCount++;
            }

            if(monsterSearchViewModel.senses.Darkvision != null)
            {
                if (sensesCount > 0)
                {
                    textBlock.Text += ", Darkvision " + monsterSearchViewModel.senses.Darkvision;
                }
                else
                {
                    textBlock.Text += "Darkvision " + monsterSearchViewModel.senses.Darkvision;
                }
            }

            if (monsterSearchViewModel.senses.Blindsight != null)
            {
                if (sensesCount > 0)
                {
                    textBlock.Text += ", Blindsight " + monsterSearchViewModel.senses.Blindsight;
                }
                else { 
                    textBlock.Text += "Blindsight " + monsterSearchViewModel.senses.Blindsight;
                }
            }

            if (monsterSearchViewModel.senses.Truesight != null)
            {
                if (sensesCount > 0)
                {
                    textBlock.Text += ", Truesight " + monsterSearchViewModel.senses.Truesight;
                }
                else
                {
                    textBlock.Text += "Truesight " + monsterSearchViewModel.senses.Truesight;
                }
            }

            if (monsterSearchViewModel.senses.Tremorsense != null)
            {
                if (sensesCount > 0)
                {
                    textBlock.Text += ", Tremorsense " + monsterSearchViewModel.senses.Tremorsense;
                }
                else
                {
                    textBlock.Text += "Tremorsense " + monsterSearchViewModel.senses.Tremorsense;
                }
            }

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddLanguages()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = "Languages: " + monsterSearchViewModel.monster.Languages;
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddChallengeRating()
        {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = String.Format("Challenge: {0} ({1} XP)", monsterSearchViewModel.challengeRatingString, monsterSearchViewModel.monster.XP);
            textBlock.FontSize = descAndStatsFontSize;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontFamily = Vinque;
            textBlock.Margin = sectionMarginBottom;

            stkpnlMonsterStats.Children.Add(textBlock);
        }

        private void AddSpecialAbilities()
        {
            if (monsterSearchViewModel.monster.SpecialAbilities.Count > 0)
            {
                foreach (var specialAbility in monsterSearchViewModel.monster.SpecialAbilities)
                {
                    TextBlock textBlockTitle = new TextBlock();
                    TextBlock textBlockDescription = new TextBlock();

                    textBlockTitle.FontFamily = Vinque;
                    textBlockTitle.FontSize = nameFontSize;
                    textBlockTitle.FontWeight = FontWeights.Medium;
                    textBlockTitle.Foreground = Brushes.Red;

                    textBlockDescription.MaxWidth = 540;
                    textBlockDescription.Margin = new Thickness(10,0,0,0);
                    textBlockDescription.FontFamily = Vinque;
                    textBlockDescription.FontSize = descAndStatsFontSize;
                    textBlockDescription.Foreground = Brushes.Black;
                    textBlockDescription.HorizontalAlignment = HorizontalAlignment.Left;
                    textBlockDescription.TextWrapping = TextWrapping.Wrap;

                    textBlockTitle.Text = specialAbility.Name;
                    textBlockDescription.Text = specialAbility.Desc;

                    if (specialAbility.IsUsage)
                    {
                        foreach (var usage in monsterSearchViewModel.usages)
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
            if (monsterSearchViewModel.monster.CombatActions.Count > 0)
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

                foreach (var combatAction in monsterSearchViewModel.monster.CombatActions)
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
                        foreach (var usage in monsterSearchViewModel.usages)
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
                        if(usage.MinDiceValue < 6)
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
            if (monsterSearchViewModel.monster.Reactions.Count > 0)
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

                foreach (var reaction in monsterSearchViewModel.monster.Reactions)
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
            if (monsterSearchViewModel.monster.LegendaryActions.Count > 0)
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
                legendaryActionRulesText.Text = String.Format("{0} can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature’s turn. {0} regains spent legendary actions at the start of their turn.", monsterSearchViewModel.monster.Name);
                legendaryActionRulesText.TextWrapping = TextWrapping.Wrap;
                legendaryActionRulesText.Margin = sectionMarginBottom;

                Rectangle rect = new Rectangle();

                rect.Height = 1;
                rect.Fill = Brushes.Red;

                stkpnlLegendaryActions.Margin = sectionMarginTop;
                stkpnlLegendaryActions.Children.Add(textBlockActionsHeader);
                stkpnlLegendaryActions.Children.Add(rect);
                stkpnlLegendaryActions.Children.Add(legendaryActionRulesText);

                foreach (var legendaryAction in monsterSearchViewModel.monster.LegendaryActions)
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

    }
}
