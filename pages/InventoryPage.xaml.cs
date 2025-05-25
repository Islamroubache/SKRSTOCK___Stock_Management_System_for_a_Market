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
using System.Windows.Media.Animation;

namespace StockManagementApp.pages
{
    /// <summary>
    /// Interaction logic for InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        public InventoryPage()
        {
            InitializeComponent();
        }

        // Add Stock Button Click
        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            ShowModal(AddStockModal);
        }

        // Edit Item Button Click
        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            // Pre-fill the edit form with existing data
            txtEditProductName.Text = "لابتوب ديل XPS 13";
            txtEditProductCode.Text = "LAP001";
            txtEditQuantity.Text = "45";
            txtEditMinThreshold.Text = "10";
            txtEditPrice.Text = "3500";

            ShowModal(EditModal);
        }

        // Add Stock to Item Button Click
        private void AddStockToItem_Click(object sender, RoutedEventArgs e)
        {
            ShowModal(AddStockModal);
        }

        // Close Modal
        private void CloseModal_Click(object sender, RoutedEventArgs e)
        {
            HideModal(AddStockModal);
            HideModal(EditModal);
        }

        // Save Product
        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            // Add your save logic here
            MessageBox.Show("تم إضافة المنتج بنجاح!", "نجح", MessageBoxButton.OK, MessageBoxImage.Information);
            HideModal(AddStockModal);
            ClearAddForm();
        }

        // Save Edit
        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            // Add your edit save logic here
            MessageBox.Show("تم حفظ التغييرات بنجاح!", "نجح", MessageBoxButton.OK, MessageBoxImage.Information);
            HideModal(EditModal);
        }

        // Show Modal with Animation
        private void ShowModal(Border modal)
        {
            modal.Visibility = Visibility.Visible;

            // Fade in animation
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(300));
            modal.BeginAnimation(Border.OpacityProperty, fadeIn);
        }

        // Hide Modal with Animation
        private void HideModal(Border modal)
        {
            // Fade out animation
            var fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(300));
            fadeOut.Completed += (s, e) => modal.Visibility = Visibility.Collapsed;
            modal.BeginAnimation(Border.OpacityProperty, fadeOut);
        }

        // Clear Add Form
        private void ClearAddForm()
        {
            txtProductName.Text = "";
            txtProductCode.Text = "";
            txtQuantity.Text = "";
            txtMinThreshold.Text = "";
            txtPrice.Text = "";
        }
    }
}
