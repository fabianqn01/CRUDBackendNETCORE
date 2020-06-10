using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SystemPro.Core.Entities;
using SystemPro.Core.Interfaces;
using SystemPro.Infrastructure.Data;

namespace SystemPro.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        //inyecccion de dependencias pra el contexto de base de datos, lo inyectamos por constructor
        private readonly SystemPro2Context _context;

        public UserRepository(SystemPro2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            //implementacion conectando directamente a db
            //listado asincrono por la firma, por eso lleva el await en el metodo
            var users = await _context.User.ToListAsync();
            return users;
        }

        public async Task<User> GetUser(int id)
        {
            //implementacion conectando directamente a db
            //listado asincrono por la firma, por eso lleva el await en el metodo
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == id);
            return user;
        }

        public async Task<User> GetUser(int id, string password)
        {
            //implementacion conectando directamente a db
            //listado asincrono por la firma, por eso lleva el await en el metodo
            var user = await _context.User.FirstOrDefaultAsync(x => x.NumberId == id && x.Password == password);
            return user;
        }

        public async Task InsertUser(User user)
        {
             user.LastChange = DateTime.Now;
             _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            var currentUser = await GetUser(user.UserId);
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.TypeIdentificationId = user.TypeIdentificationId;
            currentUser.NumberId = user.NumberId;
            currentUser.Password = user.Password;
            currentUser.Email = user.Email;
            currentUser.LastChange = DateTime.Now;
            currentUser.Active = user.Active;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var currentUser = await GetUser(id);
            _context.User.Remove(currentUser);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Menu>> GetUserMenu(int id)
        {
            var menus = await _context.Menu.ToListAsync();
            return menus;
        }

        


    }
}
