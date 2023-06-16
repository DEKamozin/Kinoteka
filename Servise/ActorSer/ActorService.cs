using Data;
using Repository.ActorRepo;
using Repository.FilmRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Service.ActorSer
{
    public class ActorService : IActorService
    {
        private IActorRepository _repository;
        public ActorService(IActorRepository repository)
        {
            _repository = repository;
        }

        public List<Actor> GetActor()
        {
            return _repository.GetAll();
        }

        public Actor GetActorById(int id)
        {
            return _repository.Get(id);
        }

        public void CreateActor(Actor actor)
        {
            _repository.Create(actor);
        }

        public void UpdateActor(Actor actor)
        {
            _repository.Update(actor);
        }

        public void DeleteActor(int id)
        {
            _repository.Delete(id);
        }
    }
}
