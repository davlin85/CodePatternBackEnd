using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataStorageAPI.Models.Interfaces;

namespace DataStorageAPI.Models.EntityModels
{
    /// <summary>
    /// Använder Single Responsibility Principle för att entiteten har ett ansvar.
    /// </summary>
    
    public class ProductDetailEntityModel : IProductDetail
    {
        public ProductDetailEntityModel()
        {
        }

        public ProductDetailEntityModel(
            string color, 
            decimal price, 
            string size, 
            decimal rating, 
            decimal quantity)
        {
            Color = color;
            Price = price;
            Size = size;
            Rating = rating;
            Quantity = quantity;
        }

        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Color { get; set; } = null!;

        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; } = 0!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Size { get; set; } = null!;

        [Required, Column(TypeName = "decimal(1,0)")]
        public decimal Rating { get; set; } = 0!;

        [Required, Column(TypeName = "decimal(8,2)")]
        public decimal Quantity { get; set; } = 0!;


        public virtual ICollection<JacketEntityModel> Jackets { get; set; }
        public virtual ICollection<JeansEntityModel> Jeans { get; set; }
        public virtual ICollection<ShoesEntityModel> Shoes { get; set; } 
        public virtual ICollection<WatchEntityModel> Watches { get; set; }
    }
}