using DataStorageAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataStorageAPI.Models.EntityModels
{
    /// <summary>
    /// Använder Single Responsibility Principle för att entiteten har ett ansvar.
    /// Interface segregation principle då alla entiteter består av interfaces.
    /// </summary>

    public class ShoesEntityModel : IShoes
    {
        public ShoesEntityModel()
        {
        }

        public ShoesEntityModel(
            string lining, 
            string insole, 
            string sole, 
            string closure)
        {
            Lining = lining;
            Insole = insole;
            Sole = sole;
            Closure = closure;
        }

        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Lining { get; set; } = null!; 

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Insole { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Sole { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Closure { get; set; } = null!;


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
