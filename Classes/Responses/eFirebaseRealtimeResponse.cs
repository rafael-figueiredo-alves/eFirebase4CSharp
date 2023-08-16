using eFirebase4CSharp.Interfaces.Responses;
using System.Globalization;
using System.Text.Encodings.Web;
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
            JsonArray resultArray = new JsonArray();
            
            if(!string.IsNullOrEmpty(fContent))
            {
                JsonObject? js = AsJSONObj();

                if(js != null)
                {
                    foreach(var item in js)
                    {
                        JsonObject registro = new JsonObject();
                        registro.Add("id", item.Key);
                        var Valor = JsonSerializer.Deserialize<JsonObject>((JsonObject)item.Value!, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(new TextEncoderSettings(System.Text.Unicode.UnicodeRanges.All)) });
                        foreach (var subitem in Valor!)
                        {
                            if(subitem.Value is JsonObject)
                            {
                                registro.Add(subitem.Key, JsonSerializer.Deserialize<JsonObject>((JsonObject)subitem.Value));
                            }
                            else if(subitem.Value is JsonArray) 
                            {
                                registro.Add(subitem.Key, JsonSerializer.Deserialize<JsonArray>((JsonArray)subitem.Value));
                            }
                            else if(bool.TryParse(subitem.Value!.ToJsonString(), out var val))
                            {
                                registro.Add(subitem.Key, val);
                            }
                            else if(int.TryParse(subitem.Value!.ToJsonString(), out var valint))
                            {
                                registro.Add(subitem.Key, valint);
                            }
                            else if(double.TryParse(subitem.Value!.ToJsonString().Replace(".", ","), out var valdouble))
                            {
                                registro.Add(subitem.Key, valdouble);
                            }
                            else
                            {
                                registro.Add(subitem.Key, subitem.Value!.ToString().Replace("\"", "").Replace("\u0022", "\""));
                            }
                        }
                        resultArray!.Add(registro);
                    }
                }
            }

            return resultArray;
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
