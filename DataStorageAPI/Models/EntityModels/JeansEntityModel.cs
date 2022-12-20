using DataStorageAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataStorageAPI.Models.EntityModels

{    /// <summary>
     /// Använder Single Responsibility Principle för att entiteten har ett ansvar.
     /// Interface segregation principle då alla entiteter består av interfaces.
     /// </summary>

    public class JeansEntityModel : IJeans
    {
        public JeansEntityModel()
        {
        }

        public JeansEntityModel(
            string closure, 
            string pockets, 
            string fit)
        {
            Closure = closure;
            Pockets = pockets;
            Fit = fit;
        }

        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Closure { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Pockets { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Fit { get; set; } = null!;


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
  