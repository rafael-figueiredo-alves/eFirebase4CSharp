using eFirebase4CSharp.Interfaces.Responses;

namespace eFirebase4CSharp.Interfaces
{
    public interface IeFirebaseAuth
    {
        public Task<IeFirebaseAuthResponse> SignUpWithEmailPasswordAsync(string Email, string Password);
        public Task<IeFirebaseAuthResponse> SignInWithEmailPasswordAsync(string Email, string Password);
        public Task<IeFirebaseAuthResponse> ExchangeRefreshToken4idTokenAsync(string RefreshToken);
        public Task<IeFirebaseAuthResponse> SendPasswordResetEmailAsync(string Email);
        public Task<IeFirebaseAuthResponse> VerifyPasswordResetCodeAsync(string oobCode);
        public Task<IeFirebaseAuthResponse> ConfirmPasswordResetAsync(string oobCode, string newPassword);
        public Task<IeFirebaseAuthResponse> SendEmailVerificationAsync(string Token);
        public Task<IeFirebaseAuthResponse> ConfirmEmailVerificationAsync(string oobCode);
        public Task<IeFirebaseAuthResponse> DeleteAccountAsync(string Token);
        public Task<IeFirebaseAuthResponse> GetProfileAsync(string Token);
        public Task<IeFirebaseAuthResponse> ChangePasswordAsync(string Token, string newPassword);
        public Task<IeFirebaseAuthResponse> ChangeProfileAsync(string Token, string DisplayName, string PhotoURL);
    }
}
