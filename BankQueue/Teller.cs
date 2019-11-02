namespace BankQueue
{
    public class Teller
    {
        public int TellerId { get; set; }
        public string TellerName { get; set; }
        public Customer CurrentCustomer { get; set; }

        public void DoCustomerRequest()
        { 
            // Do some task
        }
    }
}
