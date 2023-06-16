using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DirectorSer
{
    public interface IDirectorService
    {
        List<Director> GetDirector();
        Director GetDirectorById(int id);
        void CreateDirector(Director director);
        void UpdateDirector(Director director);
        void DeleteDirector(int id);
    }
}
