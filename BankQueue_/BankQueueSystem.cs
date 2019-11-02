using System;
using System.Collections.Generic;
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

            //Start();
        }

        public void Start()
        {
            while (CustomerAvailable())
            {
                var nextCustomer = DequeueCustomer();
            }
        }

        bool CustomerAvailable()
        {
            return customerCategory1.Count > 0 || customerCategory2.Count > 0 || customerCategory3.Count > 0;
        }

        int NextNumber()
        {
            return new Random().Next(1, 999);
        }

        public Customer DequeueCustomer() // PushNextCustomerButton
        {
            var customer = PopCustomer();
            var teller = PopTeller();
            //teller.CurrentCustomer = customer;
            //teller.DoCustomerRequest();

            Console.WriteLine($"Customer dequeued: {customer.CustomerId}");

            return customer;
        }

        Teller PopTeller() // PushNextTellerButton
        {
            // implement
            return tellers.Dequeue();
        }

        void NextCustomer()
        {
            // find the available teller (pop from a queue)
            var teller = PopTeller();

            // find the customer by some criteria

        }
        public async void EnqueueCustomer(Customer customer)
        {
            switch (customer.Priority)
            {
                case 1:
                    customerCategory1.Enqueue(customer);
                    Console.WriteLine($"Customer enqueued: {customer.CustomerId}");
                    await DoCustomerTask(customer);
                    return;
                case 2:
                    customerCategory2.Enqueue(customer);
                    Console.WriteLine($"Customer enqueued: {customer.CustomerId}");
                    await DoCustomerTask(customer);
                    return;
                case 3:
                    customerCategory3.Enqueue(customer);
                    Console.WriteLine($"Customer enqueued: {customer.CustomerId}");
                    await DoCustomerTask(customer);
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

        async Task DoCustomerTask(Customer customer)
        {
            await Console.Out.WriteLineAsync($"Customer{customer.CustomerId}'s task in progress...");
            await Console.Out.WriteLineAsync($"Customer{customer.CustomerId}'s task done!");
        }
    }
}
