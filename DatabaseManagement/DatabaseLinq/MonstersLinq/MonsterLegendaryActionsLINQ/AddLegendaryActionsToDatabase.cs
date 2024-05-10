using ConorDnD5eInitiativeTracker.APIRequests;
using DatabaseModel.Databases;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseLinq.MonstersLinq
{
    internal class AddLegendaryActionsToDatabase
    {
        internal void AddLegendaryActions(MonsterModel monster, InitiativeTrackerDB db)
        {
            foreach (var legendaryAction in monster.legendary_actions)
            {
                AddEachLegendaryActionToDatabase(monster, db, legendaryAction);
            }

        }

        internal void AddEachLegendaryActionToDatabase(MonsterModel monster, InitiativeTrackerDB db, MonsterLegendaryActionModel legendaryAction)
        {
            LegendaryAction legendaryAction1 = new LegendaryAction()
            {
                Name = legendaryAction.name,
                Desc = legendaryAction.desc,
                Attack_Bonus = (short)legendaryAction.attack_bonus,
                MonsterName = monster.name,
                IsDamage = false,
                IsDC = false
            };

            if (legendaryAction.damage != null)
            {
                legendaryAction1.IsDamage = true;
            }

            if (legendaryAction.dc != null)
            {
                legendaryAction1.IsDC = true;
            }

            try
            {
                db.LegendaryActions.Add(legendaryAction1);
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
                    if (entry.Entity is LegendaryAction)
                    {
                        // Handle the specific entity that caused the exception
                        LegendaryAction entity = (LegendaryAction)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }

            if (legendaryAction.damage != null)
            {
                AddLegendaryActionDamage(monster, db, legendaryAction.damage, legendaryAction);
            }

            if (legendaryAction.dc != null)
            {
                AddActionDC(monster, db, legendaryAction.dc, legendaryAction);
            }



            try
            {
                Console.WriteLine("Trying to save database");
                db.SaveChanges();
                Console.WriteLine("Database Saved");

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: " + validationError.PropertyName + "Of Monster: " + monster.name + " Error: " + validationError.ErrorMessage);
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
                    Console.WriteLine($"Inner Exception: {innerException}");
                }
            }
        }

        internal void AddLegendaryActionDamage(MonsterModel monster, InitiativeTrackerDB db, List<MonsterDamageModel> damages, MonsterLegendaryActionModel legendaryAction)
        {
            foreach (var damage in damages)
            {
                Damage damage1 = new Damage()
                {
                    Damage_Type = damage.damage_type.name,
                    Damage_Dice = damage.damage_dice,
                    LegendaryActionName = legendaryAction.name,
                    LegendaryActionMonsterName = monster.name
                };

                try
                {
                    db.Damages.Add(damage1);
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
                        if (entry.Entity is Damage)
                        {
                            // Handle the specific entity that caused the exception
                            Damage entity = (Damage)entry.Entity;
                            // Log or handle the failed entity (e.g., display an error message)
                            Console.WriteLine($"Failed to save entity {entity.Damage_Type} of Action {legendaryAction.name} of Monster {monster.name}: {ex.Message}");
                        }
                    }

                }
            }
        }

        internal void AddActionDC(MonsterModel monster, InitiativeTrackerDB db, MonsterDcModel dc, MonsterLegendaryActionModel legendaryAction)
        {
            DifficultyClass difficultyClass = new DifficultyClass()
            {
                DC_Type = dc.dc_type.name,
                DC_Value = (short)dc.dc_value,
                LegendaryActionName = legendaryAction.name,
                LegendaryActionMonsterName = monster.name
            };

            try
            {
                db.DifficultyClasses.Add(difficultyClass);
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
                    if (entry.Entity is DifficultyClass)
                    {
                        // Handle the specific entity that caused the exception
                        DifficultyClass entity = (DifficultyClass)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.DC_Type} of Action {legendaryAction.name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }
    }
}
