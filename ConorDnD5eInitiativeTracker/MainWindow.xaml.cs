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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConorDnD5eInitiativeTracker.APIRequests;

namespace ConorDnD5eInitiativeTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MonsterDictionaryAPIRequests monsterDictionaryAPI = new MonsterDictionaryAPIRequests();
        public MainWindow()
        {
            InitializeComponent();

            InitializeAPI.InitializeClient();



            LoadMonsterDictionaryAPI();
        }

        private void btn_testBench_Click(object sender, RoutedEventArgs e)
        {
            TestBench testBench = new TestBench(monsterDictionaryAPI);
            testBench.Show();
        }

        private async Task LoadMonsterDictionaryAPI()
        {
            await monsterDictionaryAPI.PullMonsterListFromAPI();
        }
    }
}
