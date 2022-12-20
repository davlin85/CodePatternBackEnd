using DataStorageAPI.Models.Interfaces;

namespace DataStorageAPI.Models.ViewModels
{
    /// <summary>
    /// Använder Single Responsibility Principle då modellen har ett ansvar.
    /// Uppfyller även Open-Closed Principle då classen är öppet för ny implementering.
    /// Interface segregation principle då alla modeller består av olika interfaces.
    /// </summary>

    public class WatchViewModel : IWatch, IProductItem, IProductDetail, ICategory
    {
        public WatchViewModel(
            int id,
            string articleNumber,
            string brandName,
            string productName,
            string shortDescription,
            string waterproof, 
            string display, 
            string clockWork, 
            string closure, 
            string color, 
            decimal price, 
            string size, 
            decimal rating, 
            decimal quantity, 
            string categoryName)
        {
            Id = id;
            ArticleNumber = articleNumber;
            BrandName = brandName;
            ProductName = productName;
            ShortDescription = shortDescription;
            Waterproof = waterproof;
            Display = display;
            ClockWork = clockWork;
            Closure = closure;
            Color = color;
            Price = price;
            Size = size;
            Rating = rating;
            Quantity = quantity;
            CategoryName = categoryName;
        }

        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string Waterproof { get; set; }
        public string Display { get; set; }
        public string ClockWork { get; set; }
        public string Closure { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public decimal Rating { get; set; }
        public decimal Quantity { get; set; }
        public string CategoryName { get; set; }
    }
}
