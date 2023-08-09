using eFirebase4CSharp.Interfaces.Responses;

namespace eFirebase4CSharp.Interfaces
{
    public interface IeFirebaseStorage
    {
        public IeFirebaseStorage Folder(string path);
        public IeFirebaseStorage FileName(string value);

        public IeFirebaseStorage Content(Stream value);
        public Task<IeFirebaseStorageResponse> SendAsync(string? AuthToken = null);
    }
}
