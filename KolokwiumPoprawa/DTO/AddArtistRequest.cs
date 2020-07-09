using System;
using System.ComponentModel.DataAnnotations;

namespace KolokwiumPoprawa.DTO
{
    public class AddArtistRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int IdCity { get; set; }
        [Required]
        public int IdArtMovement { get; set; }
    }
}