using Inventory_managment.DTO;

namespace Inventory_managment.Services.Interfaces
{
    public interface IMissionService
    {
        Task<MissionDTO> GetMissionAsync();
    }
}
