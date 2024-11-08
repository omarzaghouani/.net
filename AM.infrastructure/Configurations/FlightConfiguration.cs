using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Am.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //*-*relationship
            builder.HasMany(f => f.passengers)
                .WithMany( p => p.flight)
                .UsingEntity(t => t.ToTable("reservition"));
            //1-* relationship
            builder.HasOne(f => f.plane)
                .WithMany(p => p.flight)
                .HasForeignKey(f => f.PLaneFK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
;
        }
    }
}
