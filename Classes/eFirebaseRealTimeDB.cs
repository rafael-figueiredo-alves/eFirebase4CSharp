using eFirebase4CSharp.Interfaces;
using eFirebase4CSharp.Interfaces.Responses;
using eFirebase4CSharp.Types;

namespace eFirebase4CSharp.Classes
{
    public class eFirebaseRealTimeDB : IeFirebaseRealTimeDB, IeFirebaseRealtimeFilters
    {
        public IeFirebaseRealTimeDB AccessToken(string? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealTimeDB Collection(string? Collection = null)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> CreateRegister<T>(T Body)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> DeleteRegister(string? Id = null, string? ETag = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters EndAt(string? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters EndAt(int? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealTimeDB Endpoint(string? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters EqualTo(string? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters EqualTo(int? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters LimitToFirst(int? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters LimitToLast(int? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters OrderBy(eFirebaseOrderByKind? Kind = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters OrderBy(string? Fields = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters Read()
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> ReadWithoutFiltersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> SearchAsync()
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters StartAt(string? Value = null)
        {
            throw new NotImplementedException();
        }

        public IeFirebaseRealtimeFilters StartAt(int? Value = null)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> UpdateRegister<T>(T Body)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseRealtimeResponse> WriteRegister<T>(T Body, string? ETag = null)
        {
            throw new NotImplementedException();
        }
    }
}
