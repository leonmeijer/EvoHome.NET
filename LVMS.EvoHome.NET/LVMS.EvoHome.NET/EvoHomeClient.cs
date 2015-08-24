using System;
using System.Net.Http;
using System.Threading.Tasks;
using LVMS.EvoHome.Exceptions;
using LVMS.EvoHome.Interfaces;
using LVMS.EvoHome.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PortableRest;

namespace LVMS.EvoHome
{
    public partial class EvoHomeClient : IEvoHomeClient
    {
        protected string ApiUrl = "https://rs.alarmnet.com/TotalConnectComfort/WebAPI/api/";
        protected Guid AppId = Guid.Parse("91db1612-73fd-4500-91b2-e63b069b185c");
        private RestClient _httpClient;
        internal Guid SessionId;
        private bool _initialized;
        internal bool UsePollyTransientFaultHandling;


        /// <summary>
        /// Initializes a new EvoHomeClient instance with a custom API url.
        /// </summary>
        /// <param name="apiUrl">Endpoint address of the EvoHome REST API</param>
        /// <param name="usePollyTransientFaultHandling">Whether or not to use transient fault handling</param>
        public EvoHomeClient(Guid appId = default(Guid), string apiUrl = null, bool usePollyTransientFaultHandling = true)
        {
            if (apiUrl != null)
                ApiUrl = apiUrl;
            if (appId != Guid.Empty)
                AppId = appId;
            UsePollyTransientFaultHandling = usePollyTransientFaultHandling;
        }

        /// <summary>
        /// Checks whether or not this library and the connection with EvoHome is initialized.
        /// </summary>
        public void CheckInitialized()
        {
            if (!_initialized)
                throw new EvoHomeException();
        }

        /// <summary>
        /// Authenticate this client with the EvoHome API REST service.
        /// </summary>
        /// <param name="userNameEmail">User name (typically the email address)</param>
        /// <param name="password">Password</param>
        public async Task LoginAsync(string userNameEmail, string password)
        {
            _httpClient = new RestClient { BaseUrl = ApiUrl };
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            _httpClient.JsonSerializerSettings = jsonSerializerSettings;

            var loginInfo = new Login() {ApplicationId = AppId.ToString(), Username = userNameEmail, Password = password};
            var initRequest = new RestRequest("Session", HttpMethod.Post, ContentTypes.Json);
            initRequest.AddParameter(loginInfo);

            var session = await _httpClient.ExecuteWithPolicyAsync<Session>(this, initRequest, byPassCheckInitialized: true);
            if (session.SessionId.Equals(Guid.Empty))
                throw new CannotInitializeSessionException();

            // Save the SessionId, because we pass this as Cookie value to all future requests
            SessionId = session.SessionId;

            _initialized = true;
        }

        public Task<bool> CheckConnection()
        {
            throw new NotImplementedException();
        }
    }
}
