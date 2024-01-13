using eFirebase4CSharp.Interfaces;

namespace eFirebase4CSharp.Classes
{
    public class eFirebase : IeFirebase
    {
        private const string eFirebase_version = "1.1.0";
        
        private HttpClient _httpClient;
        
        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="client">Serviço HTTPClient</param>
        public eFirebase(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// Método para Utilizar os serviços de Autenticação do Firebase (Firebase Auth)
        /// </summary>
        /// <param name="API_Key">Chave API do Firebase</param>
        /// <returns>Retorna Interface com métodos do serviço Firebase Auth</returns>
        public IeFirebaseAuth Auth(string API_Key)
        {
            return new eFirebaseAuth(_httpClient, API_Key);
        }

        /// <summary>
        /// Método para Utilizar os serviços de Banco de Dados do Firebase (Firebase RealTimeDB)
        /// </summary>
        /// <param name="ProjectCode">ID do Projeto no Firebase</param>
        /// <returns>Retorna Interface com métodos do serviço RealTimeDB</returns>
        public IeFirebaseRealTimeDB RealTimeDB(string ProjectCode)
        {
            return new eFirebaseRealTimeDB(_httpClient, ProjectCode);
        }

        /// <summary>
        /// Método para Utilizar os serviços de Armazenamento em nuvem do Firebase (Firebase Storage)
        /// </summary>
        /// <param name="ProjectCode">ID do Projeto no Firebase</param>
        /// <returns>Retorna Interface com métodos do serviço RealTimeDB</returns>
        public IeFirebaseStorage Storage(string ProjectCode)
        {
            return new eFirebaseStorage(_httpClient, ProjectCode);
        }

        /// <summary>
        /// Método que retorna versão da lib eFirebase
        /// </summary>
        /// <returns>Versão da Class Library eFirebase</returns>
        public string GetVersion()
        {
            return eFirebase_version;
        }
    }
}
