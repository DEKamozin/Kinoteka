using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Repository.DirectorRepo
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly ApplicationContext _context;

        public DirectorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Director Get(int id)
        {
            return _context.Directors.FirstOrDefault(b => b.Id == id);
        }

        public List<Director> GetAll()
        {
            return _context.Directors.ToList();
        }

        public void Create(Director director)
        {
            _context.Directors.Add(director);
        }

        public void Update(Director director)
        {
            _context.Directors.Update(director);
        }

        public void Delete(int id)
        {
            Director director = Get(id);
            _context.Directors.Remove(director);
        }
    }
}
