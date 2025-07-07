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

        public AdminWindow()
        {
            InitializeComponent();

            LoadCategoriesAndProductsIntoTreeView();

        }

        private void LoadCategoriesAndProductsIntoTreeView()
        {
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
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null) return;

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

        }
    }
}
