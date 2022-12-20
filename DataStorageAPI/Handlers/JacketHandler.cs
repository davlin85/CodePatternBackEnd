using DataStorageAPI.Context;
using DataStorageAPI.Models.EntityModels;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DataStorageAPI.Models.Input.JacketInputModel;

namespace DataStorageAPI.Handlers
{
    /// <summary>
    /// Använder Single Responsibility Principle då alla metoder har olika ansvar.
    /// Framförallt är tanken är undvika upprepande kod, därför har återkommande kod lagts i egna handlers.
    /// </summary>
    
    public class JacketHandler
    {
        private readonly DataContext _context;

        public JacketHandler(DataContext context)
        {
            _context = context;
        }

        public ActionResult<JacketViewModel> ReturnJackets(JacketEntityModel jacket)
        {
            return new JacketViewModel(
                jacket.Id,
                jacket.ProductItems.ArticleNumber,
                jacket.ProductItems.BrandName,
                jacket.ProductItems.ProductName,
                jacket.ProductItems.ShortDescription,
                jacket.Fit,
                jacket.Cut,
                jacket.Length,
                jacket.BackWidth,
                jacket.ProductDetails.Color,
                jacket.ProductDetails.Price,
                jacket.ProductDetails.Size,
                jacket.ProductDetails.Rating,
                jacket.ProductDetails.Quantity,
                jacket.Categories.CategoryName);
        }

        public void GetJackets(List<JacketViewModel> jackets, JacketEntityModel jacket)
        {
            jackets.Add(new JacketViewModel(
                jacket.Id,
                jacket.ProductItems.ArticleNumber,
                jacket.ProductItems.BrandName,
                jacket.ProductItems.ProductName,
                jacket.ProductItems.ShortDescription,
                jacket.Fit,
                jacket.Cut,
                jacket.Length,
                jacket.BackWidth,
                jacket.ProductDetails.Color,
                jacket.ProductDetails.Price,
                jacket.ProductDetails.Size,
                jacket.ProductDetails.Rating,
                jacket.ProductDetails.Quantity,
                jacket.Categories.CategoryName));
        }

        public async Task CreateUpdateProducts(CreateJacketInputModel model, JacketEntityModel jacket)
        {
            var item = await _context.ProductItems.FirstOrDefaultAsync(x =>
                x.ArticleNumber == model.ArticleNumber &&
                x.BrandName == model.BrandName &&
                x.ProductName == model.ProductName &&
                x.ShortDescription == model.ShortDescription);

            if (item != null)
            {
                jacket.ProductItemsId = item.Id;
            }
            else
            {
                jacket.ProductItems = new ProductItemEntityModel(
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
                jacket.ProductDetailsId = detail.Id;
            }
            else
            {
                jacket.ProductDetails = new ProductDetailEntityModel(
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
                jacket.CategoriesId = category.Id;
            }
            else
            {
                jacket.Categories = new CategoryEntityModel(
                    model.CategoryName);
            }
        }
    }
}
 