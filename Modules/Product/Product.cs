using System.ComponentModel.DataAnnotations;

namespace StoreExample.Modules.Product
{
    public class Product : IProduct
    {
        [Key]
        public virtual int Idx { get; set; }

        public virtual double? Price { get; set; }

        [Required(ErrorMessage = "Product Category is Required")]
        public virtual int CategoryIdx { get; set; }

        [Required(ErrorMessage = "Product Name is Required")] 
        public virtual string Name { get; set; }
        public virtual Category.Category Category { get; set; }
        protected Product(){}
    }

    public sealed class NullProduct : Product
    {
        public NullProduct()
        {
            Idx = 0;
            Name = null;
            Price = null;
            CategoryIdx = 0;
        }
    }
}