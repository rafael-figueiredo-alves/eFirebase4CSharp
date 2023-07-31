using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFirebase4CSharp.Interfaces
{
    public interface IeFirebaseAuth
    {
        public Task<IeFirebaseAuthResponse> SignUpWithEmailPassword(string Email, string Password);
        public Task<IeFirebaseAuthResponse> SignInWithEmailPassword(string Email, string Password);
        public Task<IeFirebaseAuthResponse> ExchangeRefreshToken4idToken(string RefreshToken);
        public Task<IeFirebaseAuthResponse> SendPasswordResetEmail(string Email);
        public Task<IeFirebaseAuthResponse> VerifyPasswordResetCode(string oobCode);
        public Task<IeFirebaseAuthResponse> ConfirmPasswordReset(string oobCode, string newPassword);
        public Task<IeFirebaseAuthResponse> SendEmailVerification(string Token);
        public Task<IeFirebaseAuthResponse> ConfirmEmailVerification(string oobCode);
        public Task<IeFirebaseAuthResponse> DeleteAccount(string Token);
        public Task<IeFirebaseAuthResponse> GetProfile(string Token);
        public Task<IeFirebaseAuthResponse> ChangePassword(string Token, string newPassword);
        public Task<IeFirebaseAuthResponse> ChangeProfile(string Token, string DisplayName, string PhotoURL);
    }
}
