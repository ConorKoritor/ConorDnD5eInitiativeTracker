using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ConorDnD5eInitiativeTracker.MVVM.ViewModels;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseLibrary.Databases;
using System.Configuration.Internal;
using DatabaseLibrary.DatabaseQueries;

namespace ConorDnD5eInitiativeTracker.MVVM.Views
{
    /// <summary>
    /// Interaction logic for CharacterBuilderView.xaml
    /// </summary>
    public partial class CharacterBuilderView : UserControl
    {
        InitiativeTrackerDB db = new InitiativeTrackerDB("TestDatabase19");

        public CharacterBuilderView()
        {
            InitializeComponent();

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtbxCharacterNameInput.Clear();
            txtbxCharacterACInput.Clear();
            txtbxCharacterHPInput.Clear();
            txtbxCharacterCR2Input.Clear();
        }

        private void btnAddToDatabase_Click(object sender, RoutedEventArgs e)
        {
            string characterName = "Player";
            short characterLevel = 0;
            short characterAC = 0;
            int characterHP = 0;
            int characterCR2 = 0;
            bool incorrectInput = false;

            do
            {
                if (txtbxCharacterNameInput.Text.Length > 0)
                {
                    characterName = txtbxCharacterNameInput.Text;
                }
                else
                {
                    MessageBox.Show("Please Enter Your Characters Name in the Text Box");
                    incorrectInput = true;
                    break;
                }

                if (!short.TryParse(txtbxCharacterLevelInput.Text, out characterLevel))
                {
                    MessageBox.Show($"Please Enter a valid Character Level with no special characters between 0 and 20");
                    incorrectInput = true;
                    break;
                }
                if (!short.TryParse(txtbxCharacterACInput.Text, out characterAC))
                {
                    MessageBox.Show("Please Enter a valid Character Armor Class with no special characters between 0 and 50");
                    incorrectInput = true;
                    break;
                }
                if (!int.TryParse(txtbxCharacterHPInput.Text, out characterHP))
                {
                    MessageBox.Show("Please Enter a valid Character HP with no special characters between 0 and 500");
                    incorrectInput = true;
                    break;
                }
                if (!int.TryParse(txtbxCharacterCR2Input.Text, out characterCR2))
                {
                    MessageBox.Show($"Please Enter a valid Character CR2 score with no special characters between 0 and 100" +
                        "\n\n To find out more information please visit https://www.gmbinder.com/share/-N4m46K77hpMVnh7upYa");
                    incorrectInput = true;
                    break;
                }

            }while (incorrectInput);

            if (!incorrectInput)
            {
                PlayerCharacterBasic player = new PlayerCharacterBasic()
                {
                    Name = characterName,
                    Level = characterLevel,
                    AC = characterAC,
                    HP = characterHP,
                    CR_2_Score = characterCR2
                };

                var query = PlayerQueries.GetPlayers(db);
                bool IsDuplicateName = false;

                if (query.Count > 0)
                {
                    foreach (PlayerCharacterBasic playerCharacterBasic in query)
                    {
                        if (player.Name == playerCharacterBasic.Name)
                        {
                            MessageBox.Show("Error, Player Not Added To Database. Please add a player with a unique name");
                            IsDuplicateName = true;
                            break;
                        }
                    }
                }
                    if (CharacterBuilderViewModel.AddCharacterToDatabase(player) && !IsDuplicateName)
                    {
                        MessageBox.Show("Player Added to Database");
                        txtbxCharacterNameInput.Clear();
                        txtbxCharacterACInput.Clear();
                        txtbxCharacterLevelInput.Clear();
                        txtbxCharacterHPInput.Clear();
                        txtbxCharacterCR2Input.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error, Player Not Added To Database");
                    }

                
            }

        }

        private void btnClear_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FF7F7F");
            brdClear.Background = brush;
        }

        private void btnClear_MouseLeave(object sender, MouseEventArgs e)
        {
            brdClear.Background = Brushes.Red;
        }

        private void btnAddToDatabase_MouseEnter(object sender, MouseEventArgs e)
        {
            brdAddToDatabase.Background = Brushes.LightGreen;
        }

        private void btnAddToDatabase_MouseLeave(object sender, MouseEventArgs e)
        {
            brdAddToDatabase.Background = Brushes.Green;
        }
    }
}
