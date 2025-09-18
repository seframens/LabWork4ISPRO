using LabWork4ISPRO.DbLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork4ISPRO.DbLayer.Services
{
    public class RoleService
    {
        private readonly Ispp2112Context _context;

        public RoleService(Ispp2112Context context)
        {
            _context = context;
        }

        // Получить все роли
        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.Include(r => r.Users).ToList();
        }

        // Найти роль по ID
        public Role? GetById(int id)
        {
            return _context.Roles.Include(r => r.Users).FirstOrDefault(r => r.RoleId == id);
        }

        // Найти роль по названию
        public Role? GetByName(string name)
        {
            return _context.Roles.Include(r => r.Users).FirstOrDefault(r => r.Name == name);
        }

        // Добавить новую роль
        public void Add(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        // Удалить роль по ID
        public void Delete(int id)
        {
            var role = _context.Roles.Find(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}
