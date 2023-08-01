using eFirebase4CSharp.Interfaces;
using eFirebase4CSharp.Interfaces.Responses;

namespace eFirebase4CSharp.Classes
{
    internal class eFirebaseStorage : IeFirebaseStorage
    {
        public IeFirebaseStorage FileName(string? value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseStorage Folder(string? path = null)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseStorageResponse> SendAsync(string? AuthToken = null)
        {
            throw new NotImplementedException();
        }
    }
}
