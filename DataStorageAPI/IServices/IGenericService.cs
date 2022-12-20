using Microsoft.AspNetCore.Mvc;

namespace DataStorageAPI.IServices
{
    /// <summary>
    /// Använder Single Responsibility Principle då interfacet ansvarar för kontraktet för alla controllers.
    /// Uppfyller även Open-Closed Principle då interfacet är öppet för ny implementering.
    /// Möjligen att det uppfyller Interface segregation principle.
    /// Uppfyller Liskov substitution principle.
    /// </summary>

    public interface IGenericService<T, T2, T3>
    {
        Task<ActionResult<IEnumerable<T>>> GetAllAsync();
        Task<ActionResult<T>> GetOneAsync(int id);
        Task<ActionResult<IEnumerable<T>>> GetBrandAsync(string brand);
        Task<ActionResult<IEnumerable<T>>> GetCategoryAsync(string category);
        Task<ActionResult<IEnumerable<T>>> GetBrandCategoryAsync(string brand, string category);
        Task<ActionResult<T>> CreateAsync(T2 model);
        Task<ActionResult<T3>> UpdateAsync(int id, T3 model);
        Task<IActionResult> DeleteAsync(int id);
    }
}
