using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankQueue
{
    public class BankQueueSystem
    {
        Queue<Teller> _tellers = new Queue<Teller>();
        Queue<Customer> _customerCategory1 = new Queue<Customer>();
        Queue<Customer> _customerCategory2 = new Queue<Customer>();
        Queue<Customer> _customerCategory3 = new Queue<Customer>();

        private DateTime _startTime;

        public BankQueueSystem(Teller[] tellers)
        {
            foreach(var teller in tellers)
            {
                this._tellers.Enqueue(teller);
            }
        }

        public async Task Start()
        {
            _startTime = DateTime.Now;

            await RunSystem();
        }

        async Task RunSystem()
        {
            while(DateTime.Now < _startTime.AddMinutes(1))
            {
                await DequeueCustomer();
            }
        }

        async Task<Customer> DequeueCustomer() // PushNextCustomerButton
        {
            var customer = PopCustomer();

            if (customer == null)
                return null;

            var teller = PopTeller();

            if (teller == null)
                return null;

            await DoCustomerTask(teller, customer);

            return customer;
        }

        public async void EnqueueCustomer(Customer customer)
        {
            switch (customer.Priority)
            {
                case 1:
                    _customerCategory1.Enqueue(customer);
                    await Console.Out.WriteLineAsync($"Customer{customer.CustomerId} enqueued.");
                    return;
                case 2:
                    _customerCategory2.Enqueue(customer);
                    await Console.Out.WriteLineAsync($"Customer{customer.CustomerId} enqueued.");
                    return;
                case 3:
                    _customerCategory3.Enqueue(customer);
                    await Console.Out.WriteLineAsync($"Customer{customer.CustomerId} enqueued.");
                    return;
            }
        }

        Customer PopCustomer()
        {
            if (_customerCategory1.Count > 0)
                return _customerCategory1.Dequeue();
            if (_customerCategory2.Count > 0)
                return _customerCategory2.Dequeue();
            if (_customerCategory3.Count > 0)
                return _customerCategory3.Dequeue();
            return null;
        }

        Teller PopTeller() // PushNextTellerButton
        {
            // implement
            return _tellers.Dequeue();
        }

        void PushTeller(Teller teller)
        {
            _tellers.Enqueue(teller);
        }

        async Task DoCustomerTask(Teller teller, Customer customer)
        {
            await Console.Out.WriteLineAsync($"Teller{teller.TellerId} is serving Customer{customer.CustomerId}. (Service time is {customer.ServiceTime} seconds.)");
            await Task.Delay(customer.ServiceTime * 1000);
            await Console.Out.WriteLineAsync($"Customer{customer.CustomerId} has left Teller{teller.TellerId}");

            PushTeller(teller);
        }
    }
}
