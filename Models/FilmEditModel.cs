namespace csharp_boolflix.Models
{
    public class FilmEditModel
    {
        public FilmEditModel()
        {
            Films = new List<Film>();
            Actors = new List<Actor>();
            Genres = new List<Genre>();
            Features = new List<Feature>();
            
                    
        }

        public List<Film> Films { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Feature> Features { get; set; }

        public Film FilmToEdit { get; set; }
        public List<int>? ActorsToEdit { get; set; }
        public List<int>? GenresToEdit { get; set; }
        public List<int>? FeaturesToEdit { get; set; }

    }
}
