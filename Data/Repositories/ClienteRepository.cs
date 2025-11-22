using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Model;

namespace UvvFintech.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Cliente cliente)
        {
            _context.ClienteS.Add(cliente);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var c = GetById(id);
            if (c != null)
            {
                _context.ClienteS.Remove(c);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Cliente> GetAll()
        {
            return _context.ClienteS.ToList();
        }
        public Cliente GetById(int id)
        {
            return _context.ClienteS.FirstOrDefault(c => c.Id == id);
        }
        public void Update(Cliente cliente)
        {
            _context.ClienteS.Update(cliente);
            _context.SaveChanges();
        }
    }
}
