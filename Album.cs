using System;

namespace RhythmsGonnaGetYou
{
    public class Album
    {
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }
        public int Id { get; set; }
    }
}