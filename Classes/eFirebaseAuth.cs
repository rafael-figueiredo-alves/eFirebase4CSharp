using eFirebase4CSharp.Interfaces;

namespace eFirebase4CSharp.Classes
{
    public class eFirebaseAuth : IeFirebaseAuth
    {
        private HttpClient _httpClient;
        public eFirebaseAuth(HttpClient Client) 
        {
            _httpClient = Client;
        }

    }
}
