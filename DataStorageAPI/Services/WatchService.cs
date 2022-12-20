using DataStorageAPI.Context;
using DataStorageAPI.Handlers;
using DataStorageAPI.IServices;
using DataStorageAPI.Models.EntityModels;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DataStorageAPI.Models.Input.WatchInputModel;

namespace DataStorageAPI.Services
{
    /// <summary>
    /// Använder Single Responsibility Principle då alla metoder har olika ansvar.
    /// Möjligen hade metoderna kunnat lyfts ut till egna komponenter.
    /// Uppfyller möjligen Open-Closed Principle då classen är öppet för ny implementering.
    /// Möjligen Liskov substitution principle då modellerna i classerna kan bytas ut, med viss korrigering.
    /// Interface segregation principle kanske kan appliceras då modellen har ett interface som kontrakt.
    /// </summary>

    public class WatchService : IGenericService<
        WatchViewModel,
        CreateWatchInputModel,
        UpdateWatchInputModel>
    {
        private readonly DataContext _context;
        private readonly WatchHandler _watchHandler;

        public WatchService(
            DataContext context, 
            WatchHandler watchHandler)
        {
            _context = context;
            _watchHandler = watchHandler;
        }

        public async Task<ActionResult<WatchViewModel>> CreateAsync(CreateWatchInputModel model)
        {
            var watch = new WatchEntityModel(
                   model.Waterproof,
                   model.Display,
                   model.ClockWork,
                   model.Closure);

            await _watchHandler.CreateUpdateProducts(model, watch);

            _context.Watches.Add(watch);
            await _context.SaveChangesAsync();

            return _watchHandler.ReturnWatches(watch);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var watch = await _context.Watches.FindAsync(id);
            _context.Watches.Remove(watch);
            await _context.SaveChangesAsync();

            return (IActionResult)watch;
        }

        public async Task<ActionResult<IEnumerable<WatchViewModel>>> GetAllAsync()
        {
            var watches = new List<WatchViewModel>();

            foreach (var watch in await _context.Watches
                .Include(x => x.ProductItems)
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories)
                .ToListAsync())

                _watchHandler.GetWatches(watches, watch);

            return watches;
        }

        public async Task<ActionResult<IEnumerable<WatchViewModel>>> GetBrandAsync(string brand)
        {
            var watches = new List<WatchViewModel>();

            foreach (var watch in await _context.Watches
                .Include(x => x.ProductItems).Where(x => x.ProductItems.BrandName.Equals(brand))
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories)
                .ToListAsync())

                _watchHandler.GetWatches(watches, watch);

            return watches;
        }

        public async Task<ActionResult<IEnumerable<WatchViewModel>>> GetBrandCategoryAsync(string brand, string category)
        {
            var watches = new List<WatchViewModel>();

            foreach (var watch in await _context.Watches
                .Include(x => x.ProductItems).Where(x => x.ProductItems.BrandName.Equals(brand))
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories).Where(x => x.Categories.CategoryName.Equals(category))
                .ToListAsync())

                _watchHandler.GetWatches(watches, watch);

            return watches;
        }

        public async Task<ActionResult<IEnumerable<WatchViewModel>>> GetCategoryAsync(string category)
        {
            var watches = new List<WatchViewModel>();

            foreach (var watch in await _context.Watches
                .Include(x => x.ProductItems)
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories).Where(x => x.Categories.CategoryName.Equals(category))
                .ToListAsync())

                _watchHandler.GetWatches(watches, watch);

            return watches;
        }

        public async Task<ActionResult<WatchViewModel>> GetOneAsync(int id)
        {
            var watch = await _context.Watches
                    .Include(x => x.ProductItems)
                    .Include(x => x.ProductDetails)
                    .Include(x => x.Categories)
                    .FirstOrDefaultAsync(x => x.Id == id);

            return _watchHandler.ReturnWatches(watch);
        }

        public async Task<ActionResult<UpdateWatchInputModel>> UpdateAsync(int id, UpdateWatchInputModel model)
        {
            var watch = await _context.Watches.FindAsync(model.Id);
                watch.Waterproof = model.Waterproof;
                watch.Display = model.Display;
                watch.ClockWork = model.ClockWork;
                watch.Closure = model.Closure;

            await _watchHandler.CreateUpdateProducts(model, watch);

            _context.Entry(watch).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return model;
        }
    }
}
