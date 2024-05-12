using DatabaseLibrary.APIRequests;
using DatabaseLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary.DatabaseLinq.SpellsLinq
{
    internal class CheckHealingOrDamage
    {

        AddSpellDamage spellDamage = new AddSpellDamage();
        AddSpellHealingStats healingStats = new AddSpellHealingStats();
        internal void CheckSpellHealingOrDamage(SpellModel spellResult, InitiativeTrackerDB db)
        {
            if (spellResult.damage != null)
            {
                if (spellResult.damage.damage_at_slot_level != null)
                {
                    spellDamage.AddSpellDamageAtSlotLevelLevel(spellResult, db);
                }

                if (spellResult.damage.damage_at_character_level != null)
                {
                    spellDamage.AddSpellDamageAtCharacterLevel(spellResult, db);
                }
            }

            if (spellResult.heal_at_slot_level != null)
            {
                healingStats.AddSpellHealing(spellResult, db);
            }


        }
    }
}
