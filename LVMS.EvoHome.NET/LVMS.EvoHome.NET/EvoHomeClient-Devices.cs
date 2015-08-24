using System.Threading.Tasks;
using LVMS.EvoHome.Model;

namespace LVMS.EvoHome
{
    public partial class EvoHomeClient
    {
        public async Task<Device[]> GetDevices(EvoHomeData[] allData = null)
        {
            if (allData == null)
                allData = await GetAllDataAsync();

            return allData[0].Devices.ToArray();
        }
    }
}
