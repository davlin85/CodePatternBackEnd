using DataStorageAPI.Context;
using DataStorageAPI.Handlers;
using DataStorageAPI.IServices;
using DataStorageAPI.Models.EntityModels;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DataStorageAPI.Models.Input.ShoesInputModel;

namespace DataStorageAPI.Services
{
    /// <summary>
    /// Använder Single Responsibility Principle då alla metoder har olika ansvar.
    /// Möjligen hade metoderna kunnat lyfts ut till egna komponenter.
    /// Uppfyller möjligen Open-Closed Principle då classen är öppet för ny implementering.
    /// Möjligen Liskov substitution principle då modellerna i classerna kan bytas ut, med viss korrigering.
    /// Interface segregation principle kanske kan appliceras då modellen har ett interface som kontrakt.
    /// </summary>

    public class ShoesService : IGenericService<
        ShoesViewModel,
        CreateShoesInputModel,
        UpdateShoesInputModel>
    {
        private readonly DataContext _context;
        private readonly ShoesHandler _shoesHandler;

        public ShoesService(
            DataContext context, 
            ShoesHandler shoesHandler)
        {
            _context = context;
            _shoesHandler = shoesHandler;
        }

        public async Task<ActionResult<ShoesViewModel>> CreateAsync(CreateShoesInputModel model)
        {
            var shoes = new ShoesEntityModel(
                   model.Lining,
                   model.Insole,
                   model.Sole,
                   model.Closure);

            await _shoesHandler.CreateUpdateProducts(model, shoes);

            _context.Shoes.Add(shoes);
            await _context.SaveChangesAsync();

            return _shoesHandler.ReturnShoes(shoes);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var shoes = await _context.Shoes.FindAsync(id);
            _context.Shoes.Remove(shoes);
            await _context.SaveChangesAsync();

            return (IActionResult)shoes;
        }

        public async Task<ActionResult<IEnumerable<ShoesViewModel>>> GetAllAsync()
        {
            var shoess = new List<ShoesViewModel>();

            foreach (var shoes in await _context.Shoes
                .Include(x => x.ProductItems)
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories)
                .ToListAsync())

                _shoesHandler.GetShoes(shoess, shoes);

            return shoess;
        }

        public async Task<ActionResult<IEnumerable<ShoesViewModel>>> GetBrandAsync(string brand)
        {
            var shoess = new List<ShoesViewModel>();

            foreach (var shoes in await _context.Shoes
                .Include(x => x.ProductItems).Where(x => x.ProductItems.BrandName.Equals(brand))
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories)
                .ToListAsync())

                _shoesHandler.GetShoes(shoess, shoes);

            return shoess;
        }

        public async Task<ActionResult<IEnumerable<ShoesViewModel>>> GetBrandCategoryAsync(string brand, string category)
        {
            var shoess = new List<ShoesViewModel>();

            foreach (var shoes in await _context.Shoes
                .Include(x => x.ProductItems).Where(x => x.ProductItems.BrandName.Equals(brand))
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories).Where(x => x.Categories.CategoryName.Equals(category))
                .ToListAsync())

                _shoesHandler.GetShoes(shoess, shoes);

            return shoess;
        }

        public async Task<ActionResult<IEnumerable<ShoesViewModel>>> GetCategoryAsync(string category)
        {
            var shoess = new List<ShoesViewModel>();

            foreach (var shoes in await _context.Shoes
                .Include(x => x.ProductItems)
                .Include(x => x.ProductDetails)
                .Include(x => x.Categories).Where(x => x.Categories.CategoryName.Equals(category))
                .ToListAsync())

                _shoesHandler.GetShoes(shoess, shoes);

            return shoess;
        }

        public async Task<ActionResult<ShoesViewModel>> GetOneAsync(int id)
        {
            var shoes = await _context.Shoes
                    .Include(x => x.ProductItems)
                    .Include(x => x.ProductDetails)
                    .Include(x => x.Categories)
                    .FirstOrDefaultAsync(x => x.Id == id);

            return _shoesHandler.ReturnShoes(shoes);
        }

        public async Task<ActionResult<UpdateShoesInputModel>> UpdateAsync(int id, UpdateShoesInputModel model)
        {
            var shoes = await _context.Shoes.FindAsync(model.Id);
                shoes.Lining = model.Lining;
                shoes.Insole = model.Insole;
                shoes.Sole = model.Sole;
                shoes.Closure = model.Closure;

            await _shoesHandler.CreateUpdateProducts(model, shoes);

            _context.Entry(shoes).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return model;
        }
    }
}

