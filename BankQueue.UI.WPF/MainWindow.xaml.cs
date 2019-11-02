using System.Windows;

namespace BankQueue.UI.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CustomerLogLabel.Content = "";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var tellers = new [] { new Teller { TellerId = 1 }, new Teller { TellerId = 2 } };
            var system = new BankQueueSystem(tellers);
            system.Start();

            var customer1 = new Customer {CustomerId = 1, Priority = 2};
            system.EnqueueCustomer(customer1);
            CustomerLogLabel.Content += $"\r\nCustomer enqueued: {customer1.CustomerId}";

            var customer2 = new Customer { CustomerId = 2, Priority = 1 };
            system.EnqueueCustomer(customer2);
            CustomerLogLabel.Content += $"\r\nCustomer enqueued: {customer2.CustomerId}";

            var nextCustomer = system.DequeueCustomer();
            CustomerLogLabel.Content += $"\r\nCustomer taken: {nextCustomer.CustomerId}";

            var customer3 = new Customer { CustomerId = 3, Priority = 2 };
            system.EnqueueCustomer(customer3);
            CustomerLogLabel.Content += $"\r\nCustomer enqueued: {customer3.CustomerId}";

            nextCustomer = system.DequeueCustomer();
            CustomerLogLabel.Content += $"\r\nCustomer taken: {nextCustomer.CustomerId}";
        }
    }
}
