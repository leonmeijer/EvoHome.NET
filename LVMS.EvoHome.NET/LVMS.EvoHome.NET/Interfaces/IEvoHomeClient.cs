using System.Threading.Tasks;

namespace LVMS.EvoHome.Interfaces
{
    interface IEvoHomeClient
    {
        /// <summary>
        /// Establishes a secure connection with the EvoHome API service.
        /// It first calls user/init to get the nonce and then calls user/login
        /// to establish a secure session.
        /// </summary>
        /// <param name="userNameEmail">Username or E-mail address</param>
        /// <param name="password"></param>
        /// <returns><c>true</c> if success, <c>false</c> if authentication failed.</returns>
        Task LoginAsync(string userNameEmail, string password);
        Task<bool> CheckConnection();
    }
}
