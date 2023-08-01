using eFirebase4CSharp.Interfaces.Responses;

namespace eFirebase4CSharp.Interfaces
{
    public interface IeFirebaseRealTimeDB
    {
        public IeFirebaseRealTimeDB AccessToken(string? Value = null);
        public IeFirebaseRealTimeDB Endpoint(string? Value = null);
        public IeFirebaseRealTimeDB Collection(string? Collection = null);
        public IeFirebaseRealtimeFilters Read();
        public Task<IeFirebaseRealtimeResponse> ReadWithoutFiltersAsync();
        public Task<IeFirebaseRealtimeResponse> CreateRegister<T>(T Body);
        public Task<IeFirebaseRealtimeResponse> UpdateRegister<T>(T Body);
        public Task<IeFirebaseRealtimeResponse> WriteRegister<T>(T Body, string? ETag = null);
        public Task<IeFirebaseRealtimeResponse> DeleteRegister(string? Id = null, string? ETag = null);
    }
}
