using BO;
using Service.Implements;
using Service.Interfaces;
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
using System.Windows.Shapes;

namespace WPFApp_EntityFramework
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        IProductService _productService = new ProductService();
        ICategoryService _categoryService = new CategoryService();
        //Để dánh dấu category nào đang chọn trên cây
        Category selected_category = null;
        bool is_load_product_completed = false;

        public AdminWindow()
        {
            InitializeComponent();

            LoadCategoriesAndProductsIntoTreeView();

        }

        private void LoadCategoriesAndProductsIntoTreeView()
        {
            is_load_product_completed = false;

            //Tạo nút gốc
            tvCategory.Items.Clear();
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Cát Lái";
            tvCategory.Items.Add(root);

            //Nạp danh mục
            List<Category> categories = _categoryService.GetCategories();
            foreach (Category category in categories)
            {
                //Tạo Cate note
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);

                //Đọc ds sản phẩm thuộc danh mục
                category.Products = _productService.GetProductsByCategory(category.CategoryId);

                //Nạp sản phẩm node Cate
                foreach (Product product in category.Products)
                {
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node);
                }

            }
            root.ExpandSubtree();
            is_load_product_completed = true;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtMa.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                is_load_product_completed = false;

                Product product = new Product();
                product.ProductName = txtTen.Text;
                product.UnitPrice = decimal.Parse(txtDonGia.Text);
                product.UnitsInStock = short.Parse(txtSoLuong.Text);

                //Ta cần bổ sung thêm tham chiếu danh mục
                if (selected_category != null)
                    product.CategoryId = selected_category.CategoryId;

                bool ret = _productService.SaveProduct(product);

                if (ret)
                {
                    //1.Nạp lại cây
                    TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                    if (cate_node == null || selected_category == null) return;
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node);
                    //2.Nạp lại listview
                    List<Product> products = _productService.GetProductsByCategory(selected_category.CategoryId);
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = products;
                }
                is_load_product_completed = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi lưu mới: " + ex.Message,
                    "Thông báo lỗi", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                is_load_product_completed = false;

                if (selected_category == null) return;

                Product product = new Product();
                product.ProductId = int.Parse(txtMa.Text);
                product.ProductName = txtTen.Text;
                product.UnitPrice = decimal.Parse(txtDonGia.Text);
                product.UnitsInStock = short.Parse(txtSoLuong.Text);
                product.CategoryId = selected_category.CategoryId;

                bool ret = _productService.UpdateProduct(product);

                if (ret)
                {
                    //Bước 1: Nạp lại cây cho Node danh mục mới đổi
                    TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                    if (cate_node == null || selected_category == null) return;
                    cate_node.Items.Clear();
                    var products_by_cate = _productService.GetProductsByCategory(selected_category.CategoryId);
                    foreach (var p in products_by_cate)
                    {
                        TreeViewItem p_node = new TreeViewItem();
                        p_node.Header = p.ProductName;
                        p_node.Tag = p;
                        cate_node.Items.Add(p_node);
                    }
                    //Bước 2: Nạp lại listview
                    List<Product> products = _productService.GetProductsByCategory(selected_category.CategoryId);
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = products;
                }
                is_load_product_completed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi cập nhật: " + ex.Message,
                    "Thông báo lỗi", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            
    
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                is_load_product_completed = false;

                int productId = int.Parse(txtMa.Text);

                //Gọi MessageBox để xác nhận
                MessageBoxResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sản phẩm này không?",
                    "Xác nhận xóa",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result != MessageBoxResult.Yes) return;

                bool ret = _productService.DeleteProduct(productId);

                if (ret)
                {
                    //1.Nạp lại cây cho Node danh mục mới xóa
                    TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                    if (cate_node == null || selected_category == null) return;
                    cate_node.Items.Clear();
                    var products_by_cate = _productService.GetProductsByCategory(selected_category.CategoryId);
                    foreach (var p in products_by_cate)
                    {
                        TreeViewItem p_node = new TreeViewItem();
                        p_node.Header = p.ProductName;
                        p_node.Tag = p;
                        cate_node.Items.Add(p_node);
                    }
                    //2.Nạp lại listview
                    List<Product> products = _productService.GetProductsByCategory(selected_category.CategoryId);
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = products;
                }

                is_load_product_completed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi xóa: " + ex.Message,
                    "Thông báo lỗi", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null) return;

            selected_category = null;

            TreeViewItem item = e.NewValue as TreeViewItem;
            Object data = item.Tag;
            
            if (data == null)
            {
                List<Product> products = _productService.GetProducts();
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = products;
                return;
            }
                
            
            if (data is Category)
            {
                //Người dùng bấm vào nút Category                
                Category category = (Category)data;
                //Lưu vết
                selected_category = category;
                List<Product> products = _productService.GetProductsByCategory(category.CategoryId);
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = products;

            }
            else if (data is Product)
            {
                //Người dùng bấm vào nút Product
                List<Product> products = new List<Product>();
                products.Add(data as Product);
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource= products;
            }
            else
            {
                //Người dùng bấm vào nút gốc
                List<Product> products = _productService.GetProducts();
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = products;
            }

        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (is_load_product_completed == false) return;

            if (e.AddedItems.Count == 0) return;

            Product p = e.AddedItems[0] as Product;

            if (p == null) return;

            txtMa.Text = p.ProductId.ToString();
            txtTen.Text = p.ProductName;
            txtSoLuong.Text = p.UnitsInStock.ToString();
            txtDonGia.Text = p.UnitPrice.ToString();
        }
    }
}
