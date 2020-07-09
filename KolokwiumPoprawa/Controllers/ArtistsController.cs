using KolokwiumPoprawa.DTO;
using KolokwiumPoprawa.Mappers;
using KolokwiumPoprawa.Models;
using KolokwiumPoprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumPoprawa.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IDbService _dbService;
        private readonly IMapper<AddArtistRequest, Artist> _requestToArtistMapper;

        public ArtistsController(IDbService dbService, IMapper<AddArtistRequest, Artist> requestToArtistMapper)
        {
            _dbService = dbService;
            _requestToArtistMapper = requestToArtistMapper;
        }

        [HttpPost]
        public IActionResult AddArtist(AddArtistRequest request)
        {
            var artist = _requestToArtistMapper.Map(request);
            _dbService.AddArtist(artist);
            return Created("/api/artists", artist);
        }
    }
}