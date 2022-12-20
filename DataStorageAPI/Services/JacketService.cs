using DataStorageAPI.Context;
using DataStorageAPI.Handlers;
using DataStorageAPI.IServices;
using DataStorageAPI.Models.EntityModels;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DataStorageAPI.Models.Input.JacketInputModel;

namespace DataStorageAPI.Services 
{
    /// <summary>
    /// Använder Single Responsibility Principle då alla metoder har olika ansvar.
    /// Möjligen hade metoderna kunnat lyfts ut till egna komponenter.
    /// Uppfyller möjligen Open-Closed Principle då classen är öppet för ny implementering.
    /// Möjligen Liskov substitution principle då modellerna i classerna kan bytas ut, med viss korrigering.
    /// Interface segregation principle kanske kan appliceras då modellen har ett interface som kontrakt.
    /// </summary>

    public class JacketService : IGenericService<
        JacketViewModel,
        CreateJacketInputModel,
        UpdateJacketInputModel>
    {
        private readonly DataContext _context;
        private readonly JacketHandler _jacketHandler;

        public JacketService(
            DataContext context, 
            JacketHandler jacketHandler)
        {
            _context = context;
            _jacketHandler = jacketHandler;
        }

        public async Task<ActionResult<JacketViewModel>> CreateAsync(CreateJacketInputModel model)
        {
            var jacket = new JacketEntityModel(
                   model.Fit,
                   model.Cut,
                   model.Length,
                   model.BackWidth);

            await _jacketHandler.CreateUpdateProducts(model, jacket);

            _context.Jackets.Add(jacket);
            await _context.SaveChangesAsync();

            return _jacketHandler.ReturnJackets(jacket);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var jacket = await _context.Jackets.FindAsync(id);
            _context.Jackets.Remove(jacket);
            await _context.SaveChangesAsync();

            return (IActionResult)jacket;
        }

        public async Task<ActionResult<IEnumerable<JacketViewModel>>> GetAllAsync()
        {
            var jackets = new List<JacketViewModel>();

            foreach (var jacket in await _context.Jackets
                .Include(x => x.ProductItems)
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories)
                .ToListAsync())

                _jacketHandler.GetJackets(jackets, jacket);

            return jackets;
        }

        public async Task<ActionResult<IEnumerable<JacketViewModel>>> GetBrandAsync(string brand)
        {
            var jackets = new List<JacketViewModel>();

            foreach (var jacket in await _context.Jackets
                .Include(x => x.ProductItems).Where(x => x.ProductItems.BrandName.Equals(brand))
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories)
                .ToListAsync())

                _jacketHandler.GetJackets(jackets, jacket);

            return jackets;
        }

        public async Task<ActionResult<IEnumerable<JacketViewModel>>> GetBrandCategoryAsync(string brand, string category)
        {
            var jackets = new List<JacketViewModel>();

            foreach (var jacket in await _context.Jackets
                .Include(x => x.ProductItems).Where(x => x.ProductItems.BrandName.Equals(brand))
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories).Where(x => x.Categories.CategoryName.Equals(category))
                .ToListAsync())

                _jacketHandler.GetJackets(jackets, jacket);

            return jackets;
        }

        public async Task<ActionResult<IEnumerable<JacketViewModel>>> GetCategoryAsync(string category)
        {
            var jackets = new List<JacketViewModel>();

            foreach (var jacket in await _context.Jackets
                .Include(x => x.ProductItems)
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories).Where(x => x.Categories.CategoryName.Equals(category))
                .ToListAsync())

                _jacketHandler.GetJackets(jackets, jacket);

            return jackets;
        }

        public async Task<ActionResult<JacketViewModel>> GetOneAsync(int id)
        {
            var jacket = await _context.Jackets
                    .Include(x => x.ProductItems)
                    .Include(x => x.ProductDetails)
                    .Include(x => x.Categories)
                    .FirstOrDefaultAsync(x => x.Id == id);

            return _jacketHandler.ReturnJackets(jacket);
        }

        public async Task<ActionResult<UpdateJacketInputModel>> UpdateAsync(int id, UpdateJacketInputModel model)
        {
            var jacket = await _context.Jackets.FindAsync(model.Id);
                jacket.Fit = model.Fit;
                jacket.Cut = model.Cut;
                jacket.Length = model.Length;
                jacket.BackWidth = model.BackWidth;

            await _jacketHandler.CreateUpdateProducts(model, jacket);

            _context.Entry(jacket).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return model;
        }
    }
}
