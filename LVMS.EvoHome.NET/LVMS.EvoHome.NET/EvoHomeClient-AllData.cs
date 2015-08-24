using System.Net.Http;
using System.Threading.Tasks;
using LVMS.EvoHome.Model;
using PortableRest;

namespace LVMS.EvoHome
{
    public partial class EvoHomeClient
    {
        /// <summary>
        /// Returns all data, such as owner info, devices and time zone.
        /// </summary>
        /// <returns></returns>
        public async Task<EvoHomeData[]> GetAllDataAsync()
        {
            var request = new RestRequest("locations?allData=True", HttpMethod.Get);
            
            return  await _httpClient.ExecuteWithPolicyAsync<EvoHomeData[]>(this, request);            
        }       
    }
}
