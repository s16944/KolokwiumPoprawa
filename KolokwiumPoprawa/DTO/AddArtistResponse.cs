using System;

namespace KolokwiumPoprawa.DTO
{
    public class AddArtistResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CityDto City { get; set; }
        public ArtMovementDto ArtMovement { get; set; }
    }

    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Population { get; set; }
    }

    public class ArtMovementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateFounded { get; set; }
    }
}