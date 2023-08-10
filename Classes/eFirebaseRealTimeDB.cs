using eFirebase4CSharp.Interfaces;
using eFirebase4CSharp.Interfaces.Responses;
using eFirebase4CSharp.Types;
using System.ComponentModel.DataAnnotations;

namespace eFirebase4CSharp.Classes
{
    public class eFirebaseRealTimeDB : IeFirebaseRealTimeDB, IeFirebaseRealtimeFilters
    {
        const string Url_base = ".firebaseio.com/";

        private HttpClient _httpClient;
        //private string ProjectCode;
        private string fUrl = string.Empty;
        private string fToken =  string.Empty;
        private string fCollection =  string.Empty;
        private string fEndpoint =  string.Empty;
        private string fOrderBy =  string.Empty;
        private string fstartAt =  string.Empty;
        private string fendAt =  string.Empty;
        private string fequalTo =  string.Empty;
        private string flimitToFirst =  string.Empty;
        private string flimittoLast =  string.Empty;

        public eFirebaseRealTimeDB(HttpClient httpClient, string projectCode)
        {
            _httpClient = httpClient;

            fUrl = "https://" + projectCode + Url_base;
        }

        public IeFirebaseRealTimeDB AccessToken(string? Value = null)
        {
            if(!string.IsNullOrEmpty(Value))
            {
                fToken = "auth=" + Value;
            }
            return this;
        }

        public IeFirebaseRealTimeDB Collection(string? Collection = null)
        {
            if (!string.IsNullOrEmpty(Collection))
            {
                fCollection = Collection;
                fCollection = fCollection.Replace("/", "");
                fCollection = fCollection.Replace(@"\", "");
            }
            return this;
        }

        public Task<IeFirebaseRealtimeResponse> CreateRegister<T>(T Body)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> DeleteRegister(string? Id = null, string? ETag = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters EndAt(string? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters EndAt(int? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealTimeDB Endpoint(string? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters EqualTo(string? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters EqualTo(int? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters LimitToFirst(int? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters LimitToLast(int? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters OrderBy(eFirebaseOrderByKind? Kind = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters OrderBy(string? Fields = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters Read()
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> ReadWithoutFiltersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> SearchAsync()
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters StartAt(string? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters StartAt(int? Value = null)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> UpdateRegister<T>(T Body)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> WriteRegister<T>(T Body, string? ETag = null)
        {
            throw new NotImplementedException();
        }
    }
}
