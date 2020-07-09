using KolokwiumPoprawa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumPoprawa.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(a => a.IdArtist);
            builder.Property(a => a.IdArtist).UseIdentityColumn();

            builder.HasOne(a => a.ArtMovement)
                .WithMany(am => am.Artists)
                .HasForeignKey(a => a.IdArtMovement)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.CityOfBirth)
                .WithMany(c => c.Artists)
                .HasForeignKey(a => a.IdCityOfBirth)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(a => a.LastName)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(a => a.Nickname)
                .HasMaxLength(100);

            builder.Property(a => a.DateOfBirth)
                .IsRequired();
        }
    }
}