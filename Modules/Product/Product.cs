using System.ComponentModel.DataAnnotations;

namespace StoreExample.Modules.Product
{
    public class Product : IProduct
    {
        [Key]
        public virtual int Idx { get; set; }

        [Required(ErrorMessage = "Product Price is Required")]
        public virtual double Price { get; set; }

        [Required(ErrorMessage = "Product Category is Required")]
        public virtual int CategoryIdx { get; set; }

        [Required(ErrorMessage = "Product Name is Required")] 
        public virtual string Name { get; set; }
        
        public virtual Category.Category Category { get; set; }

        
        public Product(){}
    }
    
}