using csharp_boolflix.Models;

public class TVSerie : MediaContent
{
    public MediaInfo MediaInfo { get; set; }
    public int SeasonCount { get; set; }
    //public int EpisodeNumber { get; set; }
    public List<Episode> Episodes { get; set; }

}
