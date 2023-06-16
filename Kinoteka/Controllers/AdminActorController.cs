using Kinoteka.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Service.ActorSer;
using Data;

namespace Kinoteka.Controllers
{
    public class AdminActorController : Controller
    {
        private IActorService _actorServise;

        public AdminActorController(IActorService actorServise)
        {
            _actorServise = actorServise;
        }
        public IActionResult ActorList()
        {
            List<ActorViewModel> model = new List<ActorViewModel>();
            List<Actor> actors = _actorServise.GetActor();

            foreach (Actor actor in actors)
            {
                ActorViewModel item = new ActorViewModel
                {
                    Id = actor.Id,
                    Name = actor.Name,
                    CreatedDate = actor.CreateDate,
                    ModifiedDate = actor.ModifiedDate
                };
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ActorViewModel model = new ActorViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ActorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Actor actor = new Actor
                {
                    Name = model.Name,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                _actorServise.CreateActor(actor);

                return RedirectToAction("ActorsList", "AdminActor");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Actor actor = _actorServise.GetActorById(Id);
            ActorViewModel model = new ActorViewModel
            {
                Id = Id,
                Name = actor.Name
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ActorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Actor actor = _actorServise.GetActorById(model.Id);

                actor.Name = model.Name;
                actor.ModifiedDate = DateTime.Now;

                _actorServise.UpdateActor(actor);

                return RedirectToAction("ActorsList", "AdminActor");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _actorServise.DeleteActor(Id);
            return RedirectToAction("ActorsList", "AdminActor");
        }
    }
}
