using DataStorageAPI.Models.Interfaces;

namespace DataStorageAPI.Models.Input
{
    /// <summary>
    /// Använder Single Responsibility Principle då modellen har ett ansvar.
    /// Uppfyller även Open-Closed Principle då classen är öppet för ny implementering.
    /// Interface segregation principle då alla modeller består av olika interfaces.
    /// </summary>

    public class JacketInputModel
    {
        public class UpdateJacketInputModel : CreateJacketInputModel
        {
            public int Id { get; set; }
        }

        public class CreateJacketInputModel : IJacket, IProductItem, IProductDetail, ICategory
        {
            private string _articleNumber;
            private string _brandName;
            private string _productName;
            private string _shortDescription;

            private string _fit;
            private string _cut;
            private string _length;
            private string _backWidth;

            private string _color;
            private decimal _price;
            private string _size;
            private decimal _rating;
            private decimal _quantity;

            private string _categoryName;

            public string ArticleNumber
            {
                get { return _articleNumber; }
                set { _articleNumber = value.Trim(); }
            }

            public string BrandName
            {
                get { return _brandName; }
                set { _brandName = value.Trim(); }
            }

            public string ProductName
            {
                get { return _productName; }
                set { _productName = value.Trim(); }
            }

            public string ShortDescription
            {
                get { return _shortDescription; }
                set { _shortDescription = value.Trim(); }
            }

            public string Fit
            {
                get { return _fit; }
                set { _fit = value.Trim(); }
            }

            public string Cut
            {
                get { return _cut; }
                set { _cut = value.Trim(); }
            }

            public string Length
            {
                get { return _length; }
                set { _length = value.Trim(); }
            }

            public string BackWidth
            {
                get { return _backWidth; }
                set { _backWidth = value.Trim(); }
            }

            public string Color
            {
                get { return _color; }
                set { _color = value.Trim(); }
            }

            public decimal Price
            {
                get { return _price; }
                set { _price = value; }
            }

            public string Size
            {
                get { return _size; }
                set { _size = value.Trim(); }
            }

            public decimal Rating
            {
                get { return _rating; }
                set { _rating = value; }
            }

            public decimal Quantity
            {
                get { return _quantity; }
                set { _quantity = value; }
            }

            public string CategoryName
            {
                get { return _categoryName; }
                set { _categoryName = value.Trim(); }
            }

        }   
    }
}
