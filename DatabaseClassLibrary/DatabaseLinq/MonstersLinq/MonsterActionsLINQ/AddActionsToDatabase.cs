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
    internal class AddActionsToDatabase
    {
        internal void AddActions(MonsterModel monster, InitiativeTrackerDB db)
        {
            foreach (var action in monster.actions)
            {
                AddEachActionToDatabase(monster, db, action);
            }

        }

        internal void AddEachActionToDatabase(MonsterModel monster, InitiativeTrackerDB db, MonsterActionModel action)
        {
            CombatAction action1 = new CombatAction()
            {
                Name = action.name,
                Desc = action.desc,
                Attack_Bonus = (short)action.attack_bonus,
                MonsterName = monster.name,
                IsUsage = false,
                IsDamage = false,
                IsDC = false,
                HasDamageOptions = false
            };

            if (action.usage != null)
            {
                action1.IsUsage = true;
            }

            if (action.damage != null)
            {
                action1.IsDamage = true;
            }

            if (action.dc != null)
            {
                action1.IsDC = true;
            }

            if (action.damage != null)
            {
                foreach (var damage in action.damage)
                {
                    if (damage.from != null)
                    {
                        action1.HasDamageOptions = true;
                    }
                }
            }

            try
            {
                db.CombatActions.Add(action1);
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
                    if (entry.Entity is CombatAction)
                    {
                        // Handle the specific entity that caused the exception
                        CombatAction entity = (CombatAction)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }



            if (action.usage != null)
            {
                AddActionUsage(monster, db, action.usage, action);
            }

            if (action.damage != null)
            {
                CheckActionDamageOptions(monster, db, action.damage, action);
            }

            if (action.dc != null)
            {
                AddActionDC(monster, db, action.dc, action);
            }
        }

        internal void AddActionUsage(MonsterModel monster, InitiativeTrackerDB db, MonsterUsageModel usage, MonsterActionModel action)
        {
            Usage usage1 = new Usage()
            {
                Type = usage.type,
                Times = usage.times,
                Dice = usage.dice,
                MinDiceValue = usage.min_value,
                ActionName = action.name,
                ActionMonsterName = monster.name
            };

            try
            {
                db.Usages.Add(usage1);
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
                    if (entry.Entity is Usage)
                    {
                        // Handle the specific entity that caused the exception
                        Usage entity = (Usage)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Type} of Action {action.name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }

        internal void CheckActionDamageOptions(MonsterModel monster, InitiativeTrackerDB db, List<MonsterDamageModel> damages, MonsterActionModel action)
        {
            foreach (var damage in damages)
            {
                if (damage.from != null)
                {
                    foreach(var option in damage.from.options)
                    {
                        AddActionOptionDamage(monster, db, option, action);
                    }
                    
                }

                else
                {
                    AddActionDamage(monster, db, damage, action);
                }

                if(damage.dc != null)
                {
                    AddActionDC(monster, db, damage.dc, action);
                }
            }


        }
        internal void AddActionDamage(MonsterModel monster, InitiativeTrackerDB db, MonsterDamageModel damage, MonsterActionModel action)
        {
            Damage damage1 = new Damage()
            {
                Damage_Dice = damage.damage_dice,
                ActionName = action.name,
                ActionMonsterName = monster.name,
                IsOption = false
            };
            if (damage.damage_type != null)
            {
                damage1.Damage_Type = damage.damage_type.name;
            }

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
                        Console.WriteLine($"Failed to save entity {entity.Damage_Type} of Action {action.name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }

        internal void AddActionOptionDamage(MonsterModel monster, InitiativeTrackerDB db, MonsterOptionModel damage, MonsterActionModel action)
        {
            Damage damage1 = new Damage()
            {
                Damage_Dice = damage.damage_dice,
                ActionName = action.name,
                ActionMonsterName = monster.name,
                IsOption = true
            };
            if (damage.damage_type != null)
            {
                damage1.Damage_Type = damage.damage_type.name;
            }

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
                        Console.WriteLine($"Failed to save entity {entity.Damage_Type} of Action {action.name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }

        internal void AddActionDC(MonsterModel monster, InitiativeTrackerDB db, MonsterDcModel dc, MonsterActionModel action)
        {
            DifficultyClass difficultyClass = new DifficultyClass()
            {
                DC_Type = dc.dc_type.name,
                DC_Value = (short)dc.dc_value,
                ActionName = action.name,
                ActionMonsterName = monster.name
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
                        Console.WriteLine($"Failed to save entity {entity.DC_Type} of Action {action.name} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }
    }
}
