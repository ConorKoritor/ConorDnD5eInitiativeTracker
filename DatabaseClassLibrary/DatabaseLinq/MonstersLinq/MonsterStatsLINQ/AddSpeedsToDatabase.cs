using DatabaseClassLibrary.APIRequests;
using DatabaseClassLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClassLibrary.DatabaseLinq.MonstersLinq
{
    internal class AddSpeedsToDatabase
    {
        internal void AddSpeeds(MonsterModel monster, InitiativeTrackerDB db)
        {
            List<Speed> speeds = new List<Speed>();
            if (monster.speed.walk != null)
            {
                Speed speed = new Speed
                {
                    Type = "Walk",
                    Distance = monster.speed.walk,
                    MonsterName = monster.name
                };

                speeds.Add(speed);
            }
            if (monster.speed.fly != null)
            {
                Speed speed = new Speed
                {
                    Type = "Fly",
                    Distance = monster.speed.fly,
                    MonsterName = monster.name
                };

                speeds.Add(speed);
            }
            if (monster.speed.burrow != null)
            {
                Speed speed = new Speed
                {
                    Type = "Burrow",
                    Distance = monster.speed.burrow,
                    MonsterName = monster.name
                };

                speeds.Add(speed);
            }
            if (monster.speed.swim != null)
            {
                Speed speed = new Speed
                {
                    Type = "Swim",
                    Distance = monster.speed.swim,
                    MonsterName = monster.name
                };

                speeds.Add(speed);
            }
            if (monster.speed.climb != null)
            {
                Speed speed = new Speed
                {
                    Type = "Climb",
                    Distance = monster.speed.climb,
                    MonsterName = monster.name
                };

                speeds.Add(speed);
            }

            foreach (var speed in speeds)
            {
                AddEachSpeedToDatabase(speed, monster, db);
            }

        }

        internal void AddEachSpeedToDatabase(Speed speed, MonsterModel monster, InitiativeTrackerDB db)
        {
            try
            {
                db.Speeds.Add(speed);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                Exception innerException = ex.InnerException;

                // Handle the inner exception
                if (innerException != null)
                {
                    // Log or handle the inner exception
                    Console.WriteLine($"Inner Exception: {innerException.Message}");
                }
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Speed)
                    {
                        // Handle the specific entity that caused the exception
                        Speed entity = (Speed)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Type} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }
    }
}
