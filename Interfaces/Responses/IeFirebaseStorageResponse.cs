namespace eFirebase4CSharp.Interfaces.Responses
{
    public interface IeFirebaseStorageResponse
    {
        public string? Link();
        public int? StatusCode();
        public string? ErrorMessage();
    }
}
