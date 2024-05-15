using ConorDnD5eInitiativeTracker.MVVM.Models;
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

        public MonsterSearchViewModel()
        {
            db = new InitiativeTrackerDB("TestDatabase3");
            Monsters = new ObservableCollection<MonsterListItem>();

            var query = from m in db.Monsters
                        select new MonsterListItem
                        {
                            Name = m.Name,
                            Size = m.Size,
                            Type = m.Type,
                            Challenge_Rating = m.Challenge_Rating.ToString()
                        };

            foreach (var m in query)
            {
                Monsters.Add(m);
            }

        }

        public void SearchTheDatabase(string search)
        {

            Monsters.Clear();
            if (search != null)
            {
                var query = from m in db.Monsters
                            where m.Name.StartsWith(search)
                            select new MonsterListItem
                            {
                                Name = m.Name,
                                Size = m.Size,
                                Type = m.Type,
                                Challenge_Rating = m.Challenge_Rating.ToString()
                            };

                foreach (var m in query)
                {
                    Monsters.Add(m);
                }
            }
            else
            {
                var query = from m in db.Monsters
                            select new MonsterListItem
                            {
                                Name = m.Name,
                                Size = m.Size,
                                Type = m.Type,
                                Challenge_Rating = m.Challenge_Rating.ToString()
                            };

                foreach (var m in query)
                {
                    Monsters.Add(m);
                }
            }

            
        }
    }

    
}
