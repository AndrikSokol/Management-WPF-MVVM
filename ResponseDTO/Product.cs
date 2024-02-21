namespace Inventory_managment.ResponseDTO
{
    public class Product
    {
        public required string Name { get; set; }

        public required string FullName { get; set; }

        public required string Type { get; set; }

        public required string Gtin { get; set; }

        public required string Standard { get; set; }

        public required string ShelfLife { get; set; }

        public required int BarcodeShelfLife { get; set; }

        public required string BarcodeShelfLifeUnit { get; set; }

        public object? MoreInfo { get; set; }
    }
}
