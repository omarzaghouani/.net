using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Am.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AM.infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passengers>
    {
        public void Configure(EntityTypeBuilder<Passengers> builder)
        {
            // Configurer la propriété FirstName
            builder.Property(p => p.FullName.FirstName) // Référence à FullName
                .HasMaxLength(30)
                .HasColumnName("First_Name");

            // Configurer le type d'entité détenu FullName
            builder.OwnsOne(p => p.FullName, fullNameBuilder =>
            {
                fullNameBuilder.Property(fn => fn.FirstName)
                    .HasColumnName("FullName_FirstName")
                    .HasMaxLength(50);

                fullNameBuilder.Property(fn => fn.LastName)
                    .HasColumnName("FullName_LastName")
                    .HasMaxLength(50);
            });
        }
    }
}