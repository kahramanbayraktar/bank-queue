using System;

namespace BankQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var tellers = new Teller[2] { new Teller { TellerId = 1 }, new Teller { TellerId = 2 } }; 
            BankQueueSystem system = new BankQueueSystem(tellers);
            system.Start();

            system.EnqueueCustomer(new Customer { CustomerId = 1, Priority = 2 });

            system.EnqueueCustomer(new Customer { CustomerId = 2, Priority = 1 });

            var nextCustomer = system.DequeueCustomer();

            system.EnqueueCustomer(new Customer { CustomerId = 3, Priority = 2 });

            nextCustomer = system.DequeueCustomer();
        }        
    }
}
