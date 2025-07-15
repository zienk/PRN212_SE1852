using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountMemberDAO
    {
        MyStoreContext _context = new MyStoreContext();

        public AccountMember Login(string username, string password)
        {
            AccountMember am = _context.AccountMembers
                .FirstOrDefault(x => x.EmailAddress == username && x.MemberPassword == password);
            return am;
        }

        public bool ChangePassword(AccountMember accountMember, string newPassword)
        {
            var am = _context.AccountMembers.FirstOrDefault(x => x.EmailAddress == accountMember.EmailAddress);
            
            if (am != null)
            {
                am.MemberPassword = newPassword;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
