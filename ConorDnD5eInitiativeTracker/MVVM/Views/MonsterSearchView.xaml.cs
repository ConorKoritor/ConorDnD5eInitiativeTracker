using ConorDnD5eInitiativeTracker.MVVM.Models;
using ConorDnD5eInitiativeTracker.MVVM.ViewModels;
using DatabaseLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConorDnD5eInitiativeTracker.MVVM.Views
{
    /// <summary>
    /// Interaction logic for MonsterSearchView.xaml
    /// </summary>
    public partial class MonsterSearchView : UserControl
    {
        

        public MonsterSearchView()
        {
            InitializeComponent();

            string search = txtbxSearch.Text;
            MonsterSearchViewModel monsterSearchViewModel = this.DataContext as MonsterSearchViewModel;
            monsterSearchViewModel.SearchTheDatabase(search);

        }

        private void txtbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txtbxSearch.Text;
            MonsterSearchViewModel monsterSearchViewModel = this.DataContext as MonsterSearchViewModel;
            monsterSearchViewModel.SearchTheDatabase(search);
        }
    }
}
