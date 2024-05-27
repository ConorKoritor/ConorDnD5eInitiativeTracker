using ConorDnD5eInitiativeTracker.MVVM.Models;
using ConorDnD5eInitiativeTracker.MVVM.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for EnterPlayerInitiatives.xaml
    /// </summary>
    public partial class EnterPlayerInitiatives : Window
    {
        InitiativeViewModel viewModel;

        List<TextBox> textBoxes = new List<TextBox>();

        public EnterPlayerInitiatives(InitiativeViewModel initiativeViewModel)
        {
            InitializeComponent();

            viewModel = initiativeViewModel;

            foreach(var creature in viewModel.Creatures)
            {
                if (!creature.Is_Monster)
                {
                    StackPanel stkpnl = new StackPanel()
                    {
                        Orientation = Orientation.Horizontal,
                        Width = 600,
                        HorizontalAlignment = HorizontalAlignment.Left,
                    };

                    TextBlock textBlockPlayerName = new TextBlock()
                    {
                        FontSize = 22,
                        FontWeight = FontWeights.Bold,
                        FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#vinque rg"),
                        Text = creature.Name,
                        Foreground = Brushes.Red
                    };

                    TextBox textBoxPlayerInitiative = new TextBox()
                    {
                        Name = String.Join(",", creature.Name),
                        Width = 50,
                        HorizontalAlignment = HorizontalAlignment.Right
                    };

                    textBoxes.Add(textBoxPlayerInitiative);

                    stkpnl.Children.Add(textBlockPlayerName);
                    stkpnl.Children.Add(textBoxPlayerInitiative);
                    stkpnlEnterPlayersInitiatives.Children.Add(stkpnl);
                }
            }
        }

        private void btnSaveInitiatives_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            List<InitiativeListItem> initiativeListItems = new List<InitiativeListItem>();

            foreach (var creature in viewModel.Creatures)
            {
                if (!creature.Is_Monster)
                {
                    creature.Initiative = int.Parse(textBoxes[count].Text);

                    count++;
                }

                initiativeListItems.Add(creature);
                initiativeListItems.Sort();
                initiativeListItems.Reverse();
            }

            viewModel.Creatures.Clear();

            foreach (var creature in initiativeListItems)
            {
                viewModel.Creatures.Add(creature);
            }

            initiativeListItems.Clear();
            Close();
        }

        private void btnSaveInitiatives_MouseEnter(object sender, MouseEventArgs e)
        {
            brdSaveInitiatives.Background = Brushes.LightGreen;
        }

        private void btnSaveInitiatives_MouseLeave(object sender, MouseEventArgs e)
        {
            brdSaveInitiatives.Background = Brushes.Green;
        }
    }
}
