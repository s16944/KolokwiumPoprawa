using System;
using System.Collections.Generic;

namespace KolokwiumPoprawa.Models
{
    public class ArtMovement
    {
        public int IdArtMovement { get; set; }
        public int IdNextArtMovement { get; set; }
        public virtual ArtMovement NextArtMovement { get; set; }
        public virtual ICollection<ArtMovement> PreviousArtMovements { get; set; }
        public int IdMovementFounder { get; set; }
        public virtual Artist MovementFounder { get; set; }
        public string Name { get; set; }
        public DateTime DateFounded { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}