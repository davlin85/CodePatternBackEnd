﻿namespace DataStorageAPI.Models.Interfaces
{
    /// <summary>
    /// Använder Single Responsibility Principle för alla interfaces för att särskilja modeller och entiteter.
    /// Uppfyller även Open-Closed Principle då interfacet är öppet för ny implementering.
    /// Interface segregation principle då alla interfaces består av små komponenter.
    /// </summary>

    public interface IProductDetail
    {
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public decimal Rating { get; set; }
        public decimal Quantity { get; set; }

    }
}
 