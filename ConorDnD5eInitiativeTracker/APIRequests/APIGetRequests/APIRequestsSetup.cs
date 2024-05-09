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
    
}
