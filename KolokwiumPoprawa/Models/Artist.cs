using System;
using System.Collections.Generic;

namespace KolokwiumPoprawa.Models
{
    public class Artist
    {
        public int IdArtist { get; set; }
        public int IdArtMovement { get; set; }
        public virtual ArtMovement ArtMovement { get; set; }
        public int IdCityOfBirth { get; set; }
        public virtual City CityOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Painting> Paintings { get; set; }
        public virtual ICollection<Painting> CoAuthorPaintings { get; set; }
        public virtual ICollection<ArtMovement> FoundedArtMovements { get; set; }
    }
}