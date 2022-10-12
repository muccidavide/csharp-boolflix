﻿using csharp_boolflix.Models;

public class Episode : MediaContent
{
    public int SeasonNumber { get; set; }
    public int TVSeriesId { get; set; }
    public TVSerie TVSerie { get; set; }
}