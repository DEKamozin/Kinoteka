using Kinoteka.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Service.DirectorSer;
using Data;
using System.IO;

namespace Kinoteka.Controllers
{
    public class AdminDirectorController : Controller
    {
        private IDirectorService _directorService;

        public AdminDirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        public IActionResult DirectorsList()
        {
            List<DirectorViewModel> model = new List<DirectorViewModel>();
            List<Director> directors = _directorService.GetDirector();

            foreach (Director director in directors)
            {
                DirectorViewModel item = new DirectorViewModel
                {
                    Id = director.Id,
                    Name = director.Name,
                    CreatedDate = director.CreateDate,
                    ModifiedDate = director.ModifiedDate,
                };
                model.Add(item);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            DirectorViewModel model = new DirectorViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(DirectorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Director director = new Director
                {
                    Name = model.Name,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                _directorService.CreateDirector(director);

                return RedirectToAction("DirectorsList", "AdminDirector");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(DirectorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Director director = _directorService.GetDirectorById(model.Id);

                director.Name = model.Name;
                director.ModifiedDate = DateTime.Now;

                _directorService.UpdateDirector(director);

                return RedirectToAction("DirectorsList", "AdminDirector");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _directorService.DeleteDirector(Id);
            return RedirectToAction("DirectorsList", "AdminDirector");
        }

    }
}
