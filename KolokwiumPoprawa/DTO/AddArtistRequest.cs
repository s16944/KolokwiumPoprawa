using System;

namespace KolokwiumPoprawa.DTO
{
    public class AddArtistRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdCity { get; set; }
        public int IdArtMovement { get; set; }
    }
}