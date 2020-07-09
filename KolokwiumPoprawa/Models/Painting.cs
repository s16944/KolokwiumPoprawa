using System;

namespace KolokwiumPoprawa.Models
{
    public class Painting
    {
        public int IdPainting { get; set; }
        public string SurfaceType { get; set; }
        public string PaintingMedia { get; set; }
        public int IdArtist { get; set; }
        public virtual Artist Artist { get; set; }
        public int IdCoAuthor { get; set; }
        public virtual Artist CoAuthor { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}