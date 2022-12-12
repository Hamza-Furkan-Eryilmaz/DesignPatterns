namespace Interpreter
{
    public class Program
    {
        static void Main(string[] args)
        {
           BManager manager = new BManager();
            manager.Foo();
        }
    }

    interface IA
    {
        void Foo();
    }

    interface IB: IA ,IC 
    {

    }

    interface IC
    {
        void Boo();
    }

    class AManager : IA,IB
    {
        public void Boo()
        {
            Console.WriteLine("Boo");
        }

        public void Foo()
        {
            Console.WriteLine("Foo");
        }
    }

    class BManager:AManager
    {

    }

}