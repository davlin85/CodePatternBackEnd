namespace DataStorageAPI.Models.Interfaces
{
    /// <summary>
    /// Använder Single Responsibility Principle för alla interfaces för att särskilja modeller och entiteter.
    /// Uppfyller även Open-Closed Principle då interfacet är öppet för ny implementering.
    /// Interface segregation principle då alla interfaces består av små komponenter.
    /// </summary>

    public interface IJacket
    {
        public string Fit { get; set; }
        public string Cut { get; set; }
        public string Length { get; set; }
        public string BackWidth { get; set; }

    }
}
