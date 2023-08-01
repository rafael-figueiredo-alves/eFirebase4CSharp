using eFirebase4CSharp.Interfaces;

namespace eFirebase4CSharp.Classes
{
    public class eFirebase : IeFirebase
    {
        private HttpClient _httpClient;
        public eFirebase(HttpClient client)
        {
            _httpClient = client;
        }

        public IeFirebaseAuth Auth(string API_Key)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealTimeDB RealTimeDB(string ProjectCode)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseStorage Storage(string ProjectCode)
        {
            throw new NotImplementedException();
        }

        public string GetVersion()
        {
            return "0.0.1";
        }
    }
}
