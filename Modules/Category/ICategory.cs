using System.ComponentModel.DataAnnotations;

namespace StoreExample.Modules.Category
{
    public interface ICategory
    {
        [Key]
        int Idx { get; set; }
        string Name { get; set; }
    }
}