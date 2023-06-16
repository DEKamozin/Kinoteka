using Data;
using Kinoteka.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.ActorSer;
using Servise.FilmSer;
using Service.DirectorSer;

namespace Kinoteka.Controllers
{
    public class AdminFilmController : Controller
    {
        private IFilmService _filmService;
        private IDirectorService _directorService;

        public AdminFilmController(IFilmService filmService, IDirectorService directorService)
        {
            _filmService = filmService;
            _directorService = directorService;
        }

        public IActionResult FilmsList()
        {
            List<FilmViewModel> model = new List<FilmViewModel>();
            List<Film> films = _filmService.GetFilms();

            foreach (Film film in films)
            {
                FilmViewModel fvm = new FilmViewModel
                {
                    Id = film.Id,
                    Name = film.Name,
                    CreateDate = film.CreateDate,
                    ModifiedDate = film.ModifiedDate,
                };
                model.Add(fvm);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Director> directors = _directorService.GetDirector();
            FilmViewModel model = new FilmViewModel();
            List<DirectorViewModel> directorsList = new List<DirectorViewModel>();

            foreach (Director director in directors)
            {
                DirectorViewModel directorViewModel = new DirectorViewModel
                {
                    Id = director.Id,
                    Name = director.Name
                };

                directorsList.Add(directorViewModel);
            }
            model.Director = new SelectList(directorsList, "Id", "Name"); 
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(FilmViewModel model)
        {
            if (ModelState.IsValid)
            {
                Film film = new Film
                {
                    Price = model.Price,
                    Name = model.Name,
                    Description = model.Description,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                _filmService.CreateFilm(film);

                return RedirectToAction("FilmsList", "AdminFilm");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            Film film = _filmService.GetFilmById(Id);
            FilmViewModel model = new FilmViewModel
            {
                Id = Id,
                Name = film.Name
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(FilmViewModel model)
        {
            if (ModelState.IsValid)
            {
                Film film = _filmService.GetFilmById(model.Id);

                film.Name = model.Name;
                film.ModifiedDate = DateTime.Now;

                _filmService.UpdateFilm(film);

                return RedirectToAction("FilmsList", "AdminFilm");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _filmService.DeleteFilm(Id);
            return RedirectToAction("FilmsList", "AdminFilm");
        }



    }
}
