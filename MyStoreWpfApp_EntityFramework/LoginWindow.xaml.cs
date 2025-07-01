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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MyStoreContext _context = new MyStoreContext();
            
            AccountMember am = _context.AccountMembers
                .FirstOrDefault(x => x.EmailAddress == txtUsername.Text && x.MemberPassword == txtPassword.Password);

            if (am != null)
            {
                if (am.MemberRole == 1)
                {
                    MessageBox.Show("Đăng nhập thành công  - Administrator");
                    AdminWindow aw = new AdminWindow();
                    aw.Show();
                    Close();
                }
                else if (am.MemberRole == 2)
                {
                    MessageBox.Show("Đăng nhập thành công  - Nhân viên");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công  - Tài khoản khác");
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }
    }
}
