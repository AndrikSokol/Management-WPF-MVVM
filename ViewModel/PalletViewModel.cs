using Inventory_managment.Data;
using Inventory_managment.DTO;
using Inventory_managment.Enums;
using Inventory_managment.Model;
using System.Text;

namespace Inventory_managment.ViewModel
{
    public class PalletViewModel
    {
        private ApplicationDbContext _context;

        private MissionDTO _missionDTO;

        public PalletViewModel(MissionDTO missionDTO, ApplicationDbContext context)
        {
            _context = context;
            _missionDTO = missionDTO;
        }

        public async Task CreatedPalletsAsync(List<string> filteredCodes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int palletFormat = _missionDTO.PalletFormat;
            int boxFormat = _missionDTO.BoxFormat;
            int countOfPallet = (int)Math.Ceiling((double)filteredCodes.Count / (palletFormat * boxFormat));
            for (int i = 0; i < countOfPallet; i++)
            {
                stringBuilder.Append(((int)CodeOfGroup.FirstGroup).ToString("D2"));
                stringBuilder.Append(_missionDTO.Gtin);
                stringBuilder.Append((int)CodeOfGroup.SecondGroup);
                stringBuilder.Append(_missionDTO.PalletFormat);
                stringBuilder.Append((int)CodeOfGroup.ThirdGroup);

                Pallet pallet = new Pallet { Code = stringBuilder.ToString() };

                _context.Pallets.Add(pallet);
                await _context.SaveChangesAsync();

                int id = pallet.Id;

                pallet.Code = $"{stringBuilder.ToString()}{id}";

                await _context.SaveChangesAsync();

                stringBuilder.Clear();
            }
        }
    }
}
