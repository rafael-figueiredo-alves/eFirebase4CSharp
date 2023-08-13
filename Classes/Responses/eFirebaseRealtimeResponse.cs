using eFirebase4CSharp.Interfaces.Responses;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace eFirebase4CSharp.Classes.Responses
{
    public class eFirebaseRealtimeResponse : IeFirebaseRealtimeResponse
    {
        #region Variables and Constants
        private int fStatusCode { get; set; }
        private string? fETag { get; set; }
        private string fContent { get; set; }
        #endregion

        public eFirebaseRealtimeResponse(string _content, int _statusCode, string? ETag)
        {
            fContent = _content;
            fStatusCode = _statusCode;
            fETag = ETag;
        }

        public IEnumerable<T>? AsEnumerable<T>()
        {
            JsonArray? array = AsJSONArray();
            string? SArray = array?.ToString();
            return JsonSerializer.Deserialize<IEnumerable<T>>(SArray!);
        }

        public JsonArray? AsJSONArray()
        {
            throw new NotImplementedException();
        }

        public JsonObject? AsJSONObj()
        {
            return JsonSerializer.Deserialize<JsonObject>(fContent);
        }

        public string? AsJSONstr()
        {
            return fContent;
        }

        public T? AsObject<T>()
        {
            return JsonSerializer.Deserialize<T>(fContent);
        }

        public string? ETag()
        {
            return fETag;
        }

        public int? StatusCode()
        {
            return fStatusCode;
        }
    }
}
