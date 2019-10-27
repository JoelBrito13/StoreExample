using System.ComponentModel.DataAnnotations;

namespace StoreExample.Modules.Product
{
    public class IProduct
    {    [Key]            
        public int Idx { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryIdx { get; set; }
        public Category.Category Category { get; set; }
        
    }
}