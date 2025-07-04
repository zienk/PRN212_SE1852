using MyStoreWpfApp_EntityFramework.Models;
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

namespace MyStoreWpfApp_EntityFramework
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        MyStoreContext _context = new MyStoreContext();

        bool isLoadListviewCompleted = false;


        public AdminWindow()
        {
            InitializeComponent();

            DisplayCategoriesAndProducts();
        }

        private void DisplayCategoriesAndProducts()
        {
            tvCategory.Items.Clear();
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Trà Vinh";
            tvCategory.Items.Add(root);

            //Duyệt vòng lập qua tất cả các danh mục
            var categories = _context.Categories.ToList();
            foreach (var category in categories)
            {
                //Tạo node Category
                TreeViewItem cate_note = new TreeViewItem();
                cate_note.Header = category.CategoryName;
                cate_note.Tag = category;
                root.Items.Add(cate_note);

                //Vòng lập duyệt qua tất cả các sản phẩm trong danh mục

                var products = _context.Products
                    .Where(p => p.CategoryId == category.CategoryId)
                    .ToList();

                foreach (var product in products)
                { 
                    //Tạo node Product:
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_note.Items.Add(product_node);
                }

            }
            root.ExpandSubtree();
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            isLoadListviewCompleted = false;
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item != null)
            {
                Category category = item.Tag as Category;
                if (category != null)
                {
                    LoadProductListByCategory(category);
                }
            }
            isLoadListviewCompleted = true;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoadListviewCompleted == false) return;

            if (e.AddedItems.Count == 0) return;

            Product p = e.AddedItems[0] as Product;

            txtMa.Text = p.ProductId.ToString();
            txtTen.Text = p.ProductName;
            txtSoLuong.Text = p.UnitsInStock.ToString();
            txtDonGia.Text = p.UnitPrice.ToString();

            //Không phải lúc nào dữ liệu trên giao diện cũng là dữ liệu
            //Đầy đủ của Đối tượng
            //--> Trường hợp ko đầy đủ dữ liệu (ví dụ như xem Chi tiết nâng cao)
            //Thì bắt buộc ta phải truy vấn 1 lần nữa theo ID

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";



        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Chức năng thêm mới sp
            //Bước 1: Cần biết đc danh mục nào để lưu sản phẩm vào
            TreeViewItem tvItem = tvCategory.SelectedItem as TreeViewItem;

            if(tvItem == null)
            {
                MessageBox.Show("Bạn phải chọn danh mục trước", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Category category = tvItem.Tag as Category;
            if(category == null)
            {
                MessageBox.Show("Bạn phải chọn danh mục trước", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Bước 2: tạo sp
            Product p = new Product();
            
            p.ProductName = txtTen.Text;
            p.UnitsInStock = short.Parse(txtSoLuong.Text);
            p.UnitPrice = decimal.Parse(txtDonGia.Text);
            
            //Tham chiếu khóa ngoại:
            p.CategoryId = category.CategoryId;
            
            //đánh dấu thêm mới
            _context.Products.Add(p);

            //xác nhận thêm mới
            _context.SaveChanges();
            MessageBox.Show("Đã thêm sp thành công");

            //Đưa Node Sản phẩm vào Node danh mục

            TreeViewItem product_node = new TreeViewItem();
            product_node.Header = p.ProductName;
            //product_node.Tag = p;
            tvItem.Items.Add(product_node);
            tvItem.ExpandSubtree();

            //DisplayCategoriesAndProducts();

            //Hiển thị danh sách sp theo node danh mục
            LoadProductListByCategory(category);
            
        }

        private void LoadProductListByCategory(Category category)
        {
            var products = _context.Products
                    .Where(p => p.CategoryId == category.CategoryId)
                    .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //isLoadListviewCompleted = false;
            //Chức năng update sp
            //Bước 1: Phải tìm ra sp muốn sửa trc
            int id = int.Parse(txtMa.Text);
            Product product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm cần sửa", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Bước 2: Tiến hành đổi giá trị các thuộc tính của đối tượng
            //Chính là đổi dữ liệu từng cell trong mỗi dòng của Table Product
            product.ProductName = txtTen.Text;
            product.UnitsInStock = short.Parse(txtSoLuong.Text);
            product.UnitPrice = decimal.Parse(txtDonGia.Text);

            //Bước 3: đánh dấu xác nhận sửa
            _context.SaveChanges();

            //Bước 4: cập nhật lại cây và listview
            Category category = _context.Categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);

            LoadProductListByCategory(category);

            DisplayCategoriesAndProducts();
            //isLoadListviewCompleted = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Xóa sp 
            //Bước 1: tím sp cần xóa
            int id = int.Parse(txtMa.Text);
            Product product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            
            if(product == null)
            {
                MessageBox.Show("Ko tồn tại sp để xóa", "Xóa lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sp {product.ProductName} này ko?", "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;
            _context.Products.Remove(product);
            _context.SaveChanges();

            //Cập nhật lại TreeView và ListView sau khi xóa 
            DisplayCategoriesAndProducts();
           
            Category category = _context.Categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
            LoadProductListByCategory(category);

        }
    }
}
