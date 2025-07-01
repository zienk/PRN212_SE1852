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

using BusinessObject;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {

        ProductService service = new ProductService();

        bool isLoaded = false;

        public ProductWindow()
        {
            InitializeComponent();

            isLoaded = false;

            service.InnitializeDataset();

            lvProduct.ItemsSource = service.GetProducts();
            isLoaded = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            isLoaded = false;

            Product product = new Product();
            
            product.Id = int.Parse(txtId.Text);
            product.Name = txtName.Text;
            product.Quantity = int.Parse(txtQuantity.Text);
            product.Price = double.Parse(txtPrice.Text);
            
            bool result = service.SaveProduct(product);
            if (result)
            { //Nếu lưu thành công => Nạp lại giao diện
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = service.GetProducts();
            }
            isLoaded = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show(
                "Muốn xóa sản phẩm này hả");
            if (ret == MessageBoxResult.No)
                return; //KO muốn xóa
            try
            {
                isLoaded = false;
                int id = int.Parse(txtId.Text);
                bool kq = service.DeleteProduct(id);
                if(kq == true)
                {
                    lvProduct.ItemsSource= null;
                    lvProduct.ItemsSource = service.GetProducts();
                    txtId.Text = "";
                    txtName.Text = "";
                    txtQuantity.Text = "";
                    txtPrice.Text = "";
                }
                isLoaded = true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isLoaded = false;
                Product pUpdate = new Product();
                pUpdate.Id = int.Parse(txtId.Text);
                pUpdate.Name = txtName.Text;
                pUpdate.Quantity = int.Parse(txtQuantity.Text);
                pUpdate.Price = double.Parse(txtPrice.Text);
                bool kq = service.UpdateProduct(pUpdate);
                if (kq == true)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = service.GetProducts();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
                isLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi bạn ơi, kiểm tra lại nha, chi tiết:" + ex.Message);
            }
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded == false)
                return;
            if (e.AddedItems.Count < 0)
                return;//người dùng chưa chọn dòng nào
            //vì coding là ta binding list Product
            //nên ta lấy đối tượng Product ra:
            Product p = e.AddedItems[0] as Product;
            txtId.Text = p.Id.ToString();
            txtName.Text = p.Name;
            txtQuantity.Text = p.Quantity.ToString();
            txtPrice.Text = p.Price.ToString();
        }
    }
}
