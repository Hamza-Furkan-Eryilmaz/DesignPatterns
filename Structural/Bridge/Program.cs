namespace Bridge
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager= new CustomerManager();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.MessageSenderBase.Save();
            customerManager.UpdateCustomer();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }

        public abstract void Send(Body body);
       
    }

    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent with SmsSender",body);
        }
    }

    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent with EmailSender",body);
        }
    }

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }

        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body { Title = "About the course!" });
            Console.WriteLine("Customer updated!");
        }
    }
}