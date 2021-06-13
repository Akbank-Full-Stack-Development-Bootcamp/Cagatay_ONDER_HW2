using System.ComponentModel.DataAnnotations;

namespace DapperAPI.Model
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}
