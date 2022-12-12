namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Calculator=new After2010CreditCalculator();
            customerManager.SaveCredit();
            
            

            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Calculated (Before2010)");
        }
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Calculated (After2010)");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase Calculator { get; set; }

        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business codes ...");
            Calculator.Calculate();
        }
    }
}