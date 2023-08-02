using eFirebase4CSharp.Interfaces.Responses;
using eFirebase4CSharp.Types;
using System.Text.Json.Nodes;

namespace eFirebase4CSharp.Classes.Responses
{
    public class eFirebaseAuthResponse : IeFirebaseAuthResponse
    {
        #region Campos necessários (Variáveis)
        private string? fuID { get; set; }
        private string? fToken { get; set; }
        private string? fRefreshToken { get; set; }
        private int? fExpiresIn { get; set; }
        private bool fRegistered { get; set; } = false;
        private enumAuthErrors? fError { get; set; }
        private string? fDisplayName { get; set; }
        private string? femail { get; set; }
        private bool fEmailVerified { get; set; } = false;
        private string? fphotoURL { get; set; }
        private string? flastLoginAt { get; set; }
        private string? fcreatedAt { get; set; }
        private int ResponseStatusCode { get; set; }
        #endregion

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="_content">Conteúdo do response</param>
        /// <param name="_statusCode">Código do Status da response</param>
        public eFirebaseAuthResponse(string _content, int _statusCode) 
        { 
            string ResponseContent = _content;
            ResponseStatusCode = _statusCode;

            string ErrorMsg = string.Empty;

            var vJSON = JsonObject.Parse(ResponseContent);

            JsonObject oJSON = (JsonObject)vJSON!;

            JsonNode? aJSON;

            if (oJSON.TryGetPropertyValue("users", out aJSON))
            {
                var Item = (JsonArray)aJSON!;
                JsonObject _item = (JsonObject)aJSON!.First();

            }
        }

        /// <summary>
        /// Método para retornar o enumerado do erro correspondente
        /// </summary>
        /// <param name="Err_MSG">Mensagem de Erro</param>
        /// <returns>Valor do enumerado de erro</returns>
        private enumAuthErrors GetError(string? Err_MSG)
        {
            enumAuthErrors _error = enumAuthErrors.UNKNOWN;

            if (Err_MSG == "EMAIL_EXISTS")
            {
                _error = enumAuthErrors.EMAIL_EXISTS;
            }

            if (Err_MSG == "OPERATION_NOT_ALLOWED")
            {
                _error = enumAuthErrors.OPERATION_NOT_ALLOWED;
            }

            if (Err_MSG == "TOO_MANY_ATTEMPTS_TRY_LATER")
            {
                _error = enumAuthErrors.TOO_MANY_ATTEMPTS_TRY_LATER;
            }

            if (Err_MSG == "INVALID_EMAIL")
            {
                _error = enumAuthErrors.INVALID_EMAIL;
            }

            if (Err_MSG == "WEAK_PASSWORD")
            {
                _error = enumAuthErrors.WEAK_PASSWORD;
            }

            if (Err_MSG == "EMAIL_NOT_FOUND")
            {
                _error = enumAuthErrors.EMAIL_NOT_FOUND;
            }

            if (Err_MSG == "USER_DISABLED")
            {
                _error = enumAuthErrors.USER_DISABLED;
            }

            if (Err_MSG == "TOKEN_EXPIRED")
            {
                _error = enumAuthErrors.TOKEN_EXPIRED;
            }

            if (Err_MSG == "USER_NOT_FOUND")
            {
                _error = enumAuthErrors.USER_NOT_FOUND;
            }

            if (Err_MSG == "INVALID_REFRESH_TOKEN")
            {
                _error = enumAuthErrors.INVALID_REFRESH_TOKEN;
            }

            if (Err_MSG == "INVALID_GRANT_TYPE")
            {
                _error = enumAuthErrors.INVALID_GRANT_TYPE;
            }

            if (Err_MSG == "MISSING_REFRESH_TOKEN")
            {
                _error = enumAuthErrors.MISSING_REFRESH_TOKEN;
            }

            if (Err_MSG == "EXPIRED_OOB_CODE")
            {
                _error = enumAuthErrors.EXPIRED_OOB_CODE;
            }

            if (Err_MSG == "INVALID_OOB_CODE")
            {
                _error = enumAuthErrors.INVALID_OOB_CODE;
            }

            if (Err_MSG == "INVALID_ID_TOKEN")
            {
                _error = enumAuthErrors.INVALID_ID_TOKEN;
            }

            if (Err_MSG == "CREDENTIAL_TOO_OLD_LOGIN_AGAIN")
            {
                _error = enumAuthErrors.CREDENTIAL_TOO_OLD_LOGIN_AGAIN;
            }

            if (Err_MSG == "INVALID_PASSWORD")
            {
                _error = enumAuthErrors.INVALID_PASSWORD;
            }

            return _error;
        }
        public string? CreatedAt()
        {
            return fcreatedAt ?? string.Empty;
        }

        public string? DisplayName()
        {
            return fDisplayName ?? string.Empty;
        }

        public string? Email()
        {
            return femail ?? string.Empty;
        }

        public bool? EmailVerified()
        {
            return fEmailVerified;
        }

        public enumAuthErrors Erro()
        {
            return fError ?? enumAuthErrors.NONE;
        }

        public int? ExpiresIn()
        {
            return fExpiresIn ?? 0;
        }

        public string? LastLoginAt()
        {
            return flastLoginAt ?? string.Empty;
        }

        public string? PhotoUrl()
        {
            return fphotoURL ?? string.Empty;
        }

        public string? RefreshToken()
        {
            return fRefreshToken ?? string.Empty;
        }

        public bool? Registered()
        {
            return fRegistered;
        }

        public int? StatusCode()
        {
            return ResponseStatusCode;
        }

        public string? Token()
        {
            return fToken ?? string.Empty;
        }

        public string? UID()
        {
            return fuID ?? string.Empty;
        }
    }
}
