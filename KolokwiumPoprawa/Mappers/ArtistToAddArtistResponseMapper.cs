using KolokwiumPoprawa.DTO;
using KolokwiumPoprawa.Models;

namespace KolokwiumPoprawa.Mappers
{
    public class ArtistToAddArtistResponseMapper : IMapper<Artist, AddArtistResponse>
    {
        public AddArtistResponse Map(Artist data) => new AddArtistResponse
        {
            Id = data.IdArtist,
            FirstName = data.FirstName,
            LastName = data.LastName,
            Nickname = data.Nickname,
            DateOfBirth = data.DateOfBirth,
            City = ToDto(data.CityOfBirth),
            ArtMovement = ToDto(data.ArtMovement)
        };
        
        private CityDto ToDto(City city) => new CityDto
        {
            Id = city.IdCity,
            Name = city.Name,
            Population = city.Population
        };
        
        private ArtMovementDto ToDto(ArtMovement artMovement) => new ArtMovementDto()
        {
            Id = artMovement.IdArtMovement,
            Name = artMovement.Name,
            DateFounded = artMovement.DateFounded
        };
    }
}