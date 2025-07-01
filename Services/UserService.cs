using BusinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {

        private IUserRepository _userRepository;

        public UserService ()
        {
            _userRepository = new UserRepository();
        }

        public List<User> GetAllUsers()
        {

            return _userRepository.GetAllUsers();
        }
    }
}
