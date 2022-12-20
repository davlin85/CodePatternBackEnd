using DataStorageAPI.Context;
using DataStorageAPI.Models.EntityModels;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DataStorageAPI.Models.Input.ShoesInputModel;

namespace DataStorageAPI.Handlers
{
    /// <summary>
    /// Använder Single Responsibility Principle då alla metoder har olika ansvar.
    /// Framförallt är tanken är undvika upprepande kod, därför har återkommande kod lagts i egna handlers.
    /// </summary>
    
    public class ShoesHandler
    {
        private readonly DataContext _context;

        public ShoesHandler(DataContext context)
        {
            _context = context;
        }

        public ActionResult<ShoesViewModel> ReturnShoes(ShoesEntityModel shoes)
        {
            return new ShoesViewModel(
                shoes.Id,
                shoes.ProductItems.ArticleNumber,
                shoes.ProductItems.BrandName,
                shoes.ProductItems.ProductName,
                shoes.ProductItems.ShortDescription,
                shoes.Lining,
                shoes.Insole,
                shoes.Sole,
                shoes.Closure,
                shoes.ProductDetails.Color,
                shoes.ProductDetails.Price,
                shoes.ProductDetails.Size,
                shoes.ProductDetails.Rating,
                shoes.ProductDetails.Quantity,
                shoes.Categories.CategoryName);
        }

        public void GetShoes(List<ShoesViewModel> shoess, ShoesEntityModel shoes)
        {
            shoess.Add(new ShoesViewModel(
                shoes.Id,
                shoes.ProductItems.ArticleNumber,
                shoes.ProductItems.BrandName,
                shoes.ProductItems.ProductName,
                shoes.ProductItems.ShortDescription,
                shoes.Lining,
                shoes.Insole,
                shoes.Sole,
                shoes.Closure,
                shoes.ProductDetails.Color,
                shoes.ProductDetails.Price,
                shoes.ProductDetails.Size,
                shoes.ProductDetails.Rating,
                shoes.ProductDetails.Quantity,
                shoes.Categories.CategoryName));
        }

        public async Task CreateUpdateProducts(CreateShoesInputModel model, ShoesEntityModel shoes)
        {
            var item = await _context.ProductItems.FirstOrDefaultAsync(x =>
                x.ArticleNumber == model.ArticleNumber &&
                x.BrandName == model.BrandName &&
                x.ProductName == model.ProductName &&
                x.ShortDescription == model.ShortDescription);

            if (item != null)
            {
                shoes.ProductItemsId = item.Id;
            }
            else
            {
                shoes.ProductItems = new ProductItemEntityModel(
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
                shoes.ProductDetailsId = detail.Id;
            }
            else
            {
                shoes.ProductDetails = new ProductDetailEntityModel(
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
                shoes.CategoriesId = category.Id;
            }
            else
            {
                shoes.Categories = new CategoryEntityModel(
                    model.CategoryName);
            }
        }
    }
}

