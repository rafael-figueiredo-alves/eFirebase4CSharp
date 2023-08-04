using eFirebase4CSharp.Classes.Responses;
using eFirebase4CSharp.Interfaces;
using eFirebase4CSharp.Interfaces.Responses;
using System;
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

        /// <summary>
        /// Método que Executa a requisição
        /// </summary>
        /// <typeparam name="T">Tipo do corpo</typeparam>
        /// <param name="url">url do endpoint</param>
        /// <param name="body">Corpo da requisição</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> ExecuteRequest<T>(string url, T body)
        {
            string Url = url + "?key=" + API_Key;
            var Response = await _httpClient.PostAsJsonAsync<T>(Url, body);
            var Content = await Response.Content.ReadAsStringAsync();
            return new eFirebaseAuthResponse(Content, Convert.ToInt32(Response.StatusCode));
        }

        /// <summary>
        /// Método usado para Registrar uma nova conta no Firebase AUth
        /// </summary>
        /// <param name="Email">E-mail para criar conta</param>
        /// <param name="Password">Senha para criar e-mail</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> SignUpWithEmailPasswordAsync(string Email, string Password)
        {
            SignBody body = new(Email, Password);
            return await ExecuteRequest<SignBody>(SignUp_URL, body);
        }

        /// <summary>
        /// Método usado para realizar login na conta criada no Firebase Auth
        /// </summary>
        /// <param name="Email">E-mail para criar conta</param>
        /// <param name="Password">Senha para criar e-mail</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> SignInWithEmailPasswordAsync(string Email, string Password)
        {
            SignBody body = new(Email, Password);
            return await ExecuteRequest<SignBody>(SignIn_URL, body);
        }

        /// <summary>
        /// Método utilizado para Atualizar o token usando o RefreshToken
        /// </summary>
        /// <param name="RefreshToken">RefreshToken fornecido ao se conectar</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> ExchangeRefreshToken4idTokenAsync(string RefreshToken)
        {
            RefreshTokenBody body = new(RefreshToken);
            return await ExecuteRequest<RefreshTokenBody>(SecureToken_URL, body);
        }

        /// <summary>
        /// Método para obter informações do perfil de usuário na conta do Firebase Auth
        /// </summary>
        /// <param name="Token">Token fornecido ao se logar</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> GetProfileAsync(string Token)
        {
            TokenBody body = new(Token);
            return await ExecuteRequest<TokenBody>(GetProfileURL, body);
        }

        /// <summary>
        /// Método para Apagar uma conta criada no Firebase Auth
        /// </summary>
        /// <param name="Token">Token recebido ao se logar</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> DeleteAccountAsync(string Token)
        {
            TokenBody body = new(Token);
            return await ExecuteRequest<TokenBody>(DeleteAccountURL, body);
        }

        /// <summary>
        /// Método para enviar e-mail de verificação de conta
        /// </summary>
        /// <param name="Token">Token obtido ao logar</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> SendEmailVerificationAsync(string Token)
        {
            VerifyEmailBody body = new(Token);
            return await ExecuteRequest<VerifyEmailBody>(SendEmailVerURL, body);
        }

        /// <summary>
        /// Método para enviar solicitação de Resetamento de senha por e-mail
        /// </summary>
        /// <param name="Email">E-mail para enviar Código de resetamento</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> SendPasswordResetEmailAsync(string Email)
        {
            PasswordResetBody body = new(Email);
            return await ExecuteRequest<PasswordResetBody>(SendPassRestEmail, body);
        }

        /// <summary>
        /// Método para alterar/editar dados do Perfil da conta
        /// </summary>
        /// <param name="Token">Token obtido ao logar</param>
        /// <param name="DisplayName">Nome quie é exibido pela conta</param>
        /// <param name="PhotoURL">URL da foto de perfil</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> ChangeProfileAsync(string Token, string DisplayName, string PhotoURL)
        {
            ChangeProfileBody body = new(Token, DisplayName, PhotoURL);
            return await ExecuteRequest<ChangeProfileBody>(UpdateProfileURL, body);
        }

        /// <summary>
        /// Método para realizar troca de senha
        /// </summary>
        /// <param name="Token">Token obtido ao logar</param>
        /// <param name="newPassword">Nova senha</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> ChangePasswordAsync(string Token, string newPassword)
        {
            ChangePasswordBody body = new(Token, newPassword);
            return await ExecuteRequest<ChangePasswordBody>(ChangePasswordURL, body);
        }

        /// <summary>
        /// Método para enviar o codigo de confirmação para verificação do E-mail
        /// </summary>
        /// <param name="oobCode">Código de verificação enviado para o e-mail</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> ConfirmEmailVerificationAsync(string oobCode)
        {
            ConfirmEmailBody body = new(oobCode);
            return await ExecuteRequest<ConfirmEmailBody>(ConfirmEmail, body);
        }

        /// <summary>
        /// Método para inserir código de confirmação de resetamento de senha e informar nova senha
        /// </summary>
        /// <param name="oobCode">Coódigo de confirmação enviado para o e-mail</param>
        /// <param name="newPassword">Nova senha</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> ConfirmPasswordResetAsync(string oobCode, string newPassword)
        {
            ConfirmPasswordResetBody body = new(oobCode, newPassword); 
            return await ExecuteRequest<ConfirmPasswordResetBody>(PasswordReset, body);
        }

        /// <summary>
        /// Método para verificar/validar código de confirmação de resetamento de senha
        /// </summary>
        /// <param name="oobCode">Coódigo de confirmação enviado para o e-mail</param>
        /// <returns>Retorna instância de IeFirebaseAuthResponse</returns>
        public async Task<IeFirebaseAuthResponse> VerifyPasswordResetCodeAsync(string oobCode)
        {
            VerifyPassResetCodeBody body = new(oobCode);
            return await ExecuteRequest<VerifyPassResetCodeBody>(PasswordReset, body);
        }
    }

    #region Classes Body das requisições
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

    public class TokenBody
    {
        public string idToken { get; set; }

        public TokenBody(string token)
        {
            idToken = token;
        }
    }

    public class RefreshTokenBody
    {
        public string grant_type { get; set; }
        public string refresh_token { get; set; }

        public RefreshTokenBody(string refresh_token)
        {
            grant_type = "refresh_token";
            this.refresh_token = refresh_token;
        }
    }

    public class VerifyEmailBody
    {
        public string requestType { get; set; }
        public string idToken { get; set; }

        public VerifyEmailBody(string idToken)
        {
            requestType = "VERIFY_EMAIL";
            this.idToken = idToken;
        }
    }

    public class PasswordResetBody
    {
        public string requestType { get; set; }
        public string email { get; set; }

        public PasswordResetBody(string email)
        {
            requestType = "VERIFY_EMAIL";
            this.email = email;
        }
    }

    public class ChangeProfileBody
    {
        public string idToken { get; set; }
        public string displayName { get; set; }
        public string photoUrl { get; set; }
        public bool returnSecureToken { get; set; }

        public ChangeProfileBody(string idToken, string displayName, string photoUrl)
        {
            this.idToken = idToken;
            this.displayName = displayName;
            this.photoUrl = photoUrl;
            returnSecureToken = true;
        }
    }

    public class ChangePasswordBody
    {
        public string idToken { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; }

        public ChangePasswordBody(string idToken, string password)
        {
            this.idToken = idToken;
            this.password = password;
            returnSecureToken = true;
        }
    }

    public class ConfirmPasswordResetBody
    {
        public string oobCode { get; set; }
        public string newPassword { get; set; }

        public ConfirmPasswordResetBody(string oobCode, string newPassword)
        {
            this.oobCode = oobCode;
            this.newPassword = newPassword;
        }
    }

    public class ConfirmEmailBody
    {
        public string oobCode { get; set; }

        public ConfirmEmailBody(string oobCode)
        {
            this.oobCode = oobCode;
        }
    }

    public class VerifyPassResetCodeBody
    {
        public string oobCode { get; set; }

        public VerifyPassResetCodeBody(string oobCode)
        {
            this.oobCode = oobCode;
        }
    }
    #endregion
}
