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
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {

        AccountMember loginUser;
        private readonly IAccountMemberService _accService; 

        public ChangePasswordWindow(AccountMember accountMember)
        {
            InitializeComponent();

            _accService = new AccountMemberService();

            loginUser = accountMember;

            txtUsername.Text = loginUser.EmailAddress;
            

        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string newPassword = txtNewPassword.Password;

                bool ret = _accService.ChangePassword(loginUser, newPassword);

                if (ret)
                {
                    MessageBox.Show(
                        "Đổi mật khẩu thành công!",
                        "Thông báo", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Đổi mật khẩu thất bại!",
                        "Thông báo lỗi", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi đổi mật khẩu: " + ex.Message,
                    "Thông báo lỗi", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
