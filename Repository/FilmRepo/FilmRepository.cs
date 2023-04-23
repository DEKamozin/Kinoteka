using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.FilmRepo
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationContext _context;

        public FilmRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Film Get(int id)
        {
            return _context.Films.FirstOrDefault(b => b.Id == id);
        }

        public List<Film> GetAll()
        {
            return _context.Films.ToList();
        }

        public void Create(Film film)
        {
            _context.Films.Add(film);
        }

        public void Update(Film film)
        {
            _context.Films.Update(film);
        }

        public void Delete(int id)
        {
            Film film = Get(id);
            _context.Films.Remove(film);
        }

    }
}
