using DataStorageAPI.Context;
using DataStorageAPI.Handlers;
using DataStorageAPI.IServices;
using DataStorageAPI.Models.EntityModels;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DataStorageAPI.Models.Input.JeansInputModel;

namespace DataStorageAPI.Services
{
    /// <summary>
    /// Använder Single Responsibility Principle då alla metoder har olika ansvar.
    /// Möjligen hade metoderna kunnat lyfts ut till egna komponenter.
    /// Uppfyller möjligen Open-Closed Principle då classen är öppet för ny implementering.
    /// Möjligen Liskov substitution principle då modellerna i classerna kan bytas ut, med viss korrigering.
    /// Interface segregation principle kanske kan appliceras då modellen har ett interface som kontrakt.
    /// </summary>

    public class JeansService : IGenericService<
        JeansViewModel,
        CreateJeansInputModel,
        UpdateJeansInputModel>
    {
        private readonly DataContext _context;
        private readonly JeansHandler _jeansHandler;

        public JeansService(
            DataContext context,
            JeansHandler jeansHandler)
        {
            _context = context;
            _jeansHandler = jeansHandler;
        }

        public async Task<ActionResult<JeansViewModel>> CreateAsync(CreateJeansInputModel model)
        {
            var jeans = new JeansEntityModel(
                   model.Closure,
                   model.Pockets,
                   model.Fit);

            await _jeansHandler.CreateUpdateProducts(model, jeans);

            _context.Jeans.Add(jeans);
            await _context.SaveChangesAsync();

            return _jeansHandler.ReturnJeans(jeans);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var jeans = await _context.Jeans.FindAsync(id);
            _context.Jeans.Remove(jeans);
            await _context.SaveChangesAsync();

            return (IActionResult)jeans;
        }

        public async Task<ActionResult<IEnumerable<JeansViewModel>>> GetAllAsync()
        {
            var jeanss = new List<JeansViewModel>();

            foreach (var jeans in await _context.Jeans
                .Include(x => x.ProductItems)
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories)
                .ToListAsync())

                _jeansHandler.GetJeans(jeanss, jeans);

            return jeanss;
        }

        public async Task<ActionResult<IEnumerable<JeansViewModel>>> GetBrandAsync(string brand)
        {
            var jeanss = new List<JeansViewModel>();

            foreach (var jeans in await _context.Jeans
                .Include(x => x.ProductItems).Where(x => x.ProductItems.BrandName.Equals(brand))
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories)
                .ToListAsync())

                _jeansHandler.GetJeans(jeanss, jeans);

            return jeanss;
        }

        public async Task<ActionResult<IEnumerable<JeansViewModel>>> GetBrandCategoryAsync(string brand, string category)
        {
            var jeanss = new List<JeansViewModel>();

            foreach (var jeans in await _context.Jeans
                .Include(x => x.ProductItems).Where(x => x.ProductItems.BrandName.Equals(brand))
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories).Where(x => x.Categories.CategoryName.Equals(category))
                .ToListAsync())

                _jeansHandler.GetJeans(jeanss, jeans);

            return jeanss;
        }

        public async Task<ActionResult<IEnumerable<JeansViewModel>>> GetCategoryAsync(string category)
        {
            var jeanss = new List<JeansViewModel>();

            foreach (var jeans in await _context.Jeans
                .Include(x => x.ProductItems)
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories).Where(x => x.Categories.CategoryName.Equals(category))
                .ToListAsync())

                _jeansHandler.GetJeans(jeanss, jeans);

            return jeanss;
        }

        public async Task<ActionResult<JeansViewModel>> GetOneAsync(int id)
        {
            var jeans = await _context.Jeans
                    .Include(x => x.ProductItems)
                    .Include(x => x.ProductDetails)
                    .Include(x => x.Categories)
                    .FirstOrDefaultAsync(x => x.Id == id);

            return _jeansHandler.ReturnJeans(jeans);
        }

        public async Task<ActionResult<UpdateJeansInputModel>> UpdateAsync(int id, UpdateJeansInputModel model)
        {
            var jeans = await _context.Jeans.FindAsync(model.Id);
                jeans.Closure = model.Closure;
                jeans.Pockets = model.Pockets;
                jeans.Fit = model.Fit;

            await _jeansHandler.CreateUpdateProducts(model, jeans);

            _context.Entry(jeans).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return model;
        }
    }
}
