using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Film : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Continue { get; set; }
        public List<int> GenreID { get; set; }
        public int DirectorID { get; set; }
    }
}
