using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ConorDnD5eInitiativeTracker.APIRequests;
using ConorDnD5eInitiativeTracker.Databases;

namespace ConorDnD5eInitiativeTracker.DatabaseLinq.SpellsLinq
{
    public class AddSpellsToDatabase
    {

        List<SpellModel> spells = new List<SpellModel>();
        //SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
        InitiativeTrackerDBEntities db = new InitiativeTrackerDBEntities();

        /*public async Task ConnectToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(csb.ConnectionString))
            {
                conn.Open();

                await InsertToSpellsTable(conn);
            }
        }*/

        public async Task InsertToSpellsTable()
        {
            spells = await GetSpells();

            await LoopThroughSpellsAndSaveToDatabase();
        }

        public async Task LoopThroughSpellsAndSaveToDatabase()
        {
            foreach (var spellResult in spells)
            {

                AddSpell(spellResult);
                CheckSpellHealingOrDamage(spellResult);
            }

            try
            {
                MessageBox.Show("Trying to save database");
                await db.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
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
                    MessageBox.Show($"Inner Exception: {innerException}");
                }
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Spell)
                    {
                        // Handle the specific entity that caused the exception
                        Spell entity = (Spell)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        MessageBox.Show($"Failed to save entity {entity.Name}: {innerException}");
                    }
                    if (entry.Entity is SpellDamage)
                    {
                        // Handle the specific entity that caused the exception
                        SpellDamage entity = (SpellDamage)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        MessageBox.Show($"Failed to save Damage entity {entity.SpellName}: {innerException}");
                    }
                    if (entry.Entity is SpellDamageAtCharacterLevel)
                    {
                        // Handle the specific entity that caused the exception
                        SpellDamageAtCharacterLevel entity = (SpellDamageAtCharacterLevel)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        MessageBox.Show($"Failed to save Damage Character At Level entity {entity.SpellName}: {innerException}");
                    }
                    if (entry.Entity is SpellHealing)
                    {
                        // Handle the specific entity that caused the exception
                        SpellHealing entity = (SpellHealing)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        MessageBox.Show($"Failed to save Healing entity {entity.SpellName}: {innerException}");
                    }
                }

            }
        }

        internal void AddSpell(SpellModel spellResult)
        {
            Spell spell1 = new Spell
            {
                Name = spellResult.name,
                Description = String.Join(",", spellResult.desc),
                Range = spellResult.range,
                Components = String.Join(",", spellResult.components),
                IsRitual = spellResult.ritual,
                Duration = spellResult.duration,
                IsConcentration = spellResult.concentration,
                Casting_Time = spellResult.casting_time,
                Level = spellResult.level,
                School = spellResult.school.name,
                Higher_Level = String.Join(",", spellResult.higher_level),
                Material = String.Join(",", spellResult.components),
                DC_Type = null,
                DC_Success = null,
                Area_Of_Effect_Size = null,
                Area_Of_Effect_Type = null
            };

            if(spellResult.dc != null)
            {
                spell1.DC_Type = spellResult.dc.dc_type.name;
                spell1.DC_Success = spellResult.dc.dc_success;
            }
            if(spellResult.area_of_effect != null)
            {
                spell1.Area_Of_Effect_Type = spellResult.area_of_effect.type;
                spell1.Area_Of_Effect_Size = spellResult.area_of_effect.size;
            }

            try
            {
                db.Spells.Add(spell1);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
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
                    MessageBox.Show($"Inner Exception: {innerException.Message}");
                }
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Spell)
                    {
                        // Handle the specific entity that caused the exception
                        Spell entity = (Spell)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        MessageBox.Show($"Failed to save entity {entity.Name}: {ex.Message}");
                    }
                }

            }

        }

        internal void CheckSpellHealingOrDamage(SpellModel spellResult)
        {
            if (spellResult.damage != null)
            {
               if(spellResult.damage.damage_at_slot_level != null)
                {
                    AddSpellDamageAtSlotLevelLevel(spellResult);
                }

               if(spellResult.damage.damage_at_character_level != null)
                {
                    AddSpellDamageAtCharacterLevel(spellResult);
                }
            }

            if (spellResult.heal_at_slot_level != null)
            {
                AddSpellHealing(spellResult);
            }

            
        }

        internal void AddSpellDamageAtSlotLevelLevel(SpellModel spellResult)
        {
            SpellDamage spellDamage = new SpellDamage
            {
                Damage_Type = null,
                Damage_L1 = spellResult.damage.damage_at_slot_level._1,
                Damage_L2 = spellResult.damage.damage_at_slot_level._2,
                Damage_L3 = spellResult.damage.damage_at_slot_level._3,
                Damage_L4 = spellResult.damage.damage_at_slot_level._4,
                Damage_L5 = spellResult.damage.damage_at_slot_level._5,
                Damage_L6 = spellResult.damage.damage_at_slot_level._6,
                Damage_L7 = spellResult.damage.damage_at_slot_level._7,
                Damage_L8 = spellResult.damage.damage_at_slot_level._8,
                Damage_L9 = spellResult.damage.damage_at_slot_level._9,
                SpellName = spellResult.name
            };

            if(spellResult.damage.damage_type != null)
            {
                spellDamage.Damage_Type = spellResult.damage.damage_type.name;
            }
            try
            {
                db.SpellDamages.Add(spellDamage);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
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
                    MessageBox.Show($"Inner Exception: {innerException.Message}");
                }
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is SpellDamage)
                    {
                        // Handle the specific entity that caused the exception
                        SpellDamage entity = (SpellDamage)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        MessageBox.Show($"Failed to save Damage entity {entity.SpellName}: {ex.Message}");
                    }
                }

            }
        }

        internal void AddSpellDamageAtCharacterLevel(SpellModel spellResult)
        {
            SpellDamageAtCharacterLevel spellDamage = new SpellDamageAtCharacterLevel
            {
                Damage_Type = null,
                Damage_L1 = spellResult.damage.damage_at_character_level._1,
                Damage_L2 = spellResult.damage.damage_at_character_level._2,
                Damage_L3 = spellResult.damage.damage_at_character_level._3,
                Damage_L4 = spellResult.damage.damage_at_character_level._4,
                Damage_L5 = spellResult.damage.damage_at_character_level._5,
                Damage_L6 = spellResult.damage.damage_at_character_level._6,
                Damage_L7 = spellResult.damage.damage_at_character_level._7,
                Damage_L8 = spellResult.damage.damage_at_character_level._8,
                Damage_L9 = spellResult.damage.damage_at_character_level._9,
                Damage_L10 = spellResult.damage.damage_at_character_level._10,
                Damage_L11 = spellResult.damage.damage_at_character_level._11,
                Damage_L12 = spellResult.damage.damage_at_character_level._12,
                Damage_L13 = spellResult.damage.damage_at_character_level._13,
                Damage_L14 = spellResult.damage.damage_at_character_level._14,
                Damage_L15 = spellResult.damage.damage_at_character_level._15,
                Damage_L16 = spellResult.damage.damage_at_character_level._16,
                Damage_L17 = spellResult.damage.damage_at_character_level._17,
                Damage_L18 = spellResult.damage.damage_at_character_level._18,
                Damage_L19 = spellResult.damage.damage_at_character_level._19,
                Damage_L20 = spellResult.damage.damage_at_character_level._20,
                SpellName = spellResult.name
            };
            if (spellResult.damage.damage_type != null)
            {
                spellDamage.Damage_Type = spellResult.damage.damage_type.name;
            }
            try
            {
                db.SpellDamageAtCharacterLevels.Add(spellDamage);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
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
                    MessageBox.Show($"Inner Exception: {innerException.Message}");
                }
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is SpellDamage)
                    {
                        // Handle the specific entity that caused the exception
                        SpellDamage entity = (SpellDamage)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        MessageBox.Show($"Failed to save Damage entity {entity.SpellName}: {ex.Message}");
                    }
                }

            }
        }
        internal void AddSpellHealing(SpellModel spellResult)
        {
            SpellHealing spellHealing = new SpellHealing
            {
                Healing_L1 = spellResult.heal_at_slot_level._1,
                Healing_L2 = spellResult.heal_at_slot_level._2,
                Healing_L3 = spellResult.heal_at_slot_level._3,
                Healing_L4 = spellResult.heal_at_slot_level._4,
                Healing_L5 = spellResult.heal_at_slot_level._5,
                Healing_L6 = spellResult.heal_at_slot_level._6,
                Healing_L7 = spellResult.heal_at_slot_level._7,
                Healing_L8 = spellResult.heal_at_slot_level._8,
                Healing_L9 = spellResult.heal_at_slot_level._9,
                SpellName = spellResult.name
            };
            try
            {
                db.SpellHealings.Add(spellHealing);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
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
                    MessageBox.Show($"Inner Exception: {innerException.Message}");
                }
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is SpellHealing)
                    {
                        // Handle the specific entity that caused the exception
                        SpellHealing entity = (SpellHealing)entry.Entity;
                        // Log or handle the failed entity (e.g., display an error message)
                        MessageBox.Show($"Failed to save Healing entity {entity.SpellName}: {ex.Message}");
                    }
                }

            }
        }

        public async Task<List<SpellModel>> GetSpells()
        {
            SpellsAPIRequests spellsDictionaryAPI = new SpellsAPIRequests();

            await spellsDictionaryAPI.PullSpellListFromAPI();

            await spellsDictionaryAPI.PullSpellsFromAPI();

            return spellsDictionaryAPI.GetSpellsAPI();
        }
    }
}
 