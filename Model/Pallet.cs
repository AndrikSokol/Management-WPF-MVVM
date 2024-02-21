using System.ComponentModel.DataAnnotations;

namespace Inventory_managment.Model
{
    public class Pallet
    {
        [Key]
        public int Id { get; set; }

        public string? Code { get; set; }
    }
}
