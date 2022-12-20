using DataStorageAPI.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DataStorageAPI.Data
{
    /// <summary>
    /// Filen är skapad för att API:et ska ha färdiga produkter.
    /// Efter Migration och uppdatering av databasen finns nedanstående produkter klara.
    /// </summary>
    
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<JacketEntityModel>().HasData(
                   new JacketEntityModel() 
                   
                   { 
                       Id = 1,
                       Fit = "Regular Fit",
                       Cut = "Straight",
                       Length = "Normal Length",
                       BackWidth = "76 cm",
                       ProductItemsId = 1,
                       ProductDetailsId = 1,
                       CategoriesId = 1,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 1,
                        ArticleNumber = "1111-11",
                        BrandName = "Vans",
                        ProductName = "Vans Jacket",
                        ShortDescription = "New Jacket from Vans"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 1,
                        Color = "Black",
                        Price = 800,
                        Size = "M",
                        Rating = 5,
                        Quantity = 25,
                    });

            modelBuilder.Entity<JacketEntityModel>().HasData(
                   new JacketEntityModel()

                   {
                       Id = 2,
                       Fit = "Regular Fit",
                       Cut = "Straight",
                       Length = "Normal Length",
                       BackWidth = "82 cm",
                       ProductItemsId = 2,
                       ProductDetailsId = 2,
                       CategoriesId = 1,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 2,
                        ArticleNumber = "2222-11",
                        BrandName = "Nike",
                        ProductName = "Nike Jacket",
                        ShortDescription = "New Jacket from Nike"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                     new ProductDetailEntityModel()

                     {
                         Id = 2,
                         Color = "Blue",
                         Price = 500,
                         Size = "XL",
                         Rating = 2,
                         Quantity = 120,
                     });

            modelBuilder.Entity<JacketEntityModel>().HasData(
                   new JacketEntityModel()

                   {
                       Id = 3,
                       Fit = "Loose Fit",
                       Cut = "Normal Cut",
                       Length = "Loose Length",
                       BackWidth = "120 cm",
                       ProductItemsId = 3,
                       ProductDetailsId = 3,
                       CategoriesId = 1,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 3,
                        ArticleNumber = "3333-11",
                        BrandName = "Adidas",
                        ProductName = "Adidas Jacket",
                        ShortDescription = "New Jacket from Adidas"
                    });

                        modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                     new ProductDetailEntityModel()

                     {
                         Id = 3,
                         Color = "Green",
                         Price = 900,
                         Size = "L",
                         Rating = 1,
                         Quantity = 200,
                     });

            modelBuilder.Entity<JacketEntityModel>().HasData(
                   new JacketEntityModel()

                   {
                       Id = 4,
                       Fit = "Straight Fit",
                       Cut = "Normal Cut",
                       Length = "Normal Length",
                       BackWidth = "80 cm",
                       ProductItemsId = 4,
                       ProductDetailsId = 4,
                       CategoriesId = 1,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                  new ProductItemEntityModel()

                  {
                      Id = 4,
                      ArticleNumber = "4444-11",
                      BrandName = "Reebok",
                      ProductName = "Reebok Jacket",
                      ShortDescription = "New Jacket from Reebok"
                  });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                     Id = 4,
                     Color = "Yellow",
                     Price = 600,
                     Size = "S",
                     Rating = 5,
                     Quantity = 12,
                    });


            modelBuilder.Entity<JeansEntityModel>().HasData(
                   new JeansEntityModel()
                   {
                       Id = 1,
                       Closure = "Normal Closure",
                       Pockets = "4 pockets",
                       Fit = "Skinny Fit",
                       ProductItemsId = 5,
                       ProductDetailsId = 5,
                       CategoriesId = 2,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 5,
                        ArticleNumber = "5555-11",
                        BrandName = "Vans ",
                        ProductName = "Vans Jeans",
                        ShortDescription = "New Jeans from Vans"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 5,
                        Color = "Blue",
                        Price = 1200,
                        Size = "M",
                        Rating = 5,
                        Quantity = 29,
                    });

            modelBuilder.Entity<JeansEntityModel>().HasData(
                   new JeansEntityModel()
                   {
                       Id = 2,
                       Closure = "Normal Closure",
                       Pockets = "4 pockets",
                       Fit = "Loose Fit",
                       ProductItemsId = 6,
                       ProductDetailsId = 6,
                       CategoriesId = 2,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 6,
                        ArticleNumber = "6666-11",
                        BrandName = "Nike",
                        ProductName = "Nike Jeans",
                        ShortDescription = "New Jeans from Nike"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 6,
                        Color = "Purple",
                        Price = 1100,
                        Size = "XL",
                        Rating = 3,
                        Quantity = 30,
                    });

            modelBuilder.Entity<JeansEntityModel>().HasData(
                   new JeansEntityModel()
                   {
                       Id = 3,
                       Closure = "Normal Closure",
                       Pockets = "N4 Pockets",
                       Fit = "Straight Fit",
                       ProductItemsId = 7,
                       ProductDetailsId = 7,
                       CategoriesId = 2,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 7,
                        ArticleNumber = "7777-11",
                        BrandName = "Adidas",
                        ProductName = "Adidas Jeans",
                        ShortDescription = "New Jeans from Adidas"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 7,
                        Color = "Green",
                        Price = 1900,
                        Size = "XXL",
                        Rating = 5,
                        Quantity = 11,
                    });

            modelBuilder.Entity<JeansEntityModel>().HasData(
                   new JeansEntityModel()
                   {
                       Id = 4,
                       Closure = "Normal Closure",
                       Pockets = "4 Pockets",
                       Fit = "Stretch Fit",
                       ProductItemsId = 8,
                       ProductDetailsId = 8,
                       CategoriesId = 2,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                   new ProductItemEntityModel()

                   {
                       Id = 8,
                       ArticleNumber = "8888-11",
                       BrandName = "Reebook",
                       ProductName = "Reebook Jeans",
                       ShortDescription = "New Jeans from Reebook"
                   });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 8,
                        Color = "Black",
                        Price = 2500,
                        Size = "S",
                        Rating = 4,
                        Quantity = 26,
                    });

            modelBuilder.Entity<ShoesEntityModel>().HasData(
                   new ShoesEntityModel()
                   {
                       Id = 1,
                       Lining = "Leather",
                       Insole = "Textile",
                       Sole = "Art materials",
                       Closure = "Normal Closure",
                       ProductItemsId = 9,
                       ProductDetailsId = 9,
                       CategoriesId = 3,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 9,
                        ArticleNumber = "9999-11",
                        BrandName = "Vans",
                        ProductName = "Vans Shoes",
                        ShortDescription = "New Shoes from Vans"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 9,
                        Color = "Red, Yellow, Purple",
                        Price = 5000,
                        Size = "44",
                        Rating = 5,
                        Quantity = 12,
                    });


            modelBuilder.Entity<ShoesEntityModel>().HasData(
                   new ShoesEntityModel()
                   {
                       Id = 2,
                       Lining = "Leather",
                       Insole = "Textile",
                       Sole = "Art materials",
                       Closure = "Normal Closure",
                       ProductItemsId = 10,
                       ProductDetailsId = 10,
                       CategoriesId = 3,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 10,
                        ArticleNumber = "2222-22",
                        BrandName = "Nike",
                        ProductName = "Nike Shoes",
                        ShortDescription = "New Shoes from Nike"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 10,
                        Color = "Green, Purple, Pink",
                        Price = 5000,
                        Size = "44",
                        Rating = 5,
                        Quantity = 22,
                    });

            modelBuilder.Entity<ShoesEntityModel>().HasData(
                   new ShoesEntityModel()
                   {
                       Id = 3,
                       Lining = "Leather",
                       Insole = "Textile",
                       Sole = "Art materials",
                       Closure = "Normal Closure",
                       ProductItemsId = 11,
                       ProductDetailsId = 11,
                       CategoriesId = 3,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 11,
                        ArticleNumber = "3333-22",
                        BrandName = "Adidas",
                        ProductName = "Adidas Shoes",
                        ShortDescription = "New Shoes from Adidas"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 11,
                        Color = "Green, Purple, Red",
                        Price = 5000,
                        Size = "46",
                        Rating = 5,
                        Quantity = 33,
                    });

            modelBuilder.Entity<ShoesEntityModel>().HasData(
                   new ShoesEntityModel()
                   {
                       Id = 4,
                       Lining = "Leather",
                       Insole = "Textile",
                       Sole = "Art materials",
                       Closure = "Normal Closure",
                       ProductItemsId = 12,
                       ProductDetailsId = 12,
                       CategoriesId = 3,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 12,
                        ArticleNumber = "4444-22",
                        BrandName = "Reebook",
                        ProductName = "Reebook Shoes",
                        ShortDescription = "New Shoes from Reebook"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 12,
                        Color = "Green, Purple, Pink",
                        Price = 5000,
                        Size = "42",
                        Rating = 5,
                        Quantity = 21,
                    });

            modelBuilder.Entity<WatchEntityModel>().HasData(
                   new WatchEntityModel()
                   {
                       Id = 1,
                       Waterproof = "Yes",
                       Display = "Digital",
                       ClockWork = "Normal ClockWork",
                       Closure = "Normal Closure",
                       ProductItemsId = 13,
                       ProductDetailsId = 13,
                       CategoriesId = 4,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                     new ProductItemEntityModel()

                     {
                         Id = 13,
                         ArticleNumber = "5555-22",
                         BrandName = "Reebook",
                         ProductName = "Reebook Watch",
                         ShortDescription = "New Watch from Reebook"
                     });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 13,
                        Color = "Black",
                        Price = 650,
                        Size = "One Size",
                        Rating = 3,
                        Quantity = 8,
                    });

            modelBuilder.Entity<WatchEntityModel>().HasData(
                   new WatchEntityModel()
                   {
                       Id = 2,
                       Waterproof = "Yes",
                       Display = "Digital",
                       ClockWork = "Normal ClockWork",
                       Closure = "Normal Closure",
                       ProductItemsId = 14,
                       ProductDetailsId = 14,
                       CategoriesId = 4,
                   });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 14,
                        ArticleNumber = "6666-22",
                        BrandName = "Nike",
                        ProductName = "Nike Watch",
                        ShortDescription = "New Watch from Reebook"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 14,
                        Color = "Green",
                        Price = 650,
                        Size = "One Size",
                        Rating = 4,
                        Quantity = 12,
                    });

            modelBuilder.Entity<WatchEntityModel>().HasData(
                    new WatchEntityModel()
                    {
                        Id = 3,
                        Waterproof = "Yes",
                        Display = "Digital",
                        ClockWork = "Normal ClockWork",
                        Closure = "Normal Closure",
                        ProductItemsId = 15,
                        ProductDetailsId = 15,
                        CategoriesId = 4,
                    });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 15,
                        ArticleNumber = "7777-22",
                        BrandName = "Adidas",
                        ProductName = "Adidas Watch",
                        ShortDescription = "New Watch from Adidas"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 15,
                        Color = "Red",
                        Price = 650,
                        Size = "One Size",
                        Rating = 4,
                        Quantity = 29,
                    });

            modelBuilder.Entity<WatchEntityModel>().HasData(
                    new WatchEntityModel()
                    {
                        Id = 4,
                        Waterproof = "Yes",
                        Display = "Digital",
                        ClockWork = "Normal ClockWork",
                        Closure = "Normal Closure",
                        ProductItemsId = 16,
                        ProductDetailsId = 16,
                        CategoriesId = 4,
                    });

            modelBuilder.Entity<ProductItemEntityModel>().HasData(
                    new ProductItemEntityModel()

                    {
                        Id = 16,
                        ArticleNumber = "8888-22",
                        BrandName = "Vans",
                        ProductName = "Vans Watch",
                        ShortDescription = "New Watch from Vans"
                    });

            modelBuilder.Entity<ProductDetailEntityModel>().HasData(
                    new ProductDetailEntityModel()

                    {
                        Id = 16,
                        Color = "Purple",
                        Price = 650,
                        Size = "One Size",
                        Rating = 3,
                        Quantity = 32,
                    });

            modelBuilder.Entity<CategoryEntityModel>().HasData(
                    new CategoryEntityModel()

                    {
                        Id = 1,
                        CategoryName = "Jackets"
                    });

            modelBuilder.Entity<CategoryEntityModel>().HasData(
                    new CategoryEntityModel()

                    {
                        Id = 2,
                        CategoryName = "Jeans"
                    });


            modelBuilder.Entity<CategoryEntityModel>().HasData(
                    new CategoryEntityModel()

                    {
                        Id = 3,
                        CategoryName = "Shoes"
                    });


            modelBuilder.Entity<CategoryEntityModel>().HasData(
                    new CategoryEntityModel()

                    {
                        Id = 4,
                        CategoryName = "Watches"
                    });
        }
    }
}
