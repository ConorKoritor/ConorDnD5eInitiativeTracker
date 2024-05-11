using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.APIRequests
{
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
}
