using Data;
using Repository.DirectorRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DirectorSer
{
    public class DirectorService : IDirectorService
    {
        private IDirectorRepository _repository;

        public DirectorService(IDirectorRepository repository)
        {
            _repository = repository;
        }

        public List<Director> GetDirector()
        {
            return _repository.GetAll();
        }

        public Director GetDirectorById(int id)
        {
            return _repository.Get(id);
        }
        public void CreateDirector(Director director)
        {
            _repository.Create(director);
        }
        public void UpdateDirector(Director director)
        {
            _repository.Update(director);
        }
        public void DeleteDirector(int id)
        {
            _repository.Delete(id);
        }
    }
}
