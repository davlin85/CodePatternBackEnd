using DataStorageAPI.Context;
using DataStorageAPI.Models.EntityModels;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DataStorageAPI.Models.Input.WatchInputModel;

namespace DataStorageAPI.Handlers
{
    /// <summary>
    /// Använder Single Responsibility Principle då alla metoder har olika ansvar.
    /// Framförallt är tanken är undvika upprepande kod, därför har återkommande kod lagts i egna handlers.
    /// </summary>
    
    public class WatchHandler
    {
        private readonly DataContext _context;

        public WatchHandler(DataContext context)
        {
            _context = context;
        }

        public ActionResult<WatchViewModel> ReturnWatches(WatchEntityModel watch)
        {
            return new WatchViewModel(
                watch.Id,
                watch.ProductItems.ArticleNumber,
                watch.ProductItems.BrandName,
                watch.ProductItems.ProductName,
                watch.ProductItems.ShortDescription,
                watch.Waterproof,
                watch.Display,
                watch.ClockWork,
                watch.Closure,
                watch.ProductDetails.Color,
                watch.ProductDetails.Price,
                watch.ProductDetails.Size,
                watch.ProductDetails.Rating,
                watch.ProductDetails.Quantity,
                watch.Categories.CategoryName);
        }

        public void GetWatches(List<WatchViewModel> watches, WatchEntityModel watch)
        {
            watches.Add(new WatchViewModel(
                watch.Id,
                watch.ProductItems.ArticleNumber,
                watch.ProductItems.BrandName,
                watch.ProductItems.ProductName,
                watch.ProductItems.ShortDescription,
                watch.Waterproof,
                watch.Display,
                watch.ClockWork,
                watch.Closure,
                watch.ProductDetails.Color,
                watch.ProductDetails.Price,
                watch.ProductDetails.Size,
                watch.ProductDetails.Rating,
                watch.ProductDetails.Quantity,
                watch.Categories.CategoryName));
        }

        public async Task CreateUpdateProducts(CreateWatchInputModel model, WatchEntityModel watch)
        {
            var item = await _context.ProductItems.FirstOrDefaultAsync(x =>
                x.ArticleNumber == model.ArticleNumber &&
                x.BrandName == model.BrandName &&
                x.ProductName == model.ProductName &&
                x.ShortDescription == model.ShortDescription);

            if (item != null)
            {
                watch.ProductItemsId = item.Id;
            }
            else
            {
                watch.ProductItems = new ProductItemEntityModel(
                    model.ArticleNumber,
                    model.BrandName,
                    model.ProductName,
                    model.ShortDescription);
            }

            var detail = await _context.ProductDetails.FirstOrDefaultAsync(x =>
                x.Color == model.Color &&
                x.Price == model.Price &&
                x.Size == model.Size &&
                x.Rating == model.Rating &&
                x.Quantity == model.Quantity);

            if (detail != null)
            {
                watch.ProductDetailsId = detail.Id;
            }
            else
            {
                watch.ProductDetails = new ProductDetailEntityModel(
                    model.Color,
                    model.Price,
                    model.Size,
                    model.Rating,
                    model.Quantity);
            }

            var category = await _context.Categories.FirstOrDefaultAsync(x =>
                x.CategoryName == model.CategoryName);

            if (category != null)
            {
                watch.CategoriesId = category.Id;
            }
            else
            {
                watch.Categories = new CategoryEntityModel(
                    model.CategoryName);
            }
        }
    }
}
