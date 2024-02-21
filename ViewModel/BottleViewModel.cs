using Inventory_managment.Data;
using Inventory_managment.Model;

namespace Inventory_managment.ViewModel
{
    public class BottleViewModel
    {
        private ApplicationDbContext _context;

        public BottleViewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatedBottlesAsync(List<string> filteredCodes, int boxFormat)
        {
            int boxIterator = 0;
            for (int i = 0; i < filteredCodes.Count; i++)
            {
                if (i != 0 && i % boxFormat == 0)
                    boxIterator++;

                int boxId = _context.Boxes.ElementAt(boxIterator).Id;
                Bottle bottle = new Bottle { Code = filteredCodes[i], BoxId = boxId };
                _context.Bottles.Add(bottle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
