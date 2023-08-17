using eFirebase4CSharp.Classes.Responses;
using eFirebase4CSharp.Interfaces;
using eFirebase4CSharp.Interfaces.Responses;
using eFirebase4CSharp.Types;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace eFirebase4CSharp.Classes
{
    public class eFirebaseRealTimeDB : IeFirebaseRealTimeDB, IeFirebaseRealtimeFilters
    {
        #region Variáveis e Constante
        const string Url_base = ".firebaseio.com/";

        private HttpClient _httpClient;
        private string fUrl = string.Empty;
        private string fToken = string.Empty;
        private string fCollection = string.Empty;
        private string fEndpoint = string.Empty;
        private string fOrderBy = string.Empty;
        private string fstartAt = string.Empty;
        private string fendAt = string.Empty;
        private string fequalTo = string.Empty;
        private string flimitToFirst = string.Empty;
        private string flimittoLast = string.Empty;
        #endregion

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="httpClient">Injeção de HttpClient para operações Rest</param>
        /// <param name="projectCode">ID do Projeto Firebase</param>
        public eFirebaseRealTimeDB(HttpClient httpClient, string projectCode)
        {
            _httpClient = httpClient;

            fUrl = "https://" + projectCode + Url_base;
        }

        #region Métodos de construção da chamada
        /// <summary>
        /// Informar o Token para acesso a endpoints com regra de autenticação/autorização
        /// </summary>
        /// <param name="Value">Token recebido do Firebase Auth</param>
        /// <returns>Interface para encadear métodos</returns>
        public IeFirebaseRealTimeDB AccessToken(string? Value = null)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                fToken = "auth=" + Value;
            }
            return this;
        }

        /// <summary>
        /// Informar coleção a manipular, será adicionado ao termo o ".json" necessário para consumo da mesma
        /// </summary>
        /// <param name="Collection">Coleção a consultar/agir</param>
        /// <returns>Interface para encadear métodos</returns>
        public IeFirebaseRealTimeDB Collection(string? Collection = null)
        {
            if (!string.IsNullOrEmpty(Collection))
            {
                fCollection = Collection;
                if (fCollection.StartsWith('/'))
                {
                    fCollection = fCollection.Remove(0, 1);
                }

                if (fCollection.EndsWith('/'))
                {
                    fCollection = fCollection.Remove(fCollection.Length - 1, 1);
                }
            }
            return this;
        }

        /// <summary>
        /// Informar caminho/endpoint onde está coleção a consumir
        /// </summary>
        /// <param name="Value">Endpoint que deseja consumir</param>
        /// <returns>Interface para encadear métodos</returns>
        public IeFirebaseRealTimeDB Endpoint(string? Value = null)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                fEndpoint = Value;
                if(fEndpoint.StartsWith('/'))
                {
                    fEndpoint = fEndpoint.Remove(0, 1);
                }

                if(!fEndpoint.EndsWith('/'))
                {
                    fEndpoint += "/";
                }
            }
            return this;
        }
        #endregion

        #region Métodos de Suporte/Apoio
        /// <summary>
        /// Método de Apoio para Montar URL do serviço sem filtros
        /// </summary>
        /// <returns>URL completa sem filtros (apenas Token se tiver)</returns>
        private string MountUrl()
        {
            string _URL = fUrl + fEndpoint + fCollection;

            if(!string.IsNullOrEmpty(fToken))
            {
                _URL = _URL + "?" + fToken;
            }

            return _URL;
        }

        /// <summary>
        /// Método de Apoio para Montar URL do serviço com filtros
        /// </summary>
        /// <returns>URL completa com filtros (e Token se tiver)</returns>
        private string MountUrlSearch()
        {
            string _URLSearch = string.Empty;
            if(string.IsNullOrEmpty(fToken))
            {
                _URLSearch = "?";
            }
            else
            {
                _URLSearch = "&";
            }

            if(!string.IsNullOrEmpty(fOrderBy))
            {
                _URLSearch += fOrderBy;

                if(!string.IsNullOrEmpty(fstartAt))
                {
                    _URLSearch += "&" + fstartAt;

                    if(!string.IsNullOrEmpty(fendAt))
                    {
                        _URLSearch += "&" + fendAt;
                    }
                }

                if(!string.IsNullOrEmpty(fendAt))
                {
                    _URLSearch += "&" + fendAt;
                }

                if(!string.IsNullOrEmpty(fequalTo))
                {
                    _URLSearch += "&" + fequalTo;
                }

                if(!string.IsNullOrEmpty(flimitToFirst))
                {
                    _URLSearch += "&" + flimitToFirst;
                    flimittoLast = string.Empty;
                }

                if(!string.IsNullOrEmpty(flimittoLast))
                {
                    _URLSearch += "&" + flimittoLast;
                }
            }

            if((_URLSearch == "?") || (_URLSearch == "&"))
            {
                _URLSearch = string.Empty;
            }

            return _URLSearch;
        }
        #endregion

        #region Métodos de Leitura com e sem filtros
        public async Task<IeFirebaseRealtimeResponse> ReadWithoutFiltersAsync(string? id = null)
        {
            if(!string.IsNullOrEmpty(id))
            {
                fCollection += "/" + id + ".json";
            }
            else
            {
                fCollection += ".json";
            }

            string cUrl = MountUrl();

            IEnumerable<string>? teste;
            if(!_httpClient.DefaultRequestHeaders.TryGetValues("X-Firebase-ETag", out teste))
            {
                _httpClient.DefaultRequestHeaders.Add("X-Firebase-ETag", "true");
            }
            

            var Response = await _httpClient.GetAsync(cUrl);
            var Content = await Response.Content.ReadAsStringAsync();

            string? _ETag = Response.Headers.GetValues("ETag").FirstOrDefault();
            return new eFirebaseRealtimeResponse(Content, Convert.ToInt32(Response.StatusCode), _ETag);
        }

        #region Métodos para efetuar leitura com filtros
        public IeFirebaseRealtimeFilters Read()
        {
            return this;
        }

        public async Task<IeFirebaseRealtimeResponse> SearchAsync()
        {
            fCollection += ".json";

            string cUrl = MountUrl() + MountUrlSearch();

            var Response = await _httpClient.GetAsync(cUrl);
            var Content = await Response.Content.ReadAsStringAsync();

            return new eFirebaseRealtimeResponse(Content, Convert.ToInt32(Response.StatusCode), null);
        }

        //Utilizar orderBy para indicar campo/nó a pesquisar
        public IeFirebaseRealtimeFilters OrderBy(eFirebaseOrderByKind? Kind = null)
        {
            if(Kind != null)
            {
                switch(Kind)
                {
                    case eFirebaseOrderByKind.obkKey:
                        fOrderBy = @"orderBy=""$key""";
                        break;
                    case eFirebaseOrderByKind.obkValue:
                        fOrderBy = @"orderBy=""$value""";
                        break;
                    case eFirebaseOrderByKind.obkPriority:
                        fOrderBy = @"orderBy=""$priority""";
                        break;
                    default:
                        fOrderBy = @"orderBy=""$key""";
                        break;
                }
            }

            return this;
        }

        public IeFirebaseRealtimeFilters OrderBy(string? Fields = null)
        {
            if(Fields != null)
            {
                fOrderBy = $"orderBy=\"{Fields}\"";
            }
            return this;
        }
        //--------------------------------------------------------------------------

        //----------------Filtro IGUAL A--------------------------------------------
        public IeFirebaseRealtimeFilters EqualTo(string? Value = null)
        {
            if (Value != null)
            {
                fequalTo = $"equalTo=\"{Value}\"";
            }
            return this;
        }

        public IeFirebaseRealtimeFilters EqualTo(int? Value = null)
        {
            if (Value != null)
            {
                fequalTo = $"equalTo={Value}";
            }
            return this;
        }
        //---------------------------------------------------------------------------


        //----------------Filtro INICIA COM (= A MAIOR OU IGUAL A)-------------------
        public IeFirebaseRealtimeFilters StartAt(string? Value = null)
        {
            if (Value != null)
            {
                fstartAt = $"startAt=\"{Value}\"";
            }
            return this;
        }

        public IeFirebaseRealtimeFilters StartAt(int? Value = null)
        {
            if (Value != null)
            {
                fstartAt = $"startAt={Value}";
            }
            return this;
        }
        //---------------------------------------------------------------------------

        //----------------Filtro TERMINA COM (= A MENOR OU IGUAL A)------------------
        public IeFirebaseRealtimeFilters EndAt(string? Value = null)
        {
            if (Value != null)
            {
                fendAt = $"endAt=\"{Value}\"";
            }
            return this;
        }

        public IeFirebaseRealtimeFilters EndAt(int? Value = null)
        {
            if (Value != null)
            {
                fendAt = $"endAt={Value}";
            }
            return this;
        }
        //----------------------------------------------------------------------------


        //----------Métodos para limitar resultados--------------------------------
        public IeFirebaseRealtimeFilters LimitToFirst(int? Value = null)
        {
            if (Value != null)
            {
                flimitToFirst = $"limitToFirst={Value}";
            }
            return this;
        }

        public IeFirebaseRealtimeFilters LimitToLast(int? Value = null)
        {
            if (Value != null)
            {
                flimittoLast = $"limitToLast={Value}";
            }
            return this;
        }
        //--------------------------------------------------------------------------
        #endregion

        #endregion

        #region Métodos operacionais: Salvar, Atualizar, Excluir e Inserir (CRUD)
        /// <summary>
        /// Método para atualizar os dados do registro
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a enviar</typeparam>
        /// <param name="Body">Objeto a ser enviado</param>
        /// <returns>Interface com dados da resposta da requisição</returns>
        public async Task<IeFirebaseRealtimeResponse> UpdateRegister<T>(T Body, string? id = null)
        {
            if (!string.IsNullOrEmpty(id))
            {
                fCollection += "/" + id + ".json";
            }
            else
            {
                fCollection += ".json";
            }

            string cUrl = MountUrl();

            var Response = await _httpClient.PatchAsJsonAsync<T>(cUrl, Body);
            var Content = await Response.Content.ReadAsStringAsync();

            return new eFirebaseRealtimeResponse(Content, Convert.ToInt32(Response.StatusCode), null);
        }

        /// <summary>
        /// Método para atualizar/sobreescrever ou mesmo escrever (incluir) os dados do registro
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a enviar</typeparam>
        /// <param name="Body">Objeto a ser enviado</param>
        /// <param name="ETag">Identificação do recurso para confirmar se ainda existe</param>
        /// <returns>Interface com dados da resposta da requisição</returns>
        public async Task<IeFirebaseRealtimeResponse> WriteRegister<T>(T Body, string? ETag = null)
        {
            fCollection += ".json";

            string cUrl = MountUrl();

            if (!string.IsNullOrEmpty(ETag))
            {
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("if-match", "\"" + ETag + "\"");
            }

            var Response = await _httpClient.PutAsJsonAsync<T>(cUrl, Body);
            var Content = await Response.Content.ReadAsStringAsync();

            IEnumerable<string>? Tags = new List<string>();
            string? _ETag = null;
            if (Response.Headers.TryGetValues("ETag", out Tags))
            {
                _ETag = Response.Headers.GetValues("ETag").FirstOrDefault();
            }
            return new eFirebaseRealtimeResponse(Content, Convert.ToInt32(Response.StatusCode), _ETag);
        }

        /// <summary>
        /// Método para criar/incluir/inserir registro no banco de dados
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a enviar</typeparam>
        /// <param name="Body">Objeto a ser enviado</param>
        /// <returns>Interface com dados da resposta da requisição</returns>
        public async Task<IeFirebaseRealtimeResponse> CreateRegister<T>(T Body)
        {
            fCollection += ".json";

            string cUrl = MountUrl();

            _httpClient.DefaultRequestHeaders.Add("X-Firebase-ETag", "true");

            var Response = await _httpClient.PostAsJsonAsync<T>(cUrl, Body);
            var Content = await Response.Content.ReadAsStringAsync();

            string? _ETag = Response.Headers.GetValues("ETag").FirstOrDefault();
            return new eFirebaseRealtimeResponse(Content, Convert.ToInt32(Response.StatusCode), _ETag);
        }

        /// <summary>
        /// Método usado para apagar registro da base de dados
        /// </summary>
        /// <param name="Id">Id do registro a ser apagado (ou pode ser passado a coleção)</param>
        /// <param name="ETag">Identificação do recurso para confirmar se ainda existe</param>
        /// <returns>Interface com dados da resposta da requisiçã</returns>
        public async Task<IeFirebaseRealtimeResponse> DeleteRegister(string? Id = null, string? ETag = null)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                fCollection += "/" + Id + ".json";
            }
            else
            {
                fCollection += ".json";
            }

            string cUrl = MountUrl();

            if(!string.IsNullOrEmpty(ETag)) 
            {
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("if-match", "\"" + ETag + "\"");
            }

            var Response = await _httpClient.DeleteAsync(cUrl);
            var Content = await Response.Content.ReadAsStringAsync();

            return new eFirebaseRealtimeResponse(Content, Convert.ToInt32(Response.StatusCode), null);
        }
        #endregion
    }
}
