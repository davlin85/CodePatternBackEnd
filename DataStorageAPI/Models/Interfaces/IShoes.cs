namespace DataStorageAPI.Models.Interfaces
{
    /// <summary>
    /// Använder Single Responsibility Principle för alla interfaces för att särskilja modeller och entiteter.
    /// Uppfyller även Open-Closed Principle då interfacet är öppet för ny implementering.
    /// Interface segregation principle då alla interfaces består av små komponenter.
    /// </summary>

    public interface IShoes
    {
        public string Lining { get; set; }
        public string Insole { get; set; }
        public string Sole { get; set; }
        public string Closure { get; set; }
    }
}
 