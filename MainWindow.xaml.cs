using System;
using System.Collections.Generic;
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

namespace StockManagementApp
{
    public partial class MainWindow : Window
    {
        // قائمة بجميع أزرار القائمة
        private List<Button> menuButtons;

        public MainWindow()
        {
            InitializeComponent();

            // إضافة خاصية سحب النافذة
            this.MouseDown += Window_MouseDown;

            // تهيئة قائمة الأزرار
            menuButtons = new List<Button>
            {
                btnDashboard,
                btnInventory,
                btnProducts,
                btnOrders,
                btnSuppliers,
                btnReports,
                btnSettings,
                btnClients
            };

            // تحميل صفحة لوحة التحكم افتراضياً
            frameContent.Navigate(new DashboardPage());
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // تحديث حالة أزرار القائمة - Made public so DashboardPage can access it
        public void UpdateMenuButtonsState(Button activeButton)
        {
            foreach (var button in menuButtons)
            {
                button.Style = this.FindResource("MenuButtonStyle") as Style;
            }
            activeButton.Style = this.FindResource("ActiveMenuButtonStyle") as Style;
        }

        // أحداث أزرار القائمة
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMenuButtonsState(btnDashboard);
            frameContent.Navigate(new DashboardPage());
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMenuButtonsState(btnInventory);
            frameContent.Navigate(new InventoryPage());
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMenuButtonsState(btnProducts);
            frameContent.Navigate(new ProductsPage());
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMenuButtonsState(btnOrders);
            frameContent.Navigate(new OrdersPage());
        }

        private void SuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMenuButtonsState(btnSuppliers);
            frameContent.Navigate(new SuppliersPage());
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMenuButtonsState(btnReports);
            frameContent.Navigate(new ReportsPage());
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMenuButtonsState(btnSettings);
            frameContent.Navigate(new SettingsPage());
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateMenuButtonsState(btnClients);
            frameContent.Navigate(new ClientsPage());
        }

        private void frameContent_Navigated(object sender, NavigationEventArgs e)
        {
            // يمكن إضافة منطق إضافي هنا عند التنقل بين الصفحات
        }
    }
}