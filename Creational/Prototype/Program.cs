namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { Id = 1, FirstName = "Hamza Furkan", LastName = "Eryılmaz", City = "İzmir" };

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Enes";

            Employee employee1 = new Employee { FirstName = "Sabri" };

            Employee employee2 = (Employee)employee1.Clone();
            employee2.FirstName = "Mustafa";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);
            Console.WriteLine(employee1.FirstName);
            Console.WriteLine(employee2.FirstName);
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}