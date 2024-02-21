namespace Inventory_managment.ResponseDTO
{
    public class Package
    {
        public required string Volume { get; set; }

        public int BoxFormat { get; set; }

        public int PalletFormat { get; set; }
    }
}
