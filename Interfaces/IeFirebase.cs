using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFirebase4CSharp.Interfaces
{
    public interface IeFirebase
    {
        public string GetVersion();
        public IeFirebaseAuth Auth(HttpClient _client, string API_Key);
        public IeFirebaseRealTimeDB RealTimeDB(HttpClient _client, string ProjectCode);
        public IeFirebaseStorage Storage(HttpClient _client, string ProjectCode);
    }
}
