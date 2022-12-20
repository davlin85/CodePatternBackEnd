using DataStorageAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataStorageAPI.Models.EntityModels
{
    /// <summary>
    /// Använder Single Responsibility Principle för att entiteten har ett ansvar.
    /// Interface segregation principle då alla entiteter består av interfaces.
    /// </summary>

    public class ProductItemEntityModel : IProductItem
    {
        public ProductItemEntityModel()
        {
        }

        public ProductItemEntityModel(
            string articleNumber, 
            string brandName, 
            string productName, 
            string shortDescription)
        {
            ArticleNumber = articleNumber;
            BrandName = brandName;
            ProductName = productName;
            ShortDescription = shortDescription;
        }

        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(20)")]
        public string ArticleNumber { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string BrandName { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string ProductName { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(max)")]
        public string ShortDescription { get; set; } = null!;


        public virtual ICollection<JacketEntityModel> Jackets { get; set; }
        public virtual ICollection<JeansEntityModel> Jeans { get; set; }
        public virtual ICollection<ShoesEntityModel> Shoes { get; set; }
        public virtual ICollection<WatchEntityModel> Watches { get; set; }
    }
}
 