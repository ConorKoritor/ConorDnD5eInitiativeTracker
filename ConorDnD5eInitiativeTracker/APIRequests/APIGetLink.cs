using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorDnD5eInitiativeTracker.APIRequests
{
    //Sets Interface for getting the API so with dependency Injection we can run Moq tests
    public interface IAPILink
    {
        string GetAPILink();
    }

    //Interface Implementation for real Monsters API Link
    public class MonsterApiLink : IAPILink
    {
        string IAPILink.GetAPILink()
        {
            return "https://www.dnd5eapi.co/api/monsters";
        }
    }

    //Interface Implementation for real Spells API Link
    public class SpellApiLink : IAPILink
    {
        string IAPILink.GetAPILink()
        {
            return "https://www.dnd5eapi.co/api/spells";
        }
    }

    //Interface Implementation for real Conditions API Link
    public class ConditionsApiLink : IAPILink
    {
        string IAPILink.GetAPILink()
        {
            return "https://www.dnd5eapi.co/api/conditions";
        }
    }
}
