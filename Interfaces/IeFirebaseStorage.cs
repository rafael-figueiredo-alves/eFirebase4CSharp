using eFirebase4CSharp.Interfaces.Responses;

namespace eFirebase4CSharp.Interfaces
{
    public interface IeFirebaseStorage
    {
        public IeFirebaseStorage Folder(string? path = null);
        public IeFirebaseStorage FileName(string? value = null);
        public Task<IeFirebaseStorageResponse> SendAsync(string? AuthToken = null);
    }
}
