using KolokwiumPoprawa.DTO;
using KolokwiumPoprawa.Models;

namespace KolokwiumPoprawa.Mappers
{
    public class AddArtistRequestToArtistMapper : IMapper<AddArtistRequest, Artist>
    {
        public Artist Map(AddArtistRequest data) => new Artist
        {
            FirstName = data.FirstName,
            LastName = data.LastName,
            Nickname = data.Nickname,
            DateOfBirth = data.DateOfBirth,
            IdCityOfBirth = data.IdCity,
            IdArtMovement = data.IdArtMovement
        };
    }
}