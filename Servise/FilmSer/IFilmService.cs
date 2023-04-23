using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Servise.FilmSer
{
    public interface IFilmService
    {
        List<Film> GetFilms();
        Film GetFilmById(int Id);
        void CreateFilm(Film film);
        void UpdateFilm(Film film);
        void DeleteFilm(int Id);
    }
}
