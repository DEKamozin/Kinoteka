using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Image : BaseEntity
    {
        public string? Path { get; set; }
        public int FilmId { get; set; }
        public Film? Film { get; set; }
    }
}
