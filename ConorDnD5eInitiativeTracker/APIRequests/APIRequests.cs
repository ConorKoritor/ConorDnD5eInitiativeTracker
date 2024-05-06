using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
    //Pulls these down from API /monsters and saves them into the Monster Dictionary Models in /APIRequests/MonsterDictionaryModels class file
    public class MonsterDictionaryAPIRequests
    {
        private MonsterDictionaryResponseModel ResponseModel = new MonsterDictionaryResponseModel();

        public async Task PullMonsterListFromAPI()
        {
            using (HttpResponseMessage response = await InitializeAPI.ApiClient.GetAsync("monsters"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string JSONResponse = await response.Content.ReadAsStringAsync();

                    ResponseModel = JsonConvert.DeserializeObject<MonsterDictionaryResponseModel>(JSONResponse);

                }
            }
        }

       

        public List<MonsterDictionaryModel> GetMonstersAPILinks()
        {
            return ResponseModel.results;
        }
    }

    //Makes requests for Specific monsters when called
    public class MonsterAPIRequests
    {

        public MonsterAPIRequests()
        {
            
        }

    }

    
    public class SpellsAPIRequests
    {
        private SpellDictionaryResponseModel ResponseModel = new SpellDictionaryResponseModel();

        private List<SpellModel> SpellModels = new List<SpellModel>();

        public async Task PullSpellListFromAPI()
        {
            //Pulls down dictionary of Spells from the API and saves them
            //Pulls these down from API /spells and saves them into the Spell Dictionary Models in /APIRequests/SpellsDictionaryModels class file
            using (HttpResponseMessage response = await InitializeAPI.ApiClient.GetAsync("spells"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string JSONResponse = await response.Content.ReadAsStringAsync();

                    ResponseModel = JsonConvert.DeserializeObject<SpellDictionaryResponseModel>(JSONResponse);

                }
            }
        }

        public async Task PullSpellsFromAPI()
        {
            //Runs through each result in the Response Model and gets the url. This leads to /spells/{spellname} API.
            //This code then pulls down each spell and saves it using the Spell Model in /APIRequests/SpellModels code file.
            //Then saves them to a list that can later be exported
            foreach (var item in ResponseModel.results)
            {
                using (HttpResponseMessage response = await InitializeAPI.ApiClient.GetAsync(item.url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string JSONResponse = await response.Content.ReadAsStringAsync();

                        SpellModel sr;

                        sr = JsonConvert.DeserializeObject<SpellModel>(JSONResponse);

                        SpellModels.Add(sr);

                    }
                }
            }
        }

        public List<SpellDictionaryModel> GetSpellsAPILinks()
        {
            return ResponseModel.results;
        }

        public List<SpellModel> GetSpellsAPI()
        {
            return SpellModels;
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
