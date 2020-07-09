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
        private readonly IMapper<Artist, AddArtistResponse> _artistToResponseMapper;

        public ArtistsController(IDbService dbService, IMapper<AddArtistRequest, Artist> requestToArtistMapper,
            IMapper<Artist, AddArtistResponse> artistToResponseMapper)
        {
            _dbService = dbService;
            _requestToArtistMapper = requestToArtistMapper;
            _artistToResponseMapper = artistToResponseMapper;
        }

        [HttpPost]
        public IActionResult AddArtist(AddArtistRequest request)
        {
            var artist = _requestToArtistMapper.Map(request);
            _dbService.AddArtist(artist);
            var response = _artistToResponseMapper.Map(artist);
            return Created("/api/artists", response);
        }
    }
}