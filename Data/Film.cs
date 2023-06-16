using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Film : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Continue { get; set; }
        public int AuthorId { get; set; }
        public double Price { get; set; }

        public int DirectorId { get; set; }
        public Director? Director { get; set; }
        public List<Genre>? Genres { get; set; }
        public List<Actor>? Actors { get; set; }
        public Image? Image { get; set; }
    }
}
