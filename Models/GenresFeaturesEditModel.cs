namespace csharp_boolflix.Models

{
    public class GenresFeaturesEditModel
    {
        public GenresFeaturesEditModel()
        {
            Features = new List<Feature>();
            Genres = new List<Genre>();
            FeatureToEdit = new Feature();
            GenreToEdit = new Genre();
        }

        public List<Feature>? Features { get; set; }
        public List<Genre>? Genres { get; set; } 
        public Genre? GenreToEdit { get; set; }
        public Feature? FeatureToEdit { get; set; }

    }
}
