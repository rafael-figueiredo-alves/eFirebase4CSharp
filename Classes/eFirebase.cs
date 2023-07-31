using eFirebase4CSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eFirebase4CSharp.Classes
{
    public class eFirebase : IeFirebase
    {
        public string GetVersion()
        {
            return "0.0.1";
        }

        private HttpClient _httpClient;
        public eFirebase(HttpClient client)
        {
            _httpClient = client;
        }

        public IeFirebaseAuth Auth(HttpClient _client, string API_Key)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealTimeDB RealTimeDB(HttpClient _client, string ProjectCode)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseStorage Storage(HttpClient _client, string ProjectCode)
        {
            throw new NotImplementedException();
        }
    }
}
