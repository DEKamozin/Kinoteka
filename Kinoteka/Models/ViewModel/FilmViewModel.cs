namespace Kinoteka.Models.ViewModel
{
    public class FilmViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Continue { get; set; }
        public List<int> GenreID { get; set; }
        public int DirectorID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
