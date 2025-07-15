using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAccountMemberService
    {
        AccountMember Login(string username, string password);
        bool ChangePassword(AccountMember accountMember, string newPassword);
    }
}
