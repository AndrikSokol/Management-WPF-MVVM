namespace Inventory_managment.ResponseDTO
{
    public class Lot
    {
        public required int Id { get; set; }

        public required string DateAt { get; set; }

        public required Package Package { get; set; }

        public required Product Product { get; set; }
    }
}
