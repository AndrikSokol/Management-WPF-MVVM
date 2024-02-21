namespace Inventory_managment.ResponseDTO
{
    public class Mission
    {
        public double Id { get; set; }

        public required string DateAt { get; set; }

        public int CodeTypeId { get; set; }

        public required Lot Lot { get; set; }
    }
}
