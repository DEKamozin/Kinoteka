using Repository.FilmRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Servise.FilmSer
{
    public class FilmService : IFilmService
    {
        private IFilmRepository _repository;
        public FilmService(IFilmRepository repository)
        {
            _repository = repository;
        }

        public List<Film> GetFilms()
        {
            return _repository.GetAll();
        }

        public Film GetFilmById(int id)
        {
            return _repository.Get(id);
        }

        public void CreateFilm(Film film)
        {
            _repository.Create(film);
        }

        public void UpdateFilm(Film film)
        {
            _repository.Update(film);
        }

        public void DeleteFilm(int id) 
        {
            _repository.Delete(id);
        }
    }
}
