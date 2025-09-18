using LabWork4ISPRO.DbLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork4ISPRO.DbLayer.Services
{
    public class UserService
    {
        private readonly Ispp2112Context _context;

        public UserService(Ispp2112Context context)
        {
            _context = context;
        }

        // Получить всех пользователей
        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(u => u.Role).ToList();
        }

        // Найти пользователя по ID
        public User? GetById(int id)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.UserId == id);
        }

        // Найти пользователя по логину
        public User? GetByLogin(string login)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login);
        }

        // Добавить нового пользователя
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Удалить пользователя по ID
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
