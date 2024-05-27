using ConorDnD5eInitiativeTracker.MVVM.Models;
using ConorDnD5eInitiativeTracker.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConorDnD5eInitiativeTracker
{
    /// <summary>
    /// Interaction logic for PlayerSelection.xaml
    /// </summary>
    public partial class PlayerSelection : Window
    {
        ScenarioBuilderViewModel scenarioBuilderViewModel;

        public PlayerSelection(ScenarioBuilderViewModel viewModel)
        {
            InitializeComponent();

            scenarioBuilderViewModel = viewModel;
            lstbxScenarioPlayerList.ItemsSource = scenarioBuilderViewModel.ScenarioPlayers;
            lstbxPlayerList.ItemsSource = scenarioBuilderViewModel.Players;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            Point pt = e.GetPosition(WindowDrag);

            Debug.WriteLine(pt.Y);

            if (pt.Y < WindowDrag.ActualHeight)
            {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    break;
            }
        }

        

        private void btnRemoveFromScenario_MouseEnter(object sender, MouseEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FF7F7F");
            brdRemoveFromScenario.Background = brush;
        }

        private void btnRemoveFromScenario_MouseLeave(object sender, MouseEventArgs e)
        {
            brdRemoveFromScenario.Background = Brushes.Red;
        }

        private void btnAddToScenario_MouseEnter(object sender, MouseEventArgs e)
        {
            brdAddToScenario.Background = Brushes.LightGreen;
        }

        private void btnAddToScenario_MouseLeave(object sender, MouseEventArgs e)
        {
            brdAddToScenario.Background = Brushes.Green;
        }

        private void btnRemoveFromScenario_Click(object sender, RoutedEventArgs e)
        {
            if (lstbxScenarioPlayerList.SelectedItem != null)
            {
                PlayerListItem playerListItem = lstbxScenarioPlayerList.SelectedItem as PlayerListItem;
                scenarioBuilderViewModel.Players.Add(playerListItem);
                scenarioBuilderViewModel.ScenarioPlayers.Remove(playerListItem);

                scenarioBuilderViewModel.UpdatePlayerStats();
            }
        }

        private void btnAddToScenario_Click(object sender, RoutedEventArgs e)
        {
            if(lstbxPlayerList.SelectedItem != null)
            {
                PlayerListItem playerListItem = lstbxPlayerList.SelectedItem as PlayerListItem;
                scenarioBuilderViewModel.ScenarioPlayers.Add(playerListItem);
                scenarioBuilderViewModel.Players.Remove(playerListItem);

                scenarioBuilderViewModel.UpdatePlayerStats();
            }
        }

        private void txtbxPlayerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txtbxPlayerSearch.Text;
            scenarioBuilderViewModel.SearchThePlayerDatabase(search);
        }

        private void btnFinish_MouseEnter(object sender, MouseEventArgs e)
        {
            brdFInishButton.Background = Brushes.LightGreen;
        }

        private void btnFinish_MouseLeave(object sender, MouseEventArgs e)
        {
            brdFInishButton.Background = Brushes.Green;
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
