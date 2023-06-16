using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ActorSer
{
    public interface IActorService
    {
        List<Actor> GetActor();
        Actor GetActorById(int Id);
        void CreateActor(Actor actor);
        void UpdateActor(Actor actor);
        void DeleteActor(int Id);
    }
}
