using eFirebase4CSharp.Interfaces.Responses;
using System.Text.Json.Nodes;

namespace eFirebase4CSharp.Classes.Responses
{
    public class eFirebaseRealtimeResponse : IeFirebaseRealtimeResponse
    {
        public IEnumerable<T> AsEnumerable<T>()
        {
            throw new NotImplementedException();
        }

        public JsonArray AsJSONArray()
        {
            throw new NotImplementedException();
        }

        public JsonObject AsJSONObj()
        {
            throw new NotImplementedException();
        }

        public string AsJSONstr()
        {
            throw new NotImplementedException();
        }

        public T AsObject<T>()
        {
            throw new NotImplementedException();
        }

        public string? ETag()
        {
            throw new NotImplementedException();
        }

        public int? StatusCode()
        {
            throw new NotImplementedException();
        }
    }
}
