using Inventory_managment.Data;
using Inventory_managment.DTO;
using Inventory_managment.Enums;
using Inventory_managment.Model;
using System.Text;

namespace Inventory_managment.ViewModel
{
    public class BoxViewModel
    {
        private ApplicationDbContext _context;

        private MissionDTO _missionDTO;

        public BoxViewModel(MissionDTO missionDTO, ApplicationDbContext context)
        {
            _context = context;
            _missionDTO = missionDTO;

        }

        public async Task CreatedBoxesAsync(List<string> filteredCodes)
        {
            int boxFormat = _missionDTO.BoxFormat;
            int palletFormat = _missionDTO.PalletFormat;
            int boxIterator = 0;
            bool isAllCodeAdded = false;

            for (int i = 0; i < filteredCodes.Count; i++)
            {
                isAllCodeAdded = false;
                if (i != 0 && i % boxFormat == 0)
                {
                    await AddBoxInDatabase(boxIterator);

                    if (i % (boxFormat * palletFormat) == 0)
                        boxIterator++;

                    isAllCodeAdded = true;
                }

            }

            if (!isAllCodeAdded)
                await AddBoxInDatabase(boxIterator);
        }

        private async Task AddBoxInDatabase(int boxIterator)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(((int)CodeOfGroup.FirstGroup).ToString("D2"));
            stringBuilder.Append(_missionDTO.Gtin);
            stringBuilder.Append((int)CodeOfGroup.SecondGroup);
            stringBuilder.Append(_missionDTO.BoxFormat);
            stringBuilder.Append((int)CodeOfGroup.ThirdGroup);

            int palletId = _context.Pallets.ElementAt(boxIterator).Id;
            Box box = new Box { Code = stringBuilder.ToString(), PalletId = palletId };

            _context.Boxes.Add(box);
            await _context.SaveChangesAsync();

            int id = box.Id;

            box.Code = $"{stringBuilder.ToString()}{id}";

            await _context.SaveChangesAsync();

            stringBuilder.Clear();
        }

    }
}
