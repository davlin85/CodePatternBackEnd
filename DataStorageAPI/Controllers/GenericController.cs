using DataStorageAPI.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DataStorageAPI.Controllers
{
    /// <summary>
    /// Använder Single Responsibility Principle då alla metoder har olika ansvar.
    /// Uppfyller även Open-Closed Principle då controllern är öppet för ny implementering.
    /// Uppfyller Liskov substitution principle då classen är en generisk controller och applicerbar för alla controllers.
    /// </summary>

    [ApiController]
    public class GenericController<T, T2, T3> : ControllerBase where T : class
    {
        private readonly IGenericService<T, T2, T3> _genericService;

        public GenericController(IGenericService<T, T2, T3> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet]
        [Route("[controller]/get-all")]
        public Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            return _genericService.GetAllAsync();
        }

        [HttpGet]
        [Route("[controller]/get-one/{id}")]
        public Task<ActionResult<T>> GetOne(int id)
        {
            return _genericService.GetOneAsync(id);
        }

        [HttpGet]
        [Route("[controller]/get-brand/{brand}")]
        public Task<ActionResult<IEnumerable<T>>> GetBrand(string brand)
        {
            return _genericService.GetBrandAsync(brand);
        }

        [HttpGet]
        [Route("[controller]/get-category/{category}")]
        public Task<ActionResult<IEnumerable<T>>> GetCategory(string category)
        {
            return _genericService.GetCategoryAsync(category);
        }

        [HttpGet]
        [Route("[controller]/get-brand-category/{brand}/{category}")]
        public Task<ActionResult<IEnumerable<T>>> GetBrandCategory(string brand, string category)
        {
            return _genericService.GetBrandCategoryAsync(brand, category);
        }

        [HttpPost]
        [Route("[controller]/create")]
        public Task<ActionResult<T>> Create(T2 model)
        {
            return _genericService.CreateAsync(model);
        }

        [HttpPut]
        [Route("[controller]/update/{id}")]
        public Task<ActionResult<T3>> Update(int id, T3 model)
        {
            return _genericService.UpdateAsync(id, model);
        }

        [HttpDelete]
        [Route("[controller]/delete/{id}")]
        public Task<IActionResult> Delete(int id)
        {
            return _genericService.DeleteAsync(id);
        }
    }
}