using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserManager
    {
        List<UserDTO> GetAllUsers();
        UserDTO? GetUser(int id);
        UserDTO AddUser(UserDTO t);
        bool UpdateUser(UserDTO t);
        void DeleteUser(int id);
        List<UserWriteDTO> GetUsersWithCountry();
    }
}
