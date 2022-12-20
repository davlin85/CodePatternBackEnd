using DataStorageAPI.Context;
using DataStorageAPI.Models.EntityModels;
using DataStorageAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DataStorageAPI.Models.Input.JeansInputModel;

namespace DataStorageAPI.Handlers
{
    /// <summary>
    /// Använder Single Responsibility Principle då alla metoder har olika ansvar.
    /// Framförallt är tanken är undvika upprepande kod, därför har återkommande kod lagts i egna handlers.
    /// </summary>
    
    public class JeansHandler
    {
        private readonly DataContext _context;

        public JeansHandler(DataContext context)
        {
            _context = context;
        }

        public ActionResult<JeansViewModel> ReturnJeans(JeansEntityModel jeans)
        {
            return new JeansViewModel(
                jeans.Id,
                jeans.ProductItems.ArticleNumber,
                jeans.ProductItems.BrandName,
                jeans.ProductItems.ProductName,
                jeans.ProductItems.ShortDescription,
                jeans.Closure,
                jeans.Pockets,
                jeans.Fit,
                jeans.ProductDetails.Color,
                jeans.ProductDetails.Price,
                jeans.ProductDetails.Size,
                jeans.ProductDetails.Rating,
                jeans.ProductDetails.Quantity,
                jeans.Categories.CategoryName);
        }

        public void GetJeans(List<JeansViewModel> jeanss, JeansEntityModel jeans)
        {
            jeanss.Add(new JeansViewModel(
                jeans.Id,
                jeans.ProductItems.ArticleNumber,
                jeans.ProductItems.BrandName,
                jeans.ProductItems.ProductName,
                jeans.ProductItems.ShortDescription,
                jeans.Closure,
                jeans.Pockets,
                jeans.Fit,
                jeans.ProductDetails.Color,
                jeans.ProductDetails.Price,
                jeans.ProductDetails.Size,
                jeans.ProductDetails.Rating,
                jeans.ProductDetails.Quantity,
                jeans.Categories.CategoryName));
        }

        public async Task CreateUpdateProducts(CreateJeansInputModel model, JeansEntityModel jeans)
        {
            var item = await _context.ProductItems.FirstOrDefaultAsync(x =>
                x.ArticleNumber == model.ArticleNumber &&
                x.BrandName == model.BrandName &&
                x.ProductName == model.ProductName &&
                x.ShortDescription == model.ShortDescription);

            if (item != null)
            {
                jeans.ProductItemsId = item.Id;
            }
            else
            {
                jeans.ProductItems = new ProductItemEntityModel(
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
                jeans.ProductDetailsId = detail.Id;
            }
            else
            {
                jeans.ProductDetails = new ProductDetailEntityModel(
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
                jeans.CategoriesId = category.Id;
            }
            else
            {
                jeans.Categories = new CategoryEntityModel(
                    model.CategoryName);
            }
        }
    }
}

