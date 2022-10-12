public class MediaInfo
{
    public int Id { get; set; }
    public string? Year { get; set; }
    public bool? IsNew { get; set; }

    public List<Actor> Cast { get; set; }
    public List<Genre> Genres { get; set; }
    public List<Feature> Features { get; set; }

    // 1 a 1 Con Film
    public int? FilmId { get; set; }
    public Film? Film { get; set; }
    // 1 a 1 con Tvserie
    public int? TVSeriesId { get; set; }
    public TVSerie? TVSeries { get; set; }

}
