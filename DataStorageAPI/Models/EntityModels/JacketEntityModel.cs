using DataStorageAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataStorageAPI.Models.EntityModels
{
    /// <summary>
    /// Använder Single Responsibility Principle för att entiteten har ett ansvar.
    /// Interface segregation principle då alla entiteter består av interfaces.
    /// </summary>

    public class JacketEntityModel : IJacket
    {
        public JacketEntityModel()
        {
        }

        public JacketEntityModel(
            string fit, 
            string cut, 
            string length, 
            string backWidth)
        {
            Fit = fit;
            Cut = cut;
            Length = length;
            BackWidth = backWidth;
        }

        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Fit { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Cut { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Length { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string BackWidth { get; set; } = null!;


        [Required]
        public int ProductItemsId { get; set; }
        public virtual ProductItemEntityModel ProductItems { get; set; } = null!;

        [Required]
        public int ProductDetailsId { get; set; }
        public virtual ProductDetailEntityModel ProductDetails { get; set; } = null!;

        [Required]
        public int CategoriesId { get; set; }
        public virtual CategoryEntityModel Categories { get; set; } = null!;
    }
}
