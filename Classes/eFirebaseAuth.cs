using eFirebase4CSharp.Classes.Responses;
using eFirebase4CSharp.Interfaces;
using eFirebase4CSharp.Interfaces.Responses;
using System.Net.Http.Json;

namespace eFirebase4CSharp.Classes
{
    public class eFirebaseAuth : IeFirebaseAuth
    {
        #region Constantes referentes aos Endpoints do Firebase
        const string SignUp_URL        = "https://identitytoolkit.googleapis.com/v1/accounts:signUp";
        const string SignIn_URL        = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword";
        const string SendPassRestEmail = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode";
        const string SendEmailVerURL   = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode";
        const string SecureToken_URL   = "https://securetoken.googleapis.com/v1/token";
        const string PasswordReset     = "https://identitytoolkit.googleapis.com/v1/accounts:resetPassword";
        const string ConfirmEmail      = "https://identitytoolkit.googleapis.com/v1/accounts:update";
        const string DeleteAccountURL  = "https://identitytoolkit.googleapis.com/v1/accounts:delete";
        const string ChangePasswordURL = "https://identitytoolkit.googleapis.com/v1/accounts:update";
        const string UpdateProfileURL  = "https://identitytoolkit.googleapis.com/v1/accounts:update";
        const string GetProfileURL     = "https://identitytoolkit.googleapis.com/v1/accounts:lookup";
        #endregion

        private HttpClient _httpClient;
        private string API_Key;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="Client">Serviço HTTPClient</param>
        /// <param name="_API_Key">Chave API do Firebase</param>
        public eFirebaseAuth(HttpClient Client, string _API_Key) 
        {
            _httpClient = Client;
            API_Key = _API_Key;
        }

        public async Task<IeFirebaseAuthResponse> SignUpWithEmailPasswordAsync(string Email, string Password)
        {
            SignBody body = new(Email, Password);

            string Url = SignUp_URL + "?key=" + API_Key;

            var Response = await _httpClient.PostAsJsonAsync<SignBody>(Url, body);

            var Content = await Response.Content.ReadAsStringAsync();

            return new eFirebaseAuthResponse(Content, Convert.ToInt32(Response.StatusCode));
        }

        public async Task<IeFirebaseAuthResponse> SignInWithEmailPasswordAsync(string Email, string Password)
        {
            SignBody body = new(Email, Password);

            string Url = SignIn_URL + "?key=" + API_Key;

            var Response = await _httpClient.PostAsJsonAsync<SignBody>(Url, body);

            var Content = await Response.Content.ReadAsStringAsync();

            return new eFirebaseAuthResponse(Content, Convert.ToInt32(Response.StatusCode));
        }

        public Task<IeFirebaseAuthResponse> ChangePasswordAsync(string Token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseAuthResponse> ChangeProfileAsync(string Token, string DisplayName, string PhotoURL)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseAuthResponse> ConfirmEmailVerificationAsync(string oobCode)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseAuthResponse> ConfirmPasswordResetAsync(string oobCode, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseAuthResponse> DeleteAccountAsync(string Token)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseAuthResponse> ExchangeRefreshToken4idTokenAsync(string RefreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseAuthResponse> GetProfileAsync(string Token)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseAuthResponse> SendEmailVerificationAsync(string Token)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseAuthResponse> SendPasswordResetEmailAsync(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<IeFirebaseAuthResponse> VerifyPasswordResetCodeAsync(string oobCode)
        {
            throw new NotImplementedException();
        }
    }

    public class SignBody
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; } = true;

        public SignBody(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
