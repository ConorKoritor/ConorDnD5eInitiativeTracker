using DatabaseClassLibrary.APIRequests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClassLibrary.APIRequests
{
    public class MonsterAPIRequests
    {

        private MonsterDictionaryResponseModel ResponseModel = new MonsterDictionaryResponseModel();

        private List<MonsterModel> MonsterModels = new List<MonsterModel>();

        public async Task PullMonsterListFromAPI()
        {
            //Pulls down dictionary of Monsters from the API and saves them
            //Pulls these down from API /monsters and saves them into the Spell Dictionary Models in /APIRequests/MonsterDictionaryModels class file
            using (HttpResponseMessage response = await InitializeAPI.ApiClient.GetAsync("monsters"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string JSONResponse = await response.Content.ReadAsStringAsync();

                    ResponseModel = JsonConvert.DeserializeObject<MonsterDictionaryResponseModel>(JSONResponse);

                }
            }
        }

        public async Task PullMonstersFromAPI()
        {
            //Runs through each result in the Response Model and gets the url. This leads to /monsters/{monstername} API.
            //This code then pulls down each spell and saves it using the Spell Model in /APIRequests/MonsterModels code file.
            //Then saves them to a list that can later be exported
            foreach (var item in ResponseModel.results)
            {
                using (HttpResponseMessage response = await InitializeAPI.ApiClient.GetAsync(item.url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string JSONResponse = await response.Content.ReadAsStringAsync();

                        MonsterModel mm;

                        mm = JsonConvert.DeserializeObject<MonsterModel>(JSONResponse);

                        MonsterModels.Add(mm);

                    }
                }
            }
        }

        public List<MonsterDictionaryModel> GetMonstersAPILinks()
        {
            return ResponseModel.results;
        }

        public List<MonsterModel> GetMonstersAPI()
        {
            return MonsterModels;
        }
    }
}
