using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAccountMemberRepository
    {
        public AccountMember Login(string username, string password);
    }
}
