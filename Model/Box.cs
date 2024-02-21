using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_managment.Model
{
    public class Box
    {
        [Key]
        public int Id { get; set; }

        public required string Code { get; set; }

        public int PalletId { get; set; }

        [ForeignKey("PalletId")]
        public ICollection<Pallet>? Pallet { get; set; }
    }
}
