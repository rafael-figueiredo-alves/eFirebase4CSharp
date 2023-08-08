using eFirebase4CSharp.Interfaces.Responses;

namespace eFirebase4CSharp.Classes.Responses
{
    public class eFirebaseStorageResponse : IeFirebaseStorageResponse
    {
        private int ResponseStatusCode { get; set; }
        public eFirebaseStorageResponse(string _content, int _statusCode) 
        {
            string ResponseContent = _content;
            ResponseStatusCode = _statusCode;

            //GetValuesFromJSON(ResponseContent);
        }
        public string? Link()
        {
            throw new NotImplementedException();
        }

        public int? StatusCode()
        {
            throw new NotImplementedException();
        }
    }
}
