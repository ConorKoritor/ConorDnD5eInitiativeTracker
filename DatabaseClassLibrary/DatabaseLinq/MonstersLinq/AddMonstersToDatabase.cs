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
    internal class AddMonstersToDatabase
    {
        internal void AddMonster(MonsterModel monster, InitiativeTrackerDB db)
        {
            double initiativeModifierSetup = (monster.dexterity - 10) / 2;

            Monster monster1 = new Monster
            {
                Name = monster.name,
                HP = monster.hit_points,
                Initiative_Modifier = (short)Math.Floor(initiativeModifierSetup),
                Size = monster.size,
                Type = monster.type,
                Hit_Dice = monster.hit_dice,
                Hit_Points_Roll = monster.hit_points_roll,
                Alignment = monster.alignment,
                Languages = monster.languages,
                Challenge_Rating = monster.challenge_rating,
                XP = monster.xp,
                Damage_Vulnerabilities = String.Join(",", monster.damage_vulnerabilities),
                Damage_Resistances = String.Join(",", monster.damage_resistances),
                Damage_Immunities = String.Join(",", monster.damage_immunities),
                Image = monster.image
            };

            foreach (var ability in monster.special_abilities)
            {
                if (ability.spellcasting != null)
                {
                    monster1.IsSpellcaster = true;
                }
            }

            try
            {
                db.Monsters.Add(monster1);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: " + validationError.PropertyName + "For Monster: " + monster.name + " Error: " + validationError.ErrorMessage);
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
                    if (entry.Entity is Monster)
                    {
                        // Handle the specific entity that caused the exception
                        Monster entity = (Monster)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        Console.WriteLine($"Failed to save entity {entity.Name}: {ex.Message}");
                    }
                }

            }
        }
    }
}
