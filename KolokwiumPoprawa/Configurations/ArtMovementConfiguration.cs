using KolokwiumPoprawa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumPoprawa.Configurations
{
    public class ArtMovementConfiguration : IEntityTypeConfiguration<ArtMovement>
    {
        public void Configure(EntityTypeBuilder<ArtMovement> builder)
        {
            builder.HasKey(am => am.IdArtMovement);
            builder.Property(am => am.IdArtMovement).UseIdentityColumn();

            builder.HasOne(am => am.NextArtMovement)
                .WithMany(am => am.PreviousArtMovements)
                .HasForeignKey(am => am.IdNextArtMovement)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(am => am.MovementFounder)
                .WithOne(a => a.FoundedArtMovement)
                .HasForeignKey<ArtMovement>(am => am.IdMovementFounder)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(am => am.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(am => am.DateFounded)
                .IsRequired();
        }
    }
}