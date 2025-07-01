using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeViewWpfApp.models;

namespace TreeViewWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<int, Category> categories = SampleDataset.GenerateDataset();

        public MainWindow()
        {
            InitializeComponent();

            DisplayCategoriesAndProducts();

        }

        private void DisplayCategoriesAndProducts()
        {
            //Xóa dữ liệu cũ đi
            tvCategory.Items.Clear();
            
            //Tạo gốc cây (hoặc tạo tùy ta):
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Bình Dương";
            tvCategory.Items.Add(root);

            //Nạp dữ liệu mới
            foreach (KeyValuePair<int, Category> cate_kvp in categories)
            {
                Category cate = cate_kvp.Value;

                //Tạo category node
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = cate;
                //Đưa category vào gốc cây
                root.Items.Add(cate_node);
                //Vòng lặp con để nạp sp cho từng danh mục
                foreach(KeyValuePair<int, Product> product_kvp in cate.Products)
                {
                    Product product = product_kvp.Value;
                    //Tạo product node
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product;
                    //Đưa product node vào cate node
                    cate_node.Items.Add(product_node);

                }

            }
        }
    }
}