using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BankQueue
{
    public class BankQueueSystem
    {
        Queue<Teller> tellers = new Queue<Teller>();
        Queue<Customer> customerCategory1 = new Queue<Customer>();
        Queue<Customer> customerCategory2 = new Queue<Customer>();
        Queue<Customer> customerCategory3 = new Queue<Customer>();

        public BankQueueSystem(Teller[] tellers)
        {
            foreach(var teller in tellers)
            {
                this.tellers.Enqueue(teller);
            }
        }

        public async Task Start()
        {
            //while (CustomerAvailable())
            //{
            //    var nextCustomer = DequeueCustomer();
            //}

            await RunSystem();
        }

        async Task RunSystem()
        {
            for (var i = 0; i < 60; i++)
            {
                Thread.Sleep(1000);
                await DequeueCustomer();
            }
        }



        async Task<Customer> DequeueCustomer() // PushNextCustomerButton
        {
            var customer = PopCustomer();
            var teller = PopTeller();

            await DoCustomerTask(teller, customer);

            return customer;
        }

        public async void EnqueueCustomer(Customer customer)
        {
            switch (customer.Priority)
            {
                case 1:
                    customerCategory1.Enqueue(customer);
                    await Console.Out.WriteLineAsync($"Customer{customer.CustomerId} enqueued.");
                    return;
                case 2:
                    customerCategory2.Enqueue(customer);
                    await Console.Out.WriteLineAsync($"Customer{customer.CustomerId} enqueued.");
                    return;
                case 3:
                    customerCategory3.Enqueue(customer);
                    await Console.Out.WriteLineAsync($"Customer{customer.CustomerId} enqueued.");
                    return;
            }
        }

        Customer PopCustomer()
        {
            if (customerCategory1.Count > 0)
                return customerCategory1.Dequeue();
            if (customerCategory2.Count > 0)
                return customerCategory2.Dequeue();
            return customerCategory3.Dequeue();
        }

        Teller PopTeller() // PushNextTellerButton
        {
            // implement
            return tellers.Dequeue();
        }

        async Task DoCustomerTask(Teller teller, Customer customer)
        {
            await Console.Out.WriteLineAsync($"Teller{teller.TellerId} is serving Customer{customer.CustomerId}...");
            await Task.Delay(3000);
            await Console.Out.WriteLineAsync($"Customer{customer.CustomerId} has left Teller{teller.TellerId}");
        }

        

        bool CustomerAvailable()
        {
            return customerCategory1.Count > 0 || customerCategory2.Count > 0 || customerCategory3.Count > 0;
        }

        int NextNumber()
        {
            return new Random().Next(1, 999);
        }
    }
}
