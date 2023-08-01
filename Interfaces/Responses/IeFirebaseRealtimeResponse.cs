using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eFirebase4CSharp.Interfaces.Responses
{
    public interface IeFirebaseRealtimeResponse
    {
        public int? StatusCode();
        public string? ETag();
        public string AsJSONstr();
        public JsonObject AsJSONObj();
        public JsonArray AsJSONArray();
        public T AsObject<T>();
        public IEnumerable<T> AsEnumerable<T>();
    }
}
