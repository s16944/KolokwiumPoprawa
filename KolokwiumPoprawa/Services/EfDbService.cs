using System.Linq;
using KolokwiumPoprawa.Models;

namespace KolokwiumPoprawa.Services
{
    public class EfDbService : IDbService
    {
        private readonly ArtistsDbContext _dbContext;

        public EfDbService(ArtistsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddArtist(Artist artist)
        {
            _dbContext.Database.BeginTransaction();
            
            var dbArtist = _dbContext.Artists.FirstOrDefault(a => a.Nickname == artist.Nickname);
            if (dbArtist != default)
                throw new ConflictException($"Artist with nickname {artist.Nickname} already exists");

            var dbCity = _dbContext.Cities.SingleOrDefault(c => c.IdCity == artist.IdCityOfBirth);
            if (dbCity == default) throw new NotFoundException($"City with id {artist.IdCityOfBirth} not found");

            var dbArtMovement = _dbContext.ArtMovements.SingleOrDefault(am => am.IdArtMovement == artist.IdArtMovement);
            if (dbArtMovement == default)
                throw new NotFoundException($"Art movement with id {artist.ArtMovement} not found");

            artist.CityOfBirth = dbCity;
            artist.ArtMovement = dbArtMovement;
            
            _dbContext.Artists.Add(artist);
            _dbContext.SaveChanges();
            
            _dbContext.Database.CommitTransaction();
        }
    }
}