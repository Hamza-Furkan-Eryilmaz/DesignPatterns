namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();

            var builder = new OldCustomerProductBuilder();

            productDirector.GenerateProduct(builder);

            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.UnitPrice);

        }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountedPrice { get; set; }

        public bool DiscountApplied { get; set; }

    }

    public abstract class ProductBuilder
    {
        public abstract void GetProductData();

        public abstract void ApplyDiscount();

        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.ProductName = "Keyboard";
            model.CategoryName = "PC part";
            model.UnitPrice = 100;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.5;
            model.DiscountApplied = true;

        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.ProductName = "Keyboard";
            model.CategoryName = "PC part";
            model.UnitPrice = 100;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}