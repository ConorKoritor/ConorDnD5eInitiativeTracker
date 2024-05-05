using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace ConorDnD5eInitiativeTracker.APIRequests
{
    //Sets up Api Client
    public static class InitializeAPI
    {
        public static HttpClient ApiClient { get; set; }


        public static void InitializeClient()
        {
            //Setting up Api client to accept JSON.
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("http://www.dnd5eapi.co/api/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
    //Pulls down dictionary of Monsters from the API and saves them
    public class MonsterDictionaryAPIRequests
    {

        private  List<MonsterDictionaryModel> monsterAPILinks = new List<MonsterDictionaryModel>();

        public async Task PullMonsterListFromAPI()
        {
            using (HttpResponseMessage response = await InitializeAPI.ApiClient.GetAsync("monsters"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string JSONResponse = await response.Content.ReadAsStringAsync();

                    monsterAPILinks = JsonConvert.DeserializeObject<List<MonsterDictionaryModel>>(JSONResponse);
                }
            }
        }

        public List<MonsterDictionaryModel> GetMonstersAPILinks()
        {
            return monsterAPILinks;
        }
    }

    //Makes requests for Specific monsters when called
    public class MonsterAPIRequests
    {

        public MonsterAPIRequests()
        {
            
        }

    }

    //Pulls down dictionary of Spells from the API and saves them
    public class SpellsDictionaryAPIRequests
    {
        private readonly List<string> spellsAPILinks = new List<string>();

        public SpellsDictionaryAPIRequests()
        {
        }
        public List<string> GetSpellsAPILinks()
        {
            return spellsAPILinks;
        }

    }

    //Makes requests for Specific spells when called
    public class SpellsAPIRequests
    {

        public SpellsAPIRequests()
        {
        }
    }

    //Pulls down dictionary of Consitions from the API and saves them
    public class ConditionsDictionaryAPIRequests
    {

        
        private readonly List<string> conditionsAPILinks = new List<string>();

        public ConditionsDictionaryAPIRequests()
        {
        }

        public List<string> GetConditionsAPILinks()
        {
            return conditionsAPILinks;
        }
    }

    //Makes requests for Specific Conditions when called
    public class ConditionsAPIRequests
    {

        public ConditionsAPIRequests()
        {
            
        }
    }
}
