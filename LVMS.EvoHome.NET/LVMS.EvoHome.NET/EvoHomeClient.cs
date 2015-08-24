using System;
using System.Threading.Tasks;
using LVMS.EvoHome.Exceptions;
using LVMS.EvoHome.Interfaces;
using PortableRest;

namespace LVMS.EvoHome
{
    public partial class EvoHomeClient : IEvoHomeClient
    {
        private RestClient _httpClient;
        internal string Jessionid;
        private bool _initialized;
        internal bool UsePollyTransientFaultHandling;
       

        /// <summary>
        /// Initializes a new EvoHomeClient instance with a custom API url.
        /// </summary>
        /// <param name="apiUrl">Endpoint address of the EvoHome REST API</param>
        public EvoHomeClient(string apiUrl)
        {
            // todo
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
            
        }

        public Task<bool> CheckConnection()
        {
            throw new NotImplementedException();
        }
    }
}
