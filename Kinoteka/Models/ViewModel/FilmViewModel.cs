using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kinoteka.Models.ViewModel
{
    public class FilmViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Continue { get; set; }
        public double Price { get; set; }
        public int DirectorID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DirectorId { get; set; }
        public SelectList Director { get; set; }
    }
}
