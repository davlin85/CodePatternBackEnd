using DataStorageAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataStorageAPI.Models.EntityModels
{
    /// <summary>
    /// Använder Single Responsibility Principle för att entiteten har ett ansvar.
    /// Interface segregation principle då alla entiteter består av interfaces.
    /// </summary>
    public class WatchEntityModel : IWatch
    {
        public WatchEntityModel()
        {
        }

        public WatchEntityModel(
            string waterproof, 
            string display, 
            string clockWork, 
            string closure)
        {
            Waterproof = waterproof;
            Display = display;
            ClockWork = clockWork;
            Closure = closure;
        }

        [Key] 
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Waterproof { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Display { get; set; } = null!;

        [Required, Column(TypeName = "nvarchar(20)")]
        public string ClockWork { get; set; } = null!;

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
