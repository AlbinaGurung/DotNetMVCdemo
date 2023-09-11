
   using System.ComponentModel.DataAnnotations.Schema;
namespace MyProject2.Models
{
    [Table("inv_unit")]

    public class Product1
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
