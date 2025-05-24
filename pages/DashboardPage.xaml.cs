using System;
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
using SkrStock.pages;
using StockManagementApp.pages;

namespace StockManagementApp.pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        // Add Product Button Click
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Get the main window
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            // Navigate to Products page
            mainWindow.frameContent.Navigate(new ProductsPage());

            // Update the sidebar button state
            mainWindow.UpdateMenuButtonsState(mainWindow.btnProducts);
        }

        // Create Order Button Click
        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            // Get the main window
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            // Navigate to Orders page
            mainWindow.frameContent.Navigate(new OrdersPage());

            // Update the sidebar button state
            mainWindow.UpdateMenuButtonsState(mainWindow.btnOrders);
        }

        // Manage Clients Button Click
        private void ManageClients_Click(object sender, RoutedEventArgs e)
        {
            // Get the main window
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            // Navigate to Clients page
            mainWindow.frameContent.Navigate(new ClientsPage());

            // Update the sidebar button state
            mainWindow.UpdateMenuButtonsState(mainWindow.btnClients);
        }

        // Manage Suppliers Button Click
        private void ManageSuppliers_Click(object sender, RoutedEventArgs e)
        {
            // Get the main window
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            // Navigate to Suppliers page
            mainWindow.frameContent.Navigate(new SuppliersPage());

            // Update the sidebar button state
            mainWindow.UpdateMenuButtonsState(mainWindow.btnSuppliers);
        }
    }
}