using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Giftos.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than or equal to 1")]
        public int Stock { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than or equal to 1")]
        public int Price { get; set; }

        public byte[]? Image { get; set; }

        public Product() {
            Id = Guid.NewGuid();
        }

    }
}
