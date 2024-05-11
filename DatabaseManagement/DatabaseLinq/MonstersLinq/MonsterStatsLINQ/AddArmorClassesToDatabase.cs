using DatabaseModel.APIRequests;
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
    internal class AddArmorClassesToDatabase
    {
        internal void AddArmorClasses(MonsterModel monster, InitiativeTrackerDB db)
        {
            if (monster.armor_class != null)
            {
                foreach (var ac in monster.armor_class)
                {
                    AddEachArmorClassToDatabase(ac, db, monster);
                }
            }

        }
        internal void AddEachArmorClassToDatabase(MonsterArmorClassModel ac, InitiativeTrackerDB db, MonsterModel monster)
        {
            ArmorClass armorClass = new ArmorClass
            {
                AC = (short)ac.value,
                Ac_Type = ac.type,
                MonsterName = monster.name
            };
            try
            {
                db.ArmorClasses.Add(armorClass);
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
                    if (entry.Entity is ArmorClass)
                    {
                        // Handle the specific entity that caused the exception
                        ArmorClass entity = (ArmorClass)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Ac_Type} of Monster {monster.name}: {ex.Message}");
                    }
                }

            }
        }
    }
}
