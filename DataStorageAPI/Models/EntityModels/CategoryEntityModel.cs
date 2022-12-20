using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataStorageAPI.Models.Interfaces;

namespace DataStorageAPI.Models.EntityModels
{
    /// <summary>
    /// Använder Single Responsibility Principle för att entiteten har ett ansvar.
    /// Interface segregation principle då alla entiteter består av interfaces.
    /// </summary>

    public class CategoryEntityModel : ICategory
    {
        public CategoryEntityModel()
        {
        }

        public CategoryEntityModel(
            string categoryName)
        {
            CategoryName = categoryName;
        }

        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(50)")]
        public string CategoryName { get; set; } = null!;


        public virtual ICollection<JacketEntityModel> Jackets { get; set; }
        public virtual ICollection<JeansEntityModel> Jeans { get; set; }
        public virtual ICollection<ShoesEntityModel> Shoes { get; set; }
        public virtual ICollection<WatchEntityModel> Watches { get; set; }
    }
}
