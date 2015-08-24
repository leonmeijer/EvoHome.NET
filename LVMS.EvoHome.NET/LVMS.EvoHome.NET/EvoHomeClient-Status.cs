using System.Threading.Tasks;
using LVMS.EvoHome.Model;

namespace LVMS.EvoHome
{
    public partial class EvoHomeClient
    {
        /// <summary>
        /// Returns all data, such as owner info, devices and time zone.
        /// </summary>
        /// <returns></returns>
        public async Task<EvoTouchSystemsStatus> GetStatusAsync(EvoHomeData[] allData = null)
        {
            if (allData == null)
                allData = await GetAllDataAsync();

            return allData[0].EvoTouchSystemsStatus[0];
        }

        
    }
}
