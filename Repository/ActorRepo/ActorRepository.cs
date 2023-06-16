using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ActorRepo
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationContext _context;

        public ActorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Actor Get(int id)
        {
            return _context.Actors.FirstOrDefault(b => b.Id == id);
        }

        public List<Actor> GetAll()
        {
            return _context.Actors.ToList();
        }

        public void Create(Actor actor)
        {
            _context.Actors.Add(actor);
        }

        public void Update(Actor actor)
        {
            _context.Actors.Update(actor);
        }

        public void Delete(int id)
        {
            Actor actor = Get(id);
            _context.Actors.Remove(actor);
        }
    }
}
