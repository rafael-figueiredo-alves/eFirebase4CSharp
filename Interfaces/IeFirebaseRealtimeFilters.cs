using eFirebase4CSharp.Interfaces.Responses;
using eFirebase4CSharp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFirebase4CSharp.Interfaces
{
    public interface IeFirebaseRealtimeFilters
    {
        public IeFirebaseRealtimeFilters OrderBy(eFirebaseOrderByKind? Kind = null);
        public IeFirebaseRealtimeFilters OrderBy(string? Fields = null);
        public IeFirebaseRealtimeFilters StartAt(string? Value = null);
        public IeFirebaseRealtimeFilters StartAt(int? Value = null);
        public IeFirebaseRealtimeFilters EndAt(string? Value = null);
        public IeFirebaseRealtimeFilters EndAt(int? Value = null);
        public IeFirebaseRealtimeFilters EqualTo(string? Value = null);
        public IeFirebaseRealtimeFilters EqualTo(int? Value = null);
        public IeFirebaseRealtimeFilters LimitToFirst(int? Value = null);
        public IeFirebaseRealtimeFilters LimitToLast(int? Value = null);
        public Task<IeFirebaseRealtimeResponse> SearchAsync();
    }
}
