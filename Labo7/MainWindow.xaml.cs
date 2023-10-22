using System;
using System.Collections.Generic;
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
using Business;
using Entity;

namespace Labo7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Business.BProduct business;

        public MainWindow()
        {
            InitializeComponent();
            productBusiness = new BProduct();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string searchName = txtName.Text;
            List<Product> products = productBusiness.GetByName(searchName);

            dataGrid.ItemsSource = products;
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int stock = Convert.ToInt32(txtStock.Text);
            bool isActive = chkActive.IsChecked ?? false;

            Product newProduct = new Product
            {
                Name = productName,
                Price = price,
                Stock = stock,
                IsActive = isActive
            };

            productBusiness.Insert(newProduct);

            RefreshDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Product selectedProduct)
            {
                string updatedName = txtProductName.Text;
                decimal updatedPrice = Convert.ToDecimal(txtPrice.Text);
                int updatedStock = Convert.ToInt32(txtStock.Text);
                bool updatedIsActive = chkActive.IsChecked ?? false;

                selectedProduct.Name = updatedName;
                selectedProduct.Price = updatedPrice;
                selectedProduct.Stock = updatedStock;
                selectedProduct.IsActive = updatedIsActive;

                productBusiness.Update(selectedProduct);

                RefreshDataGrid();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Product selectedProduct)
            {
                productBusiness.Delete(selectedProduct.Id);

                RefreshDataGrid();
            }
        }

        private void RefreshDataGrid()
        {
            string searchName = txtName.Text;
            List<Product> products = productBusiness.GetByName(searchName);

            dataGrid.ItemsSource = products;
        }
    }
}
