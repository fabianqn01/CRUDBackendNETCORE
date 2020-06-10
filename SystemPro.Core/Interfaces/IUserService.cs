using System.Collections.Generic;
using System.Threading.Tasks;
using SystemPro.Core.Entities;

namespace SystemPro.Core.Interfaces
{
    public interface IUserService
    {

        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);

        Task<User> GetUser(int id, string password);

        Task InsertUser(User user);

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(int id);

    }
}