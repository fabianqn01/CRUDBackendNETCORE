using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemPro.Core.Entities;

namespace SystemPro.Core.Interfaces
{
    public interface IUserRepository
    {
       Task<IEnumerable<User>> GetUsers();

       Task<User> GetUser(int id);

       Task<User> GetUser(int id,string password);

       Task InsertUser(User user);

       Task<bool> UpdateUser(User user);

       Task<bool> DeleteUser(int id);

        Task<IEnumerable<Menu>> GetUserMenu(int id);


    }
}
