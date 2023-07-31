using eFirebase4CSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eFirebase4CSharp.Classes
{
    public class eFirebaseAuth : IeFirebaseAuth
    {
        private HttpClient _httpClient;
        public eFirebaseAuth(HttpClient Client) 
        {
            _httpClient = Client;
        }
        public async Task<T> TesteInicial<T>(string Token)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", Token);
            string JsonStr = await _httpClient.GetStringAsync(new Uri("https://etasks-d6988.firebaseio.com/etasks/v1/version.json"));
            return JsonSerializer.Deserialize<T>(JsonStr)!;
        }
    }
}
