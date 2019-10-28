using System.ComponentModel.DataAnnotations;

namespace StoreExample.Modules.Category
{
    public class Category : ICategory
    {  
        [Key]
        public virtual int Idx { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public virtual string Name { get; set; }

        protected Category(){}
    }
    public class NullCategory : Category
    {} 
}