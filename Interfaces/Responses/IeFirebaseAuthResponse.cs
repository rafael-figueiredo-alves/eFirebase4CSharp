using eFirebase4CSharp.Types;

namespace eFirebase4CSharp.Interfaces.Responses
{
    public interface IeFirebaseAuthResponse
    {
        public string? UID();
        public string? Token();
        public string? RefreshToken();
        public int? ExpiresIn();
        public bool? Registered();
        public enumAuthErrors Erro();
        public int? StatusCode();
        public string? DisplayName();
        public string? Email();
        public bool? EmailVerified();
        public string? PhotoUrl();
        public string? LastLoginAt();
        public string? CreatedAt();
    }
}
