namespace State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyContext context = new MyContext();
            ModifiedState modifiedState = new ModifiedState();
            modifiedState.DoAction(context);

            Console.WriteLine();


            
        }
    }

    public interface IState
    {
        void DoAction(MyContext context);

    }

    class ModifiedState : IState
    {
        public void DoAction(MyContext context)
        {
            Console.WriteLine("State:Modified");
            context.SetState(this);
        }
    }

    class DeletedState : IState
    {
        public void DoAction(MyContext context)
        {
            Console.WriteLine("State:Deleted");
            context.SetState(this);
        }
    }

    class AddedState : IState
    {
        public void DoAction(MyContext context)
        {
            Console.WriteLine("State:Added");
            context.SetState(this);
        }
    }

   public class MyContext
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState() 
        {
            return _state;
        }
    }
}