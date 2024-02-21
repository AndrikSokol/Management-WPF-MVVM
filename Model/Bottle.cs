using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_managment.Model
{
    public class Bottle
    {
        [Key]
        public int Id { get; set; }

        public string? Code { get; set; }

        public int BoxId { get; set; }

        [ForeignKey("BoxId")]
        public ICollection<Box>? Box { get; set; }
    }
}
