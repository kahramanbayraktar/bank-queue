using System;
using System.Threading.Tasks;

namespace BankQueue
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tellers = new [] { new Teller { TellerId = 1 }, new Teller { TellerId = 2 } };
            var system = new BankQueueSystem(tellers);

            for (var i = 0; i < 100; i++)
            {
                var priority = RandomNumber.GetRandomNumber(1, 4);
                var serviceTime = RandomNumber.GetRandomNumber(1, 10);
                system.EnqueueCustomer(new Customer { CustomerId = i + 1, Priority = priority, ServiceTime = serviceTime });
            }

            await system.Start();

            // Customer1 arrives at the bank (or get a ticket)
            //system.EnqueueCustomer(new Customer { CustomerId = 1, Priority = 2 });

            // Teller1 services Customer1

            // Customer2 arrives at the bank (or get a ticket)
            //system.EnqueueCustomer(new Customer { CustomerId = 2, Priority = 1 });

            // Teller2 services Customer2

            // Customer3 arrives at the bank (or get a ticket)
            //system.EnqueueCustomer(new Customer { CustomerId = 3, Priority = 2 });

            // Customer1 leaves the bank (or Teller1)

            // Teller1 services Customer3

            Console.ReadLine();
        }
    }
}
