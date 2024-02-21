using Inventory_managment.DTO;
using Inventory_managment.ResponseDTO;
using Inventory_managment.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace Inventory_managment.Services.Implementations
{
    public class MissionService : IMissionService
    {
        private const string ApiPath = "http://promark94.marking.by/client/api/get/task/";

        public async Task<MissionDTO> GetMissionAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ApiPath);

                if (response.IsSuccessStatusCode)
                {
                    var missionRespose = await response.Content.ReadFromJsonAsync<MissionResponse>();

                    if (missionRespose != null)
                    {
                        return new MissionDTO(
                            missionRespose.Mission.Lot.Product.Name,
                            missionRespose.Mission.Lot.Product.Gtin,
                            missionRespose.Mission.Lot.Package.Volume,
                            missionRespose.Mission.Lot.Package.BoxFormat,
                            missionRespose.Mission.Lot.Package.PalletFormat);
                    }
                }

                return null;
            }
        }
    }
}
