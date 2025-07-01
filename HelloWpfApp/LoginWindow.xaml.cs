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

namespace HelloWpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Giả lập account
            //Nếu user name là zienk và pass là 123
            //Thì cho vào màn hình MainWindow

            if (txtUserName.Text == "zienk" && txtPassword.Password == "123")
            {
                
                
                //Mở màn hình main
                MainWindow mw = new MainWindow();
                mw.Show();

                //Đóng màn hình đăng nhập
                Close(); //Thu hồi ô nhớ đã cấp cho LoginWindow

            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại rùi :v");
            }

        }
    }
}
