using System.Runtime.ConstrainedExecution;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personalCar= new PersonalCar { Brand="AUDI",Model="A5",Price=450000};
            SpecialOffers specialOffers= new SpecialOffers(personalCar);
            specialOffers.DiscountPercentage = 10;
            Console.WriteLine("Normal Price {0} ",personalCar.Price);
            Console.WriteLine("Discounted Price = {0}",specialOffers.Price);
        }
    }

    abstract class CarBase
    {
        public abstract string Brand { get; set; }

        public abstract string Model { get; set; }

        public abstract int Price { get; set; }

    }

    class PersonalCar : CarBase
    {
        public override string Brand { get; set; }

        public override string Model { get; set; }

        public override int Price { get; set; }
    }

    class CommercialCar:CarBase
    {
        public override string Brand { get; set; }

        public override string Model { get; set; }

        public override int Price { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private  CarBase _carBase;
        
        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }

    }

    class SpecialOffers : CarDecoratorBase
    {
        private readonly CarBase _carBase;
        public int DiscountPercentage { get; set; }

        public SpecialOffers(CarBase carBase) : base(carBase)
        {
            _carBase=carBase;
        }

        public override string Brand { get; set; }
        public override string Model { get; set; }

        public override int Price
        {
            get { return _carBase.Price - (_carBase.Price*DiscountPercentage/100); }
            set { }
        }
        
       
    }
}