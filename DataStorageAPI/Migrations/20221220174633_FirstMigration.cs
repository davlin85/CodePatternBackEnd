using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataStorageAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(1,0)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jackets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fit = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Cut = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    BackWidth = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductDetailsId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jackets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jackets_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jackets_ProductDetails_ProductDetailsId",
                        column: x => x.ProductDetailsId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jackets_ProductItems_ProductItemsId",
                        column: x => x.ProductItemsId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jeans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Closure = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Pockets = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Fit = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductDetailsId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jeans_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jeans_ProductDetails_ProductDetailsId",
                        column: x => x.ProductDetailsId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jeans_ProductItems_ProductItemsId",
                        column: x => x.ProductItemsId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lining = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Insole = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Sole = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Closure = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductDetailsId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoes_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoes_ProductDetails_ProductDetailsId",
                        column: x => x.ProductDetailsId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoes_ProductItems_ProductItemsId",
                        column: x => x.ProductItemsId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Watches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Waterproof = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Display = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ClockWork = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Closure = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProductItemsId = table.Column<int>(type: "int", nullable: false),
                    ProductDetailsId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watches_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_ProductDetails_ProductDetailsId",
                        column: x => x.ProductDetailsId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_ProductItems_ProductItemsId",
                        column: x => x.ProductItemsId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Jackets" },
                    { 2, "Jeans" },
                    { 3, "Shoes" },
                    { 4, "Watches" }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "Color", "Price", "Quantity", "Rating", "Size" },
                values: new object[,]
                {
                    { 1, "Black", 800m, 25m, 5m, "M" },
                    { 2, "Blue", 500m, 120m, 2m, "XL" },
                    { 3, "Green", 900m, 200m, 1m, "L" },
                    { 4, "Yellow", 600m, 12m, 5m, "S" },
                    { 5, "Blue", 1200m, 29m, 5m, "M" },
                    { 6, "Purple", 1100m, 30m, 3m, "XL" },
                    { 7, "Green", 1900m, 11m, 5m, "XXL" },
                    { 8, "Black", 2500m, 26m, 4m, "S" },
                    { 9, "Red, Yellow, Purple", 5000m, 12m, 5m, "44" },
                    { 10, "Green, Purple, Pink", 5000m, 22m, 5m, "44" },
                    { 11, "Green, Purple, Red", 5000m, 33m, 5m, "46" },
                    { 12, "Green, Purple, Pink", 5000m, 21m, 5m, "42" },
                    { 13, "Black", 650m, 8m, 3m, "One Size" },
                    { 14, "Green", 650m, 12m, 4m, "One Size" },
                    { 15, "Red", 650m, 29m, 4m, "One Size" },
                    { 16, "Purple", 650m, 32m, 3m, "One Size" }
                });

            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "Id", "ArticleNumber", "BrandName", "ProductName", "ShortDescription" },
                values: new object[,]
                {
                    { 1, "1111-11", "Vans", "Vans Jacket", "New Jacket from Vans" },
                    { 2, "2222-11", "Nike", "Nike Jacket", "New Jacket from Nike" },
                    { 3, "3333-11", "Adidas", "Adidas Jacket", "New Jacket from Adidas" },
                    { 4, "4444-11", "Reebok", "Reebok Jacket", "New Jacket from Reebok" },
                    { 5, "5555-11", "Vans ", "Vans Jeans", "New Jeans from Vans" },
                    { 6, "6666-11", "Nike", "Nike Jeans", "New Jeans from Nike" },
                    { 7, "7777-11", "Adidas", "Adidas Jeans", "New Jeans from Adidas" },
                    { 8, "8888-11", "Reebook", "Reebook Jacket", "New Jacket from Reebook" },
                    { 9, "9999-11", "Vans", "Vans Shoes", "New Shoes from Vans" },
                    { 10, "2222-22", "Nike", "Nike Shoes", "New Shoes from Nike" },
                    { 11, "3333-22", "Adidas", "Adidas Shoes", "New Shoes from Adidas" },
                    { 12, "4444-22", "Reebook", "Reebook Shoes", "New Shoes from Reebook" },
                    { 13, "5555-22", "Reebook", "Reebook Watch", "New Watch from Reebook" },
                    { 14, "6666-22", "Nike", "Nike Watch", "New Watch from Reebook" },
                    { 15, "7777-22", "Adidas", "Adidas Watch", "New Watch from Adidas" },
                    { 16, "8888-22", "Vans", "Vans Watch", "New Watch from Vans" }
                });

            migrationBuilder.InsertData(
                table: "Jackets",
                columns: new[] { "Id", "BackWidth", "CategoriesId", "Cut", "Fit", "Length", "ProductDetailsId", "ProductItemsId" },
                values: new object[,]
                {
                    { 1, "76 cm", 1, "Straight", "Regular Fit", "Normal Length", 1, 1 },
                    { 2, "82 cm", 1, "Straight", "Regular Fit", "Normal Length", 2, 2 },
                    { 3, "120 cm", 1, "Normal Cut", "Loose Fit", "Loose Length", 3, 3 },
                    { 4, "80 cm", 1, "Normal Cut", "Straight Fit", "Normal Length", 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Jeans",
                columns: new[] { "Id", "CategoriesId", "Closure", "Fit", "Pockets", "ProductDetailsId", "ProductItemsId" },
                values: new object[,]
                {
                    { 1, 2, "Normal Closure", "Skinny Fit", "4 pockets", 5, 5 },
                    { 2, 2, "Normal Closure", "Loose Fit", "4 pockets", 6, 6 },
                    { 3, 2, "Normal Closure", "Straight Fit", "N4 Pockets", 7, 7 },
                    { 4, 2, "Normal Closure", "Stretch Fit", "4 Pockets", 8, 8 }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "CategoriesId", "Closure", "Insole", "Lining", "ProductDetailsId", "ProductItemsId", "Sole" },
                values: new object[,]
                {
                    { 1, 3, "Normal Closure", "Textile", "Leather", 9, 9, "Art materials" },
                    { 2, 3, "Normal Closure", "Textile", "Leather", 10, 10, "Art materials" },
                    { 3, 3, "Normal Closure", "Textile", "Leather", 11, 11, "Art materials" },
                    { 4, 3, "Normal Closure", "Textile", "Leather", 12, 12, "Art materials" }
                });

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "CategoriesId", "ClockWork", "Closure", "Display", "ProductDetailsId", "ProductItemsId", "Waterproof" },
                values: new object[,]
                {
                    { 1, 4, "Normal ClockWork", "Normal Closure", "Digital", 13, 13, "Yes" },
                    { 2, 4, "Normal ClockWork", "Normal Closure", "Digital", 14, 14, "Yes" },
                    { 3, 4, "Normal ClockWork", "Normal Closure", "Digital", 15, 15, "Yes" },
                    { 4, 4, "Normal ClockWork", "Normal Closure", "Digital", 16, 16, "Yes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jackets_CategoriesId",
                table: "Jackets",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Jackets_ProductDetailsId",
                table: "Jackets",
                column: "ProductDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Jackets_ProductItemsId",
                table: "Jackets",
                column: "ProductItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Jeans_CategoriesId",
                table: "Jeans",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Jeans_ProductDetailsId",
                table: "Jeans",
                column: "ProductDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Jeans_ProductItemsId",
                table: "Jeans",
                column: "ProductItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_CategoriesId",
                table: "Shoes",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_ProductDetailsId",
                table: "Shoes",
                column: "ProductDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_ProductItemsId",
                table: "Shoes",
                column: "ProductItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_CategoriesId",
                table: "Watches",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_ProductDetailsId",
                table: "Watches",
                column: "ProductDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_ProductItemsId",
                table: "Watches",
                column: "ProductItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jackets");

            migrationBuilder.DropTable(
                name: "Jeans");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Watches");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "ProductItems");
        }
    }
}
