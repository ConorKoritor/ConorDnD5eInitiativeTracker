using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConorDnD5eInitiativeTracker.APIRequests;
using ConorDnD5eInitiativeTracker.Databases;

namespace ConorDnD5eInitiativeTracker.DatabaseLinq.SpellsLinq
{
    internal class AddSpellsToDatabase
    {

        List<SpellModel> spells = new List<SpellModel>();
        InitiativeTrackerDBContainer db = new InitiativeTrackerDBContainer();

        internal async Task InsertToSpellsTable()
        {
            spells = await GetSpells();

            foreach (var spellResult in spells)
            {
                AddSpell(spellResult);
                CheckSpellHealingOrDamage(spellResult);
                if(spellResult.damage != null)
                {
                    
                }

                if(spellResult.heal_at_slot_level != null)
                {

                }

                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    throw new Exception();
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

            db.Spells.Add(spell1);
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

            };    
        }

        internal void AddSpellDamageAtSlotLevelLevel(SpellModel spellResult)
        {
            SpellDamage spellDamage = new SpellDamage
            {
                AddSpellDamageAtCharacterLevel
            };
        }
        internal void AddSpellHealing(SpellModel spellResult)
        {

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
 