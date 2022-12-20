namespace DataStorageAPI.Models.Interfaces
{
    /// <summary>
    /// Använder Single Responsibility Principle för alla interfaces för att särskilja modeller och entiteter.
    /// Uppfyller även Open-Closed Principle då interfacet är öppet för ny implementering.
    /// Interface segregation principle då alla interfaces består av små komponenter.
    /// </summary>

    public interface IProductItem
    {
        public string ArticleNumber { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
    }
}
