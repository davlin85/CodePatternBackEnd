using DataStorageAPI.Models.Interfaces;

namespace DataStorageAPI.Models.ViewModels
{
    /// <summary>
    /// Använder Single Responsibility Principle då modellen har ett ansvar.
    /// Uppfyller även Open-Closed Principle då classen är öppet för ny implementering.
    /// Interface segregation principle då alla modeller består av olika interfaces.
    /// </summary>

    public class JacketViewModel : IJacket, IProductItem, IProductDetail, ICategory
    {
        public JacketViewModel(
            int id,
            string articleNumber,
            string brandName,
            string productName,
            string shortDescription,
            string fit, 
            string cut, 
            string length, 
            string backWidth, 
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
            Fit = fit;
            Cut = cut;
            Length = length;
            BackWidth = backWidth;
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
        public string Fit { get; set ; }
        public string Cut { get; set; }
        public string Length { get; set; }
        public string BackWidth { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public decimal Rating { get; set; }
        public decimal Quantity { get; set; }
        public string CategoryName { get; set; }
    }
}
