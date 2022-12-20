using DataStorageAPI.Data;
using DataStorageAPI.Models.EntityModels;
using DataStorageAPI.Models.Input;
using Microsoft.EntityFrameworkCore;

namespace DataStorageAPI.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<JacketEntityModel> Jackets { get; set; }
        public virtual DbSet<JeansEntityModel> Jeans { get; set; }
        public virtual DbSet<ShoesEntityModel> Shoes { get; set; }
        public virtual DbSet<WatchEntityModel> Watches { get; set; }
        public virtual DbSet<ProductItemEntityModel> ProductItems { get; set; }
        public virtual DbSet<ProductDetailEntityModel> ProductDetails { get; set; }
        public virtual DbSet<CategoryEntityModel> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}