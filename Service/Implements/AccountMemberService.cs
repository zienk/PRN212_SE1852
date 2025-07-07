using BO;
using Repository.Implements;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements
{
    public class AccountMemberService : IAccountMemberService
    {

        IAccountMemberRepository _accRepo;

        public AccountMemberService()
        {
            _accRepo = new AccountMemberRepository();
        }

        public AccountMember Login(string username, string password)
        {
            return _accRepo.Login(username, password);
        }
    }
}
