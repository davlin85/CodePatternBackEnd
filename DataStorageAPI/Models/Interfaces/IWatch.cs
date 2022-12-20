namespace DataStorageAPI.Models.Interfaces
{
    /// <summary>
    /// Använder Single Responsibility Principle för alla interfaces för att särskilja modeller och entiteter.
    /// Uppfyller även Open-Closed Principle då interfacet är öppet för ny implementering.
    /// Interface segregation principle då alla interfaces består av små komponenter.
    /// </summary>

    public interface IWatch
    {
        public string Waterproof { get; set; }
        public string Display { get; set; }
        public string ClockWork { get; set; }
        public string Closure { get; set; }

    }
}
 