using BO;
using Service.Implements;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IAccountMemberService _accService;

        public LoginWindow()
        {
            InitializeComponent();



        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            _accService = new AccountMemberService();

            AccountMember loginUser = _accService.Login(txtUsername.Text, txtPassword.Password);

            if (loginUser == null)
            {
                MessageBox.Show(
                    "Đăng nhập thất bại - vui lòng kiểm tra lại tên đăng nhập và mật khẩu!",
                    "Đăng nhập thất bại",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            else if (loginUser.MemberRole == 1)
            {
                AdminWindow adminWindow = new AdminWindow(loginUser);
                adminWindow.Show();
                Close();
            }
            
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
