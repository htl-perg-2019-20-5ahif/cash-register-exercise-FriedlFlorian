using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CashRegister.UICore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Product> products { get; set; } = new ObservableCollection<Product>();
        public double totalValue;
        public double total
        {
            get => totalValue;
            set
            {
                totalValue = value;
                OnPropertyChanged(nameof(total));
            }
        }

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            UIProducts.ItemsSource = products;
        }

        private void NewProduct(object sender, RoutedEventArgs e)
        {
            Button myButton = (Button)sender;
            string productName = myButton.CommandParameter.ToString();
            Boolean productInList = false;
            foreach (Product product in products)
            {
                if (product.ProductName.Equals(productName))
                {
                    product.Amount++;
                    product.gesamt = product.Amount * product.Price;
                    
                    productInList = true;
                }
            }
            if (!productInList)
            {
                products.Add(new Product(productName, 1, 1.99, 1.99));
            }
            UIProducts.Items.Refresh();

            foreach (Product product in products)
            {
                if (product.ProductName.Equals(productName))
                {
                    total += product.Price;
                } 
            }
        }

    }
}
