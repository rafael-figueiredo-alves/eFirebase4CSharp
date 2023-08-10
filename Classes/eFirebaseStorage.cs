using eFirebase4CSharp.Interfaces;
using eFirebase4CSharp.Interfaces.Responses;
using System.Net.Http.Json;
using System;
using eFirebase4CSharp.Classes.Responses;
using System.Net.Http.Headers;

namespace eFirebase4CSharp.Classes
{
    internal class eFirebaseStorage : IeFirebaseStorage
    {
        #region Constantes
        const string StorageURL = "https://firebasestorage.googleapis.com/v0/b/";
        const string SuffixURL  = ".appspot.com/o/";
        #endregion

        private HttpClient _httpClient;
        private string ProjectCode;
        private string fFolders;
        private string fFilename;
        private string fContentType;
        private Stream? fContent;

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="httpClient">Instância do HttpClient</param>
        /// <param name="projectCode">ID do Projeto</param>
        public eFirebaseStorage(HttpClient httpClient, string projectCode) 
        {
            _httpClient = httpClient;
            ProjectCode = projectCode;
            fFolders = string.Empty;
            fFilename = string.Empty;
            fContentType = string.Empty;
        }

        /// <summary>
        /// Método para pegar o tipo de arquivo a enviar
        /// </summary>
        /// <param name="filename">Nome do arquivo</param>
        /// <returns>Retorna ContentType</returns>
        private string GetContentType(string filename) 
        {
            string contentType = string.Empty;

            string FileType = Path.GetExtension(filename);
            FileType = FileType.Replace(".", "").ToLower();
            
            if((FileType == "png") || (FileType == "jpg") || (FileType == "jpeg") || (FileType == "gif") || (FileType == "bmp"))
            {
                contentType = "image/" + FileType;
            }

            if ((FileType == "txt"))
            {
                contentType = "text/plain";
            }

            if ((FileType == "csv") || (FileType == "css"))
            {
                contentType = "text/" + FileType;
            }

            if ((FileType == "pdf"))
            {
                contentType = "application/" + FileType;
            }

            if ((FileType == "mp3") || (FileType == "ogg"))
            {
                contentType = "audio/" + FileType;
            }

            return contentType;
        }

        /// <summary>
        /// Método para enviar o path do arquivo a ser enviado para o Storage
        /// </summary>
        /// <param name="value">Path completo do arquivo</param>
        /// <returns>Instância da própria classe</returns>
        public IeFirebaseStorage FileName(string value)
        {
            fFilename = value;
            return this;
        }

        /// <summary>
        /// Método para comnstruir hierárquia de pastas dentro do Storage
        /// </summary>
        /// <param name="path">Nome da pasta</param>
        /// <returns>Instância da própria class</returns>
        public IeFirebaseStorage Folder(string path)
        {
            fFolders = fFolders + path + "%2f";
            return this;
        }

        /// <summary>
        /// Pega stream do arquivo a enviar
        /// </summary>
        /// <param name="value">Stream com conteúdo do arquivo</param>
        /// <returns>Instância da própria interface</returns>
        public IeFirebaseStorage Content(Stream value)
        {
            fContent = value;
            return this;
        }

        /// <summary>
        /// Método de envio do arquivo para o storage
        /// </summary>
        /// <param name="AuthToken">Token de autenticação</param>
        /// <returns>Resposta da requisição</returns>
        public async Task<IeFirebaseStorageResponse> SendAsync(string? AuthToken = null)
        {
            fContentType = GetContentType(fFilename);

            string fURL = StorageURL + ProjectCode + SuffixURL + fFolders + Path.GetFileName(fFilename);

            StreamContent content = new(fContent);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(fContentType);

            if (!string.IsNullOrEmpty(AuthToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", AuthToken);
            }

            var Response = await _httpClient.PostAsync(fURL, content);
            
            var Content = await Response.Content.ReadAsStringAsync();

            return new eFirebaseStorageResponse(Content, fURL, Convert.ToInt32(Response.StatusCode));
        }
    }
}
