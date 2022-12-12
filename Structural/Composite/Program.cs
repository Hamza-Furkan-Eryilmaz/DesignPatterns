using System.Collections;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee john = new Employee { Name ="John"};
            Employee chris=new Employee { Name="Chris"};
            john.AddSubordinate(chris);
            Employee jax = new Employee { Name = "Jax" };
            john.AddSubordinate(jax);
            Employee lisa = new Employee { Name = "Lisa" };
            chris.AddSubordinate(lisa);
            Contractor matt= new Contractor {Name="Matt" };
            jax.AddSubordinate(matt);
           

            Console.WriteLine(john.Name);
            foreach (Employee manager in john)
            {
                Console.WriteLine("  "+manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("  "+employee.Name);
                }
            }

        }
    }

    interface IPerson
    {
        string Name { get;set; }
        
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson> 
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinates(IPerson person)
        {
            _subordinates.Remove(person);
        }
       
        public string Name { get ; set ; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}