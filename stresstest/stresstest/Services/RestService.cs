﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace stresstest.Services
{
    public class RestService: IRestService
    {
        private HttpClient client;

        private RestService()
        {
            client = new HttpClient();
        }
        private static RestService _instance;
        private static readonly object _lock = new object();


        public static RestService GetInstance()
        {
         
            if (_instance == null)
            {
                
                lock (_lock)
                {
                   
                    if (_instance == null)
                    {
                        _instance = new RestService();
                    }
                }
            }
            return _instance;
        }

        public async Task<string> GetItemAsync(string str)
        {
            Uri uri = new Uri("http://192.168.1.112:3000/" + str);
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                return await Task.FromResult(content);
            }
            Console.WriteLine(response.IsSuccessStatusCode);

            return null;
        }
    }
}
