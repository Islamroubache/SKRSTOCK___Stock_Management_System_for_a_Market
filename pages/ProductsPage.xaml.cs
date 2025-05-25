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
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
        }

        // Add Product Button Click
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ShowModal(AddProductModalContainer);
        }

        // Edit Product Button Click
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            // Pre-fill the form with existing data for editing
            txtProductName.Text = "لابتوب ديل XPS 13";
            txtProductSKU.Text = "LAP-XPS-001";
            cmbProductCategory.SelectedIndex = 0; // إلكترونيات
            cmbProductUnit.SelectedIndex = 0; // قطعة
            txtPurchasePrice.Text = "3200";
            txtSalePrice.Text = "3800";
            cmbProductSupplier.SelectedIndex = 0; // شركة التقنية
            txtProductDescription.Text = "لابتوب عالي الأداء مناسب للأعمال والتصميم";

            ShowModal(AddProductModalContainer);
        }

        // View Product Button Click
        private void ViewProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("عرض تفاصيل المنتج", "تفاصيل المنتج", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Delete Product Button Click
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("هل أنت متأكد من حذف هذا المنتج؟", "تأكيد الحذف",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("تم حذف المنتج بنجاح!", "نجح", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Export Products Button Click
        private void ExportProducts_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("تم تصدير قائمة المنتجات بنجاح!", "تصدير", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Close Modal
        private void CloseModal_Click(object sender, RoutedEventArgs e)
        {
            HideModal(AddProductModalContainer);
        }

        // Save Product
        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtProductSKU.Text) ||
                cmbProductCategory.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى ملء جميع الحقول المطلوبة", "خطأ", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add your save logic here
            MessageBox.Show("تم إضافة المنتج بنجاح!", "نجح", MessageBoxButton.OK, MessageBoxImage.Information);
            HideModal(AddProductModalContainer);
            ClearAddForm();
        }

        // Search Box Focus Events
        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "بحث عن منتج...")
            {
                txtSearch.Text = "";
                txtSearch.Foreground = new SolidColorBrush(Color.FromRgb(45, 55, 72)); // #2D3748
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "بحث عن منتج...";
                txtSearch.Foreground = new SolidColorBrush(Color.FromRgb(110, 122, 138)); // #6E7A8A
            }
        }

        // Show Modal with Animation
        private void ShowModal(Grid modalContainer)
        {
            modalContainer.Visibility = Visibility.Visible;

            // Get the blur backdrop and modal overlay
            var blurBackdrop = modalContainer.Children[0] as Border;
            var modalOverlay = modalContainer.Children[1] as Border;

            // Fade in animations
            var fadeInBackdrop = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(200));
            var fadeInModal = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(300));

            blurBackdrop.BeginAnimation(Border.OpacityProperty, fadeInBackdrop);
            modalOverlay.BeginAnimation(Border.OpacityProperty, fadeInModal);
        }

        // Hide Modal with Animation
        private void HideModal(Grid modalContainer)
        {
            // Get the blur backdrop and modal overlay
            var blurBackdrop = modalContainer.Children[0] as Border;
            var modalOverlay = modalContainer.Children[1] as Border;

            // Fade out animations
            var fadeOutBackdrop = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(200));
            var fadeOutModal = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(300));

            fadeOutModal.Completed += (s, e) => modalContainer.Visibility = Visibility.Collapsed;

            blurBackdrop.BeginAnimation(Border.OpacityProperty, fadeOutBackdrop);
            modalOverlay.BeginAnimation(Border.OpacityProperty, fadeOutModal);
        }

        // Clear Add Form
        private void ClearAddForm()
        {
            txtProductName.Text = "";
            txtProductSKU.Text = "";
            cmbProductCategory.SelectedIndex = -1;
            cmbProductUnit.SelectedIndex = -1;
            txtPurchasePrice.Text = "";
            txtSalePrice.Text = "";
            cmbProductSupplier.SelectedIndex = -1;
            txtProductDescription.Text = "";
        }
    }
}

