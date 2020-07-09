using KolokwiumPoprawa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumPoprawa.Configurations
{
    public class PaintingConfiguration : IEntityTypeConfiguration<Painting>
    {
        public void Configure(EntityTypeBuilder<Painting> builder)
        {
            builder.HasKey(p => p.IdPainting);
            builder.Property(p => p.IdPainting).UseIdentityColumn();

            builder.Property(p => p.SurfaceType)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(p => p.PaintingMedia)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.Artist)
                .WithMany(a => a.Paintings)
                .HasForeignKey(p => p.IdArtist)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(p => p.CoAuthor)
                .WithMany(a => a.CoAuthorPaintings)
                .HasForeignKey(p => p.IdCoAuthor)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Property(p => p.CreatedAt)
                .IsRequired();
        }
    }
}