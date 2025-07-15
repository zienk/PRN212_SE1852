using BO;
using DAL;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements
{
    public class AccountMemberRepository : IAccountMemberRepository
    {
        AccountMemberDAO _accDAO = new AccountMemberDAO();

        public bool ChangePassword(AccountMember accountMember, string newPassword)
            => _accDAO.ChangePassword(accountMember, newPassword);

        public AccountMember Login(string username, string password)
        {
            return _accDAO.Login(username, password);
        }
    }
}
