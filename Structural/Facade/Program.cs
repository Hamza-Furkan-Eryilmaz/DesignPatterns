namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CustomerManager customerManager= new CustomerManager();
            customerManager.Method();
            Console.ReadLine();
        }
    }

   public interface ILogger
    {
        void Log();
    }
   public interface ICacher
    {
        void Cache();
    }
   public interface IValidator
    {
        void Validate();
    }

   public class Logger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }

   public class Cacher : ICacher
    {
        public void Cache()
        {
            Console.WriteLine("Cached!");
        }
    }

   public class Validator : IValidator
    {
        public void Validate()
        {
            Console.WriteLine("Validated!");
        }
    }

    public class CustomerManager
    {
        private CrossCuttingConcernsFacade _concerns;

        public CustomerManager()
        {
            _concerns= new CrossCuttingConcernsFacade();
        }

        public void Method()
        {
            _concerns.Logging.Log();
            _concerns.Caching.Cache();
            _concerns.Validate.Validate();

            Console.WriteLine("Method works!");

        }

    }

    public class CrossCuttingConcernsFacade
    {
        public ILogger Logging;
        public ICacher Caching;
        public IValidator Validate;

        public CrossCuttingConcernsFacade()
        {
            Logging= new Logger();
            Caching=new Cacher();
            Validate=new Validator();
        }
    }

}