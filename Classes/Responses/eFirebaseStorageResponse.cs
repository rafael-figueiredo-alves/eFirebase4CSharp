using eFirebase4CSharp.Interfaces.Responses;
using System.Text.Json;

namespace eFirebase4CSharp.Classes.Responses
{
    public class eFirebaseStorageResponse : IeFirebaseStorageResponse
    {
        private int ResponseStatusCode { get; set; }
        private string? fErrorMessage { get; set; } = null;
        private string? fLink { get; set; } = null;
        public eFirebaseStorageResponse(string _content, string url, int _statusCode) 
        {
            string ResponseContent = _content;
            ResponseStatusCode = _statusCode;

            if(ResponseStatusCode != 200)
            {
                fErrorMessage = ResponseContent;
            }
            else
            {
                storageResponse? Resp = JsonSerializer.Deserialize<storageResponse>(ResponseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if(Resp != null)
                {
                    fLink = url + "?alt=media&token=" + Resp.downloadTokens;
                }
            }
        }
        public string? Link()
        {
            return fLink;
        }

        public int? StatusCode()
        {
            return ResponseStatusCode;
        }

        public string? ErrorMessage()
        {
            return fErrorMessage;
        }
    }

    public class storageResponse
    {
        public string? name { get; set; }
        public string? bucket { get; set; }
        public string? generation { get; set; }
        public string? metageneration { get; set; }
        public string? contentType { get; set; }
        public string? timeCreated { get; set; }
        public string? updated { get; set; }
        public string? storageClass { get; set; }
        public string? size { get; set; }
        public string? md5Hash { get; set; }
        public string? contentEncoding { get; set; }
        public string? contentDisposition { get; set; }
        public string? crc32c { get; set; }
        public string? etag { get; }
        public string? downloadTokens { get; set; }
    }
}
