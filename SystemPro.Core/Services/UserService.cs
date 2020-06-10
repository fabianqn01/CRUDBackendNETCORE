using System.Collections.Generic;
using System.Threading.Tasks;
using SystemPro.Core.Entities;
using SystemPro.Core.Interfaces;

namespace SystemPro.Core.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITypeIdentificationRepository _ITypeIdentificationRepository;
        public UserService(IUserRepository userRepository, ITypeIdentificationRepository ITypeIdentificationRepository)
        {
            _userRepository = userRepository;
            _ITypeIdentificationRepository = ITypeIdentificationRepository;
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        /// <summary>
        /// se debe solo consultar los uauarios activos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUser(int id)
        {
            var usuario = await _userRepository.GetUser(id);
            //if (usuario.Active)
            return usuario;
            //else
            //    throw new Exception("user inactive");

        }

        public async Task<User> GetUser(int id, string password)
        {
            var user = await _userRepository.GetUser(id, password);
            if (user.UserId > 0)
            {
                var menu =  _userRepository.GetUserMenu(user.RolId);
                var a = menu;
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task InsertUser(User user)
        {

            await _userRepository.InsertUser(user);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }
    }
}
